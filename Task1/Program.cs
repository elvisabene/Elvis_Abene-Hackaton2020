using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Введите стороны треугольника:");
            double firstSide = GetTriangleSide();
            double secondSide = GetTriangleSide();
            double thirdSide = GetTriangleSide();
            if (firstSide + secondSide >= thirdSide &&
                firstSide + thirdSide >= secondSide &&
                secondSide + thirdSide >= firstSide)
            {
                if (firstSide == secondSide && firstSide == thirdSide)
                {
                    Console.WriteLine("Треугольник равносторонний.");
                }
                else if (firstSide + secondSide == thirdSide || firstSide + thirdSide == secondSide || secondSide + thirdSide == firstSide)
                {
                    Console.WriteLine("Треугольник вырожденный.");
                }
                else if (firstSide == secondSide || secondSide == thirdSide || firstSide == thirdSide)
                {
                    Console.WriteLine("Треугольник равнобедренный.");
                }
                else
                {
                    Console.WriteLine("Треугольник разносторонний.");
                }
            }
            else
            {
                Console.WriteLine("Такого треугольника не существует!");
            }
            Console.ReadKey();
        }

        private static double GetTriangleSide()
        {
            double sideLength = 0;
            while (!double.TryParse(Console.ReadLine(),out sideLength) || sideLength<=0)
            {
                Console.WriteLine("Неверный формат! Повторите попытку!");
            }
            return sideLength;
        }

    }
}
