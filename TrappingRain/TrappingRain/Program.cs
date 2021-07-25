using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrappingRain
{
    class Program
    {
        public static int maxWater(int[] arr, int n)
        {
            // To store the maximum water
            // that can be stored
            int res = 0;

            // For every element of the array
            // except first and last element
            for (int i = 1; i < n - 1; i++)
            {

                // Find maximum element on its left
                int left = arr[i];
                for (int j = 0; j < i; j++)
                {
                    left = Math.Max(left, arr[j]);
                }

                // Find maximum element on its right
                int right = arr[i];
                for (int j = i + 1; j < n; j++)
                {
                    right = Math.Max(right, arr[j]);
                }

                // Update maximum water value
                res += Math.Min(left, right) - arr[i];
            }
            return res;
        }

        public static int maxWater(int[] height)
        {

            // Stores the indices of the bars
            Stack stack = new Stack();

            // size of the array
            int n = height.Length;

            // Stores the final result
            int ans = 0;

            // Loop through the each bar
            for (int i = 0; i < n; i++)
            {

                // Remove bars from the stack
                // until the condition holds
                while ((stack.Count != 0)
                       && (height[(int)stack.Peek()] < height[i]))
                {

                    // store the height of the top
                    // and pop it.
                    int pop_height = height[(int)stack.Peek()];
                    stack.Pop();

                    // If the stack does not have any
                    // bars or the the popped bar
                    // has no left boundary
                    if (stack.Count == 0)
                        break;

                    // Get the distance between the
                    // left and right boundary of
                    // popped bar
                    int distance = i - (int)stack.Peek() - 1;

                    // Calculate the min. height
                    int min_height
                      = Math.Min(height[(int)stack.Peek()],
                                 height[i]) - pop_height;

                    ans += distance * min_height;
                }

                // If the stack is either empty or
                // height of the current bar is less than
                // or equal to the top bar of stack
                stack.Push(i);
            }
            return ans;
        }
        static void Main(string[] args)
        {
            int[] arr = { 0, 1, 0, 2, 1, 0,
                1, 3, 2, 1, 2, 1 };
            int n = arr.Length;

            Console.Write(maxWater(arr, n));
            Console.ReadLine();
        }
    }
}
