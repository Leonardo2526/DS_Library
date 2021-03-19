using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ConsoleApp_NetCore
{
    class Program1
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    class Inteface_DefaultImpementation
    {
        static void Main(string[] args)
        {
            IMovable tom = new Person();
            Car tesla = new Car();
            tom.Move();     // Walking
            tesla.Move();   // Driving
            Console.ReadLine();
        }
    }

    interface IMovable
    {
        void Move()
        {
            Console.WriteLine("Walking");
        }
    }

    class Person : IMovable
    {
       
    }

     

    class Car : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Driving");
        }
    }

}
