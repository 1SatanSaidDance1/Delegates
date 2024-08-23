using Delegates;
using System;

namespace Delegates
{
    /// <summary>
    /// Класс, обходящий каталог файлов
    /// и выдающий событие при нахождении каждого файла
    /// </summary>
    public class TraversingFileDirectory
    {
        public event EventHandler<FileArgs> FileFound;

        public string Search(string dir, string param)
        {
            string console = "";

            if (!Directory.Exists(dir))
            {
                console = "Файлов в папке не обнаружено!";
            }

            foreach (var file in Directory.EnumerateFiles(dir, param))
            {
                var fileFound = ShowFoundFile(file);
                console += $"Файл {Path.GetFileName(file)} найден\r\n";

                if (fileFound.CancelingSearch)
                    break;
            }

            return console;
        }

        private FileArgs ShowFoundFile(string file)
        {
            var fileArgs = new FileArgs(file);
            FileFound(this, fileArgs);
            return fileArgs;
        }
    }
}