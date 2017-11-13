using System;
using System.Collections.Generic;

namespace Shano_Fano
{
    class Program
    {
        static void Main(string[] args)
        {
            var elements = new List<Element>()
            {
                new Element("A", 0.36),
                new Element("B", 0.18),
                new Element("C", 0.18),
                new Element("D", 0.12),
                new Element("E", 0.09),
                new Element("F", 0.07)
            };
            Coder coder = new Coder(elements);
            var result =coder.GetCodes();
            foreach(var key in result.Keys)
            {
                Console.WriteLine("Name {0}: Code: {1}", key.Name, result[key]);
            }
            Console.ReadKey();
        }
    }
}
