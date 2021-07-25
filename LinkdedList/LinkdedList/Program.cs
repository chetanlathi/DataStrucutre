using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkdedList
{
    class Program
    {
        public class Node
        {
            public int data;
            public Node next;

            public Node(int n)
            {
                data = n;
                next = null;
            }
            public void Pirnt()
            {
                Console.Write("|" + data + "|-->");
                if (next != null)
                {
                    next.Pirnt();
                }
            }
            public void AddToEnd(int newData)
            {
                if (next == null)
                {
                    next = new Node(newData);
                }
                else
                {
                    next.AddToEnd(newData);
                }
            }
            public void AddToStrat(int newData)
            {
                if (next == null)
                {
                    next = new Node(newData);
                }
                else
                {
                    Node Temp = new Node(newData);
                    Temp.next = this.next;
                }
            }
            public void AddInBetween(int newData, int postion)
            {
                if (next == null)
                {
                    next = new Node(newData);
                }
                else
                {
                    for (int i = 0; i < postion - 1; i++)
                        next = next.next;

                    Node Temp = new Node(newData);
                    Temp.next = next.next;
                    next.next = Temp;
                }
            }
            public void Delete(Node head,int val)
            {
                while(head!=null && head.data == val)
                {
                    head = head.next;
                }

                Node currnt = head;
                while (currnt != null && currnt.next != null)
                {
                    if (currnt.next.data == val)
                    {
                        currnt.next = currnt.next.next;
                    }
                    else
                    {
                        currnt = currnt.next;
                    }
                }
                head.Pirnt();
            }
        }

        public static Node AddTwoNumbers(Node l1, Node l2)
        {
            int v1 = 0, v2 = 0, carry = 0, sum = 0;
            Node headNode = new Node(-1);
            Node ptr = headNode;

            while (l1 != null || l2 != null)
            {
                if (l1 != null)
                {
                    v1 = l1.data;
                    l1 = l1.next;
                }
                else v1 = 0;

                if (l2 != null)
                {
                    v2 = l2.data;
                    l2 = l2.next;
                }
                else v2 = 0;

                sum = v1 + v2 + carry;
                carry = sum / 10;
                sum = sum % 10;
                Node temp = new Node(sum);
                ptr.next = temp;
                ptr = ptr.next;
            }
            if (carry != 0)
            {
                Node temp = new Node(carry);
                ptr.next = temp;
            }
            return headNode.next;
        }

        public static Node OddEvenNode(Node head)
        {
            Node oddHead = head;
            Node evenHead = head.next;
            Node eve = evenHead;

            while (evenHead != null && evenHead.next != null)
            {
                oddHead.next = evenHead.next;
                oddHead = oddHead.next;
                evenHead.next = oddHead.next;
                evenHead = evenHead.next;
            }
            oddHead.next = eve;
            return head;
        }

        public static bool PalindromeLinkedList(Node head)
        {
            Node sp = head, fp = head, mid = null;

            while (fp != null && fp.next != null)
            {
                sp=sp.next;
                fp = fp.next.next;
            }

            if (fp != null)
            {
                mid = sp.next;
            }
            else
            {
                mid = sp;
            }

            Node pre=null, next = null;
            while (mid != null)
            {
                next = mid.next;
                mid.next = pre;
                pre = mid;
                mid = next;
            }
            while (pre != null)
            {
                if (pre.data != head.data)
                    return false;
                pre = pre.next;
                head = head.next;
            }
            return true;
        }

        public static Node Reverse(Node head)
        {
            Node prev = null, next = null;
            while (head != null)
            {
                next = head.next;
                head.next = prev;
                prev = head;
                head = next;
            }
            return prev;
        }        

        static void Main(string[] args)
        {

            // Node List1 = new Node(2);
            // List1.AddToEnd(4);
            // List1.AddToEnd(3);
            //// List.AddToEnd(20);
            // //List.AddInBetween(18, 2);
            // List1.Pirnt();
            // Console.WriteLine();
            // Node List2 = new Node(5);
            // List2.AddToEnd(6);
            // List2.AddToEnd(4);
            // List2.Pirnt();
            // Console.WriteLine();
            // Node result = AddTwoNumbers(List1, List2);
            // result.Pirnt();

            //Node node = new Node(1);
            //node.AddToEnd(4);
            //node.AddToEnd(2);
            //node.AddToEnd(5);
            //node.AddToEnd(3);
            //node.Pirnt();
            //Console.WriteLine();
            //Node result = OddEvenNode(node);
            //result.Pirnt();

            //Node node = new Node(1);
            //node.AddToEnd(2);
            //node.AddToEnd(3);
            //node.AddToEnd(2);
            //node.AddToEnd(1);
            //node.Pirnt();
            //Console.WriteLine();
            //Console.WriteLine(PalindromeLinkedList(node));

            Node node = new Node(1);
            node.AddToEnd(1);
            node.AddToEnd(4);
            node.AddToEnd(4);
            node.AddToEnd(5);
            node.Pirnt();
            Console.WriteLine();
            node.Delete(node, 4);
       
            //Node result = Reverse(node);
            //result.Pirnt();
            Console.ReadLine();

        }
    }
}
