   M S B A M L   `   `   `  ����K  GProdavnicaObuće, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ProdavnicaObuće.FormeProdavnicaObuće.Forme  5   	   *    $ProdavnicaObuće.Forme.FrmNarudzbina   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ProdavnicaObuće.Forme     5   	     � Title$  Dodaj/Izmeni narudzbinu��5   	   $	��300��6)   $	��300��66   .��5	      � .+�5
   
   �� $��Datum:��6   $
��Left=�6!   $��	30,20,0,0q�6<   $	��Top=�6O   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpDatum��5      $
��Left=�6$   $��
140,20,0,0q�6?   $	��Top=�6S   �� 5   
   $��Cijena narudzbine:��6   $
��Left=�6-   $��	30,50,0,0q�6H   $	��Top=�6[   �� 5   
   -   5         ��Name$ 	txtCijena��5      $
��Left=�6%   $��
140,50,0,0q�6@    �� TextWrapping$
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $��23��6�   $	��120��6�   �� 5   
   $��Kupac:��6   $
��Left=�6!   $��	30,80,0,0q�6<   $	��Top=�6O   �� 5   
   $��
Zaposleni:��6   $
��Left=�6%   $��
30,110,0,0q�6@   $	��Top=�6T   �� 5   
   -   5         ��Name$ cbKupac��5      $
��Left=�6$   $��
140,80,0,0q�6?   $	��Top=�6S   $	��120��6k    �� DisplayMemberPath$ Kupac��6w    �� SelectedValuePath$ kupacID��6�   �� 5   
   -   5        $ cbZaposleni��5      $
��Left=�6(   $��140,110,0,0q�6C   $	��Top=�6X   $	��120��6p   $ 	Zaposleni��6|   $ zaposleniID��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sačuvaj��6%   $
��Left=�67   $��
30,175,0,0q�6R   $��75��6f   $	��Top=�6q   6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkaži��6$   $
��Left=�65   $��180,175,0,0q�6P   $��75��6e   $	��Top=�6p   6�   5      5      