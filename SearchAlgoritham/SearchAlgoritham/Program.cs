using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgoritham
{
    class Program
    {
        public static void BubbleSort(int[] a)
        {
            int temp = 0;
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = 0; j < a.Length - i - 1; j++)
                {
                    if (a[j] < a[j + 1])
                    {
                        temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                    Console.Write(a[j] + " ");
                }
                Console.Write("\n");
            }
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }

        }

        public static void MergeSort(int[] a, int lb, int ub)
        {
            int mid = 0;

            if (lb < ub)
            {
                mid = (lb + ub) / 2;
                MergeSort(a, lb, mid);
                MergeSort(a, mid + 1, ub);
                Merege(a, lb, mid, mid + 1, ub);

            }

        }

        private static void Merege(int[] a, int lb1, int ub1, int lb2, int ub2)
        {
            int i = lb1, j = lb2, k = 0;
            int[] b = new int[a.Length];
            while (i <= ub1 && j <= ub2)
            {
                if (a[i] > a[j])
                {
                    b[k++] = a[i];
                    i++;
                }
                else if (a[j] > a[i])
                {
                    b[k++] = a[j];
                    j++;
                }
                else
                {
                    b[k++] = a[i++];
                    b[k++] = a[j++];
                }

            }
            while (i <= ub1)
            {
                b[k++] = a[i++];
            }
            while (j <= ub2)
            {
                b[k++] = a[j++];
            }

            k = 0;
            for (i = lb1; i <= ub1; i++)
                a[i] = b[k++];
            for (j = lb2; j <= ub2; j++)
                a[j] = b[k++];

        }

        public static void QuickSort(int[] a, int first, int last)
        {
            int j = 0;
            if (first <= last)
            {
                j = Partition(a, first, last);
                QuickSort(a, first, j-1);
                QuickSort(a, j + 1, last);
            }

        }

        private static int Partition(int[] a, int first, int last)
        {
            int lower, upper, pivot, t;
            bool done = false;
            pivot = a[first];
            lower = first + 1;
            upper = last;

            while (!done)
            {

                while (lower<=upper && a[lower]<=pivot)
                    lower++;
                while (a[upper]>pivot && upper>=lower)
                    upper--;
                if (upper <lower)
                {
                    done = true;
                }
                else
                {
                    t = a[lower];
                    a[lower] = a[upper];
                    a[upper] = t;
                } 
            }

            t = a[first];
            a[first] = a[upper];
            a[upper] = t;

            return upper;
        }

        static void Main(string[] args)
        {
            int[] a = { 1, 0, 702, 502, 200, 80, 22, 16 };
            int[] sorted = new int[a.Length];
            // BubbleSort(a);
            Console.WriteLine();
            // MergeSort(a, 0, a.Length - 1);
            QuickSort(a, 0, a.Length - 1);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.ReadLine();
        }
    }
}
