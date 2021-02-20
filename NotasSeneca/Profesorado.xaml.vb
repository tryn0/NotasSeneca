Imports System.Data.SqlClient
Imports MaterialDesignThemes.Wpf

Public Class Profesorado

    ' Obtener Login
    Dim login As Login = Application.Current.MainWindow
    Dim padre As Dashboard

    ' Datos del profesor
    Public profeDni = login.profesor
    Public id_profe = login.id_profe

    Dim telefonoBD As String
    Dim passBD As String
    Dim direccionBD As String

    ' Tema
    Public temaOscuro As Boolean
    Dim oscuro As Color = login.oscuro
    Dim blanco As Color = Colors.White
    Dim negro As Color = Colors.Black

    Dim isPassShowed As Boolean = False

    ' Al cargar la ventana
    Private Sub cargado()
        ' Obtengo la ventana Dashboard (Aparecen 2 en el listado de ventanas, por lo que escojo la que tiene el ComboBox con Name clases)
        For Each w As Window In Application.Current.Windows
            If w.ToString = "NotasSeneca.Dashboard" Then
                Dim auxiliar As Dashboard = w
                If auxiliar.clases IsNot Nothing Then
                    padre = auxiliar
                    temaOscuro = Not padre.temaOscuro
                End If
            End If
        Next

        cambiaTema()
        getProfe()
    End Sub

    ' Toggle ver contraseña
    Private Sub verPass()
        If verPassLogo.Kind = MaterialDesignThemes.Wpf.PackIconKind.EyeOutline Or verPassLogo.Kind = MaterialDesignThemes.Wpf.PackIconKind.Eye Then
            ' Cambio de icono según el estado inicial (Ver contraseña)
            If temaOscuro = True Then
                verPassLogo.Kind = MaterialDesignThemes.Wpf.PackIconKind.EyeOffOutline
            Else
                verPassLogo.Kind = MaterialDesignThemes.Wpf.PackIconKind.EyeOff
            End If

            passProfe.Visibility = Visibility.Hidden
            passProfeText.Visibility = Visibility.Visible
            passProfeText.SelectionStart = passProfeText.Text.Length
            isPassShowed = True
        Else
            If temaOscuro = True Then
                verPassLogo.Kind = MaterialDesignThemes.Wpf.PackIconKind.EyeOutline
            Else
                verPassLogo.Kind = MaterialDesignThemes.Wpf.PackIconKind.Eye
            End If
            passProfe.Visibility = Visibility.Visible
            passProfeText.Visibility = Visibility.Hidden
            isPassShowed = False
        End If

    End Sub

    ' Igualo la contraseña visible al perder el foco el PasswordBox
    Private Sub passCambio()
        passProfeText.Text = passProfe.Password.Trim
    End Sub

    ' Igualo el PasswordBox al escribir en la contraseña visible
    Private Sub passTextCambio()
        passProfe.Password = passProfeText.Text.Trim
    End Sub

    ' Cambia el color del tema
    Private Sub cambiaTema()
        If temaOscuro = False Then
            setTema(blanco, negro)
        Else
            setTema(oscuro, blanco)
        End If
    End Sub

    ' Cambio de tema
    Private Sub setTema(fondo As Color, texto As Color)
        ' Seteo de colores
        principal.Background = New SolidColorBrush(fondo)
        nombre.Foreground = New SolidColorBrush(texto)
        logoProfesor.Foreground = New SolidColorBrush(texto)
        telefonoLogo.Foreground = New SolidColorBrush(texto)
        passLogo.Foreground = New SolidColorBrush(texto)
        verPassLogo.Foreground = New SolidColorBrush(texto)
        direccionLogo.Foreground = New SolidColorBrush(texto)
        dniProfe.Foreground = New SolidColorBrush(texto)
        telefonoText.Foreground = New SolidColorBrush(texto)
        passProfe.Foreground = New SolidColorBrush(texto)
        passProfeText.Foreground = New SolidColorBrush(texto)
        direccion.Foreground = New SolidColorBrush(texto)

        Dim ph As New PaletteHelper
        Dim ibt As Theme

        If texto = Colors.Black Then
            logoInfo.Source = New BitmapImage(New Uri("D:\DAM\DI\ProyectoXML\NotasSeneca\NotasSeneca\junta-andalucia-logo-verde.png"))
            logoProfesor.Kind = MaterialDesignThemes.Wpf.PackIconKind.Account
            telefonoLogo.Kind = MaterialDesignThemes.Wpf.PackIconKind.Phone
            passLogo.Kind = MaterialDesignThemes.Wpf.PackIconKind.Lock
            direccionLogo.Kind = MaterialDesignThemes.Wpf.PackIconKind.MapMarker

            If isPassShowed = True Then
                verPassLogo.Kind = MaterialDesignThemes.Wpf.PackIconKind.EyeOff
            Else
                verPassLogo.Kind = MaterialDesignThemes.Wpf.PackIconKind.Eye
            End If

            ' Botones y tema
            botonEnviar.Foreground = New SolidColorBrush(fondo)
            ibt = Theme.Create(Theme.Light, oscuro, Colors.Blue)

        Else
            logoInfo.Source = New BitmapImage(New Uri("D:\DAM\DI\ProyectoXML\NotasSeneca\NotasSeneca\junta-andalucia-logo-blanco.png"))
            logoProfesor.Kind = MaterialDesignThemes.Wpf.PackIconKind.AccountOutline
            telefonoLogo.Kind = MaterialDesignThemes.Wpf.PackIconKind.PhoneOutline
            passLogo.Kind = MaterialDesignThemes.Wpf.PackIconKind.LockOutline
            direccionLogo.Kind = MaterialDesignThemes.Wpf.PackIconKind.MapMarkerOutline

            If isPassShowed = True Then
                verPassLogo.Kind = MaterialDesignThemes.Wpf.PackIconKind.EyeOffOutline
            Else
                verPassLogo.Kind = MaterialDesignThemes.Wpf.PackIconKind.EyeOutline
            End If

            ' Botones y tema
            botonEnviar.Foreground = New SolidColorBrush(oscuro)
            ibt = Theme.Create(Theme.Dark, texto, Colors.Blue)
        End If
        ph.SetTheme(ibt)

    End Sub

    ' Obtiene los datos del profesorado que usa la app para mostrarlos
    Private Sub getProfe()
        Dim adapter As New SqlDataAdapter
        Dim con As SqlConnection = login.con
        con.Open()
        Dim cmd As New SqlCommand("SELECT * FROM profesores WHERE id_profesores = " + id_profe, con)
        Dim ds As New Data.DataSet
        adapter.SelectCommand = cmd

        ' Obtengo datos
        adapter.Fill(ds)

        adapter.Dispose()
        cmd.Dispose()
        con.Close()

        ' Rellenar ComboBox con las clases del profesor
        nombre.Text = ds.Tables(0).Rows(0)("nombre").ToString.Trim + " " + ds.Tables(0).Rows(0)("apellidos").ToString.Trim
        dniProfe.Text = ds.Tables(0).Rows(0)("dni_profesor").ToString.Trim
        telefonoText.Text = ds.Tables(0).Rows(0)("telefono").ToString.Trim
        direccion.Text = ds.Tables(0).Rows(0)("direccion").ToString.Trim

        passProfeText.Text = ds.Tables(0).Rows(0)("password").ToString.Trim
        passProfe.Password = ds.Tables(0).Rows(0)("password").ToString.Trim

        telefonoBD = telefonoText.Text.Trim
        passBD = passProfeText.Text
        direccionBD = direccion.Text.Trim
    End Sub

    ' Actualizar datos profesorado
    Private Sub updateProfe()
        If Not telefonoText.Text.Trim = telefonoBD.Trim Or Not passProfe.Password = passBD.Trim Or Not direccion.Text.Trim = direccionBD.Trim Then ' Si algún dato es disinto que el original
            Dim con As SqlConnection = login.con
            con.Open()
            Dim cmd As New SqlCommand("UPDATE profesores SET telefono = " + telefonoText.Text.Trim + ", password = " + passProfe.Password.Trim + ", direccion = '" + direccion.Text.Trim + "' WHERE id_profesores = " + id_profe, con)

            ' Actualizo los datos del profe
            cmd.ExecuteNonQuery()

            ' Cierro la conexión
            con.Close()

            MsgBox("Actualizado")

            ' Actualizo los datos del predeterminados
            telefonoBD = telefonoText.Text.Trim
            passBD = passProfeText.Text
            direccionBD = direccion.Text.Trim
        Else
            MsgBox("Nada que actualizar")
        End If
    End Sub

    ' Al salir muestra Dashboard
    Private Sub salir()
        padre.Show()
    End Sub
End Class
