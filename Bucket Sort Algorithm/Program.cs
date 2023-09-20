using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucket_Sort_Algorithm
{
    internal class Program
    {
        public static void BucketSortAlgorithm(double[] array)
        {
            if (array == null || array.Length <= 1)
                return;

            int n = array.Length;
            List<List<double>> buckets = new List<List<double>>();

            // Create empty buckets
            for (int i = 0; i < n; i++)
            {
                buckets.Add(new List<double>());
            }

            // Place elements into buckets
            foreach (double item in array)
            {
                int index = (int)(item * n);
                buckets[index].Add(item);
            }

            // Sort individual buckets (using Insertion Sort in this example)
            foreach (var bucket in buckets)
            {
                InsertionSort(bucket);
            }

            // Concatenate sorted buckets to get the final sorted array
            int currentIndex = 0;
            foreach (var bucket in buckets)
            {
                foreach (var item in bucket)
                {
                    array[currentIndex++] = item;
                }
            }
        }

        public static void InsertionSort(List<double> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                double current = list[i];
                int j = i - 1;

                while (j >= 0 && list[j] > current)
                {
                    list[j + 1] = list[j];
                    j--;
                }

                list[j + 1] = current;
            }
        }

        public static void DisplayArray(double[] array)
        {
            foreach (double item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    
    static void Main(string[] args)
        {
            double[] array = { 0.42, 0.32, 0.33, 0.52, 0.37, 0.47, 0.51 };

            Console.WriteLine("Original Array:");
            DisplayArray(array);

            BucketSortAlgorithm(array);

            Console.WriteLine("\nSorted Array:");
            DisplayArray(array);
            Console.ReadLine();
        }
    }
}
