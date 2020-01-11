using Core;
using System;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var programA = @"C:\Program Files\Notepad++\notepad++.exe";
            var programB = @"C:\Windows\System32\notepad.exe";
             
            var watcher = new ProcessWatcherWrapper();
            watcher.Execute(programA, programB);

            Console.WriteLine("To exit press any key.");
            Console.ReadLine();
        } 
    }
}
