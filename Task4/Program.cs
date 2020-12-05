using System;

namespace Task4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int length = GetArrayLength();
            int[] array = GetRandomArray(length);
            PrintArrayWithMessage(array, "Исходный массив:");
            PrintArrayWithMessage(SortArray(array), "Массив после сортировки:");
            Console.ReadKey();
        }

        private static int[] GetRandomArray(int length)
        {
            int[] array = new int[length];
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(-10, 10);
            }
            return array;
        }

        private static void PrintArrayWithMessage(int[] array, string message)
        {
            Console.WriteLine("\n" + message + "\n");
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
        }

        private static int GetArrayLength()
        {
            Console.WriteLine("Введите размер массива:");
            int number;
            while (!int.TryParse(Console.ReadLine(), out number) || number < 1)
            {
                Console.WriteLine("Неверный символ! Повторите попытку! Возможно размер массива слишком мал.");
            }
            return number;
        }

        private static int[] SortArray(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }
                }
            }
            return array;
        }
    }
}
