// See https://aka.ms/new-console-template for more information

namespace SchoolHRAdministration.DelegateBasicExample;

public class Program
{
    delegate void LogDelegate(string text);

    public static void Main(string[] args)
    {
        var log = new Log();
        var logTextToScreenDelegate = new LogDelegate(log.LogTextToScreen);
        var logTextToFileDelegate = new LogDelegate(log.LogTextToFile);
        Console.WriteLine("Please Enter Some Text:");
        var text = Console.ReadLine();
        var multiLogDelegate = logTextToScreenDelegate + logTextToFileDelegate;
        LogText(multiLogDelegate, text);
        Console.ReadKey();
    }

    private static void LogText(LogDelegate logDelegate, string text)
    {
        logDelegate(text);
    }
}

public class Log
{
    public void LogTextToScreen(string text)
    {
        Console.WriteLine($"Date: {DateTime.Now}, Text: {text}");
    }

    public void LogTextToFile(string text)
    {
        Console.WriteLine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"));
        using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
        {
            sw.WriteLine($"{DateTime.Now}: {text}");
        }
    }
    
    
}