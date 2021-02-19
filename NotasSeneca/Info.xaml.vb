Imports MaterialDesignThemes.Wpf

Public Class Info
    ' Dashboard
    Dim padre As Dashboard
    Dim login As Login = Application.Current.MainWindow

    ' Tema
    Dim temaOscuro As Boolean = False
    Dim oscuro As Color = ColorConverter.ConvertFromString("#FF00853E")
    Dim blanco As Color = Colors.White
    Dim negro As Color = Colors.Black

    ' Al cargar la ventana
    Private Sub cargado()
        For Each w As Window In Application.Current.Windows
            If w.ToString = "NotasSeneca.Dashboard" Then
                Dim auxiliar As Dashboard = w
                If auxiliar.clases IsNot Nothing Then
                    padre = auxiliar
                    temaOscuro = padre.temaOscuro
                End If
            End If
        Next

        cambiaTema()
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
        titulo.Foreground = New SolidColorBrush(texto)
        textoDetalle.Foreground = New SolidColorBrush(texto)
        logoGithub.Foreground = New SolidColorBrush(texto)

        Dim ph As New PaletteHelper
        Dim ibt As Theme

        If texto = Colors.Black Then
            logoInfo.Source = New BitmapImage(New Uri("D:\DAM\DI\ProyectoXML\NotasSeneca\NotasSeneca\junta-andalucia-logo-verde.png"))

            ' Botones y tema
            ibt = Theme.Create(Theme.Light, oscuro, Colors.Blue)

        Else
            logoInfo.Source = New BitmapImage(New Uri("D:\DAM\DI\ProyectoXML\NotasSeneca\NotasSeneca\junta-andalucia-logo-blanco.png"))

            ' Botones y tema
            ibt = Theme.Create(Theme.Dark, texto, Colors.Blue)

        End If
        ph.SetTheme(ibt)

    End Sub

    ' Redireccion al sitio web del HyperLink en el navegador
    Private Sub githubNav(sender As Object, e As RequestNavigateEventArgs)
        Process.Start(New ProcessStartInfo(e.Uri.AbsoluteUri))
        e.Handled = True
    End Sub

    ' Mostrar dashboard
    Private Sub infoClosed()
        If padre IsNot Nothing Then
            padre.Show()
        End If
    End Sub
End Class
