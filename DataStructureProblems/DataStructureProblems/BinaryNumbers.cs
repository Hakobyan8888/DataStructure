using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureProblems
{
    public class BinaryNumbers
    {
        public void printTheArray(int[] arr, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                if (arr[i] == arr[i + 1] && arr[i + 1] == 0) return;
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i]);
            }
            Console.WriteLine();
        }

        public void generateAllBinaryStrings(int n, int[] arr, int i)
        {
            if (i == n)
            {
                printTheArray(arr, n);
                return;
            }

            arr[i] = 0;
            generateAllBinaryStrings(n, arr, i + 1);

            arr[i] = 1;
            generateAllBinaryStrings(n, arr, i + 1);
        }

    }
}
