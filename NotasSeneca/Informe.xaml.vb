Imports System.Data.SqlClient
Imports MaterialDesignThemes.Wpf

Public Class Informe

    Dim login As Login = Application.Current.MainWindow
    Dim padre As Dashboard

    Dim id_profe As String = login.id_profe

    ' Tema
    Public temaOscuro As Boolean
    Dim oscuro As Color = login.oscuro
    Dim blanco As Color = Colors.White
    Dim negro As Color = Colors.Black

    ' Al cargar la ventana
    Private Sub cargado()
        ' Obtengo la ventana Dashboard (Aparecen 2 en el listado de ventanas, por lo que escojo la que tiene el ComboBox con Name clases)
        For Each w As Window In Application.Current.Windows
            If w.ToString = "NotasSeneca.Dashboard" Then
                Dim auxiliar As Dashboard = w
                If auxiliar.trigger.Text.Trim = "dash" Then
                    padre = auxiliar
                    temaOscuro = Not padre.temaOscuro
                End If
            End If
        Next

        ButtonAssist.SetCornerRadius(aprobadosBoton, New CornerRadius(5))
        ButtonAssist.SetCornerRadius(clasesBoton, New CornerRadius(5))
        cambiaTema()
    End Sub

    ' Recojo las notas de los alumnos que el profesorado tenga y las mando al informe
    Private Sub aprobados(sender As Object, e As RoutedEventArgs)
        Dim dt As System.Data.DataTable = New System.Data.DataTable()

        VerInforme.LocalReport.ReportPath = "..\..\InformeNotas.rdlc"

        Dim conexion As String = "data source=HP-OMEN-GUILLER;initial catalog=seneca;integrated security=true;persist security info=True;"
        Dim notasTotal As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM notas_alumnos WHERE cod_asignatura IN (SELECT cod_asignatura FROM asignaturas WHERE id_profesor = " + id_profe + ")", conexion)

        notasTotal.Fill(dt)

        Dim rds As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource("DataSetNotas", dt)
        VerInforme.LocalReport.DataSources.Add(rds)

        VerInforme.RefreshReport()
    End Sub

    ' Recojo las clases del profesorado y lo mando al informe
    Private Sub clases(sender As Object, e As RoutedEventArgs)
        Dim dt As System.Data.DataTable = New System.Data.DataTable()

        VerInforme.LocalReport.ReportPath = "..\..\InformeClases.rdlc"

        Dim conexion As String = "data source=HP-OMEN-GUILLER;initial catalog=seneca;integrated security=true;persist security info=True;"
        Dim notasTotal As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM clases WHERE cod_clase IN (SELECT cod_clase FROM clases_asignaturas WHERE cod_asignatura IN (SELECT cod_asignatura FROM asignaturas WHERE id_profesor = " + id_profe + "))", conexion)

        notasTotal.Fill(dt)

        Dim rds As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource("DataSetClases", dt)
        VerInforme.LocalReport.DataSources.Add(rds)

        VerInforme.RefreshReport()
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

        Dim ph As New PaletteHelper
        Dim ibt As Theme

        If texto = Colors.Black Then
            ' Botones y tema
            aprobadosBoton.Foreground = New SolidColorBrush(fondo)
            clasesBoton.Foreground = New SolidColorBrush(fondo)
            ibt = Theme.Create(Theme.Light, oscuro, Colors.Blue)

        Else
            ' Botones y tema
            aprobadosBoton.Foreground = New SolidColorBrush(oscuro)
            clasesBoton.Foreground = New SolidColorBrush(oscuro)
            ibt = Theme.Create(Theme.Dark, texto, Colors.Blue)
        End If
        ph.SetTheme(ibt)
    End Sub

    ' Muestro el dashboard
    Private Sub salir()
        padre.Show()
    End Sub
End Class
