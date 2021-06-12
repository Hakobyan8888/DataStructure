using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DataStructureProblems
{
    public class PracticeProblems
    {
        public void FindMazePathGraph()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, m];

            Graph<Point> graph = new Graph<Point>();
            GraphAlgorithms<Point> graphAlgorithms = new GraphAlgorithms<Point>();
            Point startPoint = new Point();
            Point endPoint = new Point();

            int[] directionRow = new int[] { -1, 1, 0, 0 };
            int[] directionColumn = new int[] { 0, 0, -1, 1 };

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = int.Parse(input[j]);
                    if (matrix[i, j] == 1)
                    {
                        graph.AddVertexToList(new Point(i, j));
                    }
                    else if (matrix[i, j] == 0)
                    {
                        startPoint = new Point(i, j);
                        graph.AddVertexToList(startPoint);
                    }
                    else if (matrix[i, j] == 2)
                    {
                        endPoint = new Point(i, j);
                        graph.AddVertexToList(endPoint);
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        int rr = i + directionRow[k];
                        int cc = j + directionColumn[k];
                        if (rr < 0 || cc < 0 || rr > n - 1 || cc > m - 1 || matrix[i, j] == -1 || matrix[rr, cc] == -1) continue;

                        graph.AddEdgeToList(Tuple.Create(new Point(i, j), new Point(rr, cc), 1d));
                    }
                }
            }

            var ans = graphAlgorithms.ShortestPathFunction(graph, startPoint).Invoke(endPoint);
        }



    }
}
