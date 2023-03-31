# ImageFixer

## Version .NET du script de transformation et de redimensionnement d'image en format PNG

Cette application C# . NET Core convertit les images SVG en images PNG et redimensionne toutes les images qui d�passent une dimension maximale de 600 pixels.
L�application traite tous les fichiers dans un r�pertoire d�entr�e sp�cifi� et affiche les fichiers trait�s dans un r�pertoire de sortie sp�cifi�.


## Pr�requis :
.NET Core 3.1 ou version ult�rieure

## Installation :
Clonez le d�p�t ou t�l�chargez le code source.
Ouvrez la solution dans Visual Studio ou un autre IDE compatible.
Cr�ez la solution.

## Utilisation :
Ouvrez un terminal de commande.
Acc�dez au r�pertoire contenant le fichier ex�cutable construit.
Ex�cutez le fichier ex�cutable avec la commande suivante : dotnet ImageFixer.dll
L�application traitera tous les fichiers dans inDirectory et les affichera dans outDirectory.

## Configuration :
Les variables suivantes peuvent �tre modifi�es dans le fichier program.cs pour configurer l�application :

inDirectory�: R�pertoire contenant les fichiers d�entr�e.
outDirectory�: Le r�pertoire de sortie des fichiers trait�s.
maximum�: la dimension maximale (largeur ou hauteur) des images de sortie.

## D�tails techniques :
L�application utilise les biblioth�ques suivantes�:

Svg pour convertir des images SVG en images bitmap.
Syst�me.Dessin pour travailler avec des images bitmap.
System.IO pour travailler avec les r�pertoires et les fichiers.
ImageFixer pour redimensionner les images.

Le fichier program.cs contient la logique principale de l�application.
Le fichier commence par d�finir les variables inDirectory, outDirectory et maximum. Il supprime alors outDirectory s�il existe d�j� et cr�e un nouveau outDirectory.
L�application parcourt ensuite chaque fichier dans inDirectory. Pour chaque fichier, elle d�termine si le fichier est une image SVG.
S�il s�agit d�une image SVG, l�application convertit l�image SVG en image PNG et l�enregistre dans outDirectory.
Si ce n�est pas une image SVG, l�application copie le fichier dans outDirectory.

L�application d�termine alors si le fichier est une image PNG ou une image SVG.
Si le fichier est une image PNG ou SVG, l�application redimensionne l�image si elle d�passe la dimension maximale.
L�image redimensionn�e est enregistr�e dans outDirectory.

Enfin, l�application affiche un message ��Termin頻 pour indiquer que le traitement est termin�.

