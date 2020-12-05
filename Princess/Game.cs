using System;

namespace Princess
{
    internal static class Game
    {
        public static Field field;
        private static Hero hero;
        private static Princess princess;
        public static void Menu()
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Начать новую игру");
                Console.WriteLine("2. Помощь");
                Console.WriteLine("3. Выход");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Start();
                        break;
                    case "2":
                        Console.WriteLine(
                            "Вы управляете героем (символ \'H\' на поле)." +
                            "\nДля движения используйте клавиши управления " +
                            "\n(стрелки вверх, вниз, вправо, влево) и только их!" +
                            "\nВаша цель -- добраться до принцессы (символ \'P\' на поле).");
                        break;
                    case "3":
                        Environment.Exit(0);
                        return;
                    default:
                        Console.WriteLine("Неверный ввод! Введите 1, 2 или 3.");
                        break;
                }
            }
        }

        public static void Start()
        {
            Console.CursorVisible = false;
            field = new Field();
            hero = new Hero();
            princess = new Princess();
            Character.SetCursorStartPosition();
            while(true)
            {
                hero.Move(GetKey());
            }
        }

        public static void Win()
        {
            string notification = "Победа! Вы дошли до принцессы живым. Хотите попробовать еще?";
            GetNotification(notification);
        }

        public static void Over()
        {
            string notification = "Игра окончена! Вы подорвались на мине. Хотите попробовать еще?";
            GetNotification(notification);
        }

        private static void GetNotification(string notification)
        {
            Console.SetCursorPosition(0, 12);
            Console.WriteLine(notification);
            Console.CursorVisible = true;
            Console.WriteLine("1. Да");
            Console.WriteLine("2. Нет");
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Start();
                        break;
                    case "2":
                        Console.WriteLine();
                        Console.Clear();
                        Menu();
                        break;
                    default:
                        Console.WriteLine("Неверный ввод! Введите 1 или 2.");
                        break;

                }
            }
        }

        private static ConsoleKey GetKey()
        {
            while (true)
            {
                ConsoleKey k = Console.ReadKey().Key;
                if (k == ConsoleKey.DownArrow ||
                    k == ConsoleKey.UpArrow ||
                    k == ConsoleKey.LeftArrow ||
                    k == ConsoleKey.RightArrow)
                {
                    return k;
                }
                else
                {
                    return ConsoleKey.A;
                }
            }
        }

        
    }
}
