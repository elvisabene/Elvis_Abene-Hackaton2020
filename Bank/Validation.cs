using System;

namespace Bank
{
    internal class Validation
    {
        public static string GetName(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                string name = Console.ReadLine();
                bool error = false;
                foreach (char chr in name)
                {
                    if (Char.IsDigit(chr) || Char.IsControl(chr) || Char.IsNumber(chr))
                    {
                        Message.Print("Недопустимый символ в имени!", "Error");
                        error = true;
                        break;
                    }
                }
                if (!error)
                {
                    return name;
                }
            }
        }

        public static int GetMenuResult(int amountOfPoints)
        {
            int result = 0;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out result))
                {
                    Message.Print("Неверный символ! Повторите попытку.", "Error");
                }
                else if (result < 1 || result > amountOfPoints)
                {
                    Message.Print($"Неверный пункт меню. Выберите пункт от 1 до {amountOfPoints} включительно.", "Error");
                }
                else return result;
            }
        }

        public static int GetSum(string type = "")
        {
            Console.WriteLine($"Введите сумму {type}(в денежных единицах):");
            int sum = 0;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out sum))
                {
                    Message.Print("Неверный формат! Повторите попытку.", "Error");
                }
                else if (sum < 0)
                {
                    Message.Print($"Ошибка! Введена отрицательная сумма.", "Error");
                }
                else return sum;
            }
        }
    }
}
