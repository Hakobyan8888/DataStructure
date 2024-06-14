using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace DataStructureProblems
{
    public class LeetCodeProblems
    {
        public int CountPairs_2824(List<int> nums, int target)
        {
            var result = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                for (int j = i + 1; j < nums.Count; j++)
                {
                    if (nums[i] + nums[j] < target)
                    {
                        result++;
                    }
                }
            }
            return result;
        }

        public int[] SmallerNumbersThanCurrent_1365(int[] nums)
        {
            int[] result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        result[i]++;
                    }
                    else if (nums[i] < nums[j])
                    {
                        result[j]++;
                    }
                }
            }
            return result;
        }

        public int MinimumSum_2160(int num)
        {
            var digits = new List<int>();
            while (num > 0)
            {
                var digit = num % 10;
                num /= 10;
                if (digits.Count == 0)
                {
                    digits.Add(digit);
                    continue;
                }
                for (int i = 0; i < digits.Count; i++)
                {
                    if (digits[i] >= digit)
                    {
                        digits.Insert(i, digit);
                        break;
                    }
                    if (i == digits.Count - 1)
                    {
                        digits.Add(digit);
                        break;
                    }
                }
            }

            var firstNum = digits[0] * 10 + digits[2];
            var secondNum = digits[1] * 10 + digits[3];
            int result = firstNum + secondNum;
            return result;
        }

        public string SortSentence_1859(string s)
        {
            var words = s.Split(' ');
            string[] wordsArray = new string[words.Length];
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                var index = int.Parse(words[i].Last().ToString());
                var word = words[i].Remove(words[i].Length - 1);
                wordsArray[index - 1] = word;
            }
            foreach (var item in wordsArray)
            {
                result.Append($"{item} ");
            }
            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }

        public int MinMovesToSeat_2037(int[] seats, int[] students)
        {
            var result = 0;
            var count = seats.Length;
            for (int i = 1; i < count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (seats[i] < seats[j])
                    {
                        Swap(ref seats, i, j);
                    }
                    if (students[i] < students[j])
                    {
                        Swap(ref students, i, j);
                    }
                }
            }
            for (int i = 0; i < count; i++)
            {
                result += Math.Abs(seats[i] - students[i]);
            }
            return result;
        }

        public int MaxProductDifference_1913(int[] nums)
        {
            var result = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] < nums[j])
                    {
                        Swap(ref nums, i, j);
                    }
                }
            }

            result = (nums[nums.Length - 1] * nums[nums.Length - 2]) - (nums[0] * nums[1]);
            return result;
        }

        public int MaxProduct_1464(int[] nums)
        {
            var result = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var value = (nums[i] - 1) * (nums[j] - 1);
                    if (value > result)
                    {
                        result = value;
                    }
                }
            }
            return result;
        }

        public int[][] SortTheStudents_2545(int[][] score, int k)
        {
            for (int i = 1; i < score.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (score[i][k] > score[j][k])
                    {
                        var temp = score[i];
                        score[i] = score[j];
                        score[j] = temp;
                    }
                }
            }
            return score;
        }

        public int MaxWidthOfVerticalArea_1637(int[][] points)
        {
            var result = 0;
            //for (int i = 1; i < points.Length; i++)
            //{
            //    for (int j = 0; j < i; j++)
            //    {
            //        if (points[i][0] < points[j][0])
            //        {
            //            var temp = points[i];
            //            points[i] = points[j];
            //            points[j] = temp;
            //        }
            //    }
            //}
            points = QuickSort(points, 0, points.Length);
            for (int i = 0; i < points.Length - 1; i++)
            {
                var val = points[i + 1][0] - points[i][0];
                result = val > result ? val : result;
            }
            return result;
        }

        private int[][] QuickSort(int[][] points, int low, int high)
        {
            if (low < high)
            {
                var pivot = Partition(ref points, low, high);

                QuickSort(points, low, pivot);
                QuickSort(points, pivot + 1, high);
            }
            return points;
        }

        private int Partition(ref int[][] points, int low, int high)
        {
            var pivot = low;
            var pivotPosition = low;

            for (int i = low + 1; i < high; i++)
            {
                if (points[pivot][0] > points[i][0])
                {
                    pivotPosition++;
                    var temp1 = points[i];
                    points[i] = points[pivotPosition];
                    points[pivotPosition] = temp1;
                }
            }
            var temp = points[pivotPosition];
            points[pivotPosition] = points[pivot];
            points[pivot] = temp;
            return pivotPosition;
        }

        public int[][] DiagonalSort_1329(int[][] mat)
        {
            int[][] result = new int[mat.Length][];
            PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    priorityQueue.Enqueue(mat[i][j], mat[i][j]);
                }
            }

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new int[mat[i].Length];
            }

            int index = 0;
            while (priorityQueue.Count > 0)
            {
                for (int j = index; j < result[index].Length; j++)
                {
                    result[index][j] = priorityQueue.Dequeue();
                }
                for (int i = index + 1; i < mat.Length; i++)
                {
                    result[i][index] = priorityQueue.Dequeue();
                }
                index++;
            }
            return result;
        }


        public int[][] AcceptedDiagonalSort_1329(int[][] mat)
        {

            var rowLength = mat.Length;
            var columnLength = mat[0].Length;

            for (int i = 0; i < rowLength; i++)
            {
                var list = new List<int>();
                var r = i;
                var c = 0;
                while (r < rowLength && c < columnLength)
                {
                    list.Add(mat[r][c]);
                    r++;
                    c++;
                }

                CountingSort(ref list);

                r = i;
                c = 0;
                while (r < rowLength && c < columnLength)
                {
                    mat[r][c] = list[c];
                    r++;
                    c++;
                }
            }
            for (int i = 0; i < columnLength; i++)
            {
                var list = new List<int>();
                var c = i;
                var r = 0;
                while (r < rowLength && c < columnLength)
                {
                    list.Add(mat[r][c]);
                    r++;
                    c++;
                }

                CountingSort(ref list);

                c = i;
                r = 0;
                while (r < rowLength && c < columnLength)
                {
                    mat[r][c] = list[r];
                    r++;
                    c++;
                }
            }



            return mat;
        }

        public void CountingSort(ref List<int> array)
        {
            int[] count = new int[1000];
            foreach (var item in array)
            {
                count[item]++;
            }

            var index = 0;
            for (int i = 0; i < count.Length; i++)
            {
                for (int j = 0; j < count[i]; j++)
                {
                    array[index++] = i;
                }
            }

            foreach (var item in array)
            {
                Console.Write($"{item}, ");
            }
        }


        public IList<bool> CheckArithmeticSubarrays_1630(int[] nums, int[] l, int[] r)
        {
            List<bool> result = new List<bool>();
            var queryCount = l.Length;

            for (int i = 0; i < queryCount; i++)
            {
                int[] newArray = new int[r[i] - l[i] + 1];
                var index = 0;
                for (int j = l[i]; j < r[i] + 1; j++)
                {
                    newArray[index] = nums[j];
                    index++;
                }
                result.Add(SortAndCheckIsArithmetic(newArray));
            }

            return result;
        }

        private bool SortAndCheckIsArithmetic(int[] array)
        {
            var arithmeticDifference = 0;
            for (int i = 0; i < array.Length; i++)
            {
                var minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                Swap(ref array, minIndex, i);
                if (i == 1)
                {
                    arithmeticDifference = array[i] - array[i - 1];
                }
                else if (i > 0 && array[i] - array[i - 1] != arithmeticDifference)
                {
                    return false;
                }
            }
            return true;
        }

        public int MinPairSum_1877(int[] nums)
        {

            nums = QuickSort(nums, 0, nums.Length);

            var maxValue = int.MinValue;
            int j = nums.Length - 1;
            for (int i = 0; i < nums.Length / 2; i++)
            {
                var sum = nums[i] + nums[j];
                if (sum > maxValue)
                {
                    maxValue = sum;
                }
                j--;
            }
            return maxValue;
        }

        private int[] QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                var pivot = Partition(ref array, low, high);

                QuickSort(array, low, pivot);
                QuickSort(array, pivot + 1, high);
            }
            return array;
        }

        private int Partition(ref int[] array, int low, int high)
        {
            var pivot = low;
            var pivotPosition = low;

            for (int i = low + 1; i < high; i++)
            {
                if (array[i] < array[pivot])
                {
                    pivotPosition++;
                    Swap(ref array, i, pivotPosition);
                }
            }
            Swap(ref array, pivot, pivotPosition);
            return pivotPosition;
        }

        private void Swap(ref int[] array, int indexI, int indexJ)
        {
            if (indexI == indexJ) return;
            var indexIValue = array[indexI];
            array[indexI] = array[indexJ];
            array[indexJ] = indexIValue;
        }

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
