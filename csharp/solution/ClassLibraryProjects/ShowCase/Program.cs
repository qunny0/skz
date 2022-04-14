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

    static public int MaxDepth(TreeNode root) {
        // 深搜版本

        var re = 0;
        var max = 0;
        var stk = new Stack<TreeNode>();
        var pt = root;
        TreeNode prev = null;
        while (pt != null || stk.Count > 0)
        {
            while (pt != null)
            {
                stk.Push(pt);
                pt = pt.left;
                re++;
            }
            max = Math.Max(re, max);

            pt = stk.Pop();
            if (pt.right == null || pt.right == prev)
            {
                re--;
                prev = pt;
                pt = null;
            }
            else
            {
                stk.Push(pt);
                pt = pt.right;
            }
        }

        return max;
    }

    static private void maxdepth(TreeNode pt, int level, ref int maxLevel)
    {
        if (pt == null)
        {
            maxLevel = Math.Max(level, maxLevel);
            return ;
        }

        maxdepth(pt.left, level + 1, ref maxLevel);
        maxdepth(pt.right, level + 1, ref maxLevel);
    }

    static public bool IsSymmetric(TreeNode root) {

        var lTree = root.left;
        var rTree = root.right;

        if (lTree == null && rTree == null)
        {
            return true;
        }

        var lQueue = new Queue<TreeNode>();
        var rQueue = new Queue<TreeNode>();

        lQueue.Enqueue(lTree);
        rQueue.Enqueue(rTree);

        while (lQueue.Count > 0)
        {
            var lNode = lQueue.Dequeue();
            var rNode = rQueue.Dequeue();

            if (lNode.val != rNode.val)
            {
                return false;
            }

            if (lNode.left != null && rNode.right != null)
            {
                lQueue.Enqueue(lNode.left);
                rQueue.Enqueue(rNode.right);
            }
            else if (!(lNode.left == null && rNode.right == null))
            {
                return false;
            }

            if (lNode.right != null && rNode.left != null)
            {
                lQueue.Enqueue(lNode.right);
                rQueue.Enqueue(rNode.left);
            }
            else if (!(lNode.right == null && rNode.left == null))
            {
                return false;
            }
        }

        return true;
    }

    static private bool CompareReverse(TreeNode lTree, TreeNode rTree)
    {
        if (lTree == null && rTree == null)
        {
            return true;
        }
        if (lTree == null || rTree == null)
        {
            return false;
        }
        if (lTree.val != rTree.val)
        {
            return false;
        }
        return CompareReverse(lTree.left, rTree.right) && CompareReverse(lTree.right, rTree.left);
    }

    static private bool compareLevel(Queue<TreeNode> left, Queue<TreeNode> right)
    {
        var cnt = left.Count;

        right.Reverse();

        while (cnt-- > 0)
        {
            var lNode = left.Dequeue();

        }

        return true;
    }

    static private bool compareList(List<TreeNode>l, List<TreeNode>r, int start, int end)
    {
        int cnt = end - start;
        for (int i = 0; i < cnt; i++)
        {
            var lIdx = start + i;
            var rIdx = end - i - 1;

            var lNode = l[lIdx];
            var rNode = r[rIdx];

            var lVal = lNode != null ? lNode.val : 101;
            var rVal = rNode != null ? rNode.val : 101;

            if (lVal != rVal)
            {
                return false;
            }
        }

        return true;
    }
    
    public bool HasPathSum(TreeNode root, int targetSum) {
        // 深搜
        if (root == null)
        {
            return false;
        }

        var stk = new Stack<TreeNode>();
        var pt = root;
        TreeNode prev = null;
        var tmpSum = 0;

        while (pt != null || stk.Count > 0)
        {
            while (pt != null)
            {
                stk.Push(pt);
                tmpSum = tmpSum + pt.val;
                pt = pt.left;
            }

            pt = stk.Pop();
            
            // is leaf and is answer
            if (pt.right == null && tmpSum == targetSum)
            {
                return true;
            }

            if (pt.right == null || pt.right == prev)
            {
                tmpSum -= pt.val;
                prev = pt;
                pt = null;
            }
            else 
            {
                stk.Push(pt);
                pt = pt.right;
            }
        }

        return false;
    }


    static public TreeNode BuildTree(int[] preorder, int[] inorder) {
        TreeNode root = buildSubTree(inorder, preorder, 0, inorder.Count(), 0, preorder.Count());
        return root;
    }

    // 左闭右开
    static private TreeNode buildSubTree(int[] inorder, int[] preorder, int instart, int inend, int prestart, int preend)
    {
        TreeNode pt = null;

        var rootVal = preorder[prestart];
        pt = new TreeNode(rootVal);
        var inIdx = Array.IndexOf<int>(inorder, rootVal, instart, inend - instart);

        var preLeftStart = prestart + 1;
        var preLeftEnd = prestart + 1 + inIdx - instart;
        var preRighStart = preLeftEnd;

        if (inIdx > instart)
        {
            pt.left = buildSubTree(inorder, preorder, instart, inIdx, preLeftStart, preLeftEnd);
        }
        if (inend > inIdx + 1)
        {
            pt.right = buildSubTree(inorder, preorder, inIdx + 1, inend, preRighStart, preend);
        }
        return pt;
    }

    // Definition for a Node.
    public class Node {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() {}

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next) {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
    public Node Connect(Node root) {
        if (root == null)
        {
            return root;
        }

        // 指向当前层级的最左侧节点
        Node pt = root;

        while (pt != null)
        {

            var tmpPt = pt;
            Node preNode = null;
            pt = null;

            while (tmpPt != null)
            {
                if (tmpPt.left != null)
                {
                    if (preNode == null)
                    {
                        preNode = tmpPt.left;
                        pt = tmpPt.left;
                    }
                    else 
                    {
                        preNode.next = tmpPt.left;
                        preNode = tmpPt.left;
                    }
                }
                if (tmpPt.right != null)
                {
                    if (preNode == null)
                    {
                        preNode = tmpPt.right;
                        pt = tmpPt.right;
                    }
                    else 
                    {
                        preNode.next = tmpPt.right;
                        preNode = tmpPt.right;
                    }
                }

                tmpPt = tmpPt.next;
            }
        }            

        return root;
    }

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        var pt = root;

        do {
            var pLeftSon = Helper(pt.left, p, q);
            var pRightSon = Helper(pt.right, p, q);

            if (pt.val == p.val || pt.val == q.val)
            {
                return pt;
            }

            if (pLeftSon && pRightSon)
            {
                return pt;
            }

            if (pLeftSon)
            {
                pt = pt.left;
            }
            if (pRightSon)
            {
                pt = pt.right;
            }
        } while(true);
    }

    // 以proot为根节点的树，是否是p和q的公共祖先
    private bool Helper(TreeNode proot, TreeNode p, TreeNode q)
    {   
        if (proot == null)
        {
            return false;
        }
        if (proot.val == p.val || proot.val == q.val)
        {
            return true;
        }
        return Helper(proot.left, p, q) || Helper(proot.right, p, q);
    }


    // Encodes a tree to a single string.
    static public string serialize(TreeNode root) {
        // 深度搜索 + 前序遍历
        // string 是引用传递，但是是值传递的效果
        // string的修改，相当于新建了一个新的string
        // var str = helperSerialize(root, "");
        // str = str.Remove(str.Length - 1);
        // return str;

        // BFS
        if (root == null)
        {
            return "";
        }

        var que = new Queue<TreeNode>();
        que.Enqueue(root);
        string re = "";

        while (que.Count > 0)
        {
            var cnt = que.Count;
            while (cnt-- > 0)
            {
                var pt = que.Dequeue();
                if (pt == null)
                {
                    re += "n,";
                }
                else
                {
                    re += pt.val + ",";
                    que.Enqueue(pt.left);
                    que.Enqueue(pt.right);
                }
            }
        }

        re = re.Remove(re.Length - 1);
        return re;
    }

    static private string helperSerialize(TreeNode p, string str)
    {
        if (p == null)
        {
            str += "n,";
            return str;
        }

        str += p.val.ToString() + ",";
        str = helperSerialize(p.left, str);
        str = helperSerialize(p.right, str);

        return str;
    }



    // Decodes your encoded data to tree.
    static public TreeNode deserialize(string data) {

        if (data.Length == 0)
        {
            return null;
        }

        string[] arrData = data.Split(",");
        var queue = new Queue<TreeNode>();
        var idx = 0;

        var root = new TreeNode(Convert.ToInt32(arrData[idx++]));
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var cnt = queue.Count;
            while (cnt-- > 0)
            {
                var pt = queue.Dequeue();
                var vals = arrData[idx++];
                if (vals != "n")
                {
                    pt.left = new TreeNode(Convert.ToInt32(vals));
                    queue.Enqueue(pt.left);
                }

                vals = arrData[idx++];
                if (vals != "n")
                {
                    pt.right = new TreeNode(Convert.ToInt32(vals));
                    queue.Enqueue(pt.right);
                }
            }
        }

        return root;

    }

    static private TreeNode deserializeHelper(Queue<string> queue)
    {
        var sval = queue.Dequeue();
        if (sval == "n") 
        {
            return null;

        }

        var pt = new TreeNode(Convert.ToInt32(sval));


        pt.left = deserializeHelper(queue);
        pt.right = deserializeHelper(queue);

        return pt;
    }

    /*
        pviot[0, cnt-1]

        pivot
        sum1 = sum[0, pivot-1]
        sum2 = sum[pivot+1, cnt-1]

        sum1 = 0
        sum2 = sum(1, cnt-1)

        total = nums.sum()

        sumleft
        sumright = total - sumleft - nums[i]
        sumleft == total - sumleft - nums[i]

        sumleft * 2 = total - nums[i]

    */



    public int PivotIndex(int[] nums) {
        int sum1 = 0;
        int total = nums.Sum();

        for (int i = 0; i < nums.Length; i++)
        {
            if (2 * sum1 == total - nums[i])
            {
                return i;
            }

            sum1 += nums[i];
        }

        return -1;
    }


    /*
        nums[begin, end) target
        inter = begin + (end - begin) / 2

        if inter == target --> return inter

        if inter > target
            if target > num[inter-1] --> return inter
            [begin, inter)  target

        if inter < target
            if target < num[inter+1] --> return inter
            [inter+1, end]

    */
    static public int SearchInsert(int[] nums, int target) {
        int re = helperSearch(nums, 0, nums.Length, target);
        return re;
    }

    static private int helperSearch(int[] nums, int begin, int end, int target)
    {
        if (begin == end)
        {
            if (begin < nums.Length && target > nums[begin])
            {
                return begin + 1;
            }
            return begin;
        }

        int inter = begin + (end - begin) / 2;
        if (nums[inter] == target)
        {
            return inter;
        }

        if (nums[inter] > target)
        {
            return helperSearch(nums, begin, inter, target);
        }

        return helperSearch(nums, inter + 1, end, target);
    }

    public int[][] Merge(int[][] intervals) {
        return intervals;
    }

    // 遍历【广度优先、深度优先（前、中、后）】

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

        // p0.left = p1;
        // p0.right = p2;

        // p1.left = p3;
        // p1.right = p4;

        // p2.left = p5;
        // p5.right = p8;

        // p3.left = p6;
        // p3.right = p7;

        // p7.left = p9;
        // p7.right = p10;


        // var re = HTraversal1(p0);

        // re = InorderTraversal(p0);

        // LevelOrder(p0);

        p0.left = p1;
        p0.right = p2;

        p1.left = p3;
        // p1.right = p4;
        p3.left = p4;

        p2.left = p5;
        p2.right = p6;

        // IsSymmetric(p0);

        int[] preorder = {3,9,20,15,7};
        int[] inorder = {9,3,15,20,7};
        int[] postorder = {9,15,7,20,3};
        
        /*
                [0, 5) 
            idx = 1 (3)
                [0, 1) [1, 2) - (9)
                [2, 5) [2, 5)
            idx = 3 (20)
                [2, 3) [3, 4) - (15)
                [4, 5) [4, 5) - 7
        */

        // BuildTree(preorder, inorder);

        // var str = serialize(p0);
        // var pt = deserialize(str);
        // deserialize(serialize(p0));

        int[] arrCase = {1,3,5,6};
        var re = SearchInsert(arrCase, 8);
    }
}