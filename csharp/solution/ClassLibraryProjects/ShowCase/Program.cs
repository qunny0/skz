using System;
using UtilityLibraries;
using Newtonsoft.Json;

public class Account
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime DOB { get; set; }
}

class Program
{
    static void Main1(string[] args)
    {
        Account account = new Account
        {
            Name = "Ben",
            Email = "ben@163.com",
            DOB = new DateTime(1980, 2, 20, 0, 0, 0, DateTimeKind.Utc)
        };   

        string json = JsonConvert.SerializeObject(account, Formatting.Indented);
        Console.WriteLine(json);

        int row = 0;

        do
        {
            if (row == 0 || row >= 25)
                ResetConsole();

            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;
            Console.WriteLine($"Input: {input} {"Begins with uppercase? ",30}: " +
                              $"{(input.StartsWithUpper() ? "Yes" : "No")}{Environment.NewLine}");
            row += 3;
        } while (true);
        return;

        // Declare a ResetConsole local method
        void ResetConsole()
        {
            if (row > 0)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            Console.Clear();
            Console.WriteLine($"{Environment.NewLine}Press <Enter> only to exit; otherwise, enter a string and press <Enter>:{Environment.NewLine}");
            row = 3;
        }
    }
}

public class Solution {
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public IList<int> PreorderTraversal(TreeNode root) {
        var re = new List<int>();
        TraversalTree(root, re);
        return re;
    }

    private void TraversalTree(TreeNode root, IList<int> re)
    {
        if (root == null)
        {
            return;
        }

        TraversalTree(root.left, re);
        re.Add(root.val);
        TraversalTree(root.right, re);

        // 1. root 没有left，没有right；输出结果，找到parent
        // 2. root 没有left，有right；
    }


    public static IList<int> PreorderTraversal1(TreeNode root) {
        var re = new List<int>();
        if (root == null) {
            return re;
        }
        var stack = new Stack<TreeNode>();
        var pNode = root;
        while (stack.Count > 0 || pNode != null)
        {
            while (pNode != null)
            {
                re.Add(pNode.val);
                stack.Push(pNode);
                pNode = pNode.left;
            }

            pNode = stack.Pop();
            pNode = pNode.right;
        }

        return re;
    }

    public static IList<int> HTraversal1(TreeNode root)
    {
        var re = new List<int>();
        if (root == null) {
            return re;
        }

        Stack<TreeNode> stk = new Stack<TreeNode>();
        TreeNode pt = root;
        TreeNode prev = null;

        var loopIdx = 0;

        while (pt != null || stk.Count > 0)
        {
            loopIdx++;

            Console.WriteLine($"----loop---times---{loopIdx}");

            while(pt != null)
            {
                stk.Push(pt);
                pt = pt.left;
            }

            pt = stk.Pop();
            if (pt.right == null || pt.right == prev)
            {
                re.Add(pt.val);
                prev = pt;
                pt = null;
            }
            else 
            {
                stk.Push(pt);
                pt = pt.right;
            }
        }

        return re;
    }

    public IList<int> InorderTraversal(TreeNode root) {
        var re = new List<int>();
        if (root == null) 
        {
            return re;
        }

        var stk = new Stack<TreeNode>();
        var pt = root;

        TreeNode prev = null;

        while (pt != null || stk.Count > 0)
        {
            while (pt != null)
            {
                stk.Push(pt);
                pt = pt.left;
            }

            pt = stk.Pop();

            if (pt.right == null || pt.right == prev)
            {
                re.Add(pt.val);
                prev = pt;
                pt = null;
            }
            else
            {
                stk.Push(pt);
                pt = pt.right;
            }
        }

        return re;
    }

    public IList<int> PostorderTraversal(TreeNode root) {
        var re = new List<int>();
        // traversal(root, re);
        return re;
    }

    // private void traversal(TreeNode pt, IList<int> re)
    // {
    //     if (pt == null)
    //     {
    //         return ;
    //     }

    //     traversal(pt.left, re);
    //     traversal(pt.right, re);
    //     re.Add(pt.val);
    // }

    static public IList<IList<int>> LevelOrder(TreeNode root) {
        var re = new List<IList<int>>();
        if (root == null) 
        {
            return re;
        }

        // 当前层访问节点
        var que = new Queue<TreeNode>();
        que.Enqueue(root);

        while (que.Count > 0)
        {
            re.Add(new List<int>());
            var curLevelCnt = que.Count;
            
            while (curLevelCnt > 0)
            {
                curLevelCnt--;
                var pt = que.Dequeue();
                re[re.Count - 1].Append(pt.val);

                if (pt.left != null)
                {
                    que.Enqueue(pt.left);
                }
                if (pt.right != null)
                {
                    que.Enqueue(pt.right);
                }
            }
        }

        return re;
    }

/*
                        0
                1               2
            3       4       5
        6       7               8
            9       
*/
    static void Main(string[] args)
    {
        // var test = [1, null, 2, 3];
        var p0 = new TreeNode(0);
        var p1 = new TreeNode(1);
        var p2 = new TreeNode(2);
        var p3 = new TreeNode(3);
        var p4 = new TreeNode(4);
        var p5 = new TreeNode(5);
        var p6 = new TreeNode(6);
        var p7 = new TreeNode(7);
        var p8 = new TreeNode(8);
        var p9 = new TreeNode(9);

/*
                        0
                1               2
            3       4       5
        6       7               8
            9       
*/

        p0.left = p1;
        p0.right = p2;

        p1.left = p3;
        p1.right = p4;

        p2.left = p5;
        p5.right = p8;

        p3.left = p6;
        p3.right = p7;

        p7.left = p9;
        // p7.right = p10;


        // var re = HTraversal1(p0);

        // re = InorderTraversal(p0);

        LevelOrder(p0);
    }
}