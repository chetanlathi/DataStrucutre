using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class stack
    {
        public char[] stackcustom = new char[50];
        public int top=0;

        public void Push(char x)
        {
            stackcustom[top] = x;
            top++;
        }
        public char Pop()
        {
            char x = stackcustom[top];
            top--;
            return x;
        }

        public int Priority(char exp)
        {
            switch (exp)
            {
                case '*':
                case '/':
                case '%':
                    return 2;

                case '+':
                case '-':
                    return 1;

                default:                        
                    return 0;
            }          

        }

    }
    //public class stackImProved
    //{

    //    public char[] stackcustom = new char[50];
    //    public int top = -1;

    //    public void Push(char x)
    //    {
    //        if (top == 49)
    //        {
    //            Console.WriteLine("Stack full");
    //        }
    //        stackcustom[++top] = x;

    //    }
    //    public char Pop()
    //    {
    //        if (top == -1)
    //        {
    //            Console.WriteLine("Underflow error");
    //            return '\0';
    //        }
    //        else
    //        {
    //            char x = stackcustom[top];
    //            top--;
    //            return x;
    //        }
    //    }
    //    public bool isEmpty()
    //    {
    //        return (top == -1) ? true : false;
    //    }
    //}
   
    class Program
    {
        public static bool isMatchingPair(char character1, char character2)
        {
            if (character1 == '(' && character2 == ')')
                return true;
            else if (character1 == '{' && character2 == '}')
                return true;
            else if (character1 == '[' && character2 == ']')
                return true;
            else if (character1 == '<' && character2 == '>')
                return true;
            else
                return false;
        }
        public static string BracketMatcher(string str)
        {

            stack st = new stack();

            foreach (char c in str)
            {

                if (c == '(' || c == '{' || c == '[' || c == '<')
                {
                    st.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']' || c == '>')
                {
                    if (st.top > 0)
                    {
                        st.Pop();
                    }
                    else
                    {
                        return "0";
                    }
                }

            }
            if (st.top >= 0)
                return "0";
            else
                return "1";

        }
        static void Main(string[] args)
        {

            stack s = new stack();
            //s.top = 0;
            //string postfix = string.Empty;
            //char ch1;
            //Console.WriteLine("Enter the InFix Expresion");
            //char[] input = Console.ReadLine().ToCharArray();

            //foreach(char c in input)
            //{
            //    if(c=='(')
            //    {
            //        s.Push(c);
            //    }
            //    else if(c ==')')
            //    {
            //        ch1 = s.Pop();
            //        while(ch1 != '(')
            //        {
            //            postfix = postfix + ch1;
            //            ch1 = s.Pop();
            //        }
            //    }
            //    else if (c == '*' || c == '/' || c == '+' || c == '-' || c == '%')
            //    {
            //        while(s.top != 0 && s.Priority(c) >s.Priority(s.stackcustom[s.top]) )
            //        {
            //            ch1 = s.Pop();
            //            if (ch1 != '(')                            
            //            postfix = postfix + ch1;                       
            //        }
            //        s.Push(c);
            //    }
            //    else
            //    {
            //        postfix = postfix + c;
            //    }
            //}

            //while (s.top != -1)
            //{
            //    char ch = s.Pop();
            //    if (ch != '\0')
            //    postfix = postfix + ch;
            //}

            //static void Main(string[] args)
            //{

            //    Console.WriteLine("Enter the expression");
            //    char[] exp = Console.ReadLine().ToCharArray();
            //    stack s = new stack();
            //    char sc;
            //    bool isBlance = false;
            //    foreach (char c in exp)
            //    {
            //        if (c == '(' || c == '<' || c == '{' || c == '[')
            //            s.Push(c);
            //        if (c == ')' || c == '>' || c == '}' || c == ']')
            //        {
            //            if (s.isEmpty())
            //            {
            //                isBlance = false;
            //                break;
            //            }
            //            else if (isMatchingPair(s.Pop(), c))
            //            {
            //                isBlance = true;
            //                continue;
            //            }
            //            else
            //            {
            //                isBlance = false;
            //                break;
            //            }
            //        }
            //    }
            //    if (!s.isEmpty())
            //    {
            //        isBlance = false;
            //    }

            //    if (isBlance) Console.WriteLine("Exp is Balance");
            //    else Console.WriteLine("Exp is not Balance");

            //    Console.ReadLine();

            //}

            Console.WriteLine(BracketMatcher("(c(oder)) b(yte)"));
            Console.ReadLine();
        }
    }
}
