   M S B A M L   `   `   `  ����   Combaxe2    ,Combaxe___New.écrans.EcranInventaireMagasin   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$%  Combaxe - Inventaire et magasin��$	��350��$	��525��$	��400��$	��570�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � WindowState$ 	Maximized=�����  �� ImageSource$ ../images/background.png��.���  � RowDefinitions �� $	��44* ��� $	��85* ��� $	��29* ��� $
��182* ��� $	��30* � � ColumnDefinitions �� $��* ��� $��* ��� $��* �.+��� $��0��$��3�� �� Orientation$ 
Horizontal=�$��Center=�.+��� 
�������$��Inventaire et Magasin��$��Matura MT Script Capitals)�$��30(��� $��1��$��3��
�������$��1q� �� CornerRadius$ 5��$
��75,0q�
���   �	 J� Opacity$		 0.5Q�� -   $��GridMagasin��
������ $��1��$��3��$
��75,0q� �� $��* ��� $
��4.5* ��� $��* � �� $��* ��� $��* ��� $��* �.+��� -   $��borderTxtVendre��$ 5��
�������$��0��$��0��$��1q��� -   $��borderTxtAcheterPotionVie��$ 5��
�������$��1��$��0��$��1q��� -   $#��borderTxtAcheterPotionEnergie��$ 5��
�������$��2��$��0��$��1q��� -   $��borderVendre��$ 5��
�������$��0��$��1��$��2��$��1q��� -   $��borderPotionVie��$ 5��
�������$��1��$��1��$��1q��� -   $��borderPotionVieInventaire��$ 5��
�������$��1��$��2��$��1q��� -   $��borderPotionEnergie��$ 5��
�������$��2��$��1��$��1q��� -	   $#��borderPotionEnergieInventaire��$ 5��
�������$��2��$��2��$��1q��� -
   $��lblVendreEquipement��
�������$��Center=�$��Center=�$��0��$��0��$��Matura MT Script Capitals)��� -   $��lblAcheterPotionVie��
�������$��Center=�$��Center=�$��1��$��0��$��Matura MT Script Capitals)��� -   $��lblAcheterPotionEnergie��
�������$��Center=�$��Center=�$��2��$��0��$��Matura MT Script Capitals)��� -   $��nombrePotionVie��
�������$��Center=�$��Center=�$��1��$��2���� -   $��nombrePotionEnergie��
�������$��Center=�$��Center=�$��2��$��2���� $��3��
�������$��1q�$ 5��$��5q�
���   �$		 0.5Q�� -   $��GridInventaire��$��3��
������ $��5q� �� $��* ��� $��* ��� $��* ��� $��* � �� $��* ��� $��* ��� $��* ��� $��* �� $��2��$��Bottom=�$��26��.+��� $��14(�$��Matura MT Script Capitals)�$
��Left=�$��
Inventaire��
��������� $��0,0,7,0q�$��Right=�$	��Top=�$ 
Horizontal=�.+��� $��14(�$��Matura MT Script Capitals)�$
��Or: ��
��������� -   $��
txtbArgent��   TextBoxCombat#���   $��70��$��24��{�.  
 �� TextAlignment$
 Center=�� $��2��$��1��$��Bottom=�$��26��.+��� $��14(�$��Matura MT Script Capitals)�$��Équipement vêtu��
�������� $��2��$��2��$��Bottom=�$��26��.+��� $��14(�$��2��$��2��$��Matura MT Script Capitals)�$��Caractéristiques��
��������� $��3��$��1��
�������$��1q�$ 5��
���   �$		 0.5Q�� -   $��GridEquiper��$��3��$��1��$��5q�
������  �� $��* ��� $��* ��� $��* ��� $��* � �� $��* ��� $��* ��� $��* �� -   $��GridCaracteristiques��$��3��$��2��$��5q�
������  �� $	��55* ��� $
��122* � �� $
��100* ��� $	��15* ��� $	��15* �.+��� $��2��
�������$��1q�$ 5��
���   �$		 0.5Q�� $��2�� �� $��* ��� $��* � �� $��1.25* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+�� $��Right=� �� $��* ��� $��* �.+��� 
�������$
��Wrap=�$��Right=�$��Center=�$��Niveau: ���� -   $��
txtbNiveau��#���   $��1��{�.  $��0,0,0,2q�$��20��$��40��$
��Left=�$��30��$
 Center=��� -   $��txtbProfession��
�������$��5,0,0,0q�$
��Left=�$��1��$��
Profession��$��Center=��� 
�������$��1��$
��Wrap=�$��Force:��$��Right=�$��Center=��� 
�������$��2��$
��Wrap=�$��	Énergie:��$��Right=�$��Center=��� 
�������$��3��$
��Wrap=�$
��Vie:��$��Right=�$��Center=��� 
�������$��4��$
��Wrap=�$��Vitesse:��$��Right=�$��Center=��� 
�������$��5��$
��Wrap=�$��	Défense:��$��Right=�$��Center=��� -   $��	txtbForce��#���   $��2,0,0,0q�$��1��$��1��{�.  $��65��$��30��$
��Left=�$
 Center=��� -   $��txtbEnergie��#���   $��2,0,0,0q�$��1��$��2��{�.  $��65��$��30��$
��Left=�$
 Center=��� -   $��txtbVie��#���   $��2,0,0,0q�$��1��$��3��{�.  $��65��$��30��$
��Left=�$
 Center=��� -   $��txtbVitesse��#���   $��2,0,0,0q�$��1��$��4��{�.  $��65��$��30��$
��Left=�$
 Center=��� -   $��txtbDefense��#���   $��2,0,0,0q�$��1��$��5��{�.  $��65��$��30��$
��Left=�$
 Center=��� -   $��brdMaxWidth��$		 0.5Q�
���   �$��1��
�������$��1q�$��2���� 
���   �$��2��$��2��$		 0.5Q�
�������$��1q��� -   $��brdViePerso��
���   �$��1q�$��1��
��� � �$��2��$��2q��� -   $��brdEnergiePerso��
���   �$��1q�$��2��
����  �$��2��$��2q��� -   $��txtViePerso��$��Matura MT Script Capitals)�$��16(�$��1��$��2�� K� ZIndex$ 5��
�������$��Center=�$��Center=��� -   $��txtEnergiePerso��$��Matura MT Script Capitals)�$��16(�$��2��$��2��$ 5��
�������$��Center=�$��Center=��� -   $��	btnRetour��  GlassButton#���  $��Retour��$��4��$��2��$	��100��$��50��$��0,0,5,0q�$��Right=�$	��100��