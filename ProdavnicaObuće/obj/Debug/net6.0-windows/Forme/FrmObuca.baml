   M S B A M L   `   `   `  ����K  GProdavnicaObuće, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ProdavnicaObuće.FormeProdavnicaObuće.Forme  5   	   %    ProdavnicaObuće.Forme.FrmObuca   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ProdavnicaObuće.Forme     5   	     � Title$  Dodaj/izmeni obucu��5   	   $	��330��6$   $	��300��61   .��5	      � .+�5
   
   �� $��Cijena:��6   $
��Left=�6"   $��	30,50,0,0q�6=   $	��Top=�6P   �� 5   
   -   5         ��Name$ 	txtCijena��5      $
��Left=�6%   $��
140,50,0,0q�6@    �� TextWrapping$
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $��23��6�   $	��120��6�   �� 5   
   $��	Velicina:��6   $
��Left=�6$   $��	30,20,0,0q�6?   $	��Top=�6R   �� 5   
   -   5        $ txtVelicina��5      $
��Left=�6'   $��
140,20,0,0q�6B   $
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $��23��6�   $	��120��6�   �� 5   
   $��Boja:��6   $
��Left=�6    $��	30,80,0,0q�6;   $	��Top=�6N   �� 5   
   -   5        $ txtBoja��5      $
��Left=�6#   $��
140,80,0,0q�6>   $
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $��23��6�   $	��120��6�   �� 5   
   $��Model:��6   $
��Left=�6!   $��
30,110,0,0q�6<   $	��Top=�6P   �� 5   
   $��
Tip obuce:��6   $
��Left=�6%   $��
30,140,0,0q�6@   $	��Top=�6T   �� 5   
   -   5         ��Name$ cbModel��5      $
��Left=�6$   $��140,110,0,0q�6?   $	��Top=�6T   $	��120��6l    �� DisplayMemberPath$ Model��6x    �� SelectedValuePath$ modelID��6�   �� 5   
   $��Marka:��6   $
��Left=�6!   $��
30,170,0,0q�6<   $	��Top=�6P   �� 5   
   -   5        $ cbMarka��5      $
��Left=�6$   $��140,170,0,0q�6?   $	��Top=�6T   $	��120��6l   $ Marka��5      $ markaID��6-   �� 5   
   -   5        $ 
cbTipObuce��5      $
��Left=�6'   $��140,140,0,0q�6B   $	��Top=�6W   $	��120��6o   $	 Tip��6{   $ 
tipObuceID��6�   �� 5   
   $��Narudzbina:��6   $
��Left=�6&   $��
30,200,0,0q�6A   $	��Top=�6U   �� 5   
   -   5        $ cbNarudzbina��5      $
��Left=�6)   $��140,200,0,0q�6D   $	��Top=�6Y   $	��120��6q   $ datum��6}   $ narudzbinaID��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sačuvaj��6%   $
��Left=�67   $��
30,245,0,0q�6R   $��75��6f   $	��Top=�6q   6�   �� 5   
   -	   5        $ 	btnOtkazi��5      $��Otkaži��6$   $
��Left=�65   $��180,245,0,0q�6P   $��75��6e   $	��Top=�6p   6�   5      5      