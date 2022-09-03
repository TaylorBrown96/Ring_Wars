using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenebLibrary
{
    public static class RandomBoolean
    {
        public static string RandomBool()
        {
            int n = 5;
            var random = new Random();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(random.NextDouble() >= 0.5);
            }
            return "";
        }
    }
}
