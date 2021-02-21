using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Methods
{
    class Program
    {
        public int AddNumbers(int number1, int number2)
        {
            return number1 + number2;
        }

        //Example with the optional parameter
        public int AddNumbers_Opt(int number1, int number2, int number3 = 0)
        {
            return number1 + number2 + number3;
        }

        //An arbitrary number of parameters
        public void GreetPersons(params string[] names)
        {
            foreach (string name in names)
                Console.WriteLine("Hello " + name);
        }

        static void Main_Test1(string[] args)
        {
            Program addNum = new Program();
            //Console.WriteLine(addNum.AddNumbers_Opt(1, 2,10));
            addNum.GreetPersons("John", "Jane", "Tarzan");
            Console.ReadLine();
        }

    }

    class Ref_Modifier
    {
        public void AddFive(ref int number)
        {
            number += 5;
        }

        static void Main_Test2(string[] args)
        {
            int number = 20;

            Ref_Modifier addfive = new Ref_Modifier();
            addfive.AddFive(ref number);
            Console.WriteLine(number);
            Console.ReadLine();
        }
    }

    class OutModifier
    {
        static void Main_Test1 (string [] args)
        {
            int addedValue, substractedValue;
            OutModifier domath = new OutModifier();
            domath.DoMath(10, 5, out addedValue, out substractedValue);
            Console.WriteLine(addedValue);
            Console.WriteLine(substractedValue);
            Console.ReadLine();
        }

        public void DoMath(int number1, int number2, out int addedValue, out int substractedValue)
        {
            addedValue = number1 + number2;
            substractedValue = number2 - number1;
        }
    }

    class Methods_InMethod
    {
        static void Main_Test2(string [] args)
        {
            string aVeryLargeString = "Lots of text ...";
            Methods_InMethod inmethod = new Methods_InMethod();
            inmethod.InMethod(aVeryLargeString);
        }

        //largeString is read only
        public void InMethod(in string largeString)
        {
            Console.WriteLine(largeString);
            Console.ReadLine();
        }
    }

    class NamedParameters
    {
        public void PrintUserDetails(int userID, string name, int age = -1, List<string> addressLines = null)
        {
            //Print details...
            Console.WriteLine(name + " is " + age + " years old");
            Console.ReadLine();

        }

        static void Main(string [] args)
        {
            NamedParameters userDetails = new NamedParameters();
            userDetails.PrintUserDetails(1, "John", 42, null);
            userDetails.PrintUserDetails(name: "John Doe", userID: 1);
            userDetails.PrintUserDetails(addressLines: new List<string>() { }, name: "John Doe", userID: 2);
        }
    }
}
