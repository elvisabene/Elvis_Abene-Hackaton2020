using System;

namespace Task3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string incorrectFormat = "Неверный символ! Повторите попытку! ";
            const string incorrectLength = "Возможно размер массива слишком мал.";
            const string incorrectIndex = "Возможно индекс отрицательный или индекс выходит за границы массива.";
            Console.WriteLine("Введите размер массива:");
            int length = GetNumber("Lenght", incorrectFormat + incorrectLength);
            int[] array = GetArray(length, incorrectFormat);
            Console.WriteLine("Введите индекс нового элемента:");
            int newIndex = GetNumber("Index", incorrectFormat + incorrectIndex);
            while (newIndex < 0 || newIndex > length - 1)
            {
                Console.WriteLine(incorrectIndex);
                newIndex = GetNumber("Index", incorrectFormat + incorrectIndex);
            }
            Console.WriteLine("Введите значение нового элемента:");
            int newElement = GetNumber("NewElement", incorrectFormat);
            string message = "Исходный массив:";
            PrintArrayWithMessage(array, message);
            InsertNewElementInArray(newIndex, newElement, array);
            message = "\nМассив после вставки элемента:";
            PrintArrayWithMessage(array, message);
            Console.ReadLine();
        }

        private static int GetNumber(string subtype, string errorMessage)
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
                    default:
                        {
                            return number;
                        }
                }
            }
        }

        private static int[] GetArray(int length, string errorMessage)
        {
            int[] array = new int[length];
            for (int i = 0; i < length - 1; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент");
                array[i] = GetNumber("", errorMessage);
            }
            return array;
        }

        private static void PrintArrayWithMessage(int[] array, string message)
        {
            Console.WriteLine(message);
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
