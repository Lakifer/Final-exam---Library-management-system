   M S B A M L   `   `   `  ����Q  MWpf_Biblioteka_Zavrsni, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Wpf_Biblioteka_ZavrsniWpf_Biblioteka_Zavrsni  5   	   *    $Wpf_Biblioteka_Zavrsni.Knjigovodstvo   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Wpf_Biblioteka_Zavrsni     5   	   -   5          � Title$  Knjigovodstvo��5   	   $	��500��6   $	��700��6,   ���#04c582.��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��DataGridKnjigovodstvo��5
         AutoGenerateColumns .     
IsReadOnly . $
��Left=�6^   $	��207��6y   $��
245,10,0,0q�6�   $	��Top=�6�   $	��437��6�      SelectionMode$ Single=�6�      	CellStyle 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6   5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Naziv knjige��6C      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6Y   	   FontSize$	 10Q�6e   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *	ImeKnjige+6e     5      $ 
Ime autora��6C   $	 110 6W   $	 10Q�6c   
 6%   �� *	ImeAutora+6c     5      $ Kolicina knjiga��6H   $	 100 6a   $	 10Q�6m   
 6%   �� *KolicinaKnjiga+6m     5      $ Dostupne knjige��6J   $	 100 6c   $	 10Q�6o   
 6%   �� *DostupnostKnjiga+6o   5        5   
   -   5        $��DataGridKnjigovodstvo2��5       .  $
��Left=�6M   $	��226��6h   $��172,233,0,0q�6u   $	��Top=�6�   $	��510��6�    5      �� 5      "  6    5        5      $ Naziv knjige��6C   $	 100 6Y   $	 10Q�6e   
 6%   �� *	ImeKnjige+6e     5      $ 	Ime clana��6B   $ 90 6U   $	 10Q�6`   
 6%   �� *
ImeClana+6`     5      $ Datum Iznajmljivanja��6M   $	 120 6k   $	 10Q�6w   
 6%   �� *DatumIznajmljivanja+6w     5      $ Datum Vracanja��6M   $	 100 6e   $	 10Q�6q   
 6%   �� *DatumVracanjaKnjige+6q     5       $
 JMBG��6C   $ 80 6Q   $	 10Q�6\   
 6%   �� *	JMBGClana+6\   5#      �� 5$   
   -   5        $��ButtonNazad��5$      $��Nazad��6$   $��14(�64   $
��Left=�6B   $��
46,419,0,0q�6]   $	��Top=�6q   $��80��6�   ���#545d6a
�������$��25��6�   6�   �� 5%   
   -   5        $��TextBoxPretraga��5%      $
��Left=�6)   $��26��6D   $��	24,63,0,0q�6P    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��151��6�   6�   �� 5&   
   $��Pretraga knjiga��6   $
��Left=�6*   $��	46,29,0,0q�6E   $	��Top=�6X   $
��Bold"�6p   $��14(�6�   5)      5*      