using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpe.Matrix;

namespace Markov
{
    class Program
    {
        static void Main(string[] args)
        {

            Double[] arr = { 1.0 };
            State s = new State("Sunny", new Vector(arr));

            Double[] arr2 = {0.6, 0.4};
            State s1 = new State("Rainy", new Vector(arr2));

            Double[] arr3 = {0.7, 0.2, 0.1};
            State s2 = new State("Cloudy", new Vector(arr3));
            
            Chain c = new Chain();
            c.Insert(s, new Vector(arr));
            c.Insert(s1, new Vector(arr2));
            c.Insert(s2, new Vector(arr3));

            int input = -1;
            while (input != 0)
            {
                String sa = c.Next().ToString();
                Console.WriteLine("============");
                Console.WriteLine(sa);
                input = Console.Read();
            }
        }
    }
}
