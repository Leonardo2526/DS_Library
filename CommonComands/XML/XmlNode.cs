using System;
using System.Text;
using System.Xml;

namespace ParsingXml
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<user name=\"John Doe\" age=\"42\"></user>");
            //Console.WriteLine(xmlDoc.DocumentElement.Name);
            //xmlDoc.LoadXml("<users><user>InnerText/InnerXml is here</user></users>");
            Console.WriteLine("InnerXml: " + xmlDoc.DocumentElement.InnerXml);
            Console.WriteLine("OuterXml: " + xmlDoc.DocumentElement.OuterXml);
            Console.WriteLine("InnerText: " + xmlDoc.DocumentElement.InnerText);
            if (xmlDoc.DocumentElement.Attributes["name"] != null)
                Console.WriteLine(xmlDoc.DocumentElement.Attributes["name"].Value);
            if (xmlDoc.DocumentElement.Attributes["age"] != null)
                Console.WriteLine(xmlDoc.DocumentElement.Attributes["age"].Value);
            Console.ReadKey();
        }
    }
}