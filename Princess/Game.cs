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
                Console.WriteLine($"{ConsoleKey.D1}. Начать новую игру");
                Console.WriteLine($"{ConsoleKey.D2}. Помощь");
                Console.WriteLine($"{ConsoleKey.D3}. Выход");
                ConsoleKeyInfo result = Console.ReadKey();
                switch (result.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Start();
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine(
                            "Вы управляете героем (символ \'H\' на поле)." +
                            "\nДля движения используйте клавиши управления " +
                            "\n(стрелки вверх, вниз, вправо, влево) и только их!" +
                            "\nВаша цель -- добраться до принцессы (символ \'P\' на поле).");
                        break;
                    case ConsoleKey.D3:
                        Environment.Exit(0);
                        return;
                    default:
                        Console.WriteLine(" -- Неверный ввод! Введите 1, 2 или 3.");
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
            while (true)
            {
                hero.GetMove(GetKey());
            }
        }

        private static void Win()
        {
            string notification = "Победа! Вы дошли до принцессы живым. Хотите попробовать еще?";
            GetNotification(notification);
        }

        private static void Over()
        {
            string notification = "Игра окончена! Вы подорвались на мине. Хотите попробовать еще?";
            GetNotification(notification);
        }

        internal static void CheckGameCondition(int hp)
        {
            int topPosition = Console.CursorTop;
            int leftPosition = Console.CursorLeft;
            if (topPosition == 10 && leftPosition == 20)
            {
                Win();
            }
            else if(hp == 0)
            {
                Over();
            }
        }

        private static void GetNotification(string notification)
        {
            Console.SetCursorPosition(0, 12);
            Console.WriteLine(notification);
            while (true)
            {
                Console.CursorVisible = true;
                Console.WriteLine($"{ConsoleKey.D1}. Да");
                Console.WriteLine($"{ConsoleKey.D2}. Нет");
                ConsoleKeyInfo result = Console.ReadKey();
                switch (result.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Start();
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine();
                        Console.Clear();
                        Menu();
                        break;
                    default:
                        Console.WriteLine(" -- Неверный ввод! Введите 1 или 2.");
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
