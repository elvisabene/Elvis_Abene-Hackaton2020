using System;
using System.Threading.Tasks;
using System.Threading;

namespace Bomb
{
    internal static class Game
    {
        private static int time;
        private static int attempts;
        private static int gamePassword;
        private static int userPassword;
        public static bool NewGameRequested { get; set; } = true;

        private static GameState gameState;

        private delegate void GameStateHandler();
        private static event GameStateHandler StateNotify = Notify;

       

        public static void Start()
        {
            ClearGameState();
            attempts = GetAttempts();
            time = GetTime();
            gamePassword = GetRandomPassword();
            StartNotify();
            Task.WaitAll(Task.Run(() => StartTimer()), Task.Run(() => GuessPassword()));
        }

        private static void ClearGameState()
        {
            NewGameRequested = false;
            gameState = GameState.Undefined;
        }

        private static int GetAttempts()
        {
            Console.Write("Введите количество попыток: ");
            return GetNaturalNumber();
        }

        private static int GetTime()
        {
            Console.Write("Введите время таймера (в секундах): ");
            return GetNaturalNumber();
        }

        private static int GetRandomPassword()
        {
            Console.WriteLine("Создаю случайный пароль(числа от 1 до 14)...");
            int password = new Random().Next(1, 15);
            Thread.Sleep(1000);
            Console.WriteLine("Случайный пароль создан!");
            Thread.Sleep(1000);
            return password;
        }

        private static void StartNotify()
        {
            Console.CursorVisible = false;
            PrintColorText(ConsoleColor.Blue, "Начало новой игры...");
            Console.WriteLine("Игра начинается через ");
            for (int i = 5; i > 0; i--)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
            Console.CursorVisible = true;
        }

        private static void StartTimer()
        {
            for (int i = 0; i < time; i++)
            {
                if (gameState != GameState.Undefined)
                {
                    return;
                }
                Console.Beep(6000, 150);
                Thread.Sleep(850);
            }
            gameState = GameState.TimeOver;
            StateNotify.Invoke();
        }

        private static void GuessPassword()
        {
            for (int i = 0; i < attempts; i++)
            {
                Console.WriteLine($"Попытка {i + 1}");
                userPassword = GetNaturalNumber();
                if (gameState == GameState.TimeOver)
                {
                    SetNewGameRequestResult(userPassword);
                    return;
                }
                else if (userPassword == gamePassword)
                {
                    gameState = GameState.Win;
                    StateNotify.Invoke();
                    SetNewGameRequestResult();
                    return;
                }
            }
            gameState = GameState.NoAttempts;
            StateNotify.Invoke();
            SetNewGameRequestResult();
        }

        private static int GetNaturalNumber()
        {
            int number = 0;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out number) && !(number < 0))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода!");
                }
            }
        }

        private static void Notify()
        {
            switch (gameState)
            {
                case GameState.Win:
                    {
                        PrintColorText(ConsoleColor.Green, "Вы угадали!");
                        break;
                    }
                case GameState.TimeOver:
                    {
                        PrintColorText(ConsoleColor.Red, "Время вышло! Вы проиграли.");
                        break;
                    }
                case GameState.NoAttempts:
                    {
                        PrintColorText(ConsoleColor.Red, "Попытки закончились! Вы проиграли.");

                        break;
                    }
            }
            NewGameRequestMenu();
        }

        private static void PrintColorText(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void NewGameRequestMenu()
        {
            Console.WriteLine("Введите цифру:");
            Console.WriteLine("1, если хотите начать новую игру");
            Console.WriteLine("2, если хотите выйти из игры");
        }

        private static void SetNewGameRequestResult(int number = 0)
        {
            int result = number;
            while (true)
            {
                if (result == 1)
                {
                    NewGameRequested = true;
                    return;
                }
                else if (result == 2)
                {
                    NewGameRequested = false;
                    return;
                }
                result = GetNaturalNumber();
            }
        }
    }
}
