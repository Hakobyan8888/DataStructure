using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static DataStructureProblems.LeetCodeProblems;

namespace DataStructureProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = new SubrectangleQueries(null);
            var leetCodeProblems = new LeetCodeProblems();
            //var b = new int[3][] { new int[4] { 3, 3, 1, 1 }, new int[4] { 2, 2,1,2 }, new int[4] { 1, 1, 1, 2 } };
            var a = leetCodeProblems.MinPairSum_1877(new int[] { 5, 2, 1, 1, 4, 4, 1, 2, 1, 5 });
            //var a = leetCodeProblems.GroupThePeople(new int[6] { 2, 1, 3, 3, 3, 2 });
            //TreeNode listNode2 = new TreeNode()
            //{
            //    val = 6,
            //    left = new TreeNode()
            //    {
            //        val = 7,
            //        right = new TreeNode
            //        {
            //            val = 7,
            //            right = new TreeNode
            //            {
            //                val = 4
            //            }
            //        },
            //        left = new TreeNode
            //        {
            //            val = 2
            //        }
            //    },
            //    right = new TreeNode()
            //    {
            //        val = 8,
            //        left = new TreeNode()
            //        {
            //            val = 1,
            //        },
            //        right = new TreeNode
            //        {
            //            val = 3,
            //            right = new TreeNode
            //            {
            //                val = 5,
            //            }
            //        }

            //    }
            //};
            //var a = leetCodeProblems.SumEvenGrandparent(listNode2);
            //foreach (var l in a)
            //{
            //    foreach (var s in l)
            //        Console.Write(s + " ");
            //    Console.WriteLine();
            //}
            //Console.WriteLine(leetCodeProblems.LongestPalindrome("klvxwqyzugrdoaccdafdfrvxiowkcuedfhoixzipxrkzbvpusslsgfjocvidnpsnkqdfnnzzawzsslwnvvjyoignsfbxkgrokzyusxikxumrxlzzrnbtrixxfioormoyyejashrowjqqzifacecvoruwkuessttlexvdptuvodoavsjaepvrfvbdhumtuvxufzzyowiswokioyjtzzmevttheeyjqcldllxvjraeyflthntsmipaoyjixygbtbvbnnrmlwwkeikhnnmlfspjgmcxwbjyhomfjdcnogqjviggklplpznfwjydkxzjkoskvqvnxfzdrsmooyciwulvtlmvnjbbmffureoilszlonibbcwfsjzguxqrjwypwrskhrttvnqoqisdfuifqnabzbvyzgbxfvmcomneykfmycevnrcsyqclamfxskmsxreptpxqxqidvjbuduktnwwoztvkuebfdigmjqfuolqzvjincchlmbrxpqgguwuyhrdtwqkdlqidlxzqktgzktihvlwsbysjeykiwokyqaskjjngovbagspyspeghutyoeahhgynzsyaszlirmlekpboywqdliumihwnsnwjc"));
            //ListNode listNode1 = new ListNode()
            //{
            //    val = 5,
            //    next = new ListNode()
            //    {
            //        val = 6,
            //    }
            //};

            //leetCodeProblems.AddTwoNumbersMedium(listNode1, listNode2);
            var sortingAlgo = new SortingAlgorithms();
            var array = new List<int>() { 8,9,7,9 };
            sortingAlgo.QuickSort(array);
            Console.ReadLine();
        }

        public static LinkedList<int> ReverseLinkedList(LinkedList<int> list, int operationsCount, int index)
        {
            if (operationsCount == list.Count - 1)
                return list;
            else
            {
                var node = list.ElementAt(index);
                list.Remove(list.ElementAt(index));
                list.AddFirst(node);
                return ReverseLinkedList(list, operationsCount + 1, index + 1);
            }
        }


        static int count = 0;
        public static void Timus1930()
        {
            Graph<int> graph = new Graph<int>();
            GraphAlgorithms<int> graphAlgorithms = new GraphAlgorithms<int>();
            var input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            List<Tuple<int, int>> comb = new List<Tuple<int, int>>();

            for (int i = 1; i < n + 1; i++)
            {
                graph.AddVertexToList(i);
            }
            for (int i = 0; i < m; i++)
            {
                var inp = Console.ReadLine().Split();
                int x = int.Parse(inp[0]);
                int y = int.Parse(inp[1]);
                comb.Add(Tuple.Create(x, y));
                graph.AddEdgeToList(Tuple.Create(x, y, 1.0));
            }
            var lastInput = Console.ReadLine().Split();
            int start = int.Parse(lastInput[0]);
            int end = int.Parse(lastInput[1]);


            var answer = graphAlgorithms.ShortestPathFunction(graph, start);
            var ans = answer.Invoke(end).ToList();
            var bfs = graphAlgorithms.BFS(graph, start);
            if (ans.Count == 2)
            {
                Console.WriteLine("0");
                return;
            }
            for (int i = 1; i < ans.Count - 1; i++)
            {
                if (comb.Contains(Tuple.Create(ans[i], ans[i + 1]))) continue;
                count++;
            }
            Console.WriteLine(count);
        }

        //static void Timus1320()
        //{
        //    Graph<int> graph = new Graph<int>();
        //    GraphAlgorithms<int> graphAlgorithms = new GraphAlgorithms<int>();
        //    string[] s = Console.In.ReadToEnd().Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        //    for (int i = 0; i < s.Length; i += 2)
        //    {
        //        var first = int.Parse(s[i]);
        //        var second = int.Parse(s[i + 1]);
        //        graph.AddVertexToList(first);
        //        graph.AddVertexToList(second);
        //        graph.AddEdgeToList(Tuple.Create(first, second, 1d), true);
        //    }

        //    var answer = graphAlgorithms.FindComponents(graph);
        //    foreach(var item in answer)
        //    {
        //        var list = new List<int>();
        //        foreach (var a in item.Value)
        //            list.AddRange(graph.AdjacencyList[a].ToList());

        //        if (item.Value.Count % 2 != 0)
        //        {
        //            Console.WriteLine(1);
        //            return;
        //        }

        //    }
        //    Console.WriteLine(0);
        //}


        static void Timus1354()
        {
            Stack<char> stack = new Stack<char>();

            var input = Console.ReadLine();

            var s = new StringBuilder(input);
            for (int i = 0; i < s.Length; i++)
            {
                s.Insert(s.Length - i, s[i]);
                if (IsPalindrome(s))
                {
                    Console.WriteLine(s);
                    return;
                }
            }
        }

        static bool IsPalindrome(StringBuilder word)
        {
            var l = word.Length;
            for (var i = 0; i < l / 2; i++)
            {
                if (word[i] != word[l - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }

        //static void Timus1111()
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    List<Square> squares = new List<Square>();
        //    for (int i = 0; i < n; i++)
        //    {
        //        var input = Console.ReadLine().Split();
        //        var firstPoint = new Point(int.Parse(input[0]), int.Parse(input[1]));
        //        var secondPoint = new Point(int.Parse(input[2]), int.Parse(input[3]));
        //        var thirdPoint = new Point(secondPoint.X, firstPoint.Y);
        //        var forthPoint = new Point(secondPoint.Y, firstPoint.X);
        //        squares.Add(new Square(firstPoint, secondPoint, thirdPoint, forthPoint));
        //    }

        //    var inp = Console.ReadLine().Split();
        //    var point = new Point(int.Parse(inp[0]), int.Parse(inp[1]));

        //    //for (int i = 0; i < n; i++)
        //    //{
        //    //    if(squares[i].point1.X >= )
        //    //}


        //}

        //struct Square
        //{
        //    public Point point1;
        //    public Point point2;
        //    public Point point3;
        //    public Point point4;

        //    public Square(Point point1, Point point2, Point point3, Point point4)
        //    {
        //        this.point1 = point1;
        //        this.point2 = point2;
        //        this.point3 = point3;
        //        this.point4 = point4;
        //    }
        //}

        //static void Timus1542()
        //{
        //    var trie = new Trie();
        //    var N = Convert.ToInt32(Console.ReadLine());
        //    var dict = new Dictionary<string, int>();
        //    for (int i = 0; i < N; i++)
        //    {
        //        var input = Console.ReadLine().Split();
        //        var str = input[0];
        //        var n = int.Parse(input[1]);
        //        dict.Add(str, n);
        //        trie.InsertWord(str);
        //    }
        //    var words = dict.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToList();
        //    var m = Convert.ToInt32(Console.ReadLine());
        //    for (int i = 0; i < m; i++)
        //    {
        //        var s = Console.ReadLine();
        //        var list = trie.GetWordsForPrefix(s);
        //        var count = 0;
        //        var all = words.Where(x => list.Contains(x.Key));
        //        foreach (var w in all)
        //        {
        //            count++;
        //            Console.WriteLine(w.Key);
        //            if (count == 10)
        //                break;
        //        }
        //        if (i != m - 1)
        //            Console.WriteLine();
        //    }
        //}

    }

    public class Job
    {
        public int start;
        public int finish;
        public int profit;
        public Job(int start, int finish, int profit)
        {
            this.start = start;
            this.finish = finish;
            this.profit = profit;
        }
    }
}
