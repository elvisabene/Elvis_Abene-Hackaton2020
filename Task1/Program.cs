using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите стороны треугольника:");
                    double a = int.Parse(Console.ReadLine());
                    double b = int.Parse(Console.ReadLine());
                    double c = int.Parse(Console.ReadLine());
                    if (a + b >= c && a + c >= b && b + c >= a)
                    {
                        if (a == b && a == c)
                        {
                            Console.WriteLine("Треугольник равносторонний!");
                        }
                        else if (a + b == c || a + c == b || b + c == a)
                        {
                            Console.WriteLine("Треугольник вырожденный!(оказывается и такой бывает ^_^)");
                        }
                        else if (a == b || b == c || a == c)
                        {
                            Console.WriteLine("Треугольник равнобедренный!");
                        }
                        else
                        {
                            Console.WriteLine("Треугольник разносторонний!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Треугольник не существует!");
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine("Ошибка:" + e.Message);
                }
            }
        }
    }
}
