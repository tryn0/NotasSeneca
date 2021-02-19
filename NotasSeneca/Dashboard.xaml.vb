Imports System.Data.SqlClient
Imports MaterialDesignThemes.Wpf

Public Class Dashboard
    ' Obtener Login
    Dim login As Login = Application.Current.MainWindow

    ' Datos del profesor
    Public profeDni = login.profesor

    ' Tema
    Public temaOscuro As Boolean = Not login.temaOscuro
    Dim oscuro As Color = ColorConverter.ConvertFromString("#FF00853E")
    Dim blanco As Color = Colors.White
    Dim negro As Color = Colors.Black

    ' Al cargar la ventana
    Private Sub cargado()

        ButtonAssist.SetCornerRadius(verClasesProf, New CornerRadius(5))
        ButtonAssist.SetCornerRadius(verInfoProf, New CornerRadius(5))
        ButtonAssist.SetCornerRadius(verClase, New CornerRadius(5))
        ButtonAssist.SetCornerRadius(botonSalir, New CornerRadius(5))
        cambiaTema()
    End Sub
    ' Cerrar sesión (Cierra la ventana actual y con el CloseHandler muestra Login)
    Private Sub logout(sender As Object, e As RoutedEventArgs)
        Me.Close()
    End Sub

    ' Detalles de la app
    Private Sub infoClick(sender As Object, e As RoutedEventArgs)
        Dim info As New Info()
        info.Owner = Me
        info.Show()
        Me.Hide()
    End Sub

    ' Cerrar toda las ventanas
    Public Sub salir(sender As Object, e As RoutedEventArgs)
        login.cerrarTodo()
    End Sub

    ' Dashboard cerrado, muestra login una vez cerrado
    Private Sub ventanaCerrada()
        ' Seteo del tema actual al tema del login
        login.temaOscuro = Not temaOscuro
        login.cambiaTema()

        login.Show()
    End Sub

    ' Obtiene las clases del profesorado
    Private Sub verClases(sender As Object, e As RoutedEventArgs)
        Dim adapter As New SqlDataAdapter
        Dim con As SqlConnection = login.con
        con.Open()
        Dim cmd As New SqlCommand("SELECT * FROM clases WHERE cod_clase IN (SELECT cod_clase FROM clases_asignaturas WHERE cod_asignatura IN (SELECT cod_asignatura FROM asignaturas WHERE id_profesor IN (SELECT id_profesores FROM profesores WHERE dni_profesor = '" + profeDni + "')))", con)
        Dim ds As New Data.DataSet
        adapter.SelectCommand = cmd

        ' Obtengo datos
        adapter.Fill(ds)

        adapter.Dispose()
        cmd.Dispose()
        con.Close()

        ' Rellenar ComboBox con las clases del profesor
        clases.ItemsSource = ds.Tables(0).DefaultView
        clases.SelectedValuePath = "cod_clase"
        clases.DisplayMemberPath = "nombre"
        clases.SelectedIndex = 0
        clases.Visibility = Visibility.Visible

        If clases.SelectedItem IsNot "" Then
            logoClases.Visibility = Visibility.Visible
            verClase.Visibility = Visibility.Visible
        End If
    End Sub

    ' Al clicar en ver la clase
    Private Sub verClase_Click(sender As Object, e As RoutedEventArgs) Handles verClase.Click
        Dim alumnado As New Alumnado()
        alumnado.Owner = Me
        alumnado.Show()
        Me.Hide()
    End Sub

    ' Cambia el color del tema
    Private Sub cambiaTema()

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
        Menu.Background = New SolidColorBrush(fondo)
        menu.Foreground = New SolidColorBrush(texto)
        logoClases.Foreground = New SolidColorBrush(texto)
        clases.Foreground = New SolidColorBrush(texto)

        Dim ph As New PaletteHelper
        Dim ibt As Theme

        If texto = Colors.Black Then
            logoClases.Kind = MaterialDesignThemes.Wpf.PackIconKind.AccountGroup
            tema.Header = "_Tema oscuro"

            ' Botones y tema
            verClasesProf.Foreground = New SolidColorBrush(fondo)
            verInfoProf.Foreground = New SolidColorBrush(fondo)
            verClase.Foreground = New SolidColorBrush(fondo)
            botonSalir.Foreground = New SolidColorBrush(oscuro)
            ibt = Theme.Create(Theme.Light, oscuro, Colors.Blue)

        Else
            logoClases.Kind = MaterialDesignThemes.Wpf.PackIconKind.AccountGroupOutline
            tema.Header = "_Tema claro"

            ' Botones y tema
            verClasesProf.Foreground = New SolidColorBrush(oscuro)
            verInfoProf.Foreground = New SolidColorBrush(oscuro)
            verClase.Foreground = New SolidColorBrush(oscuro)
            botonSalir.Foreground = New SolidColorBrush(texto)
            ibt = Theme.Create(Theme.Dark, texto, Colors.Blue)
        End If
        ph.SetTheme(ibt)

    End Sub
End Class
