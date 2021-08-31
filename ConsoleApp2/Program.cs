using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> attend = new List<int>();
            List<int> absent = new List<int>();

            attend.Add(1);
            attend.Add(1);
            attend.Add(2);
            attend.Add(3);
            attend.Add(3);
            attend.Add(4);
            attend.Add(1);
            attend.Add(2);
            attend.Add(5);
            attend.Add(5);
            attend.Add(1);
            //1=3  , 2=2  3=2   4=1    5=1
            int hdour;
            foreach (var i in attend)
            {
                hdour = 0;
                Console.WriteLine(i +" ");
                for (int j =i; j <attend.Count; j++)
             
                {
                    if (absent.Contains(attend[j]) == false)
                    {
                            //if (attend[i] == attend[j])
                            //{
                            absent.Add(attend[j]);
                           // hdour += 1;
                            //}
                            //else
                            //{
                            //  absent.Add(attend[j]);
                            //}
                    }
                    
                }
            }
            Console.WriteLine();
            Console.Write("absent ");

            foreach (var item in absent)
            {
                Console.Write(" "+item);


            }
            Console.WriteLine(" ****"+absent.Count);
            Console.ReadKey();
        }
    }
}
