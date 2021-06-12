using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureProblems
{
    public class LeetCodeProblems
    {
        public void AddTwoNumbersMedium(ListNode l1, ListNode l2)
        {
            var a = AddTwoLinkedLists(l1, l2);
            while (a.next != null)
            {
                Console.WriteLine(a.val);
                a = a.next;
            }

        }

        private ListNode AddTwoLinkedLists(ListNode l1, ListNode l2)
        {
            var listAnswer = new List<int>();
            var currnetNodel1 = l1;
            var currnetNodel2 = l2;
            ListNode temp = new ListNode();
            ListNode answer = temp;
            int carry = 0;
            while (currnetNodel1 != null || currnetNodel2 != null)
            {
                var sum = (currnetNodel1 == null ? 0 : currnetNodel1.val) + (currnetNodel2 == null ? 0 : currnetNodel2.val) + carry;
                carry = sum > 9 ? 1 : 0;
                sum %= 10;
                temp.val = sum;
                //listAnswer.Add(sum);
                if (currnetNodel1 != null)
                    currnetNodel1 = currnetNodel1.next;
                if (currnetNodel2 != null)
                    currnetNodel2 = currnetNodel2.next;
                if (currnetNodel1 != null || currnetNodel2 != null)
                {
                    temp.next = new ListNode();
                    temp = temp.next;
                }
            }
            if (carry > 0)
            {
                temp.next = new ListNode();
                temp = temp.next;
                temp.val = carry;
            }
            return answer;
        }

        public int LongestSubstringWithoutRepeatingCharacters(string s)
        {
            var dict = new Dictionary<char, int>();
            var count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    count = count > dict.Count ? count : dict.Count;
                    i = dict[s[i]] + 1;
                    dict.Clear();
                }
                dict.Add(s[i], i);
                count = dict.Count > count ? dict.Count : count;
            }
            return count;
        }

        public int MyAtoi(string s)
        {
            long ans = 0;
            int i = 10;
            bool isNegative = false;
            s = s.Trim();
            if (s.Length == 0 || (!char.IsDigit(s[0]) && s[0] != '-' && s[0] != '+')) return 0;
            int a = 0;
            if (s[0] == '-' || s[0] == '+')
            {
                isNegative = s[0] == '-';
                a = 1;
            }
            for (; a < s.Length; a++)
            {
                if (char.IsDigit(s[a]))
                {
                    ans = ans * i + Convert.ToInt64(Char.GetNumericValue(s[a]));
                    if (ans > int.MaxValue)
                    {
                        if (isNegative)
                            return int.MinValue;
                        else
                            return int.MaxValue;
                    }
                }
                else
                {
                    if (isNegative)
                    {
                        ans *= -1;
                        return ans < int.MinValue ? int.MinValue : Convert.ToInt32(ans);
                    }
                    else
                    {
                        return ans > int.MaxValue ? int.MaxValue : Convert.ToInt32(ans);
                    }
                }
            }
            if (isNegative)
            {
                ans *= -1;
                return ans < int.MinValue ? int.MinValue : Convert.ToInt32(ans);
            }
            else
            {
                return ans > int.MaxValue ? int.MaxValue : Convert.ToInt32(ans);
            }
        }

        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            string answer = s[0].ToString();
            //for (int i = 0; i < s.Length; i++)
            //{
            //    var str = new StringBuilder();
            //    str.Append(s[i]);
            //    var revStr = new StringBuilder();
            //    revStr.Append(s[i]);
            //    for (int j = i + 1; j < s.Length; j++)
            //    {
            //        str.Append(s[j]);
            //        revStr.Insert(0, s[j]);
            //        if (str.ToString() == revStr.ToString() && str.Length > answer.Length)
            //            answer = str.ToString();
            //    }
            //}
            int j = 0;
            for (int i = 0; i <= j; i++)
            {
                for (j = s.Length - 1; j >= i; j--)
                {
                    if (s[j] == s[i])
                    {

                    }
                }
            }

            return answer;
        }

        public int[] CountPoints(int[][] points, int[][] queries)
        {
            var answer = new int[queries.Length];
            int i = 0;

            foreach (var query in queries)
            {
                int count = 0;
                foreach (var point in points)
                {
                    if (Math.Sqrt((point[0] - query[0]) * (point[0] - query[0]) + (point[1] - query[1]) * (point[1] - query[1])) <= query[2])
                        count++;
                }
                answer[i] = count;
                i++;
            }
            return answer;
        }

        public int[] MinOperations(string boxes)
        {
            var answer = new int[boxes.Length];
            for (int i = 0; i < boxes.Length; i++)
            {
                var value = char.GetNumericValue(boxes[i]);
                if (value == 1)
                {
                    for (int j = 0; j < boxes.Length; j++)
                        answer[j] += Math.Abs(i - j);
                }
            }
            return answer;
        }

        /// <summary>
        /// find each digit's sum with 1 and sum all the representations of 1 by rows and it is the answer which is equals to the maximum number of the string.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MinPartitionsDeciBinary(string n)
        {
            var max = 0;
            if (n.Length == 1) return int.Parse(n);
            for (int i = 0, j = n.Length - 1; i <= j && j >= i; i++, j--)
            {
                max = Math.Max(Math.Max(n[i] - '0', n[j] - '0'), max);
            }
            return Convert.ToInt32(max);
        }

        public int DeepestLeavesSum(TreeNode root)
        {
            TraverseInOrder(root, 0);
            return answer;
        }
        int maxLevel = 0;
        int answer = 0;
        public void TraverseInOrder(TreeNode parent, int level)
        {
            if (parent.left == null && parent.right == null)
            {
                if (maxLevel > level) return;
                if (maxLevel == level) answer += parent.val;
                if (maxLevel < level) maxLevel = level; answer = parent.val;
            }
            else
            {
                if (parent.left != null)
                    TraverseInOrder(parent.left, level + 1);
                if (parent.right != null)
                    TraverseInOrder(parent.right, level + 1);
            }
        }

        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            if (original == null || cloned == null || target == null) return null;
            if (original == target)
                return cloned;
            var left = GetTargetCopy(original.left, cloned.left, target);
            if (left != null) return left;
            var right = GetTargetCopy(original.right, cloned.right, target);
            if (right != null) return right;
            return null;
        }

        public IList<IList<int>> GroupThePeople(int[] groupSizes)
        {
            var list = new List<KeyValuePair<int, int>>();
            var answer = new List<IList<int>>();
            for (int i = 0; i < groupSizes.Length; i++)
            {
                list.Add(new KeyValuePair<int, int>(i, groupSizes[i]));
            }
            list = list.OrderBy(x => x.Value).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                var l = new List<int>();
                int j = i;
                for (j = i; j < i + list[i].Value; j++)
                {
                    l.Add(list[j].Key);
                }
                i = j - 1;
                answer.Add(l);
            }
            return answer;
        }
        public int SumEvenGrandparent(TreeNode root)
        {
            int answer = 0;
            var curr = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (curr != null || stack.Count > 0)
            {
                while (curr != null)
                {
                    if (curr.val % 2 == 0)
                    {
                        int? val = (curr?.left?.left?.val ?? 0) + (curr?.left?.right?.val ?? 0) + (curr?.right?.left?.val ?? 0) + (curr?.right?.right?.val ?? 0);
                        answer += val.GetValueOrDefault();
                    }
                    stack.Push(curr);
                    curr = curr.left;
                }
                curr = stack.Pop().right;
            }
            return answer;
        }

        public class SubrectangleQueries
        {
            public int[][] Rectangle;
            public SubrectangleQueries(int[][] rectangle)
            {
                Rectangle = new int[][]
                {
                    new int[] { 1, 2, 1 },
                    new int[] { 4, 3, 4 },
                    new int[] { 3, 2, 1 },
                    new int[] { 1, 1, 1 }
                };
                UpdateSubrectangle(0, 0, 3, 2, 5);
                UpdateSubrectangle(3, 0, 3, 2, 10);
                for (int y = 0; y < Rectangle.Length; y++)
                {
                    for (int i = 0; i < Rectangle[0].Length; i++)
                    {
                        Console.Write(Rectangle[y][i] + " ");
                    }
                    Console.WriteLine();
                }
            }

            public void UpdateSubrectangle(int row1, int col1, int row2, int col2, int newValue)
            {
                for (int x = col1; x <= col2; x++)
                {
                    for (int y = row1; y <= row2; y++)
                    {
                        Rectangle[y][x] = newValue;
                    }
                }
            }

            public int GetValue(int row, int col)
            {
                return Rectangle[row][col];
            }
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

    }
}
