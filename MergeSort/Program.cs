using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter digits:");
            string input = Console.ReadLine();
            int[] digits = Array.ConvertAll(input.Split(' '), int.Parse);
            digits = Sort(digits);
            foreach (int d in digits)
                Console.Write(d + " ");
        }

        static int[] Sort(int[] c)
        {
            if (c.Length <= 1)
                return c;
            else
            {
                int middleNum = c.Length / 2;
                int rightSize = c.Length - middleNum;
                int[] left = new int[middleNum];
                int[] right = new int[rightSize];
                Array.Copy(c, left, middleNum);
                Array.Copy(c, middleNum, right, 0, rightSize);
                left = Sort(left);
                right = Sort(right);
                return Merge(left, right);
            }
        }

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
