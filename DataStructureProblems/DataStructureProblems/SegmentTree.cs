using System;
namespace DataStructureProblems
{
    public struct Node
    {
        public int pairs;
        public int open;
        public int closed;
    }
    public class SegmentTree
    {
        private long[] _tree;
        private Tuple<long, long>[] _treeTuples;
        private Node[] _treeBrackets;
        public SegmentTree(int n)
        {
            _tree = new long[4 * n];
            _treeTuples = new Tuple<long, long>[4 * n];
            _treeBrackets = new Node[4 * n];
        }
        public void UpdateValue(int[] arr, int n, int updateIndex, int newValue)
        {
            var diff = newValue - arr[updateIndex];
            arr[updateIndex] = newValue;
            UpdateValue(0, n - 1, updateIndex, diff, 0);
        }
        public void UpdateValue(int left, int right, int updateIndex, int diff, int index)
        {
            if (left == right)
            {
                _tree[index] = _tree[index] + diff;
                return;
            }
            var mid = GetMid(left, right);
            if (mid >= updateIndex)
                UpdateValue(left, mid, updateIndex, diff, 2 * index);
            else
                UpdateValue(mid + 1, right, updateIndex, diff, 2 * index + 1);
            _tree[index] = _tree[2 * index] + _tree[2 * index + 1];
        }
        private int GetMid(int s, int e)
        {
            return s + (e - s) / 2;
        }
        #region Sum
        public long BuildSumTree(int[] arr, int left, int right, int index)
        {
            if (left == right)
            {
                _tree[index] = arr[left];
                return arr[left];
            }
            var mid = GetMid(left, right);
            _tree[index] = BuildSumTree(arr, left, mid, index * 2) +
                           BuildSumTree(arr, mid + 1, right, index * 2 + 1);
            return _tree[index];
        }
        public long GetSum(int left, int right, int queryStart, int queryEnd, int index)
        {
            if (queryStart > queryEnd)
                return 0;
            if (left > right)
                return 0;
            if (queryStart == left && queryEnd == right)
                return _tree[index];
            var mid = GetMid(left, right);
            return GetSum(left, mid, queryStart, Math.Min(mid, queryEnd), 2 * index) +
                   GetSum(mid + 1, right, Math.Max(mid + 1, queryStart), queryEnd, 2 * index + 1);
        }
        #endregion
        #region Sub
        public long BuildSubTree(int[] arr, int left, int right, int index)
        {
            if (left == right)
            {
                _tree[index] = arr[left];
                return arr[left];
            }
            var mid = GetMid(left, right);
            _tree[index] = BuildSubTree(arr, left, mid, index * 2 + 1) -
                           BuildSubTree(arr, mid + 1, right, index * 2 + 2);
            return _tree[index];
        }
        public long GetSub(int left, int right, int queryStart, int queryEnd, int index)
        {
            if (queryStart <= left && queryEnd >= right)
                return _tree[index];
            if (right < queryStart || left > queryEnd)
                return 0;
            var mid = GetMid(left, right);
            return GetSub(left, mid, queryStart, queryEnd, 2 * index + 1) -
                   GetSub(mid + 1, right, queryStart, queryEnd, 2 * index + 2);
        }
        #endregion
        #region Max
        public long BuildMaxTree(int[] arr, int left, int right, int index)
        {
            if (left == right)
            {
                _tree[index] = arr[left];
                return arr[left];
            }
            var mid = GetMid(left, right);
            _tree[index] = Math.Max(BuildMaxTree(arr, left, mid, index * 2 + 1),
                BuildMaxTree(arr, mid + 1, right, index * 2 + 2));
            return _tree[index];
        }
        public long GetMax(int left, int right, int queryStart, int queryEnd, int index)
        {
            if (queryStart <= left && queryEnd >= right)
                return _tree[index];
            if (right < queryStart || left > queryEnd)
                return int.MinValue;
            var mid = GetMid(left, right);
            return Math.Max(GetMax(left, mid, queryStart, queryEnd, 2 * index + 1),
                GetMax(mid + 1, right, queryStart, queryEnd, 2 * index + 2));
        }
        #endregion
        #region Min
        public long BuildMinTree(int[] arr, int left, int right, int index)
        {
            if (left == right)
            {
                _tree[index] = arr[left];
                return arr[left];
            }
            var mid = GetMid(left, right);
            _tree[index] = Math.Min(BuildMinTree(arr, left, mid, index * 2 + 1),
                BuildMinTree(arr, mid + 1, right, index * 2 + 2));
            return _tree[index];
        }
        public long GetMin(int left, int right, int queryStart, int queryEnd, int index)
        {
            if (queryStart <= left && queryEnd >= right)
                return _tree[index];
            if (right < queryStart || left > queryEnd)
                return int.MaxValue;
            var mid = GetMid(left, right);
            return Math.Min(GetMin(left, mid, queryStart, queryEnd, 2 * index + 1),
                GetMin(mid + 1, right, queryStart, queryEnd, 2 * index + 2));
        }
        #endregion
        #region Gcd
        public void BuildGcdTree(long[] arr, int left, int right, int index)
        {
            if (left == right)
            {
                _tree[index] = arr[left];
            }
            else
            {
                int mid = (left + right) / 2;
                BuildGcdTree(arr, left, mid, index * 2);
                BuildGcdTree(arr, mid + 1, right, index * 2 + 1);
                _tree[index] = Gcd(_tree[index * 2], _tree[index * 2 + 1]);
            }
        }
        public long GetGcd(int left, int right, long queryStart, long queryEnd, int index)
        {
            if (queryStart > queryEnd)
                return 0;
            if (queryStart == left && queryEnd == right)
                return _tree[index];
            int mid = (left + right) / 2;
            var l = GetGcd(left, mid, queryStart, Math.Min(mid, queryEnd), index * 2);
            var r = GetGcd(mid + 1, right, Math.Max(mid + 1, queryStart), queryEnd, index * 2 + 1);
            return Gcd(l, r);
        }
        private long Gcd(long a, long b)
        {
            return b == 0 ? a : Gcd(b, a % b);
        }
        #endregion
        #region AdditionalMin
        public Tuple<long, long> GetMinimum(Tuple<long, long> a, Tuple<long, long> b)
        {
            if (a.Item1 == b.Item1)
                return Tuple.Create(a.Item1, a.Item2 + b.Item2);
            return a.Item1 < b.Item1 ? a : b;
        }
        public void BuildAdditionalMinTree(Tuple<long, long>[] arr, int left, int right, int index)
        {
            if (left == right)
            {
                _treeTuples[index] = arr[left];
            }
            else
            {
                int mid = (left + right) / 2;
                BuildAdditionalMinTree(arr, left, mid, index * 2);
                BuildAdditionalMinTree(arr, mid + 1, right, index * 2 + 1);
                _treeTuples[index] = GetMinimum(_treeTuples[index * 2], _treeTuples[index * 2 + 1]);
            }
        }
        public Tuple<long, long> GetAdditionalMin(int left, int right, long queryStart, long queryEnd, int index)
        {
            if (queryStart > queryEnd)
                return Tuple.Create(long.MaxValue, 0l);
            if (queryStart == left && queryEnd == right)
                return _treeTuples[index];
            int mid = (left + right) / 2;
            var l = GetAdditionalMin(left, mid, queryStart, Math.Min(mid, queryEnd), index * 2);
            var r = GetAdditionalMin(mid + 1, right, Math.Max(mid + 1, queryStart), queryEnd, index * 2 + 1);
            return GetMinimum(l, r);
        }
        #endregion
        #region NodeBrackets
        public Node GetCorrectBracket(Node leftChild, Node rightChild)
        {
            Node parentNode;
            var minMatched = Math.Min(leftChild.open, rightChild.closed);
            parentNode.pairs = leftChild.pairs + rightChild.pairs + minMatched;
            parentNode.open = leftChild.open + rightChild.open - minMatched;
            parentNode.closed = leftChild.closed + rightChild.closed - minMatched;
            return parentNode;
        }
        public void BuildBracketTree(string bracket, int left, int right, int index)
        {
            if (left == right)
            {
                _treeBrackets[index].open = bracket[left] == '(' ? 1 : 0;
                _treeBrackets[index].closed = bracket[left] == ')' ? 1 : 0;
            }
            else
            {
                int mid = (left + right) / 2;
                BuildBracketTree(bracket, left, mid, index * 2);
                BuildBracketTree(bracket, mid + 1, right, index * 2 + 1);
                _treeBrackets[index] = GetCorrectBracket(_treeBrackets[index * 2], _treeBrackets[index * 2 + 1]);
            }
        }
        public Node GetBracket(int left, int right, long queryStart, long queryEnd, int index)
        {
            if (queryStart > queryEnd)
                return new Node();
            if (queryStart == left && queryEnd == right)
                return _treeBrackets[index];
            int mid = (left + right) / 2;
            var l = GetBracket(left, mid, queryStart, Math.Min(mid, queryEnd), index * 2);
            var r = GetBracket(mid + 1, right, Math.Max(mid + 1, queryStart), queryEnd, index * 2 + 1);
            return GetCorrectBracket(l, r);
        }
        #endregion
    }
}
