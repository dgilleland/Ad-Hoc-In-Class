using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class IntExtensions
    {
        public static string Quack(this int self)
        {
            string result = "(Quack)";
            if(self <= 1)
            {
                return result;
            }
            else
            {
                while (self > 1)
                {
                    result += " (quack)";
                    self--;
                }
            }
            return result;
        }
    }
}
