using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers separated by a space:");
            string input = Console.ReadLine();
            int[] digits = Array.ConvertAll(input.Split(' '), int.Parse); // Splitting entered numbers
            digits = Sort(digits);
            foreach (int d in digits)
                Console.Write(d + " ");
            Console.WriteLine();
        }

        static int[] Sort(int[] c)
        {
            if (c.Length <= 1) // divide until there is only one element in array
                return c;
            else
            {
                int middleNum = c.Length / 2; // Index of the middle element
                int rightSize = c.Length - middleNum; // Amount of numbers in second half
                int[] left = new int[middleNum]; // first half of numbers
                int[] right = new int[rightSize]; // second half of numbers
                Array.Copy(c, left, middleNum); // Copying first half
                Array.Copy(c, middleNum, right, 0, rightSize); // Copying second half
                left = Sort(left);
                right = Sort(right);
                return Merge(left, right);
            }
        }
        
        // comparison of two subarrays and merging them into one
        static int[] Merge(int[] a, int[] b)
        {
            int[] c = new int[a.Length + b.Length];
            for(int i = 0, j = 0, k = 0; k < a.Length + b.Length; k++)
            {
                if ((j >= b.Length) || (i < a.Length && a[i] < b[j]))
                {
                    c[k] = a[i];
                    i++;
                }
                else
                {
                    c[k] = b[j];
                    j++;
                }
            }
            return c;
        }
    }
}
