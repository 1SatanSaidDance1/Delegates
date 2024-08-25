using Delegates;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Логика для задачи "Максимальное число"
        List<IFloatValue> list = new()
            {
                new FloatValue(2f),
                new FloatValue(1313f),
                new FloatValue(-66.06f)
            };

        float maxElement = list.GetMax(GetParameter).Value;

        string console = "Задача 'Максимальное число'\n\r";
        console += "На вход даны числа 2, 1313, -66.06 ";
        console += $"Максимальное число: {maxElement}\n\r\n\r";

        Console.WriteLine(console);

        // Логика для задачи "Вывести в консоль сообщения, возникающие при срабатывании событий."
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
    }

    private static float GetParameter<T>(T param) where T : class => param switch
    {
        IFloatValue value => value.Value,
        float convertToFloat => convertToFloat,
        _ => throw new ArgumentException("Не удается преобразовать тип")
    };
}