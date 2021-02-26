using System;
using System.Collections;

namespace HelloApp
{
    class Week
    {
        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday",
                         "Friday", "Saturday", "Sunday" };

        public IEnumerator GetEnumerator()
        {
            return days.GetEnumerator();
        }
    }
    class Program1
    {
        static void Main1(string[] args)
        {
            Week week = new Week();
            foreach (var day in week)
            {
                Console.WriteLine(day);
            }
            Console.Read();
        }
    }
    class Program2
    {
        static void Main2(string[] args)
        {
            int[] numbers = { 0, 2, 4, 6, 8, 10 };

            IEnumerator ie = numbers.GetEnumerator(); // получаем IEnumerator
            while (ie.MoveNext())   // пока не будет возвращено false
            {
                int item = (int)ie.Current;     // берем элемент на текущей позиции
                Console.WriteLine(item);
            }
            ie.Reset(); // сбрасываем указатель в начало массива
            Console.Read();
        }
    }
}