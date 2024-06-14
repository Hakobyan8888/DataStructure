using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DataStructureProblems
{
    public class SortingAlgorithms
    {
        /// <summary>
        /// Selection Sort 
        /// Complexity O(n^2)
        /// </summary>
        /// <param name="array"></param>
        public void SelectionSort(List<int> array)
        {
            for (int i = 0; i < array.Count; i++)
            {
                var minIndex = i;
                for (int j = i + 1; j < array.Count; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                Swap(ref array, minIndex, i);
            }
            foreach (var item in array)
            {
                Console.Write($"{item}, ");
            }
        }

        /// <summary>
        /// Bubble Sort 
        /// Complexity O(n^2)
        /// </summary>
        /// <param name="array"></param>
        public void BubbleSort(List<int> array)
        {
            int n = array.Count;
            while (n > 0)
            {
                bool isSorted = true;
                for (int i = 0; i < n - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        isSorted = false;
                        Swap(ref array, i, i + 1);
                    }
                }
                if (isSorted) return;
                n--;
            }
            foreach (var item in array)
            {
                Console.Write($"{item}, ");
            }
        }

        /// <summary>
        /// Insertion Sort
        /// Best case O(n)
        /// Worst case O(n^2)
        /// </summary>
        /// <param name="array"></param>
        public void InsertionSort(List<int> array)
        {
            for (int i = 1; i < array.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[i] < array[j])
                    {
                        Swap(ref array, i, j);
                    }
                }
            }
            foreach (var item in array)
            {
                Console.Write($"{item}, ");
            }
        }

        /// <summary>
        /// Counting Sort
        /// Complexity O(n + count.length)
        /// </summary>
        /// <param name="array"></param>
        public void CountingSort(List<int> array)
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

        #region MergeSort
        /// <summary>
        /// Merge Sort
        /// Time Complexity O(n * lg(n))
        /// Extra memory storage O(n)
        /// </summary>
        /// <param name="array"></param>
        public void MergeSortResult(List<int> array)
        {
            var result = MergeSort(ref array);

            foreach (var item in result)
            {
                Console.Write($"{item}, ");
            }
        }

        private List<int> MergeSort(ref List<int> array)
        {
            if (array.Count <= 1) return array;
            var left = new List<int>();
            var right = new List<int>();
            var midPoint = array.Count / 2;
            for (int i = 0; i < midPoint; i++)
            {
                left.Add(array[i]);
            }
            for (int i = midPoint; i < array.Count; i++)
            {
                right.Add(array[i]);
            }

            MergeSort(ref left);
            MergeSort(ref right);

            array = Merge(ref left, ref right);
            return array;
        }

        private List<int> Merge(ref List<int> left, ref List<int> right)
        {
            int leftIndex = 0, rightIndex = 0;
            var mergedList = new List<int>();
            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    mergedList.Add(left[leftIndex++]);
                }
                else
                {
                    mergedList.Add(right[rightIndex++]);
                }
            }
            while (leftIndex < left.Count)
            {
                mergedList.Add(left[leftIndex++]);
            }
            while (rightIndex < right.Count)
            {
                mergedList.Add(right[rightIndex++]);
            }
            return mergedList;
        }
        #endregion

        #region QuickSort
        /// <summary>
        /// Quick Sort
        /// Time Complexity O(n * log(n))
        /// </summary>
        /// <param name="array"></param>
        public void QuickSort(List<int> array)
        {
            var result = QuickSort(array, 0, array.Count);
            foreach (var item in result)
            {
                Console.Write($"{item}, ");
            }
        }

        private List<int> QuickSort(List<int> array, int low, int high)
        {
            if (low < high)
            {
                var pivot = Partition(ref array, low, high);

                QuickSort(array, low, pivot);
                QuickSort(array, pivot + 1, high);
            }
            return array;
        }

        private int Partition(ref List<int> array, int low, int high)
        {
            var pivot = low;
            var pivotPosition = low;

            for (int i = low + 1; i < high; i++)
            {
                if (array[pivot] > array[i])
                {
                    pivotPosition++;
                    Swap(ref array, i, pivotPosition);
                }
            }
            Swap(ref array, pivot, pivotPosition);
            return pivotPosition;
        }
        #endregion

        public void Swap(ref List<int> array, int indexI, int indexJ)
        {
            if (indexI == indexJ) return;
            var indexIValue = array[indexI];
            array[indexI] = array[indexJ];
            array[indexJ] = indexIValue;
        }
    }
}
