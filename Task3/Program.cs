using System;

namespace Task3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива:");
            string errorMessage = "Неверный символ! Повторите попытку! Возможно размер массива слишком мал.";
            int length = GetNumber("Lenght", errorMessage, 0);
            int[] array = GetArray(length);
            Console.WriteLine("Введите индекс нового элемента:");
            errorMessage = "Неверный символ! Повторите попытку! Возможно индекс отрицательный или индекс выходит за границы массива.";
            int newIndex = GetNumber("Index", errorMessage, length);
            Console.WriteLine("Введите значение нового элемента:");
            errorMessage = "Неверный символ! Повторите попытку!";
            int newElement = GetNumber("NewElement", errorMessage, 0);
            string message = "Исходный массив:";
            PrintArrayWithMessage(array, message);
            InsertNewElementInArray(newIndex, newElement, array);
            message = "\nМассив после вставки элемента";
            PrintArrayWithMessage(array, message);
            Console.ReadLine();
        }

        private static int GetNumber(string subtype, string errorMessage, int arrayLength)
        {
            int number = 0;
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine(errorMessage);
                }
                switch (subtype)
                {
                    case "Lenght":
                        {
                            if (number > 0)
                            {
                                return number;
                            }
                            else
                            {
                                Console.WriteLine(errorMessage);
                                break;
                            }
                        }
                    case "Index":
                        if (number >= 0 && number <= arrayLength - 1)
                        {
                            return number;
                        }
                        else
                        {
                            Console.WriteLine(errorMessage);
                            break;
                        }
                    default:
                        {
                            return number;
                        }
                }
            }
        }

        private static int[] GetArray(int length)
        {
            int[] array = new int[length];
            for (int i = 0; i < length - 1; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент");
                array[i] = GetNumber("", "Неверный формат! Повторите попытку!", 0);
            }
            return array;
        }

        private static void PrintArrayWithMessage(int[] array, string message)
        {
            Console.WriteLine(message + "\n");
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
        }

        private static void InsertNewElementInArray(int newindex, int newelement, int[] array)
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
