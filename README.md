# ImageFixer

## Version .NET du script de transformation et de redimensionnement d'image en format PNG

Cette application C# . NET Core convertit les images SVG en images PNG et redimensionne toutes les images qui dépassent une dimension maximale de 600 pixels.

L’application traite tous les fichiers dans un répertoire d’entrée spécifié et affiche les fichiers traités dans un répertoire de sortie spécifié.


## Prérequis :
.NET Core 3.1 ou version ultérieure

## Installation :

Clonez le dépôt ou téléchargez le code source.

Ouvrez la solution dans Visual Studio ou un autre IDE compatible.

Créez la solution.


## Utilisation :
Ouvrez un terminal de commande.

Accédez au répertoire contenant le fichier exécutable construit.

Exécutez le fichier exécutable avec la commande suivante : dotnet ImageFixer.dll

L’application traitera tous les fichiers dans inDirectory et les affichera dans outDirectory.


## Configuration :
Les variables suivantes peuvent être modifiées dans le fichier program.cs pour configurer l’application :

inDirectory : Répertoire contenant les fichiers d’entrée.

outDirectory : Le répertoire de sortie des fichiers traités.

maximum : la dimension maximale (largeur ou hauteur) des images de sortie.

## Détails techniques :
L’application utilise les bibliothèques suivantes :

Svg pour convertir des images SVG en images bitmap
.
Système.Dessin pour travailler avec des images bitmap.

System.IO pour travailler avec les répertoires et les fichiers.

ImageFixer pour redimensionner les images.



Le fichier program.cs contient la logique principale de l’application.

Le fichier commence par définir les variables inDirectory, outDirectory et maximum. Il supprime alors outDirectory s’il existe déjà et crée un nouveau outDirectory.

L’application parcourt ensuite chaque fichier dans inDirectory. Pour chaque fichier, elle détermine si le fichier est une image SVG.

S’il s’agit d’une image SVG, l’application convertit l’image SVG en image PNG et l’enregistre dans outDirectory.

Si ce n’est pas une image SVG, l’application copie le fichier dans outDirectory.

L’application détermine alors si le fichier est une image PNG ou une image SVG.

Si le fichier est une image PNG ou SVG, l’application redimensionne l’image si elle dépasse la dimension maximale.

L’image redimensionnée est enregistrée dans outDirectory.


Enfin, l’application affiche un message « Terminé » pour indiquer que le traitement est terminé.

