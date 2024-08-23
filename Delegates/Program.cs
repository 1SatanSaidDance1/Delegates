using Delegates;
using System.Xml.Linq;

Console.WriteLine(MaxElements.Run());

Console.WriteLine("Задача 'Вывести в консоль сообщения, возникающие при срабатывании событий.'");
Console.WriteLine("Отмена дальнейшего поиска, если найден файл с расширением '.py'\n\r");

TraversingFileDirectory traversingFileDirectory = new();
int t = 0;
List<string> filesnames = [];

EventHandler<FileArgs> handler = (search, fileArgs) =>
{
    filesnames.Add(fileArgs.SearchFile);
    fileArgs.CancelingSearch = false;

    if (fileArgs.SearchFile.Contains(".py"))
        fileArgs.CancelingSearch = true;
    t++;
};

traversingFileDirectory.FileFound += handler;

Console.WriteLine(traversingFileDirectory.Search(@"C:\Users\Home\Desktop\TestFolder", "*"));

traversingFileDirectory.FileFound -= handler;


Console.WriteLine($"\n\rНайдено файлов: {t}");

if (t > 0) Console.WriteLine($"Отмена обработчика на {Path.GetFileName(filesnames[t - 1])}");