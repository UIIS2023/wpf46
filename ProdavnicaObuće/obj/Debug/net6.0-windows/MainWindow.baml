   M S B A M L   `   `   `  ����K  GProdavnicaObuće, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ProdavnicaObućeProdavnicaObuće  5   	   !    ProdavnicaObuće.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ProdavnicaObuće     5   	     � Title$  Prodavnica obuće��5   	   $	��350��6"   $	��700��6/   
��� ���.��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridCentralni��5      $��Center=�6.   $��Center=�6K   $
��auto��6f   $
��auto��6s      
IsReadOnly$
 True��6�      AlternatingRowBackground
 � ���   CanUserAddRows$ False��5   3      SelectionUnit$ FullRow=�6J      SelectionMode$ Single=�6b   �� 5   
   $��Center=�6   $	��Top=�62   $��30��6J   $
��auto��6V    �� Orientation$ 
Horizontal=�6c   .+�5      �� -   5         ��Name$ btnZaposleleni��5      $��	Zaposleni��6-   $
��Left=�6A   $	��Top=�6]   $��75��6u   $��30��6�   
���� K�$��4q�6�   
�������6�   �� 5      -   5        $ btnKupci��5      $��Kupci��6'   $
��Left=�67   $	��Top=�6S   $��75��6k   $��30��6v   
���� K�$��4q�6�   
�������6�   �� 5      -   5        $ btnObuca��5      $��Obuca��6'   $
��Left=�67   $	��Top=�6S   $��75��6k   $��30��6v   
���� K�$��4q�6�   
�������6�   �� 5      -   5        $ 	btnModeli��5      $��Modeli��6(   $
��Left=�69   $	��Top=�6U   $��75��6m   $��30��6x   
���� K�$��4q�6�   
�������6�   �� 5      -   5        $ btnMarke��5      $��Marke��6'   $
��Left=�67   $	��Top=�6S   $��75��6k   $��30��6v   
���� K�$��4q�6�   
�������6�   �� 5      -   5        $ 	btnTipovi��5      $��Tipovi��6(   $
��Left=�69   $	��Top=�6U   $��75��6m   $��30��6x   
���� K�$��4q�6�   
�������6�   �� 5      -   5        $ btnNarudzbine��5      $��
Narudzbine��6,   $
��Left=�6A   $	��Top=�6]   $��75��6u   $��30��6�   
���� K�$��4q�6�   
�������6�   �� 5      -	   5        $ 
btnPotvrde��5      $��Potvrde��6)   $
��Left=�6;   $	��Top=�6W   $��75��6o   $��30��6z   
���� K�$��4q�6�   
�������6�   5      �� 5   
   $��Center=�6   $��Bottom=�62   $��30��6M   $
��auto��6Y   $ 
Horizontal=�6f   .+�5      �� -
   5        $ btnDodaj��5      $��Dodaj��6'   $
��Left=�67   $��Bottom=�6S   $��50��6n   $��30��6y   
���� K�$��4q�6�   
�������6�   �� 5      -   5        $ 	btnIzmeni��5      $��Izmeni��6(   $
��Left=�69   $��Bottom=�6U   $��50��6p   $��30��6{   	 J� RenderTransformOrigin$	 -8.743,-4.048&�6�   
���� K�$��4q�6�   
�������6�   �� 5      -   5        $ 	btnObrisi��5      $��Obrisi��6(   $
��Left=�69   $��Bottom=�6U   $��50��6p   $��30��6{   
���� K�$��4q�6�   
�������6�   5"      5#      5$      