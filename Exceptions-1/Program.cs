using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions_1
{
    

    class Program
    {
        static void Method()
        {
            int[] intArray = { 10, 4, 7, 0, 12 };
            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine(2 / intArray[i]);
            }
        }

        static void Method2()
        {
            Method();
        }

        static void Method3()
        {
            Method2();
        }

        static void Main(string[] args)
        {
            try
            {
                Method3();
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            Console.ReadLine();
        }
    }
}
