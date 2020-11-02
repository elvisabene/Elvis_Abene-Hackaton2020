using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива:");
            int length = GetArrayLength();
            int[] array = ArrayFromUser(length);
            int newIndex = GetIndexOfNewElement(length);
            int newElement = GetValueOfNewElement();
            string message = "Исходный массив:";
            PrintArrayWithMessage(array, message);
            InsertNewElementInArray(newIndex, newElement, array);
            message = "\nМассив после вставки элемента";
            PrintArrayWithMessage(array, message);
            Console.ReadLine();
        }
        static int GetArrayLength()
        {
            int number;
            while (!int.TryParse(Console.ReadLine(), out number) || number < 1)
            {
                Console.WriteLine("Неверный символ! Повторите попытку! Возможно размер массива слишком мал.");
            }
            return number;
        }
        static int[] ArrayFromUser(int length)
        {
            int[] array = new int[length];
            for (int i = 0; i < length - 1; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент");
                while (!int.TryParse(Console.ReadLine(), out array[i]))
                {
                    Console.WriteLine("Неверный формат! Повторите попытку!");
                }
            }
            return array;
        }
        static int GetIndexOfNewElement(int length)
        {
            Console.WriteLine("Введите индекс нового элемента:");
            int index = 0;
            while (!int.TryParse(Console.ReadLine(), out index) || index < 0 || index > length - 1)
            {
                Console.WriteLine("Неверный символ! Повторите попытку! Возможно индекс отрицательный или индекс выходит за границы массива.");
            }
            return index;
        }
        static int GetValueOfNewElement()
        {
            Console.WriteLine("Введите значение нового элемента:");
            int value = 0;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Неверный формат! Повторите попытку!");
            }
            return value;
        }
        static void PrintArrayWithMessage(int[] array, string message)
        {
            Console.WriteLine(message + "\n");
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
        }
        static void InsertNewElementInArray(int newindex, int newelement, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i == newindex)
                {
                    for (int j = array.Length - 1; j > newindex; j--)
                    {
                        array[j] = array[j - 1];
                    }
                    array[i] = newelement;
                    break;
                }
            }
        }
    }
}
