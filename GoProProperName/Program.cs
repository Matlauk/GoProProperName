using System;
using System.IO;
using System.Linq;

namespace GoProProperName
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath;
            if (args.Any())
            {
                folderPath = args[0];
            }
            else
            {
                folderPath = Directory.GetCurrentDirectory();
            }

            Console.WriteLine($"Working on directory:{folderPath}");
            
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("The folder path specified does not exist.");
            }
            
            var files = Directory.EnumerateFiles(folderPath);
            
            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                var ext = Path.GetExtension(file);

                if (fileName.Length != 8)
                {
                    continue;
                }
                
                var p1 = fileName[0..1];
                var p2 = fileName[1..2];
                var p3 = fileName[2..4];
                var p4 = fileName[4..8];

                if (p1 != "G")
                {
                    continue;
                }

                if (p2 != "H" && p2 != "X")
                {
                    continue;
                }

                if (!p3.Any(char.IsNumber) && p3 != "AA") // TODO:: Loop prefix may not be static to AA?
                {
                    continue;
                }
                
                if (!p4.Any(char.IsNumber))
                {
                    continue;
                }

                var toFilename = $"{p4}-{p3}-{p1}{p2}";

                File.Move(file, Path.Combine(folderPath, $"{toFilename}{ext}"));
            }
        }
    }
}