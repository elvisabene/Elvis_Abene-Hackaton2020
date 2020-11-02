using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для ввода массива с клавитуры нажмите                  \"1\"\n" +
                              "Для заполнения массива случайными числами нажмите      \"2\"");

            int result = GetNumber1Or2();
            Console.WriteLine("Введите размер массива:");
            int length = GetArrayLength();
            int[] array;
            if (result == 1)
            {
                array = ArrayFromUser(length);
            }
            else
            {
                array = ArrayWithRandomNumbers(length);
            }
            string message = "Исходный массив:";
            PrintArrayWithMessage(array,message);
            Console.WriteLine($"\n{GetMessageAboutMostFrequentNumberIn(array)}.");
            Console.ReadKey();
        }
        static int GetNumber1Or2()
        {
            int number;
            while (!int.TryParse(Console.ReadLine(), out number) || number != 1 && number != 2)
            {
                Console.WriteLine("Неверный символ! Повторите попытку! Введите символ 1 или 2!");
            }
            return number;
            
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
            for (int i = 0; i<length; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент");
                while (!int.TryParse(Console.ReadLine(), out array[i]))
                {
                    Console.WriteLine("Неверный формат! Повторите попытку!");
                }
            }
            return array;
        }
        static int[] ArrayWithRandomNumbers(int length)
        {
            int[] array = new int[length];
            Random random = new Random();
            for (int i = 0; i<length; i++)
            {
                array[i] = random.Next(-10, 10);
            }
            return array;
        }
        static void PrintArrayWithMessage(int [] array, string message) 
        {
            Console.WriteLine(message+"\n");
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
        }
        static string GetMessageAboutMostFrequentNumberIn(int [] array)
        {
            int k = -1; //индекс наиболее встречаемого элемента
            int f = 0;  //количество встреч элемента в массиве
            for(int i = 0; i<array.Length; i++)
            {
                int[] matches = Array.FindAll(array, x => x == array[i]);
                if(matches.Length > f)
                {
                    if (matches.Length == 1)
                    {
                        continue;
                    }
                    f = matches.Length;
                    k = i;
                }
            }
            if (k == -1)
            {
                return "В массиве все числа встречаются по одному разу!";
            }
            else  
            {
                return $"Чаще всего в массиве встречается число {array[k].ToString()}";
            }

        }
    }
}
