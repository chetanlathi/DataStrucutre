using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking
{
    class Program
    {
        public static int BracketCombinations(int num)
        {

            List<string> result = new List<string>();
            Helper(result, "", 0, 0, num);
            return result.Count;

        }

        public static void Helper(List<string> result, string matches,
                                  int open, int close, int n)
        {
            if (matches.Length == n * 2)
            {
                result.Add(matches);
                return;
            }

            if (open < n)
            {
                Helper(result, matches + "(", open+1, close, n);
            }
            if (close < open)
            {
                Helper(result, matches + ")", open, close+1, n);
            }

        }
        
        public static List<List<int>> NumberCombinations(int[] num)
        {
            List<List<int>> res = new List<List<int>>();
            if (num.Length == 0)
                return res;
            num = num.OrderBy(i => i).ToArray<int>();

            BackTraking(res,new List<int>(),0,num);
            return res;

        }

        public static void BackTraking(List<List<int>> res,List<int> curr, int start, int[] num)
        {
            res.Add(new List<int>(curr));
            for(int i = start; i < num.Length; i++)
            {
                if(i>start && num[i - 1] == num[i])
                {
                    continue;
                }

                curr.Add(num[i]);
                BackTraking(res,curr, i+1, num);
                curr.RemoveAt(curr.Count - 1);
            }

        }


        static void Main(string[] args)
        {
            //Console.WriteLine(BracketCombinations(2));
            Console.WriteLine(NumberCombinations(new int[] { 2,1,2}));
            Console.ReadLine();

        }
    }
}
