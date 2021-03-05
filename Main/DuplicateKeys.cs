using System;
using System.Linq;

public class Example
{
    public static void Main()
    {
        string[] Sarray = { "First", "Second", "Third", "First", "Third" };
        string[] output = new string[Sarray.Length];

        //Output if array contain repeated elements
        if (IFDuplicateKeys(Sarray) == true)
        {
            Console.WriteLine("Y");
        }
        else
        {
            Console.WriteLine("N");
        }

        DuplicateKeys(Sarray, ref output);

        //Output of repeated elements
        foreach (string n in output)
        {
            Console.WriteLine(n);
        }
        
        Console.ReadLine();
    }

    public static void DuplicateKeys(string[] array, ref string[] output)
    {
        //Record of repeated elements to output array
        var duplKeys = array.GroupBy(x => x)
                        .Where(group => group.Count() > 1)
                        .Select(group => group.Key);

        for (int i = 0; i < duplKeys.Count(); i++)
        {
            output[i] = duplKeys.ElementAt(i);
        }
           
            
    }
    public static bool IFDuplicateKeys(string[] array)
    {
        //Detection if array contain repeates elements
        var duplKeys = array.GroupBy(x => x)
                        .Where(group => group.Count() > 1)
                        .Select(group => group.Key);
        if (duplKeys.Count() != 0)
        {
            return true;
        }
        else
            return false;
    }
}