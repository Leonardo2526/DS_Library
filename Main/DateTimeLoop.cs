using System;
using System.Globalization;
using System.Linq;

public class Example
{

    public static string DateT()
    {
        string DateTimeString = DateTime.Now.ToString("yyMMdd_HHmmss");
        return DateTimeString;
    }

    public static void Main()
    {

        //string DateTimeString = DateTime.Now.ToString("yyMMdd_HHmmss");
        Example t = new Example();
        //string output = t.DateT();

        while (Console.ReadLine() == "")
        {
            Console.WriteLine(Test1());
        }
        Console.ReadLine();
    }

    public static string Test1()
    {
        string output1 = DateT();
        return output1 + "!";
    }
}