using System;

namespace Task2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Для ввода массива с клавитуры нажмите                  \"1\"\n" +
                              "Для заполнения массива случайными числами нажмите      \"2\"");

            int result = GetNumber("Number1or2", out int number, "Неверный символ! Повторите попытку! Введите символ 1 или 2!");
            Console.WriteLine("Введите размер массива:");
            int length = GetNumber("Length", out number, "Неверный символ! Повторите попытку! Возможно размер массива слишком мал.");
            int[] array;
            if (result == 1)
            {
                array = InputArray(length);
            }
            else
            {
                array = GetRandomArray(length);
            }
            string message = "Исходный массив:";
            PrintArrayWithMessage(array, message);
            Console.WriteLine(GetResult(array));
            Console.ReadKey();
        }

        private static int[] InputArray(int length)
        {
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент");
                array[i] = GetNumber("", out int number, "Неверный формат! Повторите попытку!");
            }
            return array;
        }

        private static int GetNumber(string subtype, out int number, string errorMessage)
        {
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine(errorMessage);
                }
                switch (subtype)
                {
                    case "Number1or2":
                        if (number == 1 || number == 2)
                        {
                            return number;
                        }
                        else
                        {
                            Console.WriteLine(errorMessage);
                            break;
                        }
                    case "Length":
                        if (number > 0)
                        {
                            return number;
                        }
                        else
                        {
                            Console.WriteLine(errorMessage);
                            break;
                        }
                    default:
                        return number;
                }
            }
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
            Console.WriteLine(message + "\n");
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
        }

        private static string GetResult(int[] array)
        {
            int[] count = new int[array.Length];
            int index = 0;
            array = SortArray(array);
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        count[i]++;
                    }
                }
                if (i > 0)
                {
                    if (count[i - 1] < count[i])
                    {
                        index = i;
                    }
                }
            }
            if (count[0] > count[index])
            {
                index = 0;
            }
            else if (count[count.Length - 1] > count[index])
            {
                index = count.Length - 1;
            }
            if (index == 0 && count[0] == 1)
            {
                return "\nВ массиве все числа встречаются по одному разу";
            }
            else
            {
                return $"\nЧаще всего в массиве встречается число {array[index].ToString()}.";
            }
        }

        private static int[] SortArray(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }

    }
}
