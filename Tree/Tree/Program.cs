using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode Left;
            public TreeNode right;
            public TreeNode(int x) {
                val = x;
                Left = right = null;
            }
        }

        public static string TreeConstructor(string[] strArr)
        {

            var childCounts = new Dictionary<string, int>();
            List<string> values = new List<string>();
            foreach (string pair in strArr)
            {
                string[] tree = pair.Split(',');
                string value = tree[0];
                string parent = tree[1];

                if (!values.Contains(value))
                {
                    values.Add(value);
                }
                else
                {
                    return "false";
                }

                if (!childCounts.ContainsKey(parent))
                {
                    childCounts[parent] = 0;
                }
                childCounts[parent] = childCounts[parent] + 1;
                if (childCounts[parent] > 2)
                {
                    return "false";
                }

            }
            // code goes here  
            return "true";

        }

        public static Dictionary<int, int> dec = new Dictionary<int, int>();
        public static int preIndex = 0;
        public static TreeNode TreeConstructor(int[] inorder, int[] preorder)
        {

            for (int i = 0; i < inorder.Length; i++)
            {
                dec.Add(inorder[i], i);
            }
            TreeNode res = Build(inorder, preorder, 0, inorder.Length - 1);
            return res;
        }
        public static TreeNode Build(int[] inorder, int[] preorder, int start, int end)
        {
            if (start > end)
                return null;

            TreeNode root = new TreeNode(preorder[preIndex++]);

            if (root == null)
                return null;

            if (start == end)
                return root;

            int index;

            if (dec.TryGetValue(root.val, out index))
            {
                root.Left = Build(inorder, preorder, start, index - 1);
                root.right = Build(inorder, preorder, index + 1, end);
            }
            else
            {
                return null;
            }

            return root;
        }

        public static bool isSymatric(TreeNode root)
        {
            return isMirror(root,root);
        }

        public static bool isMirror(TreeNode root1,TreeNode root2)
        {
            if (root1 == null && root2 == null) return true;
            if (root1 == null || root2 == null) return false;

            return root1.val == root2.val && isMirror(root1.Left, root2.right) && isMirror(root1.right, root2.Left);
             
        }

        public static int annser = 0;
        public static int pathOfTree(TreeNode node)
        {
            getLength(node);
            return annser == 0 ? 0 : annser-1;
        }
        public static int getLength(TreeNode node)
        {
            if (node == null)
                return 0;

            int l = getLength(node.Left);
            int r = getLength(node.right);
            annser = Math.Max(annser, (l+r+1));
            return Math.Max(l, r) + 1;
        }

        public static TreeNode LowestCommonAncector(TreeNode root,int x,int y)
        {
            if (root == null)
            {
                return null;
            }
            if (root.val == x || root.val == y)
            {
                return root;
            }

            TreeNode leftNode = LowestCommonAncector(root.Left, x, y);
            TreeNode rightNode = LowestCommonAncector(root.right, x, y);
            if (leftNode == null) return rightNode;
            if (rightNode == null) return leftNode;
            return root;
        }

        public static TreeNode invertTree(TreeNode root)
        {
            TreeNode result= invert(root);
            return result;
        }
        public static TreeNode invert(TreeNode root)
        {
            if (root == null)
                return null;

            TreeNode left = invert(root.Left);
            TreeNode right = invert(root.right);

            root.Left = right;
            root.right = left;
            return root;
        }

        public static TreeNode MeregeTwoTree(TreeNode t1,TreeNode t2)
        {
            TreeNode result= Merge(t1, t2);
            return result;
        }

        public static TreeNode Merge(TreeNode t1,TreeNode t2)
        {
            if (t1 == null && t2 == null) return null;
            if (t1 == null && t2 != null) return t2;
            if (t1 != null && t2 == null) return t1;

            TreeNode node = new TreeNode(t1.val + t1.val);
            node.Left = Merge(t1.Left, t2.Left);
            node.right = Merge(t1.right, t2.right);

            return node;
        }

        public static int SumOfTreeNodesValues(TreeNode root)
        {
            int sum= SumOfValues(root);
            return sum;
        }

        public static int SumOfValues(TreeNode root)
        {
            if (root == null)
                return 0;

            int sumLeft = SumOfValues(root.Left);
            int sumright = SumOfValues(root.right);
            return root.val + sumLeft + sumright;

        }

        public static int MaxOfValues(TreeNode root)
        {
            if (root == null)
                return 0;
            int sumLeft = MaxOfValues(root.Left);
            int sumright = MaxOfValues(root.right);
            int max = Math.Max(sumLeft, sumright);
            return Math.Max(root.val, max);

        }

        public static int HightOfTree(TreeNode root)
        {
            if (root == null)
                return 0;
            int leftHeight = HightOfTree(root.Left);
            int rightHight = HightOfTree(root.right);

            return 1+ Math.Max(leftHeight, rightHight);

        }

        public static bool ExisitsInTree(TreeNode root,int val)
        {
            if (root == null)
                return false;
            bool leftSearch = ExisitsInTree(root.Left,val);
            bool rightSearch = ExisitsInTree(root.right,val);

            return root.val == val ||leftSearch ||rightSearch;

        }

        static void Main(string[] args)
        {

            //Console.WriteLine(TreeConstructor(new string[] { "(1,2)", "(2,4)", "(7,2)","(9,4)"}));
            //TreeNode node = TreeConstructor(new int[] { 9,3,15,20,7 }, new int[] { 3,9,20,15,7 });
            //Console.WriteLine(isSymatric(node));
            //Console.WriteLine(pathOfTree(node));

            TreeNode tree = new TreeNode(1);
            tree.Left = new TreeNode(2);
            tree.right = new TreeNode(3);
            tree.Left.Left = new TreeNode(4);
            tree.Left.right = new TreeNode(5);
            tree.right.Left = new TreeNode(6);
            tree.right.right = new TreeNode(7);

            //Console.WriteLine("LCA(4, 5) = " +
            //          LowestCommonAncector(tree, 4, 5).val);
            //Console.WriteLine("LCA(2, 4) = " +
            //         LowestCommonAncector(tree, 2, 4).val);
            //Console.WriteLine(invertTree(tree));
            //Console.WriteLine(MeregeTwoTree(tree,tree));
            //Console.WriteLine(SumOfTreeNodesValues(tree));
            //Console.WriteLine(MaxOfValues(tree)); 
            //Console.WriteLine(HightOfTree(tree));
            Console.WriteLine(ExisitsInTree(tree,0)); 
            Console.ReadLine();
        }
    }
}
