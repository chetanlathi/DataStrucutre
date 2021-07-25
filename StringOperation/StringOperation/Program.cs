using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringOperation
{
    class Program
    {

        public static int CalculateMaxLengthSubsting(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }
            int st = 0, en = 0, cl = 0, ml = -1;
            HashSet<char> hs = new HashSet<char>();

            while (en < s.Length)
            {
                char c = s.ElementAt(en);
                if (!hs.Contains(c))
                {
                    hs.Add(c);
                    en++;
                    cl = en - st;
                }
                else
                {
                    if (ml < cl)
                        ml = cl;
                    else
                        while (st <= en && en < s.Length)
                        {
                            if (s.ElementAt(st) != s.ElementAt(en))
                            {
                                hs.Remove(s.ElementAt(st));
                                st++;
                            }
                            else
                            {
                                st++;
                                en++;
                                break;
                            }
                        }
                }
            }
            if (ml < cl)
                ml = cl;
            else if (ml == -1)
                ml = s.Length;

            return ml;
        }

        public static string LongestPossibleSubstring(string s)
        {
            string reverse = string.Empty;

            if (string.IsNullOrEmpty(s))
                return s;
            int start = 0, end = 0, len1 = 0, len2 = 0, len = 0;

            for (int i = 0; i < s.Length; i++)
            {
                len1 = expandAroundCenter(s, i, i);
                len2 = expandAroundCenter(s, i, i + 1);
                len = Math.Max(len1, len2);

                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + (len / 2);
                }
            }
            return s.Substring(start, end - start + 1);
        }

        private static int expandAroundCenter(string s, int i, int j)
        {
            while (i >= 0 && j < s.Length && s.ElementAt(i) == s.ElementAt(j))
            {
                i--;
                j++;
            }

            return j - 1 - i;
        }

        public static string FirstReverse(string str)
        {

            string reverse = string.Empty;
            for (int i = str.Length - 1; i >= 0; i--)
            {

                reverse = reverse + str.ElementAt(i);
            }

            return reverse;

        }

        public static string BracketMatcher(string str)
        {

            Stack<char> st = new Stack<char>();

            foreach (char c in str)
            {

                if (c == '(' || c == '{' || c == '[' || c == '<')
                {
                    st.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']' || c == '>')
                {
                    if (st.Count > 0)
                    {
                        st.Pop();
                    }
                }

            }
            if (st.Count > 0)
                return "0";
            else
                return "1";

        }

        public static string QuestionsMarks(string str)
        {

            int count = 0;
            int valueBefore = 0;
            int valueAfter = 0;
            string result = string.Empty;
            for (int i = 0; i < str.Length - 1; i++)
            {
                valueBefore = (int)(str.ElementAt(i)) - 48;
                if (valueBefore > 0 && valueBefore <= 9)
                {
                    int j = i + 1;
                    while (j < str.Length - 1)
                    {
                        int val = (int)(str.ElementAt(j)) - 48;
                        if (str.ElementAt(j) == '?')
                        {
                            count++;

                        }
                        else if (count == 3)
                        {
                            break;
                        }
                        else if (val >= 0 && val <= 9)
                        {
                            result = "false";
                            break;
                        }
                        j++;
                    }
                    valueAfter = (int)(str.ElementAt(j)) - 48;
                    if (valueAfter > 0 && valueAfter <= 9 && count == 3)
                    {
                        if (valueBefore + valueAfter == 10)
                        {
                            result = "true";
                            valueBefore = 0;
                            valueAfter = 0;
                            count = 0;
                        }

                    }
                }
            }
            if (result != "true")
                result = "false";
            return result;
        }

        public static string CodelandUsernameValidation(string str)
        {

            int length = str.Length;

            char cend = str.ElementAt(str.Length - 1);
            int charEdnAssCI = (int)cend;

            bool cond1, cond2, cond3, cond4 = false;

            if (Char.IsLetter(str.ElementAt(0)))
                cond1 = true;
            else
                cond1 = false;

            if (length >= 4 && length <= 25)
                cond2 = true;
            else
                cond2 = false;

            if (charEdnAssCI != (int)'_')
                cond3 = true;
            else
                cond3 = false;

            for (int i = 1; i < str.Length - 2; i++)
            {
                char ch = str.ElementAt(i);
                if (Char.IsLetterOrDigit(ch) || ch == (int)'_')
                    cond4 = true;
                else
                {
                    cond4 = false;
                    break;
                }

            }
            if (cond1 && cond2 && cond3 && cond4)
                return "True";
            else
                return "False";

        }

        public static string MinWindowSubstring(string[] strArr)
        {
            int left = 0, right = 0;
            int currentStringLength = strArr[0].Length;
            int minWindowLength = 9999;
            string minWindow = "";


            for (left = 0; left < currentStringLength; left++)
            {
                for (right = left; right < currentStringLength; right++)
                {
                    string substring = strArr[0].Substring(left, right + 1 - left);
                    bool isFound = subStrinFound(substring, strArr[1]);

                    if (isFound && substring.Length < minWindowLength)
                    {

                        minWindowLength = substring.Length;
                        minWindow = substring;
                    }

                }

            }
            return minWindow;

        }

        public static bool subStrinFound(string subString, string required)
        {
            var requiredChar = new Dictionary<char, int>();

            for (int i = 0; i < required.Length; i++)
            {
                int occurences = 0;
                if (requiredChar.ContainsKey(required[i]))
                {
                    occurences = requiredChar[required[i]];
                }
                requiredChar[required[i]] = occurences + 1;
            }

            for (int i = 0; i < subString.Length; i++)
            {
                if (requiredChar.ContainsKey(subString[i]))
                {

                    int newOcuurances = requiredChar[subString[i]] - 1;

                    if (newOcuurances == 0)
                    {
                        requiredChar.Remove(subString[i]);
                    }
                    else
                    {
                        requiredChar[subString[i]] = newOcuurances;
                    }

                }

            }
            return requiredChar.Count == 0;
        }

        public static string FindIntersection(string[] strArr)
        {

            HashSet<char> hs = new HashSet<char>();
            string one = strArr[0];
            string two = strArr[1];
            string result = string.Empty;

            for (int i = 0; i < one.Length - 1; i++)
            {
                for (int j = 0; j <= two.Length - 1; j++)
                {
                    if (one[i] == two[j])
                    {
                        if (!hs.Contains(two[j]))
                            hs.Add(two[j]);
                    }

                }
            }
            foreach (var n in hs)
            {
                result = result + n;
            }
            // code goes here  
            return result;

        }

        public static List<List<string>> AnargamInArray(string[] strArr)
        {
            List<List<string>> res = new List<List<string>>();
            if (strArr.Length <= 0)
                return res;
            Dictionary<string, List<string>> hs = new Dictionary<string, List<string>>();

            foreach (string str in strArr)
            {
                int[] prese = new int[26];
                for (int i = 0; i <=str.Length - 1; i++)
                {
                    prese[str.ElementAt(i) - 'a']++;
                }

                StringBuilder sb = new StringBuilder();
                foreach(int c in prese)
                {
                    sb.Append(c);
                    sb.Append('#');
                }

                string Key = sb.ToString();
                if (hs.ContainsKey(Key))
                {
                    List<string> ana = new List<string>();
                    if (hs.TryGetValue(Key, out ana))
                    {
                        ana.Add(str);
                        hs.Remove(Key);
                        hs.Add(Key, ana);
                    }
                }
                else
                {
                    List<string> ana = new List<string>();
                    ana.Add(str);
                    hs.Add(Key, ana);
                }

            }

            foreach (var val in hs)
            {
                res.Add(val.Value);
            }
            return res;
        }

        public static List<int> find_anagrams(string s, string p)
        {
            if (p.Length > s.Length)
            {
                return new List<int>();
            }
            var output = new List<int>();
            int[] s_map = new int[26];
            int[] p_map = new int[26];
           
            for (int i=0; i < p.Length;i++)
            {
                s_map[s.ElementAt(i) - 'a'] = s_map[s.ElementAt(i) - 'a'] + 1;
                p_map[p.ElementAt(i) - 'a'] = p_map[p.ElementAt(i) - 'a'] + 1;
            }
            if (Enumerable.SequenceEqual(s_map, p_map))
            {
                output.Add(0);
            }
            for (int i=p.Length; i< s.Length; i++)
            {
                s_map[s.ElementAt(i - p.Length) - 'a'] = s_map[s.ElementAt(i - p.Length) - 'a'] - 1;
                s_map[s.ElementAt(i) - 'a'] = s_map[s.ElementAt(i) - 'a'] + 1;

                if (Enumerable.SequenceEqual(s_map, p_map))
                {
                    output.Add(i-p.Length+1);
                }
            }
            return output;
        }
    
        public static string Decode(string s)
        {
            string result = "";
            int ptr = 0;
            Stack<int> sin = new Stack<int>();
            Stack<string> str = new Stack<string>();

            while (ptr < s.Length)
            {
                char c = s.ElementAt(ptr);
                if (Char.IsDigit(c))
                {
                    int num = 0;
                    while (Char.IsDigit(s.ElementAt(ptr)))
                    {
                        num = num * 10 + s.ElementAt(ptr)-'0';
                        ptr++;
                    }
                    sin.Push(num);
                }
                else if (c == '[')
                {
                    str.Push(result);
                    result = "";
                    ptr++;
                }
                else if(c==']')
                {
                    StringBuilder sb = new StringBuilder(str.Pop());
                    int number = sin.Pop();
                    for(int i=1 ;i <= number; i++)
                    {
                        sb.Append(result);
                    }
                    result = sb.ToString();
                    ptr++;
                }
                else
                {
                    result = result + c;
                    ptr++;
                }

            }
            return result ;
        }

        // Function to reverse a string
        public static string reverseStr(string input)
        {
            char[] str = input.ToCharArray();
            int n = input.Length;
            char temp;
            // Swap character starting from two
            // corners
            for (int i = 0; i < n / 2; i++)
            {
                temp = str[i];
                str[i] = str[n - i - 1];
                str[n - i - 1] = temp;
            }
            return str.ToString(); 
        }

        static void Main(string[] args)
        {
            // Console.WriteLine(CalculateMaxLengthSubsting("pwwkew"));
            // Console.WriteLine(LongestPossibleSubstring("bnatabcdcbakll"));
            // Console.WriteLine(FirstReverse("Chetan"));
            // Console.WriteLine(FindIntersection(new string[] { "1, 3, 4, 7, 13", "1, 2, 4, 13, 15" }));

            //List<List<string>> res = Program.AnargamInArray(new string[] { "eat", "tea", "nat", "tes" });
            //foreach (var obj in res)
            //{
            //    Console.Write("[");
            //    foreach (var val in obj)
            //        if(obj.Count>1)
            //          Console.Write(val + ", ");
            //        else
            //          Console.Write(val);
            //    Console.Write("],");
            //}

            //List<int> res= find_anagrams("bcabac","abc");   
            //Console.WriteLine(Decode("3[a3[c]]z"));

            // Print the intails of String
            //Console.WriteLine("Enter the string :");
            //char[] str = Console.ReadLine().ToCharArray();
            //Console.Write(str[0]);
            //for (int i = 0; i < str.Length; i++)
            //{
            //    if (str[i] == ' ')
            //    {
            //        Console.Write(str[i + 1]);
            //    }
            //}
            
            Console.ReadLine();

        }
}
}
