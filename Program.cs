// See https://aka.ms/new-console-template for more information

using Svg;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ImageFixer;

Console.WriteLine("Hello, World!");

string inDirectory = @"D:\images\uploads";
string outDirectory = @"d:\out\";

var maximum = 600; 

Directory.Delete(outDirectory, true);
Directory.CreateDirectory(outDirectory);

// Parcourir les fichiers dans un 

var outDirectoryInfo = new DirectoryInfo(outDirectory);
var inDirectoryInfo = new DirectoryInfo(inDirectory);


foreach (var inDirectoryFile in new DirectoryInfo(inDirectory).EnumerateFiles("*", SearchOption.AllDirectories))
{
    var relativePath = 
        inDirectoryFile.FullName.Replace(inDirectoryInfo.FullName, string.Empty);

    var fullDestinationPath =new  FileInfo
    (outDirectoryInfo.FullName + relativePath).FullName; 

    Directory.CreateDirectory(Path.GetDirectoryName(fullDestinationPath)!);

    // Traîtement du png 

    var isSvgFile = inDirectoryFile.FullName.EndsWith("svg", StringComparison.CurrentCultureIgnoreCase); 
   


    if (isSvgFile)
    {
        fullDestinationPath = fullDestinationPath.Replace(".svg", ".png"); 

        Console.WriteLine($"Conversion svg : {inDirectoryFile.FullName}");
        var svgDocument = SvgDocument.Open(inDirectoryFile.FullName);
        using var bitmap = svgDocument.Draw();

        bitmap.MakeTransparent();

        bitmap.Save(fullDestinationPath, ImageFormat.Png);

    }
    else
    {
        Console.WriteLine($"Copie du fichier  : {inDirectoryFile.FullName}");
        File.Copy(inDirectoryFile.FullName, fullDestinationPath);
    }

    var isPngFile = 
        inDirectoryFile.FullName.EndsWith("png", StringComparison.CurrentCultureIgnoreCase) 
        || isSvgFile;

    var destinationArray = File.ReadAllBytes(fullDestinationPath); 

    var memoryStream = new MemoryStream(destinationArray);

    try
    {
        using var destinationImage = Image.FromStream(memoryStream);

        if (destinationImage.Width > maximum || destinationImage.Height > maximum)
        {

            if (destinationImage.Width > destinationImage.Height)
            {
                // Resize according to width 


                Console.WriteLine($"Redimensionnement width  : {fullDestinationPath}");

                var newWidth = maximum;
                var newHeight = (int)(maximum * (double)destinationImage.Height / destinationImage.Width);

                var resized = destinationImage;

                using var finalFile = ImageHelper.ResizeImage(destinationImage, newWidth, newHeight);

                finalFile.Save(fullDestinationPath, isPngFile ? ImageFormat.Png : ImageFormat.Jpeg);
            }
            else
            {
                // Resize according to heightt

                Console.WriteLine($"Redimensionnement height  : {fullDestinationPath}");

                var newHeight = maximum;
                var newWidth = (int)(maximum * (double)destinationImage.Width / destinationImage.Height);

                var resized = destinationImage;

                using var finalFile = ImageHelper.ResizeImage(destinationImage, newWidth, newHeight);

                finalFile.Save(fullDestinationPath, isPngFile ? ImageFormat.Png : ImageFormat.Jpeg);
            }
        }
    }
    catch (ArgumentException)
    {
        continue; 
    }
}



Console.WriteLine("Terminé");