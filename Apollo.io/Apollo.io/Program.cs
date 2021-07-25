using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.io
{
    class Program
    {
        public static int[] TwoSum(int[] arr, int target)
        {
            int[] result = new int[2];
            Dictionary<int, int> dec = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int comp = target - arr[i];
                if (dec.ContainsKey(comp))
                {
                    result[0] = dec[comp];
                    result[1] = i;
                }
                else
                {
                    dec.Add(arr[i], i);

                }
            }
            return result;
        }

        public static int[] TwoSumSorted(int[] arr, int target)
        {
            int left = 0, right = arr.Length - 1;
            int[] result = new int[2];

            while (left < right)
            {
                int l = arr[left];
                int r = arr[right];

                if (l + r == target)
                {
                    result[0] = left + 1;
                    result[1] = right + 1;
                    break;
                }
                else if (l + r < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return result;
        }

        public static void CalcualteFourSum(int[] a, int x)
        {
            HashSet<string> set = new HashSet<string>();

            int n = a.Length;

            for (int i = 0; i < n - 3; i++)
            {
                for (int j = i + 1; j < n - 2; j++)
                {
                    for (int k = j + 1; k < n - 1; k++)
                    {
                        for (int l = k + 1; l < n; l++)
                        {
                            int sum = a[i] + a[j] + a[k] + a[l];
                            if (sum > x)
                                break;

                            if (sum == x)
                            {
                                string quard = a[i] + ", " + a[j] + ", " + a[k] + ", " + a[l];
                                Console.Write(quard + "\n");
                                set.Add(quard);
                            }

                        }
                    }
                }
            }
            foreach (string s in set)
            {
                Console.WriteLine(s);
            }
        }

        public static void CalcualteOptimizedFourSum(int[] a, int x)
        {
            HashSet<string> set = new HashSet<string>();

            int n = a.Length, left, right;
            Array.Sort(a);
            for (int i = 0; i < n - 3; i++)
            {
                for (int j = i + 1; j < n - 2; j++)
                {
                    left = j + 1;
                    right = n - 1;

                    while (left < right)
                    {
                        int sum = a[i] + a[j] + a[left] + a[right];
                        if (sum == x)
                        {
                            string quard = a[i] + ", " + a[j] + ", " + a[left] + ", " + a[right];
                            set.Add(quard);
                            right--;
                            left++;
                        }
                        else if (sum > x)
                            right--;
                        else
                            left++;

                    }
                }
            }
            foreach (string s in set)
            {
                Console.WriteLine(s);
            }
        }

        public static int pathSum(int[,] grid)
        {
            int row = grid.GetLength(0);
            int col = grid.GetLength(1);
            int[,] dp = new int[row,col];

            for (int i = row - 1; i >= 0; i--)
            {
                for (int j = col - 1; j >= 0; j--)
                {
                    if (i == row - 1 && j != col - 1)
                    {
                        dp[i,j] = grid[i,j] + dp[i,j + 1];
                    }
                    else if (i != row - 1 && j == col - 1)
                    {
                        dp[i,j] = grid[i,j] + dp[i + 1,j];
                    }
                    else if (i != row - 1 && j != col - 1)
                    {
                        dp[i,j] = grid[i,j] + Math.Min(dp[i,j + 1], dp[i + 1,j]);
                    }
                    else
                    {
                        dp[i,j] = grid[i,j];
                    }
                }
            }
            return dp[0,0];
        }

        public static int ConvertToIntfroHex(string hexnumber)
        {
            int base1 = 1;
            int number = 0;

            for (int i = hexnumber.Length - 1; i >= 0; i--)
            {
                if (hexnumber[i] >= '0' && hexnumber[i] <= '9')
                    number = number + (hexnumber[i] - 48) * base1;

                if (hexnumber[i] >= 'A' && hexnumber[i] <= 'F')
                    number = number + (hexnumber[i] - 55) * base1;

                base1 = base1 * 16;
            }
            return number;
        }
        public static int getMinSquares(int n)
        {
            if (n <= 3)
                return n;

            // Create a dynamic programming
            // table to store sq
            int[] dp = new int[n + 1];

            // getMinSquares table for base
            // case entries
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 2;
            dp[3] = 3;

            // getMinSquares for rest of the
            // table using recursive formula
            for (int i = 4; i <= n; i++)
            {
                // max value is i as i can
                // always be represented
                // as 1 * 1 + 1 * 1 + ...
                dp[i] = i;

                // Go through all smaller numbers to
                // to recursively find minimum
                for (int x = 1; x <= Math.Ceiling(
                                  Math.Sqrt(i)); x++)
                {
                    int temp = x * x;
                    if (temp > i)
                        break;
                    else
                        dp[i] = Math.Min(dp[i], 1 +
                                        dp[i - temp]);
                }
            }

            // Store result and free dp[]
            int res = dp[n];

            return res;
        }
        public static int Solve(int n)
        {
            // base cases
            if (n <= 3)
                return n;

            // getMinSquares rest of the
            // table using recursive
            // formula

            // Maximum squares required is
            // n (1*1 + 1*1 + ..)
            int res = n;

            // Go through all smaller numbers
            // to recursively find minimum
            for (int x = 1; x <= n; x++)
            {
                int temp = x * x;
                if (temp > n)
                    break;
                else
                    res = Math.Min(res, 1 +
                          Solve(n - temp));
            }
            return res;
        }
        public static void PerfectSquare(string[] args)
        {

            Console.WriteLine("Enter the number :");
            int number = Convert.ToInt32(Console.ReadLine());
            bool perfectSquare = false;
            int perfectSquareOf = 0;
            if (number == 1)
            {
                perfectSquare = true;
                perfectSquareOf = 1;
            }
            else
            {
                for (int i = 1; i < number; i++)
                {
                    if (i * i == number)
                    {
                        perfectSquare = true;
                        perfectSquareOf = i;
                        break;
                    }
                    else
                    {
                        continue;
                    }

                }
            }

            if (perfectSquare)
            {
                Console.WriteLine("Number is Perfect Square of number : " + perfectSquareOf);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Not Perfect Square");
                Console.ReadLine();
            }
        }

        public static int BinarySearch(int[] a, int key)
        {
            int l = 0, h = a.Length - 1, mid;

            while (l <= h)
            {
                mid = (l + h) / 2;
                if (a[mid] == key)
                {
                    return mid;
                }
                if (a[mid] > key)
                {
                    h = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }


            }

            return -1;

        }

        public static int RecBinarySearch(int[] a, int key, int l, int h)
        {
            int mid = (l + h) / 2;
            if (l > h)
            {
                return -1;
            }
            else
            {
                if (a[mid] == key)
                    return mid;
                if (a[mid] > key)
                    return RecBinarySearch(a, key, l, mid - 1);
                else
                    return RecBinarySearch(a, key, mid + 1, h);
            }

        }

        public static int Power(int numb, int pow)
        {
            if (pow == 0)
            {
                return 1;
            }
            else
            {
                return numb * Power(numb, pow - 1);
            }

        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Reult is");
            //int[] res = Program.TwoSumSorted(new int[] { 2, 7, 9, 11, 15, 19, 20 }, 18);
            //foreach (int i in res)
            //    Console.Write(i + " ,");

            //int[,] array2Da = new int[3, 3] { { 1, 3, 1 }, { 1,5,1 }, { 4,2,1 } };
            //Console.WriteLine(pathSum(array2Da));

            //Console.WriteLine("Enter the hexadecimal number");
            //string hexnumber = Console.ReadLine();
            //int number = ConvertToIntfroHex(hexnumber);
            //Console.WriteLine(number);
            //Console.WriteLine(getMinSquares(number));

            //int[] a = { 1, 1, 1, 2, 3, 4 };
            //int x = 10;
            //CalcualteOptimizedFourSum(a, x);

            //int[] a = { 3, 5, 7, 8, 9, 24, 51, 57, 63 };
            //int result = BinarySearch(a, 3);
            //int res = RecBinarySearch(a, 31, 0, a.Length);
            //Console.WriteLine(result);
            //Console.WriteLine(res);
            //Console.WriteLine(Power(5, 1));


            Console.ReadLine();

        }
    }
}
