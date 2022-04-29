using System;
using UtilityLibraries;
using Newtonsoft.Json;
using System.Collections.Generic;

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
    // public class Node {
    //     public int val;
    //     public Node left;
    //     public Node right;
    //     public Node next;

    //     public Node() {}

    //     public Node(int _val) {
    //         val = _val;
    //     }

    //     public Node(int _val, Node _left, Node _right, Node _next) {
    //         val = _val;
    //         left = _left;
    //         right = _right;
    //         next = _next;
    //     }
    // }
    // public Node Connect(Node root) {
    //     if (root == null)
    //     {
    //         return root;
    //     }

    //     // 指向当前层级的最左侧节点
    //     Node pt = root;

    //     while (pt != null)
    //     {

    //         var tmpPt = pt;
    //         Node preNode = null;
    //         pt = null;

    //         while (tmpPt != null)
    //         {
    //             if (tmpPt.left != null)
    //             {
    //                 if (preNode == null)
    //                 {
    //                     preNode = tmpPt.left;
    //                     pt = tmpPt.left;
    //                 }
    //                 else 
    //                 {
    //                     preNode.next = tmpPt.left;
    //                     preNode = tmpPt.left;
    //                 }
    //             }
    //             if (tmpPt.right != null)
    //             {
    //                 if (preNode == null)
    //                 {
    //                     preNode = tmpPt.right;
    //                     pt = tmpPt.right;
    //                 }
    //                 else 
    //                 {
    //                     preNode.next = tmpPt.right;
    //                     preNode = tmpPt.right;
    //                 }
    //             }

    //             tmpPt = tmpPt.next;
    //         }
    //     }            

    //     return root;
    // }

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
        // nums：是一个升序数组
        // answer: 找到 第一个 大于等于target 的元素下标
        // 二分查找

        int left = 0, right = nums.Length;
        while (left < right)
        {
            var middle = (left + right) >> 1;
            if (nums[middle] == target)
            {
                return middle;
            }

            if (nums[middle] > target)
            {
                right = middle;
            }
            else
            {
                left = middle + 1;
            }
        }

        return left;
    }

    static public int[][] Merge(int[][] intervals) {
        Array.Sort(intervals, (e1, e2) => e1[0].CompareTo(e2[0]));
        var ans = new List<int[]>();
        ans.Add(intervals[0]);

        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] <= ans[ans.Count-1][1])
            {
                ans[ans.Count-1][1] = Math.Max(intervals[i][1], ans[ans.Count-1][1]);
            }
            else
            {
                ans.Add(intervals[i]);
            }
        }

        var ret = ans.ToArray();
        return ret;
    }

    static public void Rotate(int[][] matrix) {
        var N = matrix.Length - 1;
        // N维 [i, j] -> [j, N - i]

        // [i, j] -> [j, N-i] -> [N-i, N-j] -> [N-j, i] -> [i, j]

        // [i, j] -> [i, N-j] -> [j, N-i];

        // [i, j] -> [N-i, j]
        for (int i = 0; i < matrix.Length/2; i++)
        {
            for (int j = 0; j < matrix.Length; j++)
            {
                var temp = matrix[N-i][j];
                matrix[N-i][j] = matrix[i][j];
                matrix[i][j] = temp;
            }
        }

        // [i,j]->[j,i];
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = i+1; j < matrix.Length; j++)
            {
                var temp = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = temp;
            }
        }
    }

    static public void SetZeroes(int[][] matrix) {
        // var rows = new List<int>();
        // var cols = new List<int>();

        var firstLine0 = false;
        var firstCol0= false;

        for (int i = 0; i < matrix[0].Length; i++)
        {
            if(matrix[0][i] == 0)
            {
                firstLine0 = true;
                break;
            }
        }
        for (int i = 0; i < matrix.Length; i++)
        {
            if (matrix[i][0] == 0)
            {
                firstCol0 = true;
                break;
            }
        }

        for (int i = 1; i < matrix.Length; i++)
        {
            for (int j = 1; j < matrix[0].Length; j++)
            {
                if (matrix[i][j] == 0)
                {
                    matrix[0][j] = 0;
                    matrix[i][0] = 0;
                }
            }
        }

        for (int i = 1; i < matrix.Length; i++)
        {
            for (int j = 1; j < matrix[0].Length; j++)
            {
                if (matrix[i][0] == 0 || matrix[0][j] == 0)
                {
                    matrix[i][j] = 0;
                }
            }
        }

        if (firstLine0)
        {
            for (int i = 0; i < matrix[0].Length; i++)
            {
                matrix[0][i] = 0;
            }
        }
        if (firstCol0)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i][0] = 0;
            }
        }
    }

    static public int[] FindDiagonalOrder(int[][] mat) {
        var i = 0;
        var j = 0;
        var diri = 1;
        var dirj = -1;

        var ans = new List<int>();

        var iMax = mat.Length - 1;
        var jMax = mat[0].Length - 1;

        var needReverse = true;
        while (true)
        {
            var cntNum = 0;
            needReverse = !needReverse;
            
            do
            {
                ans.Add(mat[i][j]);
                i += diri;
                j += dirj;
                cntNum++;
            } while( i <= iMax && j >= 0);

            if (needReverse)
            {
                ans.Reverse(ans.Count - cntNum, cntNum);
            }

            i -= diri;
            j -= dirj;

            if (i == iMax && j == jMax)
            {
                break;
            }

            if (i < iMax)
            {
                i += 1;
            }
            else
            {
                j += 1;
            }
        };

        return ans.ToArray();
    }

    // static public string LongestCommonPrefix(string[] strs) {
    //     // 中心扩展法
    // }

    static public string LongestPalindrome(string s) {
        if (s == null || s.Length <= 1)
        {
            return s;
        }

        // 中心扩展法
        var start = 0;
        var end = 0;

        for (int i = 0; i < s.Length - 1; i++)
        {
            // [i, i]
            // [i, i+1]

        }

        return s.Substring(start, end-start);
    }

    // static public string ReverseWords(string s) {
    //     var ans = string.Empty;
    //     var words = s.Split(' ');

    //     for (int i = words.Length - 1; i >= 0; i--)
    //     {
    //         var w = words[i];
    //         if (w.Length > 0)
    //         {
    //             if (ans.Length > 0)
    //             {
    //                 ans = ans + ' ';
    //             }
    //             ans = ans + w;
    //         }
    //     }
    //     return ans;
    // }

    static public int StrStr(string haystack, string needle) {
        // KMP
        // create next array
        int[] next = new int[needle.Length];
        int si = 0;
        next[si] = 0;
        for (int i = 2; i < needle.Length; i++)
        {
            // subNeedle --> [ts, ti) 的子串
            int ts = si;
            int ti = i;
            // k是needle子串长度
            for (int k = 1; k < i; k++)
            {
                // tk是子串比较
                int tk = 0;
                for (tk = 0; tk < k; tk++)
                {
                    if (needle[ts+tk] != needle[ti-k+tk])
                    {
                        break;
                    }
                }
                if (tk == k)
                {
                    next[ti] = k;
                }
            }
        }

        int hayi = 0;
        int needi = 0;
        while (hayi < haystack.Length)
        {
            if (haystack[hayi] == needle[needi])
            {
                needi++;
                if (needi == needle.Length)
                {
                    var ans = hayi - needle.Length + 1;
                    return ans;
                }
            }
            else
            {
                if (needi > 0)
                {
                    needi = next[needi];
                    hayi--;
                }
                else
                {
                    needi = 0;
                }
            }
            hayi++;
        }

        return -1;
    }

    public void ReverseString(char[] s) {
        // int begin = 0;
        // int end = s.Length - 1;

        // while (begin < end)
        // {
        //     var t = s[begin];
        //     s[begin] = s[end];
        //     s[end] = t;

        //     begin++;
        //     end--;
        // }
        // Array.Reverse(s);
    }

    public int ArrayPairSum(int[] nums) {
        Array.Sort(nums);
        var sum = 0;

        for (int i = 0; i < nums.Length; i += 2)
        {
            sum += nums[i];
        }

        return sum;
    }

    public int[] TwoSum(int[] numbers, int target) {
        var ans = new int[2];

        var start = 0;
        var end = numbers.Length - 1;
        while (start < end)
        {
            var sum = numbers[start] + numbers[end];

            if (sum > target)
            {
                end--;
            }
            else if (sum < target)
            {
                start++;
            }
            else
            {
                ans[0] = start + 1;
                ans[1] = end + 1;
                break;
            }
        }

        return ans;
    }

    // 连续1的个数
    public int FindMaxConsecutiveOnes(int[] nums) {
        int si = -1;
        int fasti = 0;
        var ans = 0;

        while (fasti < nums.Length)
        {
            if (nums[fasti] == 1)
            {
                if (si == -1)
                {
                    si = fasti;
                }
                if (fasti == nums.Length - 1 && si != -1)
                {
                    ans = Math.Max(ans, fasti-si+1);
                    break;
                }
            }
            else
            {
                if (si != -1)
                {
                    ans = Math.Max(ans, fasti-si);
                }
                si = -1;
            }
            fasti++;
        }

        return ans;
    }

    static public int MinSubArrayLen(int target, int[] nums) {
        // 滑动窗口
        // 因为 nums[i] >= 1，所以数组长度和为递增

        // int n = nums.length;
        // if (n == 0) {
        //     return 0;
        // }
        // int ans = Integer.MAX_VALUE;
        // int start = 0, end = 0;
        // int sum = 0;
        // while (end < n) {
        //     sum += nums[end];
        //     while (sum >= s) {
        //         ans = Math.min(ans, end - start + 1);
        //         sum -= nums[start];
        //         start++;
        //     }
        //     end++;
        // }
        // return ans == Integer.MAX_VALUE ? 0 : ans;

        var ans = nums.Length + 1;
        var start = 0;
        var end = 0;
        var sum = 0;

        while (end < nums.Length)
        {
            sum += nums[end];
            while (sum >= target)
            {
                ans = Math.Min(ans, end - start + 1);
                sum -= nums[start];
                start++;
            }
            end++;
        }

        return ans == nums.Length + 1 ? 0 : ans;
    }

    static public IList<IList<int>> Generate(int numRows) {
        var ans = new List<IList<int>>();

        for (int i = 0; i < numRows; i++)
        {
            var level = new List<int>();
            for (int k = 0; k < i + 1; k++)
            {
                if (k == 0 || k == i)
                {
                    level.Add(1);
                }
                else
                {
                    level.Add(ans[i-1][k-1] + ans[i-1][k]);
                }
            }
            ans.Add(level);
        }

        return ans;
    }

    static public IList<int> GetRow(int rowIndex) {
        var ans = new List<int>();
        ans.Add(1);
        if (rowIndex == 0)
        {
            return ans;
        }
        ans.Add(1);
        if (rowIndex == 1)
        {
            return ans;
        }

        for (int k = 2; k <= rowIndex; k++)
        {
            for (int i = k - 1; i > 0; i--)
            {
                ans[i] = ans[i] + ans[i-1];
            }
            ans.Add(1);
        }

        return ans;
    }
    static public string ReverseWords(string s) {
        var ans = string.Empty;
        // [start, end)
        var start = 0;
        var end = 0;

        while (end <= s.Length)
        {
            if (end == s.Length || s[end] == ' ')
            {
                if (end > start)
                {
                    if (ans != string.Empty)
                    {
                        ans += ' ';
                    }
                    for (int k = end - 1; k >= start; k--)
                    {
                        ans += s[k];
                    }

                    // reverse [start, end)
                    start = end + 1;
                    while(start < s.Length)
                    {
                        if (s[start] != ' ')
                        {
                            break;
                        }
                        start++;
                    }
                }
            }

            end++;
        };

        return ans;
    }

    static public int FindMin(int[] nums) {
        var left = 0;
        var right = nums.Length;

        while (left < right - 1)
        {
            var mid = (left + right) / 2;

            if (nums[mid] > nums[right-1])
            {
                left = mid + 1;
            }
            else
            {
                if (mid > 0 && nums[mid] < nums[mid-1])
                {
                    return nums[mid];
                }
                else
                {
                    right = mid;
                }
            }
        }

        return nums[left];
    }

    static public void MoveZeroes(int[] nums) { 
        var zeroPivot = -1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0 && zeroPivot == -1)
            {
                zeroPivot = i;
            }

            if (nums[i] != 0)
            {
                if (zeroPivot != -1 && zeroPivot < i)
                {
                    nums[zeroPivot] = nums[i];
                    nums[i] = 0;
                    zeroPivot++;
                }
            }
        }    
    }

    public class MyCircularQueue {

        private int front;
        private int rear;
        private int count;
        private int[] _data;

        public MyCircularQueue(int k) {
            front = -1;
            rear = -1;
            count = k;
            _data = new int[count];
        }
        
        public bool EnQueue(int value) {
            if (IsFull())
            {
                return false;
            }
            if (IsEmpty())
            {
                front = 0;
            }

            rear = (rear + 1) % count;
            _data[rear] = value;
            return true;
        }
        
        public bool DeQueue() {
            if (IsEmpty())
            {
                return false;
            }

            if (front == rear)
            {
                front = -1;
                rear = -1;
                return true;
            }

            front = (front + 1) % count;
            return true;
        }
        
        public int Front() {
            if (IsEmpty())
            {
                return -1;
            }
            return _data[front];
        }
        
        public int Rear() { 
            if (IsEmpty())
            {
                return -1;
            }
            return _data[rear];
        }
        
        public bool IsEmpty() {
            return front == -1;
        }
        
        public bool IsFull() {
            return (rear + 1) % count == front;
        }
    }

    class Point
    {
        private int _x;
        private int _y;

        public Point(int x, int y)
        {   
            _x = x;
            _y = y;
        }

        public int x
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        public int y
        {
            get 
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
    }
    
    static public int NumIslands(char[][] grid) {
        int ans = 0;
        bool[,] visited = new bool[grid.Length, grid[0].Length];

        var lq = new Queue<Point>();

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    if (visited[i, j])
                    {
                        continue;
                    }

                    ans++;
                    lq.Enqueue(new Point(i, j));
                    while (lq.Count > 0)
                    {
                        var size = lq.Count;
                        while (size-- > 0)
                        {
                            var pt = lq.Dequeue();
                            // top
                            if ((pt.x - 1) >= 0 && grid[pt.x - 1][pt.y] == '1' && !visited[pt.x - 1, pt.y])
                            {
                                lq.Enqueue(new Point(pt.x - 1, pt.y));
                                visited[pt.x - 1, pt.y] = true;
                            }
                            // bottom
                            if ((pt.x + 1) < grid.Length && grid[pt.x + 1][pt.y] == '1' &&  !visited[pt.x + 1, pt.y])
                            {
                                lq.Enqueue(new Point(pt.x + 1, pt.y));
                                visited[pt.x + 1, pt.y] = true;
                            }
                            // left
                            if ((pt.y - 1) >= 0 && grid[pt.x][pt.y - 1] == '1' &&  !visited[pt.x, pt.y - 1])
                            {
                                lq.Enqueue(new Point(pt.x, pt.y - 1));
                                visited[pt.x, pt.y - 1] = true;
                            }
                            // right
                            if ((pt.y + 1) < grid[0].Length && grid[pt.x][pt.y + 1] == '1'  && !visited[pt.x, pt.y + 1])
                            {
                                lq.Enqueue(new Point(pt.x, pt.y + 1));
                                visited[pt.x, pt.y + 1] = true;
                            }

                        }
                    }
                }
            }
        }

        return ans;
    }

    public int OpenLock(string[] deadends, string target) {
        // 按八叉树处理~_~
        int ans = -1;
        if (target == "0000")
        {
            return 0;
        }

        ISet<string> dead = new HashSet<string>();
        foreach (string deadend in deadends)
        {
            dead.Add(deadend);
        }
        if (dead.Contains("0000"))
        {
            return -1;
        }

        // 防止重复搜索
        ISet<string> seen = new HashSet<string>();
        seen.Add("0000");

        Queue<string> searchQueue = new Queue<string>();
        searchQueue.Enqueue("0000");
        ans = 0;

        while (searchQueue.Count > 0)
        {
            var cnt = searchQueue.Count;
            ans++;
            while (cnt-- > 0)
            {
                var ele = searchQueue.Dequeue();
                var nextStatus = GetNext(ele);
                foreach (string str in nextStatus)
                {
                    if (!dead.Contains(str) && !seen.Contains(str))
                    {
                        if (str.Equals(target))
                        {
                            return ans;
                        }
                        seen.Add(str);
                        searchQueue.Enqueue(str);
                    }
                }
            }
        }

        return -1;
    }

    private char NumPrev(char x)
    {
        return x == '0' ? '9' : (char)(x - 1);
    }

    private char NumNext(char x)
    {
        return x == '9' ? '1' : (char)(x + 1);
    }

    private IList<string> GetNext(string status)
    {
        IList<string> nextstatus = new List<string>();
        char[] array = status.ToCharArray();
        for (int i = 0; i < 4; i++)
        {
            char num = array[i];
            array[i] = NumPrev(num);
            nextstatus.Add(new string(array));
            array[i] = NumNext(num);
            nextstatus.Add(new string(array));
            array[i] = num;
        }

        return nextstatus;
    }


// public class Solution {
//     public int NumSquares(int n) {
//         int[] f = new int[n + 1];
//         for (int i = 1; i <= n; i++) {
//             int minn = int.MaxValue;
//             for (int j = 1; j * j <= i; j++) {
//                 minn = Math.Min(minn, f[i - j * j]);
//             }
//             f[i] = minn + 1;
//         }
//         return f[n];
//     }
// }

    static public int NumSquares(int n) {
        int[] f = new int[n+1];

        for (int i = 1; i <= n; i++)
        {
            int minn = int.MaxValue;
            for (int j = 1; j * j <= i; j++)
            {
                minn = Math.Min(minn, f[i - j *j ]);
            }
            f[i] = 1 + minn;
        }

        return f[n];
    }

    public class MinStack {
        Stack<(int, int)> theStack;

        public MinStack()
        {
            theStack = new Stack<(int, int)>();
        }

        public void Push(int val)
        {
            if (theStack.Count == 0)
            {
                theStack.Push((val, val));
            }
            else
            {
                theStack.Push((val, Math.Min(val, theStack.Peek().Item2)));
            }
        }

        public void Pop()
        {
            theStack.Pop();
        }

        public int Top()
        {
            return theStack.Peek().Item1;
        }

    public int GetMin()
    {
        return theStack.Peek().Item2;
    }
    }

    public int[] DailyTemperatures(int[] temperatures) {
        int[] ans = new int[temperatures.Length];

        for (int i = 0; i < temperatures.Length; i++)
        {
            int nextIdx = i + 1;
            while (nextIdx < temperatures.Length)
            {
                if (temperatures[nextIdx] > temperatures[i])
                {   
                    ans[i] = nextIdx - i;
                    break;
                }
                nextIdx++;
            }
        }

        return ans;
    }
    
    // 波兰
    public int EvalRPN(string[] tokens) {
        Stack<int> _stack = new Stack<int>();
        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == "+" || tokens[i] == "-" || tokens[i] == "*" ||  tokens[i] == "/")
            {
                var rval = _stack.Pop();
                var lval = _stack.Pop();
                var re = 0;
                switch (tokens[i])
                {
                    case "+":
                        re = lval + rval;
                        break;
                    case "-":
                        re = lval - rval;
                        break;
                    case "*":
                        re = lval * rval;
                        break;
                    case "/":
                        re = (int)(lval / rval);
                        break;
                }
                _stack.Push(re);
            }
            else
            {
                _stack.Push(Convert.ToInt32(tokens[i]));
            }
        }

        return _stack.Pop();
    }


    // Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}

    private Node BFS_Graph(Node node)
    {
        if (node == null)
            return null;
        Dictionary<Node, Node> visit = new Dictionary<Node, Node>();

        var stk = new Stack<Node>();
        stk.Push(node);

        var cproot = node;

        Node root = new Node(node.val);
        visit.Add(node, root);

        while (stk.Count > 0)
        {
            var cnt = stk.Count;
            while (cnt-- > 0)
            {
                var pt = stk.Pop();

                var neighs = pt.neighbors;
                foreach (var nt in neighs)
                {
                    Node tempPt = null;
                    if (!visit.ContainsKey(nt))
                    {
                        stk.Push(nt);
                        tempPt = new Node(nt.val);
                        visit.Add(nt, tempPt);
                    }
                    else
                    {
                        tempPt = visit[nt];
                    }

                    visit[pt].neighbors.Add(tempPt);
                }
            }
        }

        return root;
    }


    Dictionary<Node, Node> _visit = new Dictionary<Node, Node>();
    static public Node CloneGraph(Node node) {
        // DFS
        if (node == null)
        {
            return null;
        }

        if (_visit.ContainsKey(node))
        {
            return _visit[node];
        }


        var nn = new Node(node.val);
        _visit.Add(node, nn);

        foreach (var ele in node.neighbors)
        {
            nn.neighbors.Add(CloneGraph(node));
        }
        return nn;
    }



    public int FindTargetSumWays(int[] nums, int target) {
        int cnt = 0;
        sumHelp(nums, 0+nums[0], 1, target, ref cnt);
        sumHelp(nums, 0-nums[0], 1, target, ref cnt);

        return cnt;
    }

    private void sumHelp(int[] nums, int sum, int idx, int target, ref int cnt)
    {
        if (idx == nums.Length)
        {
            if (sum == target)
            {
                cnt++;
            }
            return ;
        }

        sumHelp(nums, sum + nums[idx], idx + 1, target, ref cnt);
        sumHelp(nums, sum - nums[idx], idx + 1, target, ref cnt);
    }

    public class MyQueue
    {
        Stack<int> _stack1;
        Stack<int> _stack2;

        public MyQueue()
        {
            _stack1 = new Stack<int>();
            _stack2 = new Stack<int>();
        }

        public void Push(int x)
        {
            while (_stack1.Count > 0)
            {
                _stack2.Push(_stack1.Pop());
            }

            _stack1.Push(x);

            while (_stack2.Count > 0)
            {
                _stack1.Push(_stack2.Pop());
            }
        }

        public int Pop()
        {
            return _stack1.Pop();
        }

        public int Peek()
        {
            return _stack1.Peek();
        }

        public bool Empty()
        {
            return _stack1.Count == 0;
        }
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

        // int[] arrCase = {1,3,5,6};
        // var re = SearchInsert(arrCase, 3);
        // Console.WriteLine($"re:{re}");

        // var case1 = {[1,3],[2,6],[8,10],[15,18]};

        // int[][] case1 = {[1, 3]};
        // int[,] case1 = new int[,] { { 1, 3 }, { 2, 6 }, { 8, 10 }, { 15, 18 } };

        int[][] case1 = {
            new int[] {1, 3},
            new int[] {2, 6},
            new int[] {8, 10},
            new int[] {15, 18},
        };

        // int[][] matrix = 
        // {
        //     new int[] {5, 0, 9, 11},
        //     new int[] {2, 4, 8,10},
        //     new int[] {13, 3, 6, 7},
        //     new int[] {15,14,12,16},
        // };

        int[][] matrix = 
        {
            new int[] {1, 2, 3},
            new int[] {4, 5, 6},
            new int[] {7, 8, 9},
        };




        // var case1 = new List<int[]>();
        // case1.Add( new int[](1, 3));

        // var ans = Merge(case1);

        // Rotate(matrix);
        // FindDiagonalOrder(matrix);

        // ReverseWords("  a good   example  ");
        // "mississippi"
        // "issip"
        // StrStr("hello", "ll");
        // StrStr("mississippi", "issip");
        // StrStr("mississippi", "actgpacy");

        // acta  -- 1
        // actac

        // Console.WriteLine(matrix);

        int[] testcase = {0,1,0,3,12};
        // MinSubArrayLen(11, testcase);

        // GetRow(3);

        // FindMin(testcase);

        // ReverseWords("Let's take LeetCode contest");

        // MoveZeroes(testcase);


        char[][] grid = 
        {
            new char[] {'1','1','0','0','0'},
            new char[] {'1','1','0','0','0'},
            new char[] {'1','1','0','0','0'},
            new char[] {'1','1','0','0','0'},
        };

        // NumIslands(grid);

        // NumSquares(7168);

        //var mins = new MinStack();

        MyQueue myQueue = new MyQueue();
        myQueue.Push(1);    // queue is: [1]
        myQueue.Push(2);    // queue is: [1, 2] (leftmost is front of the queue)
        myQueue.Push(3);    // queue is: [1, 2] (leftmost is front of the queue)
        myQueue.Peek();     // return 1
        myQueue.Pop();      // return 1, queue is [2]
        myQueue.Empty();    // return false
    }
}