Imports System.Data.SqlClient
Imports MaterialDesignThemes.Wpf

Class Login
    ' Archivo de configuración, CAMBIAR AL CARGAR EL PROYECTO
    Dim settings As String = "D:\DAM\DI\ProyectoXML\NotasSeneca\settings.conf"

    ' Conexion a la BD
    Public con As New SqlConnection("data source=HP-OMEN-GUILLER;initial catalog=seneca;integrated security=true;persist security info=True;")
    ' Datos del profe
    Public profesor As String

    ' Tema
    Public temaOscuro As Boolean = True
    Dim oscuro As Color = ColorConverter.ConvertFromString("#FF00853E")
    Dim blanco As Color = Colors.White
    Dim negro As Color = Colors.Black

    ' Al cargar Login
    Private Sub cargado()
        ' Carga de ajustes si existen
        If My.Computer.FileSystem.FileExists(settings) Then
            For Each line As String In IO.File.ReadAllLines(settings)
                Dim parts() As String = line.Split(":")
                temaOscuro = Convert.ToBoolean(parts(1))
            Next
        End If

        ' Radio de las esquinas en los botones
        ButtonAssist.SetCornerRadius(botonLogin, New CornerRadius(15))
        ButtonAssist.SetCornerRadius(botonSalir, New CornerRadius(15))

        cambiaTema()
    End Sub

    ' Login del profesor
    Private Sub login_Click()
        Dim existe As Boolean = False
        con.Open()
        Dim cmd As New SqlCommand("SELECT * FROM profesores WHERE dni_profesor = '" + dni.Text.Trim + "' AND password = '" + pwd.Password.Trim + "';", con)
        Using rdr As SqlDataReader = cmd.ExecuteReader()
            ' Si la consulta devuelve datos, existe profesor con esa contraseña
            While rdr.Read()
                existe = True
            End While
            rdr.Close()
        End Using
        con.Close()

        ' Existe el profesor
        If existe Then
            profesor = dni.Text.Trim

            abrirDashboard()
            Me.Hide()
        Else
            MsgBox("Profesor no encontrado, revise el NIF y/o la contraseña")
        End If
    End Sub

    ' Si hay algo escrito en NIF desbloquea la contraseña y al revés
    Private Sub dni_TextChanged(sender As Object, e As TextChangedEventArgs) Handles dni.TextChanged
        If dni.Text.Length > 0 Then
            pwd.IsEnabled = True
            HintAssist.SetHint(pwd, "Contraseña") ' Seteo de Hint en la contraseña solo si hay algo escrito en el NIF
        Else
            pwd.IsEnabled = False
            HintAssist.SetHint(pwd, "")
        End If
    End Sub


    ' AÑADIR AL PRESIONAR ENTER EN TODOS LOS FORMULARIOS QUE HAGA LA ACCION DEL BOTON PRINCIPAL
    Private Sub enterPresionado(sender As Object, e As KeyEventArgs)
        If e.Key = Key.Enter Then
            If dni.Text.Length > 0 And pwd.Password.Length > 0 Then
                login_Click()
            ElseIf dni.Text.Length = 0 Then
                MsgBox("Debe introducir el NIF")
            ElseIf pwd.Password.Length = 0 Then
                MsgBox("Debe introducir la contraseña")
            End If
        End If
    End Sub

    ' Abrir ventana Dashboard
    Private Sub abrirDashboard()
        Dim dashboard As New Dashboard()
        dashboard.Owner = Me
        dashboard.WindowStartupLocation = WindowStartupLocation.CenterOwner
        dashboard.Show()
    End Sub

    ' Cambia el color del tema
    Public Sub cambiaTema()
        If temaOscuro = False Then
            setTema(blanco, negro)
        Else
            setTema(oscuro, blanco)
        End If
        temaOscuro = Not temaOscuro
    End Sub

    ' Cambio de tema
    Private Sub setTema(fondo As Color, texto As Color)
        ' Seteo de colores
        principal.Background = New SolidColorBrush(fondo)
        menu.Background = New SolidColorBrush(fondo)
        menu.Foreground = New SolidColorBrush(texto)
        dni.Foreground = New SolidColorBrush(texto)
        pwd.Foreground = New SolidColorBrush(texto)
        logoPwd.Foreground = New SolidColorBrush(texto)
        logoProfesor.Foreground = New SolidColorBrush(texto)

        Dim ph As New PaletteHelper
        Dim ibt As Theme

        ' CAMBIAR URI POR LA RUTA EN EL PC
        If texto = Colors.Black Then
            cabecera.Source = New BitmapImage(New Uri("D:\DAM\DI\ProyectoXML\NotasSeneca\NotasSeneca\notas-seneca-logo-verde.png"))
            logoProfesor.Kind = MaterialDesignThemes.Wpf.PackIconKind.Account
            logoPwd.Kind = MaterialDesignThemes.Wpf.PackIconKind.Lock
            tema.Header = "_Tema oscuro"

            ' Botones y tema
            botonLogin.Foreground = New SolidColorBrush(fondo)
            botonSalir.Foreground = New SolidColorBrush(oscuro)
            ibt = Theme.Create(Theme.Light, oscuro, Colors.Blue)

        Else
            cabecera.Source = New BitmapImage(New Uri("D:\DAM\DI\ProyectoXML\NotasSeneca\NotasSeneca\notas-seneca-logo-blanco.png"))
            logoProfesor.Kind = MaterialDesignThemes.Wpf.PackIconKind.AccountOutline
            logoPwd.Kind = MaterialDesignThemes.Wpf.PackIconKind.LockOutline
            tema.Header = "_Tema claro"

            ' Botones y tema
            botonLogin.Foreground = New SolidColorBrush(oscuro)
            botonSalir.Foreground = New SolidColorBrush(texto)
            ibt = Theme.Create(Theme.Dark, texto, Colors.Blue)
        End If
        ph.SetTheme(ibt)

        textoProfesor.Foreground = New SolidColorBrush(texto)
        textoPass.Foreground = New SolidColorBrush(texto)
    End Sub

    ' Cerrar todas las ventanas de la app y guardar configuración de tema
    Public Sub cerrarTodo()
        ' Guarda/escribe los ajustes
        IO.File.Create(settings).Dispose()
        Using sw As IO.StreamWriter = IO.File.AppendText(settings)
            sw.Write("Dark theme: " + (Not temaOscuro).ToString)
        End Using

        ' Cierra todas las ventanas (a veces la ventana Login no se cierra)
        For intCounter As Integer = Application.Current.Windows.Count - 1 To 1 Step -1
            If Application.Current.Windows.Count > 0 Then
                Application.Current.Windows(intCounter).Close()
            End If
        Next

        ' Si queda alguna ventana sería Login (Esta)
        If Application.Current.Windows.Count > 0 Then
            Me.Close()
        End If
    End Sub
End Class