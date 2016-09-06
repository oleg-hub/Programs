using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Sort(int[] array, int left, int right)
        {
            int i = left;
            int j = right;
            int x = array[(left + right) / 2];
            while (i <= j)
            {
                while (array[i] < x) i++;
                while (array[j] > x) j--;
                if (i <= j)
                {
                    int k = array[i];
                    array[i] = array[j];
                    array[j] = k;
                    i++;
                    j--;
                }
            }
            //Рекурсия
            if (left < j) Sort(array, left, j);
            if (i < right) Sort(array, i, right);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массива:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            Console.WriteLine("Введите массив чисел:");
            string[] digits = Console.ReadLine().Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < digits.Length; i++)
                array[i] = Convert.ToInt32(digits[i]);
            Console.WriteLine("Сортировка");
            Sort(array, 0, array.Length - 1);
            foreach (int i in array)
                Console.WriteLine(i + " ");
            Console.ReadKey();
        }
    }
}
