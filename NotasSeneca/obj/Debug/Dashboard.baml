   M S B A M L   `   `   `  ����F  BNotasSeneca, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:NotasSenecaNotasSeneca  5   	       NotasSeneca.Dashboard   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   %localclr-namespace:NotasSeneca  5   	   -   5          � Title$  Notas Séneca | Dashboard��5	   	   $	��450��6*   $	��400��67   $	��450��6C   $	��400��6S   $	��450��6b   $	��400��6r    � Icon$ logo-app.png��6�    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   %    5      .��5      � -   5        $��	principal��5      .+�5   
   �� -   5        $��trigger��5   (   $y�Hidden=�6   dash6=   �� 5   
    �� Orientation$ Vertical=�6   .+�5      o� -   5        $
��menu��5       $
��Auto��6   .@�5      m� $��	_Opciones��6   .@�5      m� -   5        $��_Ver informe��5      65   m� 5      -   5        $��	_Detalles��5      62   m� 5      -   5        $
��tema��5   5   $��_Tema oscuro��6   6A   �� 5      m� 5      -   5        $��_Cerrar sesión��5      67   m� 5      -	   5        $��_Salir��5      6/   5      5       5!      �� 5$   
   $ Vertical=�6   $	��Top=�6,   $��	0,110,0,0q�6D   .+�5%      �� $ 
Horizontal=�6   $
��Left=�62   .+�5&      �� -
   5        $��verClasesProf��5&   Q   $	��125��6   $��30��6%   $
��45,0q�61   .��6f   Ver mis clases6v   �� 5'      -   5        $��verInfoProf��5'   1   $	��135��6   $��30��6%   .��6D   Ver información6U   5(      5)      �� 5,   
   $ 
Horizontal=�6   .+�5-      '  !MaterialDesignThemes.Wpf.PackIcon  -   5        $��
logoClases��5-   e      Kind$ accountGroup=�6&   $��25��6:   $��20��6F   $��
45,175,0,0q�6Q   $y�Hidden=�6w   �� 5.      -   5        $��clases��5.   ]   $��25��6   $	��100��6#   $
��Left=�6/   $��	5,-45,0,0q�6J   $y�Hidden=�6k   5/      �� 51   
   -   5        $��
numAlumnos��51   F    �� TextAlignment$ Center=�6   $��Bottom=�6+   $��	0,0,0,105q�6X   $��18(�6k   Nº de alumnos:6�   �� 52   
   -   5        $��	numClases��52   +   $ Center=�6   $��Bottom=�6=   $��0,0,0,80q�6X   $��18(�6j   Nº de clases:6�   �� 53   
   -   5        $��numAsignaturas��53   +   $ Center=�6   $��Bottom=�6B   $��0,0,0,55q�6]   $��18(�6o   Nº de asignaturas:6�   �� 55   
   -   5        $��verClase��55   W   $	��125��6   $��25��6   $
��Left=�6)   $��	50,50,0,0q�6D   $y�Hidden=�6g   .��6{   	Ver clase6�   �� 56   
   -   5        $��
botonSalir��56   X   $��75��6   $��25��6   $
��Left=�6(   $��150,350,0,0q�6C      MaterialDesignFlatButton#���   6x   .��6�   Salir6�   58      59      