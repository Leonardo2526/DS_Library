using System;

namespace Program
    {
    interface IMovable
    {
        void Move();
        //{
          //  Console.WriteLine("Walking");
       // }
    }

    // применение интерфейса в классе
    class Person : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Человек идет");
        }
    }
    // применение интерфейса в структуре
    struct Car : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Машина едет");
        }
    }
    class Program
    {
    
        static void Main1(string[] args)
        {
            Person person = new Person();
            person.Move();
            Car car = new Car();
            car.Move();
            Console.Read();
        }
    }
}