   M S B A M L   `   `   `  ����   Combaxe3    -Combaxe___New.écrans.EcranCreationPersonnage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     X TXceed.Wpf.Toolkit, Version=2.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � Title$'  !Combaxe - Création de personnage��$	��350��$	��525��$	��350��$	��525�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � WindowState$ 	Maximized=�����  �� ImageSource$ ../images/background.png��.���  � RowDefinitions �� $	��51* ��� $	��87* ��� $	��30* ��� $
��128* ��� $	��24* � � ColumnDefinitions �� $
��222* ��� $
��295* �.+��� $��0��$��2�� �� Orientation$ Vertical=�.+��� 
�������$��Center=�$��Création de personnage��$��Matura MT Script Capitals)�$��38(�$��	34,0,33,0q�� $��1�� �� $��* ��� $��* ��� $��* � �� $��* ��� $��* �.+��� -   $��txtbNom��   TextBoxStyle#���    �� 	MaxLength$ 20��	 �� TextAlignment$	 Center=�$��20(�$��Nom du personnage��$��Stretch=�$��5,5,5,5q�$��45��$��3���� -   $��btnGuerrier��  GlassButton#���  $��1��$��Stretch=�$��Guerrier���� -   $��
btnPaladin��#���  $��1��$��Stretch=�$��Paladin��$��1���� -   $��btnMagicien��#���  $��1��$��Stretch=�$��Magicien��$��2���� -   $��txtbDescriptionProf��$
��Auto=�  TextBoxCombat#���  $	 Justify=�$��1��$��1��{�. 
 �� 
IsReadOnly
 . $��	1,35,75,0q��� $��2��$��2��$��0,10,0,0q�$��25(�$��Matura MT Script Capitals)�$��Caracteristiques��
�������$	��Top=�$��Center=��� 
���   � J� Opacity$	 0.5Q�$��3�� �� CornerRadius$ 5��$��5q�$	��340��� 
������ $��3��$	��340��$��5q� �� $��* ��� $��* ��� $��* ��� $��* ��� $��* � �� $	��75* ��� $
��137* �.+��� $��Matura MT Script Capitals)�$��16(�
�������$��Right=�$��Center=�$��Force:��$��0��$��0���� $��0��$��1��$ 
Horizontal=�.+��� -   $��btnMoinsForce��#���  $��-��$��30��$��40���� -   $��txtForce��#���  $��0��{�.  $��50��$��40��$	 Center=��� -   $��btnPlusForce��#���  $��+��$��30��$��40���� $��Matura MT Script Capitals)�$��16(�
�������$��Right=�$��Center=�$��	Énergie:��$��1��$��0���� $��1��$��1��$ 
Horizontal=�.+��� -	   $��btnMoinsEnergie��#���  $��-��$��30��$��40���� -
   $��
txtEnergie��#���  $��0��{�.  $��50��$��40��$	 Center=��� -   $��btnPlusEnergie��#���  $��+��$��30��$��40���� $��Matura MT Script Capitals)�$��16(�
�������$��Right=�$��Center=�$
��Vie:��$��2��$��0���� $��2��$��1��$ 
Horizontal=�.+��� -   $��btnMoinsVie��#���  $��-��$��30��$��40���� -   $��txtVie��#���  $��0��{�.  $��50��$��40��$	 Center=��� -   $��
btnPlusVie��#���  $��+��$��30��$��40���� $��Matura MT Script Capitals)�$��16(�
�������$��Right=�$��Center=�$��Vitesse:��$��3��$��0���� $��3��$��1��$ 
Horizontal=�.+��� -   $��btnMoinsVitesse��#���  $��-��$��30��$��40���� -   $��
txtVitesse��#���  $��0��{�.  $��50��$��40��$	 Center=��� -   $��btnPlusVitesse��#���  $��+��$��30��$��40���� $��Matura MT Script Capitals)�$��16(�
�������$��Right=�$��Center=�$��	Défense:��$��4��$��0���� $��4��$��1��$ 
Horizontal=�.+��� -   $��btnMoinsDefense��#���  $��-��$��30��$��40���� -   $��
txtDefense��#���  $��0��{�.  $��50��$��40��$	 Center=��� -   $��btnPlusDefense��#���  $��+��$��30��$��40��� $��2��$��3��$��1�� �� $
��157* ��� $	��25* � �� $��* ��� $��5* ��� $��* �.+��� $ Vertical=�$��0��$��Right=�$��Center=�.+�#  Xceed.Wpf.Toolkit.ColorPicker  -   $��_colorPicker��$	��Top=��� -   $��choixPointeur���� -   $��btnRectangle��#���  $��20(�$��	Rectangle���� -   $��
btnEllipse��#���  $��20(�$��Ellipse���� -   $��btnToutSupprimer��#���  $��20(�$��
Suppresion���� -    ��Name$ btnImageGuerrier��$��0,25,0,0q�#���  $��20(�$��Guerrier��$	��100���� -   $ btnImagePaladin��#���  $��20(�$��Paladin��$	��100���� -   $ btnImageMage��#���  $��20(�$
��Mage��$	��100���� -   $ btnImageDefaut��#���  $��20(�$��Défaut��$	��100��� $��1��
�������$��5,5,50,5q�.+��� -   $��_personnageDessin�� �� EditingMode$	 Ink=� �� 
Background �� $ ..\images\defaut.png�� j� Stretch$ Uniform=� �� DefaultDrawingAttributes *  $System.Windows.Ink.DrawingAttributes     Color$ Black��   
FitToCurve .     Height$ 5Q�   Width$ 5Q�   IgnorePressure .     IsHighlighter .     	StylusTip$ Ellipse=��� $ 
Horizontal=�$��4��$��1��$��Right=�.+��� -   $��btnAide��#���  $
��Aide��$��50��$��0,0,5,0q��� -    $��	btnRetour��#���  $��Retour��$	��100��$��50��$��0,0,5,0q��� -!   $��btnCreerPerso��#���  $��Créer personnage��$��50��$��0,0,13,0q��� $��Center=�$��4��$ 
Horizontal=�.+��� $��15(�$��Matura MT Script Capitals)�
�������$��Points restants:���� -"   $��txtbPointsRestants��#���  $	��Top=�{�.  $��0,0,0,2q�$��40��$��30��$��0��$	 Center=�