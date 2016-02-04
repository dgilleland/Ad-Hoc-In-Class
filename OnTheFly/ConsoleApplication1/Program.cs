using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 4;

            Console.WriteLine(counter.Quack());
            int result = AddNumbers(2, 7, 12, 44);
            Console.WriteLine("The sum of the numbers is " + result);

            int[] numbers = new int[] {1,2,3};
            Console.WriteLine("The sum of the second set of numbers is " + AddNumbers(numbers));
            double total = 10 * 10.5 + 3;

            result = AddNumbers(result, AddNumbers(numbers));

            Console.WriteLine(DRY("Hello", 3));
            string message = DRY(count: 3, message: "Goodbye");
        }

        static string DRY(string message, int count)
        {
            if(count >= 1)
            {
                message += " " + message;
                count--;
            }
            return message;
        }

        static int AddNumbers(params int[] values)
        {
            int sum = 0;
            foreach(int item in values)
                sum += item;
            return sum;
        }
    }
}
