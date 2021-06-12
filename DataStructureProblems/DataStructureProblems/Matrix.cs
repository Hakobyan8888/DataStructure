using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureProblems
{
    struct Matrix
    {
        readonly int n;

        public Matrix(int n)
        {
            this.n = n;
        }

        const int maxn = 105;
        public static int[,] el = new int[maxn, maxn];
        static int[,] sums = new int[maxn, maxn];

        public void Input()
        {
            for (int i = 0; i < n; ++i)
            {
                string[] input = Console.ReadLine().Split();
                for (int j = 0; j < n; ++j)
                    el[i, j] = int.Parse(input[j]);
            }
        }

        public void PrecalcPrefixSums()
        {
            sums[0, 0] = el[0, 0];
            for (int j = 1; j < n; ++j)
                sums[0, j] = sums[0, j - 1] + el[0, j];
            for (int i = 1; i < n; ++i)
                sums[i, 0] = sums[i - 1, 0] + el[i, 0];
            for (int i = 1; i < n; ++i)
                for (int j = 1; j < n; ++j)
                    sums[i, j] = sums[i - 1, j] + sums[i, j - 1] - sums[i - 1, j - 1] + el[i, j];
        }

        public int GetSubmatrixSum(int uli, int ulj, int lri, int lrj)
        {
            if (uli == 0 && ulj == 0)
            {
                return sums[lri, lrj];
            }
            if (uli == 0)
            {
                return sums[lri, lrj] - sums[lri, ulj - 1];
            }
            if (ulj == 0)
            {
                return sums[lri, lrj] - sums[uli - 1, lrj];
            }
            return sums[lri, lrj] - sums[uli - 1, lrj] - sums[lri, ulj - 1] + sums[uli - 1, ulj - 1];
        }
    }
}
