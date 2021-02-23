Imports System.Data.SqlClient
Imports MaterialDesignThemes.Wpf

Public Class Dashboard
    ' Obtener Login
    Dim login As Login = Application.Current.MainWindow

    ' Datos del profesor
    Public profeDni = login.profesor
    Public id_profe = login.id_profe

    ' Tema
    Public temaOscuro As Boolean = Not login.temaOscuro
    Dim oscuro As Color = login.oscuro
    Dim blanco As Color = Colors.White
    Dim negro As Color = Colors.Black

    ' Listados
    Dim alumnos As New List(Of String)
    Dim totalClases As New List(Of String)
    Dim totalAsignaturas As New List(Of String)

    ' Al cargar la ventana
    Private Sub cargado()

        ButtonAssist.SetCornerRadius(verClasesProf, New CornerRadius(5))
        ButtonAssist.SetCornerRadius(verInfoProf, New CornerRadius(5))
        ButtonAssist.SetCornerRadius(verClase, New CornerRadius(5))
        ButtonAssist.SetCornerRadius(botonSalir, New CornerRadius(5))
        cambiaTema()

        getAlumnos()
        getClases()
        getAsignaturas()
    End Sub

    ' Obtengo todos los datos de todo el alumnado de la actual clase
    Private Sub getAlumnos()
        Dim con As SqlConnection = login.con
        con.Open()
        Dim cmd As New SqlCommand("select id_alumno from clases_alumnos where cod_clase in (select cod_clase from clases where cod_clase in (select cod_clase from clases_asignaturas where cod_asignatura in (select cod_asignatura from asignaturas where id_profesor = " + id_profe + ")))", con)
        Dim ds As New Data.DataSet
        Dim adapter As New SqlDataAdapter
        adapter.SelectCommand = cmd

        ' Obtengo datos
        adapter.Fill(ds)

        ' Cierro dataset, SqlCommand y Conexion
        adapter.Dispose()
        cmd.Dispose()
        con.Close()

        ' Recolección de alumnos en un Dictionary
        For Each dato In ds.Tables(0).Rows
            alumnos.Add(dato(0).ToString)
        Next

        ' Seteo la cantidad de alumnos en el textBlock
        numAlumnos.Text += " " + alumnos.Count.ToString
    End Sub

    ' Obtengo todos los datos de todo el alumnado de la actual clase
    Private Sub getClases()
        Dim con As SqlConnection = login.con
        con.Open()
        Dim cmd As New SqlCommand("select * from clases where cod_clase in (select cod_clase from clases_asignaturas where cod_asignatura in (select cod_asignatura from asignaturas where id_profesor = " + id_profe + "))", con)
        Dim ds As New Data.DataSet
        Dim adapter As New SqlDataAdapter
        adapter.SelectCommand = cmd

        ' Obtengo datos
        adapter.Fill(ds)

        ' Cierro dataset, SqlCommand y Conexion
        adapter.Dispose()
        cmd.Dispose()
        con.Close()

        ' Recolección de alumnos en un Dictionary
        For Each dato In ds.Tables(0).Rows
            totalClases.Add(dato(0).ToString)
        Next

        ' Seteo la cantidad de alumnos en el textBlock
        numClases.Text += " " + totalClases.Count.ToString

    End Sub

    ' Obtengo todos los datos de las asignaturas del profesorado que usa la app
    Private Sub getAsignaturas()
        Dim con As SqlConnection = login.con
        con.Open()
        Dim cmd As New SqlCommand("select * from asignaturas where id_profesor = " + id_profe, con)
        Dim ds As New Data.DataSet
        Dim adapter As New SqlDataAdapter
        adapter.SelectCommand = cmd

        ' Obtengo datos
        adapter.Fill(ds)

        ' Cierro dataset, SqlCommand y Conexion
        adapter.Dispose()
        cmd.Dispose()
        con.Close()

        ' Recolección de alumnos en un Dictionary
        For Each dato In ds.Tables(0).Rows
            totalAsignaturas.Add(dato(0).ToString)
        Next

        ' Seteo la cantidad de alumnos en el textBlock
        numAsignaturas.Text += " " + totalAsignaturas.Count.ToString
    End Sub

    ' Cerrar sesión (Cierra la ventana actual y con el CloseHandler muestra Login)
    Private Sub logout(sender As Object, e As RoutedEventArgs)
        Me.Close()
    End Sub

    ' Detalles de la app
    Private Sub infoClick(sender As Object, e As RoutedEventArgs)
        Dim info As New Info()
        info.Owner = Me
        Me.Hide()
        info.Show()
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
        Me.Hide()
        alumnado.Show()
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

        numClases.Foreground = New SolidColorBrush(texto)
        numAlumnos.Foreground = New SolidColorBrush(texto)
        numAsignaturas.Foreground = New SolidColorBrush(texto)

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

    ' Ver información del profesorado que usa la app
    Private Sub verInfoProf_Click(sender As Object, e As RoutedEventArgs) Handles verInfoProf.Click
        Dim profe As New Profesorado
        Me.Hide()
        profe.Show()
    End Sub

    ' Abre la ventana de informes
    Private Sub informe()
        Me.Hide()
        Dim inf As New Informe
        inf.Show()
    End Sub
End Class
