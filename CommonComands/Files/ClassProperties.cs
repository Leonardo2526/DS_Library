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

        public string Name { get; set; } = "John Doe";


 
    }
    class Program
    {
        /*private string _name = "John Doe";
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        */


    static void Main(string[] args)
    {
        Name_Properties name_Prop = new Name_Properties();
        Console.WriteLine(name_Prop.Name);
        Console.ReadLine();
    }
}
}
