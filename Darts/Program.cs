using System;

namespace Darts
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            double x = GetCoordinate("x");
            double y = GetCoordinate("y");
            Console.WriteLine($"Ваш результат: {GetResult(x, y)}.");
            Console.ReadKey();
        }

        private static double GetCoordinate(string coordinate)
        {
            Console.WriteLine($"Введите координату {coordinate} точки попадания:");
            double number = 0;
            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Неверный формат! Повторите попытку!");
            }
            return number;
        }

        private static int GetScore(double x, double y)
        {
            double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            if (distance <= 1)
            {
                return 10;
            }
            else if (distance <= 5)
            {
                return 5;
            }
            else if (distance <= 10)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private static string GetResult(double x, double y)
        {
            int scores = GetScore(x, y);
            switch (scores)
            {
                case 1:
                    {
                        return $"{scores} очко";
                    }
                default:
                    {
                        return $"{scores} очков";
                    }
            }
        }
    }
}
