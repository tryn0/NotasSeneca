﻿#ExternalChecksum("..\..\Informe.xaml","{8829d00f-11b8-4213-878b-770e8597ac16}","2B0C677964230AB9F034D78185F383C271379AF0FC83D3270C7F32D3646AE2A5")
'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports MaterialDesignThemes.Wpf
Imports MaterialDesignThemes.Wpf.Converters
Imports MaterialDesignThemes.Wpf.Transitions
Imports Microsoft.Reporting.WinForms
Imports NotasSeneca
Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Forms.Integration
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Shell


'''<summary>
'''Informe
'''</summary>
<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class Informe
    Inherits System.Windows.Window
    Implements System.Windows.Markup.IComponentConnector
    
    
    #ExternalSource("..\..\Informe.xaml",20)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents principal As System.Windows.Controls.Grid
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\Informe.xaml",22)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents WinInforme As System.Windows.Forms.Integration.WindowsFormsHost
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\Informe.xaml",23)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents VerInforme As Microsoft.Reporting.WinForms.ReportViewer
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\Informe.xaml",28)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents aprobadosBoton As System.Windows.Controls.Button
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\Informe.xaml",29)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents clasesBoton As System.Windows.Controls.Button
    
    #End ExternalSource
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
    Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        Dim resourceLocater As System.Uri = New System.Uri("/NotasSeneca;component/informe.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\Informe.xaml",1)
        System.Windows.Application.LoadComponent(Me, resourceLocater)
        
        #End ExternalSource
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")>  _
    Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
        If (connectionId = 1) Then
            
            #ExternalSource("..\..\Informe.xaml",10)
            AddHandler CType(target,Informe).Closed, New System.EventHandler(AddressOf Me.salir)
            
            #End ExternalSource
            
            #ExternalSource("..\..\Informe.xaml",10)
            AddHandler CType(target,Informe).Loaded, New System.Windows.RoutedEventHandler(AddressOf Me.cargado)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 2) Then
            Me.principal = CType(target,System.Windows.Controls.Grid)
            Return
        End If
        If (connectionId = 3) Then
            Me.WinInforme = CType(target,System.Windows.Forms.Integration.WindowsFormsHost)
            Return
        End If
        If (connectionId = 4) Then
            Me.VerInforme = CType(target,Microsoft.Reporting.WinForms.ReportViewer)
            Return
        End If
        If (connectionId = 5) Then
            Me.aprobadosBoton = CType(target,System.Windows.Controls.Button)
            
            #ExternalSource("..\..\Informe.xaml",28)
            AddHandler Me.aprobadosBoton.Click, New System.Windows.RoutedEventHandler(AddressOf Me.aprobados)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 6) Then
            Me.clasesBoton = CType(target,System.Windows.Controls.Button)
            
            #ExternalSource("..\..\Informe.xaml",29)
            AddHandler Me.clasesBoton.Click, New System.Windows.RoutedEventHandler(AddressOf Me.clases)
            
            #End ExternalSource
            Return
        End If
        Me._contentLoaded = true
    End Sub
End Class

