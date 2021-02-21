Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports MaterialDesignThemes.Wpf

Public Class Alumnado
    ' Obtengo Dashboard, Login y la conexión de Login
    Dim padre As Dashboard
    Dim login As Login = Application.Current.MainWindow
    Dim con As SqlConnection = login.con

    ' Datos de la clase, del alumnado, del profesorado y nota
    Dim claseId As String
    Dim claseName As String
    Dim profesorDni As String = login.profesor
    Dim idProfesor As String
    Dim idAlumno As String
    Dim notaFinal As Decimal = -1
    Dim notaExistente As Boolean = False
    Dim alumnos As New Dictionary(Of String, List(Of String))

    Dim pos As Integer = 0

    ' Tema
    Public temaOscuro As Boolean
    Dim oscuro As Color = login.oscuro
    Dim blanco As Color = Colors.White
    Dim negro As Color = Colors.Black

    ' Al cargar la ventana de Alumnado
    Private Sub alumnadoCargado()
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

        claseId = padre.clases.SelectedValue.ToString
        claseName = padre.clases.Text.ToString

        ' Botones
        ButtonAssist.SetCornerRadius(enviarNotaAlumno, New CornerRadius(5))
        ButtonAssist.SetCornerRadius(salirBoton, New CornerRadius(5))
        ButtonAssist.SetCornerRadius(siguiente, New CornerRadius(5))
        ButtonAssist.SetCornerRadius(anterior, New CornerRadius(5))

        getInfoProfesor()
        getAlumnos()

        profeDNI.Text = profesorDni
        nombreClase.Text = claseName
        nombreClase.HorizontalAlignment = HorizontalAlignment.Center
        nombreClase.TextAlignment = TextAlignment.Center
        cambiaTema()
    End Sub

    ' Obtengo todos los datos de todo el alumnado de la actual clase
    Private Sub getAlumnos()
        con.Open()
        Dim cmd As New SqlCommand("SELECT * FROM alumnos WHERE id_alumno IN (SELECT id_alumno FROM clases_alumnos WHERE cod_clase = " + claseId + ");", con)
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
            Dim data As New List(Of String) From {dato(0).ToString, dato(1).ToString, dato(2).ToString, dato(3).ToString, dato(4).ToString, dato(5).ToString, dato(6).ToString}
            alumnos.Add(dato(0).ToString, data)
        Next

        ' Seteo datos alumno en ventana WPF (El profesor no podrá modificar la información)
        setInfoAlumnoPos(pos)

    End Sub

    ' Obtención de los datos del profesor que usa la app
    Private Sub getInfoProfesor()
        con.Open()
        Dim cmd As New SqlCommand("SELECT * FROM profesores WHERE dni_profesor = '" + profesorDni + "';", con)
        Dim ds As New Data.DataSet
        Dim adapter As New SqlDataAdapter
        adapter.SelectCommand = cmd

        ' Obtengo datos
        adapter.Fill(ds)

        adapter.Dispose()
        cmd.Dispose()
        con.Close()

        idProfesor = ds.Tables(0).Rows(0)("id_profesores").ToString.Trim
        profeNombre.Text = ds.Tables(0).Rows(0)("nombre").ToString.Trim + " " + ds.Tables(0).Rows(0)("apellidos").ToString.Trim
        profeNombre.HorizontalAlignment = HorizontalAlignment.Center
    End Sub

    ' Botón siguiente
    Private Sub siguiente_alumno(sender As Object, e As RoutedEventArgs)
        pos = pos + 1
        If pos < alumnos.Keys.Count - 1 Or pos = alumnos.Keys.Count - 1 Then
            notaExisteBD(0)
            setInfoAlumnoPos(pos)
        End If
    End Sub

    ' Botón anterior
    Private Sub anterior_alumno(sender As Object, e As RoutedEventArgs)
        pos = pos - 1
        If pos >= 0 Or pos = 0 Then
            notaExisteBD(0)
            setInfoAlumnoPos(pos)
        End If
    End Sub

    ' Rellena los datos del alumno con el alumno en la posicion pasada
    Private Sub setInfoAlumnoPos(i As Integer)
        If pos = alumnos.Keys.Count - 1 Then
            siguiente.Visibility = Visibility.Hidden
        Else
            siguiente.Visibility = Visibility.Visible
        End If

        If pos = 0 Then
            anterior.Visibility = Visibility.Hidden
        Else
            anterior.Visibility = Visibility.Visible
        End If

        nombreAlumno.Text = alumnos.ElementAt(i).Value(1).Trim + " " + alumnos.ElementAt(i).Value(2).Trim
        telefono.Text = "Teléfono: " + alumnos.ElementAt(i).Value(3).Trim
        dni.Text = "DNI: " + alumnos.ElementAt(i).Value(4).Trim
        direccion.Text = "Dirección: " + alumnos.ElementAt(i).Value(5).Trim
        telefono_emergencia.Text = "Teléfono de emergencia: " + alumnos.ElementAt(i).Value(6).Trim

        idAlumno = alumnos.ElementAt(i).Value(0).Trim
        getClasesAlumno(idAlumno)
    End Sub

    ' Obtener las clases del alumno
    Private Sub getClasesAlumno(idAlumno As String)
        con.Open()
        Dim cmd As New SqlCommand("SELECT * FROM asignaturas WHERE cod_asignatura IN (SELECT cod_asignatura FROM clases_asignaturas WHERE cod_clase = (SELECT cod_clase FROM clases_alumnos WHERE id_alumno = " + idAlumno + ")) AND id_profesor = " + idProfesor + ";", con)
        Dim ds As New Data.DataSet
        Dim adapter As New SqlDataAdapter
        adapter.SelectCommand = cmd

        ' Obtengo datos
        adapter.Fill(ds)

        adapter.Dispose()
        cmd.Dispose()
        con.Close()

        ' Rellenar ComboBox con las clases del profesor
        clasesAlumno.ItemsSource = ds.Tables(0).DefaultView
        clasesAlumno.SelectedValuePath = "cod_asignatura"
        clasesAlumno.DisplayMemberPath = "nombre"
        clasesAlumno.SelectedIndex = 0
        clasesAlumno.Visibility = Visibility.Visible

        If clasesAlumno.SelectedItem IsNot "" Then
            notaAsignatura.Visibility = Visibility.Visible
        End If
    End Sub

    ' Al clicar en enviar inserta la nota en la BD
    Private Sub enviarNotaAlumno_Click(sender As Object, e As RoutedEventArgs) Handles enviarNotaAlumno.Click
        notaExisteBD(0)

        If notaIsNumeric() Then
            ' Dependiendo si exista ya una nota o no inserta o actualiza la nota
            If notaExistente = True Then
                updateNota()
            Else
                insertNota()
            End If
            MsgBox("Nota subida con éxito")
        End If
    End Sub

    ' Al cambio de texto de la nota
    Private Sub notaAsignatura_TextChanged(sender As Object, e As TextChangedEventArgs) Handles notaAsignatura.TextChanged
        notaFinal = -1
        If notaAsignatura.Text.Length > 0 Then
            enviarNotaAlumno.Visibility = Visibility.Visible
        Else
            enviarNotaAlumno.Visibility = Visibility.Hidden
        End If

    End Sub

    ' Al seleccionar la clase del alumno a la que poner la nota
    Private Sub clasesAlumno_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles clasesAlumno.SelectionChanged
        notaExisteBD(1)
    End Sub

    ' Inserta una nota al alumno en una asignatura seleccionada
    Private Sub insertNota()
        con.Open()
        Dim cmd As New SqlCommand("INSERT INTO notas_alumnos VALUES(" + idAlumno + "," + clasesAlumno.SelectedValue.ToString + "," + Replace(notaFinal.ToString, ",", ".") + ");", con)

        ' Inserto la nota en la BD
        cmd.ExecuteNonQuery()

        ' Cierro la conexión
        con.Close()
    End Sub

    ' Actualiza la nota del alumno en la asignatura seleccionada
    Private Sub updateNota()
        con.Open()
        Dim cmd As New SqlCommand("UPDATE notas_alumnos  SET nota = " + Replace(notaFinal.ToString, ",", ".") + " WHERE id_alumno = " + idAlumno + " AND cod_asignatura = " + clasesAlumno.SelectedValue.ToString, con)

        ' Actualizo la nota del alumnado
        cmd.ExecuteNonQuery()

        ' Cierro la conexión
        con.Close()
    End Sub

    ' Comprueba si la nota escrita tiene el formato correcto
    Private Function notaIsNumeric()
        Dim regex As New Regex("\d{1,2}(\.[0-9]{1,2})*")
        If regex.IsMatch(notaAsignatura.Text) And notaAsignatura.Text.Length < 5 Then
            notaFinal = Decimal.Parse(notaAsignatura.Text, CultureInfo.InvariantCulture)
            If notaFinal >= 0 And notaFinal <= 10 Then
                ' Formato correcto y entre 0 y 10
                Return True
            Else ' Nota menor que 0 o mayor que 10
                MsgBox("La nota debe ser como mínimo 0 y como máximo 10. ")
                Return False
            End If
        Else ' Formato incorrecto
            MsgBox("Formato incorrecto, ejemplo: 5.25")
            Return False
        End If
    End Function

    ' Busca si existe una nota para el alumno seleccionado, pasando como parámetro un integer, hará de trigger si la nota que encuentre la plasmará en el texbox de notas o no
    Private Sub notaExisteBD(i As Integer)
        If idAlumno IsNot Nothing And clasesAlumno.SelectedValue IsNot Nothing Then
            con.Open()
            Dim cmd As New SqlCommand("SELECT nota FROM notas_alumnos WHERE id_alumno = " + idAlumno + "AND cod_asignatura = " + clasesAlumno.SelectedValue.ToString, con)
            Dim ds As New Data.DataSet
            Dim adapter As New SqlDataAdapter
            adapter.SelectCommand = cmd

            ' Obtengo datos
            adapter.Fill(ds)

            adapter.Dispose()
            cmd.Dispose()
            con.Close()

            If ds.Tables(0).Rows.Count > 0 Then
                ' Rellenar notaAsignatura con la nota del alumno, si la hay y si la hay cambia el "interruptor" para el update
                If i = 1 Then
                    notaAsignatura.Text = ds.Tables(0).Rows(0)("nota").ToString
                End If
                notaExistente = True
            Else
                If i = 1 Then
                    notaAsignatura.Text = ""
                End If
                notaExistente = False
            End If
        End If
    End Sub

    ' Salir de alumnado, reabrir Dashboard
    Private Sub salirAlumnado(sender As Object, e As RoutedEventArgs)
        Me.Close()
    End Sub

    ' Al salir de Alumnado, abre Dashboard
    Private Sub salir()
        padre.Show()
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
        profeNombre.Foreground = New SolidColorBrush(texto)
        profeDNI.Foreground = New SolidColorBrush(texto)
        nombreClaseTitle.Foreground = New SolidColorBrush(texto)
        nombreClase.Foreground = New SolidColorBrush(texto)
        nombreAlumno.Foreground = New SolidColorBrush(texto)
        telefono.Foreground = New SolidColorBrush(texto)
        direccion.Foreground = New SolidColorBrush(texto)
        dni.Foreground = New SolidColorBrush(texto)
        telefono_emergencia.Foreground = New SolidColorBrush(texto)
        notaAlumno.Foreground = New SolidColorBrush(texto)
        notaAsignatura.Foreground = New SolidColorBrush(texto)
        clasesAlumno.Foreground = New SolidColorBrush(texto)

        Dim ph As New PaletteHelper
        Dim ibt As Theme

        If texto = Colors.Black Then
            ' Botones y tema
            anterior.Foreground = New SolidColorBrush(fondo)
            siguiente.Foreground = New SolidColorBrush(fondo)
            enviarNotaAlumno.Foreground = New SolidColorBrush(fondo)
            salirBoton.Foreground = New SolidColorBrush(oscuro)
            ibt = Theme.Create(Theme.Light, oscuro, Colors.Blue)

        Else
            ' Botones y tema
            anterior.Foreground = New SolidColorBrush(oscuro)
            siguiente.Foreground = New SolidColorBrush(oscuro)
            enviarNotaAlumno.Foreground = New SolidColorBrush(oscuro)
            salirBoton.Foreground = New SolidColorBrush(texto)
            ibt = Theme.Create(Theme.Dark, texto, Colors.Blue)
        End If
        ph.SetTheme(ibt)
    End Sub
End Class
