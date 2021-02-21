using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace ReflectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Type testType = typeof(TestClass);
            ConstructorInfo ctor = testType.GetConstructor(System.Type.EmptyTypes);
            if (ctor != null)
            {
                object instance = ctor.Invoke(null);
                MethodInfo methodInfo = testType.GetMethod("TestMethod");
                Console.WriteLine(methodInfo.Invoke(instance, new object[] { 10 }));
            }
            Console.ReadKey();
        }
    }

    public class TestClass
    {
        private int testValue = 42;

        public int TestMethod(int numberToAdd)
        {
            return this.testValue + numberToAdd;
        }
    }
}