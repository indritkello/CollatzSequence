using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// This is my solution to the CollatzChainLength problem using dynamic programming. 
/// auth: Indrit Kello 2019
/// </summary>
namespace Problem14
{
  class Program
  {
    public static Dictionary<long, int> terms = new Dictionary<long, int>();
    public static int GetCollatzChainLength(long number, int counter)
    {
      if (number == 1)//Although it has not been proved yet
      {
        return counter;
      }
      else if (terms.ContainsKey(number))
      {
        return counter + terms[number];
      }
      else
      {

        if (number % 2 == 0) return GetCollatzChainLength(number / 2, ++counter);
        else
        {
          number = number * 3 + 1; //this will be even, so we can devide by 2 directly
          counter++;
          number = number / 2;
          counter++;//since 2 terms are added to the sequence
          return GetCollatzChainLength(number, counter);
        }

      }
    }
    static void Main(string[] args)
    {
      long max = 0;
      long positionOfLargest = 0;
      int term;
      Stopwatch sw = new Stopwatch();
      sw.Start();
      for (long i = 1; i < 1000000; i++)
      {
        term = GetCollatzChainLength(i, 0);
        terms.Add(i, term);
        if (term > max)
        {
          max = term;
          positionOfLargest = i;
        }

      }
      sw.Stop();
      Console.WriteLine("Time taken to evaluate {0} s!", sw.ElapsedMilliseconds/1000.0);//less than a second
      Console.WriteLine(positionOfLargest);
      Console.ReadKey();
    }
  }
}
