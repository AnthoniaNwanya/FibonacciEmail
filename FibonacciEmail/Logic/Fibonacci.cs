using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Collections;
using System.Collections.Generic;


namespace FibonacciEmail.Logic
{
    public class Fibonacci
    {
        List<int> oddlist = new List<int>();
        List<int> evenlist = new List<int>();

        public Tuple<List<int>, List<int>> CalculateSeries(int number1, int number2)
        {
            int a = 0;
            int b = 1;
            int c = 1;

            while (true)
            {
                c = a + b;

                if (c > number2)
                {
                    break;
                }
                //OddNumbers Except Multiples of 3
                if (c > number1 && c % 2 != 0 && c % 3 != 0)
                {
                    oddlist.Add(c);
                }
                // Even numbers
                if (c > number1 && c % 2 == 0)
                {
                    evenlist.Add(c);

                }
                a = b;
                b = c;
            }
            return Tuple.Create(oddlist, evenlist);
        }

    }
}
