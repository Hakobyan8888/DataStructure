using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;

namespace DataStructureProblems
{
    class PassedTimusProblems
    {

        static void Timus1026()
        {
            int n = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();
            for (int i = 0; i < n; i++)
            {
                numbers.Add(int.Parse(Console.ReadLine()));
            }
            numbers.Sort();

            var a = Console.ReadLine();
            int k = int.Parse(Console.ReadLine());

            for (int i = 0; i < k; i++)
            {
                int q = int.Parse(Console.ReadLine());
                Console.WriteLine(numbers[q - 1]);
            }

        }

        static void Timus1052()
        {
            int n = int.Parse(Console.ReadLine());
            List<Point> points = new List<Point>();

            for (int i = 0; i < n; i++)
            {
                var xy = Console.ReadLine().Split();
                points.Add(new Point(int.Parse(xy[0]), int.Parse(xy[1])));
            }
            Console.WriteLine(MaxPointsOnLine(points));
        }

        static int MaxPointsOnLine(List<Point> points)
        {
            int N = points.Count;
            if (N < 2)
                return N;

            int maxPoint = 0;
            int curMax, overlapPoints, verticalPoints;

            Dictionary<Point, List<Point>> slopePairs = new Dictionary<Point, List<Point>>();

            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    int deltaY = points[j].Y - points[i].Y;
                    int deltaX = points[j].X - points[i].X;
                    int g = GCD(deltaX, deltaY);

                    deltaY /= g;
                    deltaX /= g;
                    var point = new Point(deltaY, deltaX);
                    if (!slopePairs.ContainsKey(point))
                        slopePairs.Add(point, new List<Point>());
                    slopePairs[point].Add(points[i]);
                    slopePairs[point].Add(points[j]);

                }
                slopePairs.Clear();
            }

            return maxPoint;
        }

        static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        static List<Tuple<long, long, int>> tastes = new List<Tuple<long, long, int>>();
        static void Timus2067()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var s = long.Parse(input[0]);
                var r = long.Parse(input[1]);
                tastes.Add(Tuple.Create(s, r, i + 1));
            }
            if (n == 2)
            {
                Console.WriteLine(1);
                Console.WriteLine($"1 2");
                return;
            }
            var a = true;

            for (int i = 2; i < n; i++)
            {
                if (!IsBestFriend(i - 2, i - 1, i))
                {
                    a = false;
                    break;
                }
            }
            if (a)
            {
                var l = tastes.OrderBy(x => x.Item1).ThenBy(y => y.Item2);
                Console.WriteLine(1);
                Console.WriteLine($"{l.First().Item3} {l.Last().Item3}");
            }
            else
                Console.WriteLine(0);

        }

        static bool IsBestFriend(int v, int u, int w)
        {
            return (tastes[u].Item2 - tastes[v].Item2) * (tastes[w].Item1 - tastes[v].Item1) == (tastes[w].Item2 - tastes[v].Item2) * (tastes[u].Item1 - tastes[v].Item1);
        }

        static void Timus1640()
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var x = new int[n];
            var y = new int[n];
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                x[i] = input[0];
                y[i] = input[1];
            }
            var t = 0.5000000000;
            var r = double.MinValue;
            for (int i = 0; i < n; i++)
            {
                var x1 = x[i] - t;
                var y1 = y[i] - t;
                var sqrt = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
                if (sqrt > r)
                {
                    r = sqrt;
                }
            }
            Console.WriteLine("{0} {1} {2}", t, t, Math.Round(r, 10));
        }

        static void Timus1028()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            var st = new SegmentTree(40000);
            var level = new int[n];
            for (int i = 0; i < n; i++)
            {
                var temp = Console.ReadLine().Split(' ');
                var x = int.Parse(temp[0]);
                //level[st.GetSum(0, 40000, 0, x, 0)]++;
                st.UpdateValue(0, 40000, x, 1, 0);
            }
            for (int i = 0; i < level.Length; i++)
            {
                Console.WriteLine(level[i]);
            }
        }

        static void Timus2035()
        {
            string[] input = Console.ReadLine().Split();

            int x = int.Parse(input[0]);
            int y = int.Parse(input[1]);
            int c = int.Parse(input[2]);

            if (x + y < c)
            {
                Console.WriteLine("Impossible");
            }
            else
            {
                int a = Math.Min(x, y);
                int b = c - a;
                while (b < 0 && a > 0)
                {
                    a--;
                    b = c - a;
                }
                if (b > y || a > x)
                {
                    int temp = a;
                    a = b;
                    b = temp;
                }
                Console.WriteLine($"{a} {b}");
            }

        }

        static void Timus1025()
        {
            int n = int.Parse(Console.ReadLine());
            List<int> groups = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => int.Parse(arrTemp)).ToList();

            groups.Sort();

            int minGroups = 0;

            if (groups.Count % 2 == 1)
            {
                minGroups = groups.Count / 2;
            }
            else
            {
                minGroups = groups.Count / 2 - 1;
            }

            int answer = 0;

            for (int i = 0; i <= minGroups; i++)
            {
                answer += groups[i] / 2 + 1;
            }

            Console.WriteLine(answer);
        }

        static void Timus1224()
        {
            string[] input = Console.ReadLine().Split();
            long n = int.Parse(input[0]);
            long m = int.Parse(input[1]);

            long answer = Math.Min(2 * (n - 1), 2 * m - 1);
            Console.WriteLine(answer);

        }

        static void Timus1457()
        {
            int n = int.Parse(Console.ReadLine());
            var items = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => int.Parse(arrTemp));
            double answer = 0;
            foreach (var item in items)
            {
                answer += item;
            }

            answer /= n;
            Console.WriteLine(string.Format("{0:0.000000}", answer));

        }

        static void Timus1083()
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            string factors = input[1];
            int answer = n;
            var a = n % factors.Length;
            int i = 1;
            while (n - i * factors.Length > 0)
            {
                answer *= n - i * factors.Length;
                i++;
            }
            Console.WriteLine(answer);
        }

        static void Timus1638()
        {
            string[] input = Console.ReadLine().Split();


        }

        static void Timus1935()
        {
            int n = int.Parse(Console.ReadLine());
            var items = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => int.Parse(arrTemp)).ToList();
            items.Sort();
            int answer = items[0];

            for (int i = 1; i < n; i++)
            {
                answer += Math.Max(items[i], items[i - 1]);
            }
            answer += items.Last();
            Console.WriteLine(answer);
        }

        static void Timus2031()
        {
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                Console.WriteLine("11");
            }
            else if (n == 2)
            {
                Console.WriteLine("11 01");
            }
            else if (n == 3)
            {
                Console.WriteLine("06 68 88");
            }
            else if (n == 4)
            {
                Console.WriteLine("16 06 68 88");
            }
            else
            {
                Console.WriteLine("Glupenky Pierre");
            }
        }

        static void Timus2111()
        {
            int n = int.Parse(Console.ReadLine());
            var items = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => long.Parse(arrTemp));
            items = mergeSort(items);
            long answer = 0;
            long sum = items.Sum();
            for (int i = 0; i < n; i++)
            {
                answer += sum * items[i];
                sum -= items[i];
                answer += sum * items[i];
            }
            Console.WriteLine(answer);
        }

        public static long[] mergeSort(long[] array)
        {
            long[] left;
            long[] right;
            long[] result = new long[array.Length];
            if (array.Length <= 1)
                return array;
            long midPoint = array.Length / 2;
            left = new long[midPoint];
            if (array.Length % 2 == 0)
                right = new long[midPoint];
            else
                right = new long[midPoint + 1];
            for (long i = 0; i < midPoint; i++)
                left[i] = array[i];
            long x = 0;
            for (long i = midPoint; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }
            left = mergeSort(left);
            right = mergeSort(right);
            result = merge(left, right);
            return result;
        }

        public static long[] merge(long[] left, long[] right)
        {
            long resultLength = right.Length + left.Length;
            long[] result = new long[resultLength];
            long indexLeft = 0, indexRight = 0, indexResult = 0;
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    if (left[indexLeft] >= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }

        static void Timus1502()
        {
            long n = int.Parse(Console.ReadLine());

            Console.WriteLine(n * (n + 1) * (n + 2) / 2);
        }

        static void Timus1131()
        {
            string[] input = Console.ReadLine().Split();
            long n = int.Parse(input[0]);
            long k = int.Parse(input[1]);
            long currentComps = 2;
            long time = 1;
            if (k == 1)
            {
                time = n - 1;
                Console.WriteLine(time);
                return;
            }
            if (n == 1)
            {
                Console.WriteLine("0");
                return;
            }
            while (currentComps < Math.Min(k, n))
            {
                currentComps += currentComps;
                time += 1;
            }
            if (currentComps < n)
            {
                if ((n - currentComps) % k == 0)
                    time += (n - currentComps) / k;
                else
                    time += (n - currentComps) / k + 1;
            }
            Console.WriteLine(time);
        }

        static void Timus1792()
        {
            var items = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => long.Parse(arrTemp));

            long count = 0;
            for (int i = 0; i < 7; i++)
            {
                items[i] = items[i] == 1 ? 0 : 1;
                if (items[4] == (items[1] + items[2] + items[3]) % 2)
                {
                    count++;
                }
                if (items[5] == (items[0] + items[2] + items[3]) % 2)
                {
                    count++;
                }
                if (items[6] == (items[0] + items[1] + items[3]) % 2)
                {
                    count++;
                }
                if (count == 3)
                {
                    break;
                }
                else
                {
                    items[i] = items[i] == 1 ? 0 : 1;
                    count = 0;
                }
            }
            foreach (var item in items)
            {
                Console.Write(item + " ");
            }


        }

        static void Timus1139()
        {
            string[] input = Console.ReadLine().Split();
            int divider = int.Parse(input[0]) - 1;
            int divident = int.Parse(input[1]) - 1;

            int answer = divider + divident - FindCrossesOnTheWay(divident, divider);
            Console.WriteLine(answer);
        }

        static int FindCrossesOnTheWay(int divider, int divident)
        {
            if (divider < divident)
            {
                int temp = divider;
                divider = divident;
                divident = temp;
            }
            int crosses = 0;
            for (int i = 1; i <= divider; i++)
            {
                if ((divident * i) % divider == 0) crosses++;
            }
            return crosses;
        }

        static void Timus1290()
        {
            int n = int.Parse(Console.ReadLine());
            long[] arr = new long[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            arr = mergeSort(arr);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        static void Timus1404()
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string input = Console.ReadLine();
            int[] arr = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                arr[i] = alphabet.IndexOf(input[i]);
            }
            for (int i = 1; i < arr.Length; i++)
            {
                int secStep = 0;
                while ((secStep + arr[i - 1]) % 26 != arr[i])
                {
                    secStep++;
                }
                arr[i] = arr[i - 1] + secStep;
            }
            for (int i = arr.Length - 1; i > 0; i--)
            {
                arr[i] -= arr[i - 1];
            }
            arr[0] -= 5;
            if (arr[0] < 0)
            {
                arr[0] += 26;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(alphabet[arr[i]]);
            }
        }

        static void Timus2011()
        {
            int n = int.Parse(Console.ReadLine());

            var items = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => long.Parse(arrTemp)).ToList();
            items.Sort();
            if (items.All(x => x == items.First()) || items.Count < 3)
            {
                Console.WriteLine("No");
                return;
            }

            if (items.Count >= 6)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                if (items.Contains(1) && items.Contains(2) && items.Contains(3))
                {
                    Console.WriteLine("Yes");
                    return;
                }
                else if (items.Count == 4)
                {
                    if (items.First() == items[2] || items[1] == items.Last())
                    {
                        Console.WriteLine("No");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Yes");
                        return;
                    }
                }
                else if (items.Count == 5)
                {
                    if (items.Last() != items[items.Count - 2])
                    {
                        Console.WriteLine("No");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Yes");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("No");
                    return;
                }
            }
        }

        static void Timus2025()
        {
            int t, n, k, i, a, b, x, res;
            t = int.Parse(Console.ReadLine());
            for (i = 0; i < t; i++)
            {
                string[] input = Console.ReadLine().Split();
                n = int.Parse(input[0]);
                k = int.Parse(input[1]);
                if (n % k == 0)
                {
                    x = n / k;
                    res = n * (n - x) / 2;
                    Console.WriteLine(res);
                }
                else
                {
                    x = n / k;
                    b = n - k * x;
                    a = k - b;
                    res = ((n - x) * a * x + (n - x - 1) * (x + 1) * b) / 2;
                    Console.WriteLine(res);
                }
            }
        }

        static void Timus1353()
        {
            var s = Convert.ToInt32(Console.ReadLine());
            var VF = new long[s + 1];
            VF[0] = 1;
            if (s == 1)
                Console.WriteLine(10);
            else
            {
                for (int i = 1; i < 10; i++)
                    for (int j = s; j >= 0; j--)
                        for (int d = 1; d <= Math.Min(9, j); d++)
                            VF[j] += VF[j - d];
                Console.WriteLine(VF[s]);
            }
        }
        static int count = 0;

        public static long[] VF;
        static void Timus2068()
        {
            int n = int.Parse(Console.ReadLine());
            var items = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => long.Parse(arrTemp)).ToList();
            items.Sort();
            var comb = items;
            bool firstPlayer = true;

            foreach (var item in items)
            {
                if (item / 2 % 2 == 0)
                {
                    firstPlayer = !firstPlayer;
                }
            }
            if (firstPlayer)
                Console.WriteLine("Daenerys");
            else
                Console.WriteLine("Stannis");
        }

        //static void Timus1297()
        //{
        //    string input = Console.ReadLine();
        //    var inputReverse = input.Reverse().ToList();
        //    string inReverse = "";
        //    for (int i = 0; i < inputReverse.Count(); i++)
        //    {
        //        inReverse += inputReverse[i];
        //    }
        //    StringHashStruct inputHash = new StringHashStruct(input);
        //    StringHashStruct inputReverseHash = new StringHashStruct(inReverse);

        //    List<string> result = new List<string>();

        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        for (int j = i; j < input.Length; j++)
        //        {
        //            if (inputHash.GetSubstringHash(i, j) == inputReverseHash.GetSubstringHash(input.Length - j - 1, input.Length - i - 1))
        //            {
        //                result.Add(input.Substring(i, j - i + 1));
        //            }
        //        }
        //    }
        //    if (result[0].First() != result[0].Last())
        //        result.Remove(result[0]);
        //    Console.WriteLine(result.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur));

        //}

        static void Timus1837()
        {
            int n = int.Parse(Console.ReadLine());
            Graph<string> graph = new Graph<string>();
            GraphAlgorithms<string> algorithms = new GraphAlgorithms<string>();
            string name = "Isenbaev";
            bool isIsenbayev = false;
            double dist = 1;
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                if (!isIsenbayev && input.Contains("Isenbaev")) isIsenbayev = true;
                graph.AddVertexToList(input[0]);
                graph.AddVertexToList(input[1]);
                graph.AddVertexToList(input[2]);
                graph.AddEdgeToList(Tuple.Create(input[0], input[1], dist));
                graph.AddEdgeToList(Tuple.Create(input[0], input[2], dist));
                graph.AddEdgeToList(Tuple.Create(input[1], input[2], dist));
            }
            var names = new List<string>(graph.AdjacencyList.Keys.ToList());
            names.Sort();
            if (!isIsenbayev)
            {
                foreach (var vertex in names)
                {
                    Console.WriteLine($"{vertex} undefined");
                }
                return;
            }

            var bfs = algorithms.BFS(graph, name);
            foreach (var vertex in names)
            {
                if (bfs.ContainsKey(vertex))
                {
                    Console.WriteLine($"{vertex} {bfs[vertex]}");
                }
                else
                {
                    Console.WriteLine($"{vertex} undefined");
                }
            }
        }

        static void KingEscape()
        {
            int n = int.Parse(Console.ReadLine());
            Graph<KeyValuePair<int, int>> graph = new Graph<KeyValuePair<int, int>>((n + 1) * (n + 1));
            GraphAlgorithms<KeyValuePair<int, int>> graphAlgorithms = new GraphAlgorithms<KeyValuePair<int, int>>();
            int[,] matrix = new int[n, n];
            var input = Console.ReadLine().Split();
            var queenPoint = new KeyValuePair<int, int>(int.Parse(input[0]), int.Parse(input[1]));
            input = Console.ReadLine().Split();
            var kingPoint = new KeyValuePair<int, int>(int.Parse(input[0]), int.Parse(input[1]));
            input = Console.ReadLine().Split();
            var finalPoint = new KeyValuePair<int, int>(int.Parse(input[0]), int.Parse(input[1]));
            graph.AddVertexToList(kingPoint);
            int[] directionRow = new int[] { -1, 1, 0, 0, -1, -1, 1, 1 };
            int[] directionColumn = new int[] { 0, 0, -1, 1, -1, 1, -1, 1 };
            int x = queenPoint.Key;
            int y = queenPoint.Value;
            while (x > -1 && y > -1)
            {
                matrix[x, y] = -1;
                x--;
                y--;
            }
            x = queenPoint.Key;
            y = queenPoint.Value;
            while (x < n && y < n)
            {
                matrix[x, y] = -1;
                x++;
                y++;
            }
            x = queenPoint.Key;
            y = queenPoint.Value;
            while (x > -1)
            {
                matrix[x, y] = -1;
                x--;
            }
            x = queenPoint.Key;
            y = queenPoint.Value;
            while (y > -1)
            {
                matrix[x, y] = -1;
                y--;
            }
            x = queenPoint.Key;
            y = queenPoint.Value;
            while (x < n)
            {
                matrix[x, y] = -1;
                x++;
            }
            x = queenPoint.Key;
            y = queenPoint.Value;
            while (y < n)
            {
                matrix[x, y] = -1;
                y++;
            }
            int i;
            int j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    if (matrix[i, j] == -1) continue;
                    graph.AddVertexToList(new KeyValuePair<int, int>(i, j));
                    for (int k = 0; k < 8; k++)
                    {
                        int rr = i + directionRow[k];
                        int cc = j + directionColumn[k];
                        if (rr < 0 || cc < 0 || rr > n - 1 || cc > n - 1 || matrix[rr, cc] == -1) continue;
                        graph.AddVertexToList(new KeyValuePair<int, int>(rr, cc));
                        graph.AddEdgeToList(Tuple.Create(new KeyValuePair<int, int>(i, j), new KeyValuePair<int, int>(rr, cc), 1d), true);
                    }
                }
            }

            var ans = graphAlgorithms.ShortestPathFunction(graph, kingPoint);
            var answer = ans.Invoke(finalPoint);
            if (answer == null) Console.WriteLine("NO");
            else Console.WriteLine("YES");
        }

        static void Timus1982()
        {
            Graph<int> graph = new Graph<int>();
            GraphAlgorithms<int> graphAlgorithms = new GraphAlgorithms<int>();
            var input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);
            double[,] matrix = new double[n, n];

            List<int> builtStations = new List<int>();
            if (k > 0)
                builtStations = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => int.Parse(arrTemp)).ToList();


            for (int i = 0; i < n; i++)
            {
                graph.AddVertexToList(i + 1);
                var inp = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(inp[j]);
                }
            }

            foreach (var item in builtStations)
            {
                for (int j = 0; j < n; j++)
                {
                    if (item == j + 1 || builtStations.Contains(j + 1)) continue;
                    graph.AddVertexToList(j + 1);
                    graph.AddEdgeToList(Tuple.Create(item, j + 1, matrix[item - 1, j]), true);
                }
            }

            for (int i = 1; i < n + 1; i++)
            {
                if (builtStations.Contains(i)) continue;
                for (int j = 0; j < n; j++)
                {
                    if (graph.AdjacencyList.ContainsKey(j + 1) && graph.AdjacencyList[j + 1].Where(x => x.EdgeTo == i).ToList().Count > 0 || builtStations.Contains(i) && builtStations.Contains(j + 1) || i == j + 1) continue;
                    graph.AddEdgeToList(Tuple.Create(i, j + 1, matrix[i - 1, j]), true);
                }
            }

            Dictionary<int, double> answer = new Dictionary<int, double>();
            var a = graphAlgorithms.Kruskal(graph, builtStations);
            int l = n - k;
            a.Sort();
            double sum = 0;
            for (int i = 0; i < n - k; i++)
            {
                sum += a[i].Weight;
            }

            Console.WriteLine(sum);

        }

        static void Bakery()
        {
            Graph<long> graph = new Graph<long>();
            GraphAlgorithms<long> graphAlgorithms = new GraphAlgorithms<long>();
            var firstLine = Console.ReadLine().Split();
            long n = long.Parse(firstLine[0]);
            long m = long.Parse(firstLine[1]);
            long k = long.Parse(firstLine[2]);

            for (long i = 0; i < m; i++)
            {
                var input = Console.ReadLine().Split();
                var u = long.Parse(input[0]);
                var v = long.Parse(input[1]);
                var l = double.Parse(input[2]);
                graph.AddVertexToList(u);
                graph.AddVertexToList(v);
                graph.AddEdgeToList(Tuple.Create(u, v, l));
            }
            List<long> items = new List<long>();
            if (k > 0)
                items = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => long.Parse(arrTemp)).ToList();

            List<long> otherCities = new List<long>();
            for (long i = 1; i < n + 1; i++)
            {
                if (items.Contains(i)) continue;
                otherCities.Add(i);
            }

            double answer = long.MaxValue;
            if (items.Count > 0)
                foreach (var item in items)
                {
                    for (int i = 0; i < otherCities.Count; i++)
                    {
                        if (!graph.AdjacencyList.ContainsKey(item)) continue;
                        var ans = graphAlgorithms.OrderedListShortesDistance(graph, otherCities[i], item);
                        if (ans == null) continue;
                        answer = Math.Min(answer, ans.Last().Item2);
                    }
                }
            else
            {
                answer = -1;
            }
            if (answer == long.MaxValue)
                answer = -1;
            Console.WriteLine(answer);
        }

        static void Timus1280()
        {
            Graph<int> graph = new Graph<int>();
            GraphAlgorithms<int> graphAlgorithms = new GraphAlgorithms<int>();
            var input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            for (int i = 1; i < n + 1; i++)
            {
                graph.AddVertexToList(i);
            }
            double l = 1;
            for (int i = 0; i < m; i++)
            {
                var inp = Console.ReadLine().Split();
                graph.AddEdgeToList(Tuple.Create(int.Parse(inp[0]), int.Parse(inp[1]), l), true);
            }
            var answer = Console.ReadLine().Split().Select(int.Parse).ToHashSet();
            if (m == 0)
            {
                Console.WriteLine("YES");
                return;
            }
            var myAnswer = graphAlgorithms.IsTopologicalSortValid(graph, answer);

            if (myAnswer)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        static int N = 10005;
        static int[] a = new int[100050];
        static List<int>[] dist = new List<int>[N];
        static List<int>[] f1 = new List<int>[N];
        static List<int>[] f2 = new List<int>[N];


        #region Timus1651
        static void Timus1651()
        {
            var n = Convert.ToInt32(Console.ReadLine());
            a = ("0 " + Console.In.ReadToEnd()).Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            if (a[1] == a[n])
            {
                Console.WriteLine(a[1]);
                return;
            }
            dist[a[1]] = new List<int>();
            dist[a[1]].Add(0);
            f1[a[1]] = new List<int>();
            f1[a[1]].Add(-1);
            f2[a[1]] = new List<int>();
            f2[a[1]].Add(-1);


            for (int i = 2; i <= n; i++)
            {
                if (dist[a[i]] == null)
                    dist[a[i]] = new List<int>();
                if (f1[a[i]] == null)
                    f1[a[i]] = new List<int>();
                if (f2[a[i]] == null)
                    f2[a[i]] = new List<int>();
                int l1 = dist[a[i]].Count;
                int l2 = dist[a[i - 1]].Count;

                if (l1 == 0 || (dist[a[i]][l1 - 1] > dist[a[i - 1]][l2 - 1] + 1))
                {
                    dist[a[i]].Add(dist[a[i - 1]][l2 - 1] + 1);
                    f1[a[i]].Add(a[i - 1]);
                    f2[a[i]].Add(l2 - 1);
                }

            }

            DFS(a[n], dist[a[n]].Count - 1);

        }

        static void DFS(int s, int e)
        {
            if (f1[s][e] != -1)
                DFS(f1[s][e], f2[s][e]);
            Console.Write(s + " ");
        }
        #endregion

        public static void Timus1210()
        {
            int n = int.Parse(Console.ReadLine());

            Graph<int> graph = new Graph<int>();
            GraphAlgorithms<int> graphAlgorithms = new GraphAlgorithms<int>();
            List<List<int>> levels = new List<List<int>>();
            int vertexCount = 0;
            levels.Add(new List<int>() { 0 });
            graph.AddVertexToList(vertexCount++);
            for (int i = 0; i < n; i++)
            {
                var q = Console.ReadLine();
                if (q == "*")
                {
                    i--;
                    continue;
                }
                int k = int.Parse(q);
                levels.Add(new List<int>());
                for (int m = 0; m < k; m++)
                {
                    graph.AddVertexToList(vertexCount);
                    levels.Last().Add(vertexCount);
                    vertexCount++;
                }
                for (int j = 0; j < k; j++)
                {
                    var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                    for (int l = 0; l < input.Length - 2; l += 2)
                    {
                        var firstVertex = levels[i][input[l] - 1];
                        graph.AddEdgeToList(Tuple.Create(firstVertex, levels[i + 1][j], (double)input[l + 1]), true);
                    }
                }
            }

            var ez = graphAlgorithms.ShortestDistance(graph, 0);
            List<double> answer = new List<double>();
            foreach (var item in levels.Last())
            {
                if (ez.ContainsKey(item))
                    answer.Add(ez[item]);
            }
            answer.Sort();
            Console.WriteLine(answer.First());
        }

        public static void Timus1272()
        {
            var nkm = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = nkm[0];
            var k = nkm[1];
            var m = nkm[2];
            var dj = new DisjointSet(n);
            for (int i = 0; i < k; i++)
            {
                var xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
                dj.Union(xy[0], xy[1]);
            }
            for (int i = 0; i < m; i++)
            {
                var xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }
            Console.WriteLine(dj.SetCount - 1);


        }

        public static void Timus1022()
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var graph = new Graph<int>();
            for (int i = 1; i <= n; i++)
                graph.AddVertexToList(i);
            for (int i = 1; i <= n; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < input.Length - 1; j++)
                {
                    graph.AddEdgeToList(Tuple.Create(i, input[j], 1.0), true);
                }
            }
            GraphAlgorithms<int> graphAlgorithms = new GraphAlgorithms<int>();
            var a = graphAlgorithms.TopologicalSortKahn(graph);
            Console.WriteLine(string.Join(" ", a));
        }


        public static void Timus1471()
        {
            var n = Convert.ToInt32(Console.ReadLine());
            if (n == 1)
            {
                Console.WriteLine(0);
                return;
            }
            var tree = new Tree(n);
            for (int i = 1; i < n; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                tree.AddEdge(input[0], input[1], input[2]);
            }
            tree.Precalculate();
            var m = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var x = input[0];
                var y = input[1];
                if (x == y)
                    Console.WriteLine(0);
                else
                {
                    var node = tree.GetLowestCommonAncestor(x, y);
                    var xw = tree._weighted[x];
                    var yw = tree._weighted[y];
                    var nw = tree._weighted[node];
                    Console.WriteLine(xw + yw - 2 * nw);
                }
            }
        }
        static void Timus1000()
        {
            string[] a = Console.ReadLine().Split();
            int b = int.Parse(a[0]);
            int c = int.Parse(a[1]);
            Console.WriteLine(c + b);
        }

        static void Timus1001()
        {
            string[] s = Console.In.ReadToEnd()
                .Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = s.Length - 1; i >= 0; i--)
            {
                Console.WriteLine("{0:0.0000}", Math.Sqrt(double.Parse(s[i])));
            }


        }

        static void Timus1002()
        {
            Dictionary<char, string> dict = new Dictionary<char, string>();
            List<string> answer = new List<string>();
            dict.Add('1', "ij");
            dict.Add('2', "abc");
            dict.Add('3', "def");
            dict.Add('4', "gh");
            dict.Add('5', "kl");
            dict.Add('6', "mn");
            dict.Add('7', "prs");
            dict.Add('8', "tuv");
            dict.Add('9', "wxy");
            dict.Add('0', "oqz");
            string line = "";

            string number = "";
            while ((line = Console.ReadLine()) != "-1")
            {
                int count = 0;
                number = line;
                int n = int.Parse(Console.ReadLine());
                List<string> words = new List<string>();

                for (int k = 0; k < n; k++)
                {
                    words.Add(Console.ReadLine());
                }

                words = words.OrderByDescending(x => x.Length).ToList();
                int i = 0;
                while (i < number.Length)
                {

                    var str = dict[number[i]];

                    string answerStr = "";
                    foreach (var word in words)
                    {
                        for (int f = 0; f < word.Length; f++)
                        {

                            if (str.Contains(word[f]))
                            {
                                if (i < number.Length - 1)
                                    str = dict[number[++i]];
                            }
                            else
                            {
                                count++;
                                break;
                            }

                            if (f == word.Length - 1)
                            {
                                if (i == number.Length - 1)
                                {
                                    answerStr += word;
                                    i++;
                                    break;
                                }
                                else
                                {
                                    answerStr += word + " ";
                                    break;
                                }

                            }
                        }


                    }

                    if (answerStr == "")
                    {
                        answerStr = "No solution.";
                    }

                    answer.Add(answerStr);
                }

            }

            foreach (var ans in answer)
            {
                Console.WriteLine(ans);
            }
        }

        static void Timus1293()
        {
            string[] values = Console.ReadLine().Split();
            int n = int.Parse(values[0]);
            int a = int.Parse(values[1]);
            int b = int.Parse(values[2]);

            Console.WriteLine(2 * n * a * b);


        }

        static void Timus1787()
        {
            string[] input = Console.ReadLine().Split();
            int k = int.Parse(input[0]);
            int n = int.Parse(input[1]);


            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));

            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += k - arr[i];
                if (sum > 0)
                {
                    sum = 0;
                }
            }

            Console.WriteLine(Math.Abs(sum));
        }

        static void Timus1820()
        {
            string[] value = Console.ReadLine().Split();
            int n = int.Parse(value[0]);
            int k = int.Parse(value[1]);
            int answer;
            if (n <= k)
            {
                answer = 2;
            }
            else
            {
                if ((n * 2) % k == 0)
                {
                    answer = (int)n * 2 / k;
                }
                else
                {
                    answer = n * 2 / k + 1;
                }
            }

            Console.WriteLine(answer);
        }

        static void Timus2066()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            List<int> arr = new List<int>();

            arr.Add(a);
            arr.Add(b);
            arr.Add(c);

            arr.Sort();
            int answer = 0;
            if (arr[0] - arr[1] * arr[2] > arr[0] - arr[1] - arr[2])
            {
                answer = arr[0] - arr[1] - arr[2];
            }
            else
            {
                answer = arr[0] - arr[1] * arr[2];
            }

            Console.WriteLine(answer);
        }

        static void Timus1785()
        {
            int n = int.Parse(Console.ReadLine());
            if (n <= 4)
            {
                Console.WriteLine("few");
            }
            else if (n <= 9)
            {
                Console.WriteLine("several");
            }
            else if (n <= 19)
            {
                Console.WriteLine("pack");
            }
            else if (n <= 49)
            {
                Console.WriteLine("lots");
            }
            else if (n <= 99)
            {
                Console.WriteLine("horde");
            }
            else if (n <= 249)
            {
                Console.WriteLine("throng");
            }
            else if (n <= 499)
            {
                Console.WriteLine("swarm");
            }
            else if (n <= 999)
            {
                Console.WriteLine("zounds");
            }
            else if (n >= 1000)
            {
                Console.WriteLine("legion");
            }

        }

        static void Timus1409()
        {
            string[] input = Console.ReadLine().Split();
            int harry = int.Parse(input[0]);
            int larry = int.Parse(input[1]);
            int n = harry + larry;
            Console.WriteLine(n - harry - 1 + " " + (n - larry - 1));

        }

        static void Timus2012()
        {
            int n = int.Parse(Console.ReadLine());
            int p = 12;
            int t = 240;
            int b = 45;

            int a = p - n;
            if (a * b <= 240)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }

        static void Timus1877()
        {
            int f = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());
            if (f % 2 == 0 || s % 2 != 0)
                Console.WriteLine("yes");
            else if (f % 2 != 0 || s % 2 == 0)
                Console.WriteLine("no");
        }

        static void Timus2001()
        {
            string[] input1 = Console.ReadLine().Split();
            string[] input2 = Console.ReadLine().Split();
            string[] input3 = Console.ReadLine().Split();
            int a1 = int.Parse(input1[0]);
            int b1 = int.Parse(input1[1]);
            int a2 = int.Parse(input2[0]);
            int b2 = int.Parse(input2[1]);
            int a3 = int.Parse(input3[0]);
            int b3 = int.Parse(input3[1]);
            int ans1 = a1 - a3;
            int ans2 = b1 - b2;
            Console.WriteLine(ans1 + " " + ans2);
        }

        static void Timus1264()
        {
            string[] input = Console.ReadLine().Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            int answer = 0;
            for (int i = 0; i <= b; i++)
            {
                answer += a;
            }

            Console.WriteLine(answer);
        }

        static void Timus1197()
        {
            int n = int.Parse(Console.ReadLine());
            int answer = 0;
            for (int i = 0; i < n; i++)
            {
                answer = 0;
                var input = Console.ReadLine();
                var text = input[0];
                var rank = int.Parse(input[1].ToString());
                if (text + 2 <= 'h')
                {
                    if (rank + 1 <= 8) answer++;
                    if (rank - 1 >= 1) answer++;
                }

                if (text - 2 >= 'a')
                {
                    if (rank + 1 <= 8) answer++;
                    if (rank - 1 >= 1) answer++;
                }
                if (rank + 2 <= 8)
                {
                    if (text + 1 <= 'h') answer++;
                    if (text - 1 >= 'a') answer++;
                }

                if (rank - 2 >= 1)
                {
                    if (text + 1 <= 'h') answer++;
                    if (text - 1 >= 'a') answer++;
                }

                Console.WriteLine(answer);
            }
        }

        static void Timus2100()
        {
            int n = int.Parse(Console.ReadLine());
            int count = n;
            for (int i = 0; i < n; i++)
            {
                if (Console.ReadLine().Contains('+'))
                {
                    count++;
                }
            }
            count += 2;

            if (count == 13)
            {
                count++;
            }

            Console.WriteLine(count * 100);
        }

        static void Timus1880()
        {
            int n1 = int.Parse(Console.ReadLine());
            int[] arr1 = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int n2 = int.Parse(Console.ReadLine());
            int[] arr2 = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int n3 = int.Parse(Console.ReadLine());
            int[] arr3 = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int answer = 0;
            for (int i = 0; i < n1; i++)
            {
                if (arr2.Contains(arr1[i]) && arr3.Contains(arr1[i]))
                {
                    answer++;
                }
            }

            Console.WriteLine(answer);
        }

        static void Timus1639()
        {
            string[] input = Console.ReadLine().Split();
            int m = int.Parse(input[0]);
            int n = int.Parse(input[1]);
            if ((m * n) % 2 != 0)
            {
                Console.WriteLine("[second]=:]");

            }
            else
            {
                Console.WriteLine("[:=[first]");
            }

        }

        static void Timus1910()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            Dictionary<int, int> allAnswers = new Dictionary<int, int>();
            int i = 0;


            while (i + 3 <= n)
            {
                var value = arr[i] + arr[i + 1] + arr[i + 2];
                if (!allAnswers.ContainsKey(value))
                    allAnswers.Add(value, i + 2);
                i++;
            }
            var answer = allAnswers.Aggregate((l, r) => l.Key > r.Key ? l : r);
            Console.WriteLine(answer.Key + " " + answer.Value);

        }

        static void Timus1924()
        {
            int n = int.Parse(Console.ReadLine());
            if (n % 2 != 0)
            {
                Console.WriteLine("grimy");
            }
            else
            {
                Console.WriteLine("black");
            }
        }

        static void Timus2023()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, List<string>> casesDictionary = new Dictionary<int, List<string>>();
            casesDictionary.Add(1, new List<string> { "Alice", "Ariel", "Aurora", "Phil", "Peter", "Olaf", "Phoebus", "Ralph", "Robin" });
            casesDictionary.Add(2, new List<string> { "Bambi", "Belle", "Bolt", "Mulan", "Mowgli", "Mickey", "Silver", "Simba", "Stitch" });
            casesDictionary.Add(3, new List<string> { "Dumbo", "Genie", "Jiminy", "Kuzko", "Kida", "Kenai", "Tarzan", "Tiana", "Winnie" });
            int currentPos = 1;
            int newPos = 0;
            int answer = 0;
            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                foreach (var cases in casesDictionary)
                {
                    var exists = cases.Value.Exists(x => x.Equals(name));
                    if (exists)
                    {
                        newPos = cases.Key;
                        break;
                    }
                }

                answer += Math.Abs(newPos - currentPos);
                currentPos = newPos;
            }

            Console.WriteLine(answer);
        }

        static void Timus1209()
        {
            int n = int.Parse(Console.ReadLine());
            string answer = "";
            for (int i = 0; i < n; i++)
            {
                long a = int.Parse(Console.ReadLine());
                var ans = Math.Sqrt(8 * a - 7);
                if (ans % 1 == 0) Console.Write("1 ");

                else
                    Console.Write("0 ");
            }
        }

        static void Timus1313()
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = arr[j];
                }

            }
            List<int> answer = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int temp = i;
                for (int j = 0; j <= i; j++)
                {
                    answer.Add(matrix[temp, j]);
                    Console.WriteLine(matrix[temp, j]);
                    temp--;
                }
            }

            for (int j = 1; j < n; j++)
            {
                var temp = j;
                for (int i = n - 1; i > j - 1; i--)
                {
                    answer.Add(matrix[i, temp]);
                    Console.WriteLine(matrix[i, temp]);
                    temp++;
                }
            }

        }

        private static long sum = 0;
        private static long answer = long.MaxValue;
        static void Timus1005()
        {
            long n = int.Parse(Console.ReadLine());
            List<long> arr = new List<long>();
            long[] arrRead = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => long.Parse(arrTemp));
            arr.AddRange(arrRead);
            sum = arr.Sum();
            List<long> comb = new List<long>();
            PrintComb(arr, n, 0, comb);
            Console.WriteLine(answer);
        }
        private static void PrintComb(List<long> arr, long k, int start, List<long> comb)
        {
            Print(comb);

            for (int i = start; i < arr.Count; i++)
            {
                comb.Add(arr[i]);
                PrintComb(arr, k, i + 1, comb);
                comb.RemoveAt(comb.Count - 1);
            }

        }

        private static void Print(List<long> comb)
        {
            var a = sum - comb.Sum();
            if (Math.Abs(a - comb.Sum()) < answer)
            {
                answer = Math.Abs(a - comb.Sum());
            }
            //foreach (var i in comb)
            //{
            //    Console.Write(i);
            //}

            //Console.WriteLine();
        }

        static void Timus1068()
        {
            int n = int.Parse(Console.ReadLine());
            bool minus = n >= 0 ? false : true;
            int answer = 0;
            if (n == 1 || n == 0)
            {
                answer = 1;
                Console.WriteLine(answer);
                return;
            }
            for (int i = 0; i <= Math.Abs(n); i++)
            {
                answer += i;
            }

            if (minus)
            {
                answer = -answer;
                answer++;

            }
            Console.WriteLine(answer);
        }

        static void Timus1319()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int num = 1;
            for (int i = 0; i < n; i++)
            {
                int temp = i;
                for (int j = n - 1; j >= n - 1 - i; j--)
                {
                    matrix[temp, j] = num;
                    temp++;
                    num++;
                }
            }

            for (int j = 1; j < n; j++)
            {
                var temp = j;
                for (int i = n - 1; i > j - 1; i--)
                {
                    matrix[temp, i] = num;
                    temp++;
                    num++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        static void Timus1567()
        {
            var values = new Dictionary<char, int>();
            string input = Console.ReadLine();

            values.Add('a', 1);
            values.Add('b', 2);
            values.Add('c', 3);
            values.Add('d', 1);
            values.Add('e', 2);
            values.Add('f', 3);
            values.Add('g', 1);
            values.Add('h', 2);
            values.Add('i', 3);
            values.Add('j', 1);
            values.Add('k', 2);
            values.Add('l', 3);
            values.Add('m', 1);
            values.Add('n', 2);
            values.Add('o', 3);
            values.Add('p', 1);
            values.Add('q', 2);
            values.Add('r', 3);
            values.Add('s', 1);
            values.Add('t', 2);
            values.Add('u', 3);
            values.Add('v', 1);
            values.Add('w', 2);
            values.Add('x', 3);
            values.Add('y', 1);
            values.Add('z', 2);
            values.Add('.', 1);
            values.Add(',', 2);
            values.Add('!', 3);
            values.Add(' ', 1);

            int answer = 0;

            foreach (var c in input)
            {
                answer += values[c];
            }
            Console.WriteLine(answer);
        }

        static void Timus1581()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arrRead = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => int.Parse(arrTemp));
            Dictionary<int, int> values = new Dictionary<int, int>();
            List<Tuple<int, int>> items = new List<Tuple<int, int>>();
            int j = 1;

            for (int i = 0; i < arrRead.Length; i++)
            {
                if (i > 0 && items[i - j].Item1 == arrRead[i])
                {
                    int count = items[i - j].Item2;
                    items[i - j] = Tuple.Create(arrRead[i], ++count);
                    j++;
                }
                else
                {
                    items.Add(Tuple.Create(arrRead[i], 1));
                }
            }
            foreach (var val in items)
            {
                Console.Write(val.Item2 + " " + val.Item1 + " ");
            }

        }

        static void Timus1585()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> penguins = new Dictionary<string, int> { { "Emperor Penguin", 0 }, { "Little Penguin", 0 }, { "Macaroni Penguin", 0 } };

            for (int i = 0; i < n; i++)
            {
                penguins[Console.ReadLine()]++;
            }

            var answer = penguins.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            Console.WriteLine(answer);
        }

        static void Timus1263()
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            Dictionary<int, int> elections = new Dictionary<int, int>();
            for (int i = 1; i < n + 1; i++)
            {
                elections.Add(i, 0);
            }

            for (int i = 0; i < m; i++)
            {
                int elected = int.Parse(Console.ReadLine());
                elections[elected]++;
            }

            for (int i = 1; i < n + 1; i++)
            {
                decimal a = (decimal)elections[i] / (decimal)m * 100;
                Console.WriteLine(a.ToString("f2") + "%");
            }

        }

        static void Timus1991()
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);

            int[] arrRead = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => int.Parse(arrTemp));
            int unusedBooms = 0;
            int unkilledSoldiers = 0;

            foreach (var item in arrRead)
            {
                if (item - k >= 0)
                {
                    unusedBooms += item - k;
                }
                else
                {
                    unkilledSoldiers += k - item;
                }
            }
            Console.WriteLine(unusedBooms + " " + unkilledSoldiers);

        }

        static void Timus1100()
        {
            int n = int.Parse(Console.ReadLine());
            List<Tuple<int, int>> teams = new List<Tuple<int, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                int id = int.Parse(input[0]);
                int m = int.Parse(input[1]);
                teams.Add(Tuple.Create(id, m));
            }
            for (int i = 100; i >= 0; i--)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == teams[j].Item2) Console.WriteLine(teams[j].Item1 + " " + teams[j].Item2);
                }
            }
        }

        static void Timus2056()
        {
            int n = int.Parse(Console.ReadLine());
            List<double> arr = new List<double>();
            for (int i = 0; i < n; i++)
            {
                var mark = double.Parse(Console.ReadLine());
                arr.Add(mark);
            }
            var average = arr.Sum() / n;
            bool isExcelent = arr.All(item => item == 5);
            if (arr.Contains(3))
            {
                Console.WriteLine("None");
            }
            else if (isExcelent)
            {
                Console.WriteLine("Named");
            }
            else if (average >= 4.5)
            {
                Console.WriteLine("High");
            }

            else
            {
                Console.WriteLine("Common");
            }
        }

        static void Timus1493()
        {
            int ticket = int.Parse(Console.ReadLine()) + 1;
            int firstNum = ticket / 1000;
            int secondNum = ticket % 1000;
            int firstSum = 0;
            int secondSum = 0;

            for (int i = 0; i < 3; i++)
            {
                firstSum += firstNum % 10;
                firstNum = firstNum / 10;
                secondSum += secondNum % 10;
                secondNum = secondNum / 10;
            }
            if (firstSum == secondSum)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                ticket = ticket - 2;
                firstNum = ticket / 1000;
                secondNum = ticket % 1000;
                firstSum = 0;
                secondSum = 0;
                for (int i = 0; i < 3; i++)
                {
                    firstSum += firstNum % 10;
                    firstNum = firstNum / 10;
                    secondSum += secondNum % 10;
                    secondNum = secondNum / 10;
                }
                if (firstSum == secondSum)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
        }

        static void Timus1607()
        {
            string[] input = Console.ReadLine().Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            int c = int.Parse(input[2]);
            int d = int.Parse(input[3]);
            if (a > c)
            {
                c = a;
            }
            while (a < c)
            {
                a += b;
                if (c - d < a)
                {
                    break;
                }
                c -= d;
            }
            Console.WriteLine(Math.Min(a, c));
        }

        static void Timus1876()
        {
            string[] input = Console.ReadLine().Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            int answer = 0;
            if (a > b)
            {
                answer = 2 * a + 39;
            }
            else
            {
                answer = 2 * b + 40;
            }
            Console.WriteLine(answer);
        }

        static void Timus1110()
        {
            string[] input = Console.ReadLine().Split();
            BigInteger n = int.Parse(input[0]);
            BigInteger m = int.Parse(input[1]);
            BigInteger y = int.Parse(input[2]);
            string ans = "";
            for (int i = 1; i < m; i++)
            {
                if (BigInteger.ModPow(i, n, m) == y)
                {
                    if (ans == "")
                    {
                        ans += i.ToString();
                    }
                    else
                    {
                        ans += " " + i.ToString();
                    }
                }
            }
            if (ans == "")
            {
                Console.WriteLine("-1");
                return;
            }
            Console.WriteLine(ans);

        }

        static void Timus1349()
        {
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                Console.WriteLine("1 2 3");
            }
            else if (n == 2)
            {
                Console.WriteLine("3 4 5");
            }
            else
            {
                Console.WriteLine("-1");
            }
        }

        static void Timus1545()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> lines = new List<string>();
            for (int i = 0; i < n; i++)
            {
                lines.Add(Console.ReadLine());
            }

            char character = char.Parse(Console.ReadLine());
            List<string> answer = new List<string>();
            foreach (var item in lines)
            {
                if (item[0] == character)
                {
                    answer.Add(item);
                }
            }
            answer.Sort();
            foreach (var item in answer)
            {
                Console.WriteLine(item);
            }
        }

        static void Timus1496()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> pairs = new Dictionary<string, int>();
            Dictionary<string, int> answer = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                if (pairs.ContainsKey(input))
                {
                    if (!answer.ContainsKey(input))
                    {
                        answer.Add(input, i);
                    }
                }
                else
                {
                    pairs.Add(input, i);
                }
            }
            foreach (var item in answer)
            {
                Console.WriteLine(item.Key);
            }
        }

        static void Timus1893()
        {
            char[] alpha = "LABCDEFGHJKLMNOPQRSTUVWXYZ".ToCharArray();
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            for (int i = 1; i < 3; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    string a = $"{i}{alpha[j]}";
                    if (j == 1 || j == 4)
                    {
                        pairs.Add(a, "window");

                    }
                    else
                    {
                        pairs.Add(a, "aisle");
                    }
                }
            }

            for (int i = 3; i < 21; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    string a = $"{i}{alpha[j]}";
                    if (j == 1 || j == 6)
                    {
                        pairs.Add(a, "window");
                    }
                    else if (j % 2 == 0 || j % 2 == 1)
                    {
                        pairs.Add(a, "aisle");
                    }
                }

            }

            for (int i = 21; i < 66; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    string a = $"{i}{alpha[j]}";
                    if (j == 1 || j == 10)
                    {
                        pairs.Add(a, "window");
                    }
                    else if (j == 3 || j == 4 || j == 7 || j == 8)
                    {
                        pairs.Add(a, "aisle");
                    }
                    else
                    {
                        pairs.Add(a, "neither");
                    }
                }
            }

            string input = Console.ReadLine();

            Console.WriteLine(pairs[input]);


        }

        static void Timus1881()
        {
            string[] input = Console.ReadLine().Split();
            int h = int.Parse(input[0]);
            int w = int.Parse(input[1]);
            int n = int.Parse(input[2]);

            List<string> words = new List<string>();
            int pages = 1;
            int currentLine = 1;

            for (int i = 0; i < n; i++)
            {
                words.Add(Console.ReadLine() + " ");
            }
            string a = "";
            for (int i = 0; i < n; i++)
            {
                if (a.Length + words[i].Length - 1 <= w)
                {
                    a += words[i];
                }
                else
                {
                    currentLine++;
                    a = words[i];
                }
                if (currentLine > h)
                {
                    pages++;
                    currentLine = 1;
                }
            }
            Console.WriteLine(pages);
        }

        static void Timus1196()
        {
            long n = long.Parse(Console.ReadLine());
            HashSet<long> dates = new HashSet<long>();
            for (int i = 0; i < n; i++)
            {
                dates.Add(long.Parse(Console.ReadLine()));
            }
            long m = int.Parse(Console.ReadLine());
            int res = 0;
            for (long i = 0; i < m; i++)
            {
                long value = long.Parse(Console.ReadLine());
                if (dates.Contains(value))
                {
                    res++;
                }
            }
            Console.WriteLine(res);
        }

        static void Timus1563()
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                set.Add(Console.ReadLine());
            }
            Console.WriteLine(n - set.Count);

        }

        static void Timus1636()
        {
            string[] input = Console.ReadLine().Split();
            int T1 = int.Parse(input[0]);
            int T2 = int.Parse(input[1]);
            int answer = 0;
            int[] arrRead = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => int.Parse(arrTemp));
            for (int i = 0; i < 10; i++)
            {
                answer += arrRead[i] * 20;
            }
            if (T1 <= T2 - answer)
            {
                Console.WriteLine("No chance.");
            }
            else
            {
                Console.WriteLine("Dirty debug :(");
            }
        }

        static void Timus1654()
        {
            string input = Console.ReadLine();
            Stack<char> set = new Stack<char>();
            for (int i = input.Length - 1; i > -1; i--)
            {
                if (set.Count > 0 && set.Peek() == input[i])
                {
                    set.Pop();
                }
                else
                {
                    set.Push(input[i]);
                }
            }
            int n = set.Count;
            for (int i = 0; i < n; i++)
            {
                Console.Write(set.Pop());
            }
        }

        static void Timus1925()
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);
            int difference = (n + 1) * 2;
            int sumNum = k;
            int ansNum = 0;
            for (int i = 0; i < n; i++)
            {
                string[] inp = Console.ReadLine().Split();

                sumNum += int.Parse(inp[0]);
                ansNum += int.Parse(inp[1]);
            }
            if (sumNum - ansNum - difference > 0)
            {
                Console.WriteLine(sumNum - ansNum - difference);
            }
            else
            {
                Console.WriteLine("Big Bang!");
            }
        }

        static void Timus1617()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> pairs = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (pairs.ContainsKey(input))
                {
                    pairs[input]++;
                }
                else
                {
                    pairs.Add(input, 1);
                }
            }
            int count = 0;
            foreach (var item in pairs)
            {
                if (item.Value >= 4)
                {
                    count += item.Value / 4;
                }
            }
            Console.WriteLine(count);
        }

        static void Timus2002()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> users = new Dictionary<string, string>();
            bool[] isLogged = new bool[n];
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                string user = input[1];
                string password = "";
                if (input.Length == 3)
                    password = input[2];
                int userLoggedIndex = users.Keys.ToList().IndexOf(user);
                switch (command)
                {
                    case "register":
                        if (!users.ContainsKey(user))
                        {
                            users.Add(user, password);
                            Console.WriteLine("success: new user added");
                        }
                        else
                        {
                            Console.WriteLine("fail: user already exists");
                        }
                        break;
                    case "login":
                        if (!users.ContainsKey(user))
                        {
                            Console.WriteLine("fail: no such user");
                        }
                        else if (users[user] != password)
                        {
                            Console.WriteLine("fail: incorrect password");
                        }
                        else if (isLogged[userLoggedIndex])
                        {
                            Console.WriteLine("fail: already logged in");
                        }
                        else
                        {
                            isLogged[userLoggedIndex] = true;
                            Console.WriteLine("success: user logged in");
                        }
                        break;
                    case "logout":
                        if (!users.ContainsKey(user))
                        {
                            Console.WriteLine("fail: no such user");
                        }
                        else if (!isLogged[userLoggedIndex])
                        {
                            Console.WriteLine("fail: already logged out");
                        }
                        else
                        {
                            isLogged[userLoggedIndex] = false;
                            Console.WriteLine("success: user logged out");
                        }
                        break;
                }
            }
        }

        static void Timus1518()
        {
            string[] input = Console.ReadLine().Split();
            long n = long.Parse(input[0]);
            long x = long.Parse(input[1]);
            long y = long.Parse(input[2]);

            List<long> k = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => long.Parse(arrTemp)).ToList();
            List<long> c = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => long.Parse(arrTemp)).ToList();
            while (k.Count != x)
            {
                long answer = 0;
                for (long i = c.Count - 1; i > -1; i--)
                {
                    answer += k[(int)(i)] * c[(int)(i)];
                }
                answer %= y;
                k.Add(answer);
                k.RemoveAt(0);
                x--;
            }
            Console.WriteLine(k.Last());
        }

        static void Timus1518Working()
        {
            var nxy = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var n = nxy[0];
            var x = nxy[1];
            var y = nxy[2];
            var k = Console.ReadLine().Split(' ').Select(long.Parse).Reverse().ToArray();
            var c = Console.ReadLine().Split(' ').Select(long.Parse).Reverse().ToArray();
            var matrix = new long[n, n];
            for (int i = 1; i < n; i++)
            {
                matrix[i, i - 1] = 1;
            }
            for (int i = 0; i < n; i++)
            {
                matrix[0, i] = c[i];
            }
            var f = FindPow(matrix, x - n, y, n);
            long ans = 0;
            for (int i = 0; i < n; i++)
            {
                ans += f[0, i] * k[i];
                ans %= y;
            }
            Console.WriteLine(ans);
        }
        static long[,] FindPow(long[,] matrix, long a, long mod, long n)
        {
            var res = new long[n, n];
            for (int i = 0; i < n; i++)
                res[i, i] = 1;
            while (a > 0)
            {
                if ((a & 1) == 1)
                    res = MatrixMul(res, matrix, mod, n);
                matrix = MatrixMul(matrix, matrix, mod, n);
                a /= 2;
            }
            return res;
        }
        static long[,] MatrixMul(long[,] a, long[,] b, long mod, long n)
        {
            var res = new long[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    long current = 0;
                    for (int k = 0; k < n; k++)
                    {
                        current += a[i, k] * b[k, j];
                        current %= mod;
                    }
                    res[i, j] = current;
                }
            }
            return res;
        }

        static void Timus1343()
        {
            int n = int.Parse(Console.ReadLine());
            string number;
            if (n > 0)
                number = Console.ReadLine();
            else
                number = "0";
            number = number.PadRight(12, '0');
            long num = long.Parse(number);
            while (true)
            {
                if (IsPrime(num))
                {
                    var ans = num.ToString();
                    Console.WriteLine(ans.PadLeft(12, '0'));
                    break;
                }
                ++num;
            }
        }

        static bool IsPrime(long n)
        {
            for (long i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return n > 1;
        }

        static void Timus1146()
        {
            int n = int.Parse(Console.ReadLine());
            Matrix matrix = new Matrix(n);
            matrix.Input();
            matrix.PrecalcPrefixSums();
            int max = Matrix.el[0, 0];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    for (int l = i; l < n; l++)
                        for (int r = j; r < n; r++)
                        {
                            int sum = matrix.GetSubmatrixSum(i, j, l, r);
                            max = Math.Max(sum, max);
                        }
            Console.WriteLine(max);
        }


        public static void Timus1462()
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var arr = new BigInteger[n + 1];
            arr[0] = 4; // 3
            arr[1] = 7; // 4
            for (int i = 2; i <= n; i++)
            {
                arr[i] = BigInteger.Add(arr[i - 1], arr[i - 2]);
                if (i > 4)
                {
                    arr[i - 4] = 0;
                }
            }
            Console.WriteLine(arr[n - 3]);
        }

        public static void Timus1095()
        {
            var n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var m = Console.ReadLine();
                Console.WriteLine(DivideSeven(m));
            }
        }
        public static BigInteger DivideSeven(string m)
        {
            var nums = new[]
            {
                1234,
                1243,
                1324,
                1342,
                1423,
                1432,
                2134,
                2143,
                2341,
                2314,
                2413,
                2431,
                3124,
                3142,
                3214,
                3241,
                3421,
                3412,
                4123,
                4132,
                4213,
                4231,
                4312,
                4321
            };
            var num = "";
            var zeros = "";
            var temp = "";
            foreach (var c in m)
            {
                if (c == '1' && !temp.Contains("1"))
                    temp += "1";
                else if (c == '2' && !temp.Contains("2"))
                    temp += "2";
                else if (c == '3' && !temp.Contains("3"))
                    temp += "3";
                else if (c == '4' && !temp.Contains("4"))
                    temp += "4";
                else if (c == '0')
                    zeros += c;
                else
                    num += c;
            }
            if (num == "" && zeros == "")
            {
                return 4123;
            }
            if (num == "" && zeros != "")
            {
                foreach (var s in nums)
                {
                    if (s * Math.Pow(10, zeros.Length) % 7 == 0)
                    {
                        return new BigInteger(s * Math.Pow(10, zeros.Length));
                    }
                }
            }
            var number = long.Parse(num + zeros);
            var res = new BigInteger(0);
            foreach (var s in nums)
            {
                res = BigInteger.Add(BigInteger.Multiply(number, 10000), s);
                BigInteger r = BigInteger.One;
                BigInteger.DivRem(res, new BigInteger(7), out r);
                if (r == 0)
                    break;
            }
            return res;
        }


        private static int n;
        public static void Timus1033()
        {
            n = Convert.ToInt32(Console.ReadLine());
            matrix = new int[n, n];
            fill = new int[n, n];
            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                for (var j = 0; j < input.Length; j++)
                {
                    if (input[j] == '#')
                        matrix[i, j] = 1;
                }
            }
            FloodFill(0, 0);
            FloodFill(n - 1, n - 1);
            var ans = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (fill[i, j] != 1) continue;
                    if (i + 1 > n - 1 || fill[i + 1, j] != 1)
                        ans++;
                    if (j + 1 > n - 1 || fill[i, j + 1] != 1)
                        ans++;
                    if (i - 1 < 0 || fill[i - 1, j] != 1)
                        ans++;
                    if (j - 1 < 0 || fill[i, j - 1] != 1)
                        ans++;
                }
            }
            Console.WriteLine((ans - 4) * 9);
        }
        private static int[,] fill;
        private static int[,] matrix;
        public static void FloodFill(int x, int y)
        {
            fill[x, y] = 1;
            if (x + 1 < n && matrix[x + 1, y] != 1 && fill[x + 1, y] != 1)
                FloodFill(x + 1, y);
            if (y + 1 < n && matrix[x, y + 1] != 1 && fill[x, y + 1] != 1)
                FloodFill(x, y + 1);
            if (x - 1 >= 0 && matrix[x - 1, y] != 1 && fill[x - 1, y] != 1)
                FloodFill(x - 1, y);
            if (y - 1 >= 0 && matrix[x, y - 1] != 1 && fill[x, y - 1] != 1)
                FloodFill(x, y - 1);
        }

        public static void Timus1160()
        {
            var nm = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = nm[0];
            var m = nm[1];
            var graph = new Graph<int>();
            var graphAlgorithms = new GraphAlgorithms<int>();
            for (int i = 1; i <= n; i++)
                graph.AddVertexToList(i);
            for (int i = 1; i <= m; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                graph.AddEdgeToList(Tuple.Create(input[0], input[1], (double)input[2]), true);
            }

            var answer = graphAlgorithms.Kruskal(graph);
            var min = answer.Max().Weight;
            var edgesCount = answer.Count;
            Console.WriteLine(min);
            Console.WriteLine(edgesCount);
            foreach (var item in answer)
            {
                Console.WriteLine($"{item.EdgeFrom} {item.EdgeTo}");
            }

        }
        public static void Timus1205()
        {
            var v1v2 = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var v1 = v1v2[0];
            var v2 = v1v2[1];
            var graph = new Graph<KeyValuePair<double, double>>();
            var graphAlgorithms = new GraphAlgorithms<KeyValuePair<double, double>>();
            var n = Convert.ToInt32(Console.ReadLine());
            var points = new List<KeyValuePair<double, double>>();
            var stationEdges = new List<Tuple<KeyValuePair<double, double>, KeyValuePair<double, double>>>();
            for (int i = 0; i < n; i++)
            {
                var xy = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
                points.Add(new KeyValuePair<double, double>(xy[0], xy[1]));
                graph.AddVertexToList(points[i]);
            }
            while (true)
            {
                var xy = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (xy[0] == 0 && xy[1] == 0)
                    break;
                var point1 = points[xy[0] - 1];
                var point2 = points[xy[1] - 1];
                stationEdges.Add(Tuple.Create(point1, point2));
                graph.AddEdgeToList(Tuple.Create(point1, point2, Math.Round(Time(point1, point2, v2), 7)));
            }
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i; j < n; j++)
                {
                    graph.AddEdgeToList(Tuple.Create(points[i], points[j], Math.Round(Time(points[i], points[j], v1), 7)));
                }
            }
            var a = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var b = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var ap = new KeyValuePair<double, double>(a[0], a[1]);
            var bp = new KeyValuePair<double, double>(b[0], b[1]);
            graph.AddVertexToList(ap);
            graph.AddVertexToList(bp);
            graph.AddEdgeToList(Tuple.Create(ap, bp, Math.Round(Time(ap, bp, v1), 7)));
            for (int i = 0; i < n; i++)
            {
                graph.AddEdgeToList(Tuple.Create(ap, points[i], Math.Round(Time(ap, points[i], v1), 7)));
                graph.AddEdgeToList(Tuple.Create(bp, points[i], Math.Round(Time(bp, points[i], v1), 7)));
            }
            var dijk = graphAlgorithms.OrderedListShortesDistance(graph, ap, bp);
            if (dijk.Count == 1)
            {
                Console.WriteLine("0.000000");
                Console.WriteLine(0);
                return;
            }

            List<int> pathList = new List<int>();

            for (int i = 0; i < dijk.Count - 1; i++)
            {
                if (stationEdges.Contains(Tuple.Create(dijk[i].Item1, dijk[i + 1].Item1)) || stationEdges.Contains(Tuple.Create(dijk[i + 1].Item1, dijk[i].Item1)))
                {
                    var h = points.IndexOf(dijk[i].Item1) + 1;
                    var f = points.IndexOf(dijk[i + 1].Item1) + 1;
                    if (!pathList.Contains(h))
                    {
                        pathList.Add(h);
                    }
                    if (!pathList.Contains(f))
                    {
                        pathList.Add(f);
                    }
                }
            }

            Console.WriteLine($"{dijk.Last().Item2}");
            Console.Write(pathList.Count + " ");
            foreach (var item in pathList)
            {
                Console.Write(item + " ");
            }
        }
        public static double Time(KeyValuePair<double, double> a, KeyValuePair<double, double> b, double v)
        {
            var y0 = Math.Abs(b.Value - a.Value);
            var x0 = Math.Abs(b.Key - a.Key);
            var s = Math.Sqrt(x0 * x0 + y0 * y0);
            return (double)(s / v);
        }

        static Dictionary<string, int> map = new Dictionary<string, int>();
        static List<List<string>> groups = new List<List<string>>();
        public static void Timus1208()
        {
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                groups.Add(new List<string>());
                for (int l = 0; l < 3; l++)
                {
                    groups[i].Add(input[l]);
                    map[groups[i][l]] = 0;
                }
            }

            for (int i = 0; i < groups.Count; i++)
            {
                map[groups[i][0]] = 1;
                map[groups[i][1]] = 1;
                map[groups[i][2]] = 1;
                Recursion(i + 1, 1);
                map[groups[i][0]] = 0;
                map[groups[i][1]] = 0;
                map[groups[i][2]] = 0;
            }


            Console.WriteLine(max);
        }

        static int max = 0;
        private static void Recursion(int index, int teamNum)
        {
            max = Math.Max(max, teamNum);
            if (index < groups.Count)
            {
                if (map[groups[index][0]] == 0 && map[groups[index][1]] == 0 && map[groups[index][2]] == 0)
                {
                    map[groups[index][0]] = 1;
                    map[groups[index][1]] = 1;
                    map[groups[index][2]] = 1;
                    Recursion(index + 1, teamNum + 1);
                    map[groups[index][0]] = 0;
                    map[groups[index][1]] = 0;
                    map[groups[index][2]] = 0;
                }
                Recursion(index + 1, teamNum);
            }
        }

        static void Timus1112()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            var list = new List<Job>();
            for (int i = 0; i < n; i++)
            {
                var se = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                list.Add(new Job(Math.Min(se[0], se[1]), Math.Max(se[1], se[0]), 1));
            }
            list = list.OrderBy(j => j.start).ToList();
            list = list.OrderBy(j => j.finish).ToList();
            int last = list[0].finish;
            var res = new List<Tuple<int, int>>();
            res.Add(Tuple.Create(list[0].start, list[0].finish));
            for (int i = 1; i < n; i++)
            {
                if (list[i].start >= last)
                {
                    last = list[i].finish;
                    res.Add(Tuple.Create(list[i].start, list[i].finish));
                }
            }
            Console.WriteLine(res.Count);
            foreach (var r in res)
            {
                Console.WriteLine(r.Item1 + " " + r.Item2);
            }
        }

        public static void Timus1506()
        {
            var nk = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = nk[0];
            var k = nk[1];
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            k = (n + k - 1) / k;
            for (int i = 0; i < k; i++)
            {
                for (int j = i; j < input.Length; j += k)
                {
                    if (j > input.Length) break;
                    if (input[j] < 10)
                        Console.Write("   " + input[j]);
                    else if (input[j] < 100)
                        Console.Write("  " + input[j]);
                    else if (input[j] < 1000)
                        Console.Write(" " + input[j]);
                }
                Console.WriteLine();
            }
        }

    }
}
