using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Level1
{
    class SearchMethod
    {
        public static void SearchFiles(string path, string expansion)
        {
            if (Directory.Exists(path))
            {
                var myFiles = new DirectoryInfo($"{path}").GetFiles($"*{expansion}*");

                if (myFiles.Length == 1)
                {
                    foreach (var i in myFiles)
                    {
                        Console.WriteLine(i);
                    }
                }
                else if (myFiles.Length < 1 || expansion == "")
                {
                    Console.WriteLine("Файлов с таким расширением в директории нет");
                }
                else
                {       
                    myFiles = myFiles.OrderByDescending(file => file.CreationTime).ToArray();
                    var lastFile = myFiles.First();
                    var otherFiles = myFiles.TakeWhile(file => lastFile.CreationTime - file.CreationTime <= new TimeSpan (0, 0, 0, 10)).ToArray();
                    Console.WriteLine($"Последний файл и файлы, которые были созданы за 10 секунд до него: ");
                    foreach (var i in otherFiles)
                        {
                            Console.WriteLine(i);
                        }
                }
            }
            else
            {
                Console.WriteLine("Неверно указан путь к директории");
            }
            
            Console.ReadKey();
        }
    }
}
