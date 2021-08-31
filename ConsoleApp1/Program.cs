using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "2020-03-25";
            string str1 = "2020-03-30";
            var x = DateTime.Parse(str);
            var x1 = DateTime.Parse(str1);

            ////String hourMinute = DateTime.Now.ToString("yyyy-MM-dd");
            //  if (x > x1)
            //   {
            //       Console.WriteLine("yes");

            //   }
            var t = x1 - x;
            
          //  int c = int.Parse( t.ToString());
            Console.WriteLine(t.ToString("dd"));
            Console.Read();
        }
    }
}
