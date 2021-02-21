using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProperties
{
    class Name_Properties
    {
        /*private string _name = "John Doe";
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        */

        //public string Name { get; set; } = "John Doe";


 
    }
    class Program
    {
        private string _name = "John Doe";

        public string Name
        {
            get
            {
                return _name.ToUpper();
            }
            set
            {
                if (!value.Contains(" "))
                    throw new Exception("Please specify both first and last name!");
                _name = value;
            }
        }



        static void Main(string[] args)
    {
            Program name_Prop = new Program();
            Console.WriteLine(name_Prop.Name);

            Console.Write("Enter your name: ");
            name_Prop.Name = Console.ReadLine();
            Console.WriteLine(name_Prop.Name);
            Console.ReadLine();
        }
}
}
