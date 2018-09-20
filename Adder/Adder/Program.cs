using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Adder
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> Answers = new List<int>();

            var one = SimpleAddition(0, 1000, Answers);
            var two = SimpleAddition(1000, 2000, Answers);
            var three = SimpleAddition(2000, 3000, Answers);


            Task.WaitAll(one, two, three);

            Console.WriteLine($"Total Sum: {Answers.Sum()}");

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }


        static Task SimpleAddition(int start, int end, List<int> Answers)
        {
            return Task.Factory.StartNew(()=> 
            {
                int sum = 0;
                for (int i = start; i < end; i++)
                {
                    sum += i;
                }

                Console.WriteLine($"Range: {start}-{end} Sum:{sum}");
                Answers.Add(sum);
            });
        }
    }
    
}
