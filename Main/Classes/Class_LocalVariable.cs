using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_v2.Examples_Classes
{
    class Class_LocalVariable
    {
		static void Main(string[] args)
		{
			bool doesNameStartWithUppercaseChar(string name)
			{
				if (String.IsNullOrEmpty(name))
					throw new Exception("name parameter must contain a value!");
				return Char.IsUpper(name[0]);
			}

			List<string> names = new List<string>()
	{
		"john doe",
		"Jane doe",
		"dog Doe"
	};

			foreach (string name in names)
				Console.WriteLine(name + " starts with uppercase char: " + doesNameStartWithUppercaseChar(name));
			Console.ReadLine();

		}
	}
}
