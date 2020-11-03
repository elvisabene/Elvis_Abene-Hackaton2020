using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Введите стороны треугольника:");
            double SideA = GetTriangleSide();
            double SideB = GetTriangleSide();
            double SideC = GetTriangleSide();
            if (SideA + SideB >= SideC && 
                SideA + SideC >= SideB && 
                SideB + SideC >= SideA)
            {
                if (SideA == SideB && SideA == SideC)
                {
                    Console.WriteLine("Треугольник равносторонний.");
                }
                else if (SideA + SideB == SideC || SideA + SideC == SideB || SideB + SideC == SideA)
                {
                    Console.WriteLine("Треугольник вырожденный.");
                }
                else if (SideA == SideB || SideB == SideC || SideA == SideC)
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
