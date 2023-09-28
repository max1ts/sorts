using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Data?");
            var parts = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
            var array = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                array[i] = Convert.ToInt32(parts[i]);
            }

            Console.WriteLine("Sort?");
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Selection Sort");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine($"Sorted: {string.Join(", ", BubbleSort(array))}");
                    break;
                case 2:
                    Console.WriteLine($"Sorted: {string.Join(", ", SelectionSort(array))}");
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }

        static void Swap(ref int e1, ref int e2)
        {
            (e1, e2) = (e2, e1);
        }

        static int IndexOfMin(int[] arr, int start)
        {
            var index = start;

            for (var i = start; i < arr.Length; i++)
            {
                if (arr[i] < arr[index])
                {
                    index = i;
                }
            }

            return index;
        }

        static int[] SelectionSort(int[] arr, int currentIndex = 0)
        {
            if (currentIndex == arr.Length)
                return arr;

            var index = IndexOfMin(arr, currentIndex);

            if (index != currentIndex)
            {
                Swap(ref arr[index], ref arr[currentIndex]);
            }

            return SelectionSort(arr, currentIndex + 1);
        }

        static int[] BubbleSort(int[] arr)
        {
            for (var i = 1; i < arr.Length; i++)
            {
                for (var j = 0; j < arr.Length - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }

            return arr;
        }
    }
}