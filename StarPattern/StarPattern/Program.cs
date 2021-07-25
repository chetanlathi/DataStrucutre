using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarPattern
{
    class Program
    {

        public static void AllStar(int i,int j)
        {
            Console.Write("\n");
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
        }

        public static void UpperStar(int i, int j)
        {
            Console.Write("\n");
            for (i = 1; i <= 4; i++)
            {
                for (j = 1; j <= i; j++)
                {
                    Console.Write(j);
                }
                Console.Write("\n");
            }
        }

        public static void LowerStar(int i, int j)
        {
            Console.Write("\n");
            for (i = 0; i < 4; i++)
            {
                for (j = 4; j > i; j--)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
        }

        public static void RightAlignStar(int i, int j)
        {
            Console.Write("\n");
            for (i = 0; i < 4; i++)
            {
                for (j = 4; j > i; j--)
                {
                    Console.Write(" ");

                }
                for (int k = 0; k <= i; k++)
                {
                    Console.Write("*");
                }
               
                Console.Write("\n");
            }
            
            for (i = 0; i < 4; i++)
            {
                for (int k = 0; k <= i; k++)
                {
                    Console.Write(" ");
                }
                for (j = 4; j > i; j--)
                {
                    Console.Write("*");

                }
                Console.Write("\n");
            }
        }
        static void Main(string[] args)
        {
            int i=4, j=4;
            AllStar(i, j);
            UpperStar(i, j);
            LowerStar(i, j);
            RightAlignStar(i, j);
            Console.ReadLine();
        }
    }
}
