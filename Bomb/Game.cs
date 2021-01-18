using System;
using System.Threading.Tasks;
using System.Threading;

namespace Bomb
{
    static class Game
    {
        static int time;
        static int attempts;
        static int gamePassword;
        static int userPassword;
        public static bool NewGameRequested { get; set; } = true;

        static GameState gameState;

        delegate void GameStateHandler();
        static event GameStateHandler StateNotify = Notify;

        enum GameState
        {
            Win,
            TimeOver,
            NoAttempts,
            Undefined
        }

        public static void Start()
        {
            ClearGameState();
            attempts = GetAttempts();
            time = GetTime();
            gamePassword = GetRandomPassword();
            StartNotify();
            Task.WaitAll(Task.Run(() => StartTimer()), Task.Run(() => GuessPassword()));
        }

        static void ClearGameState()
        {
            NewGameRequested = false;
            gameState = GameState.Undefined;
        }

        static int GetAttempts()
        {
            Console.Write("Введите количество попыток: ");
            return GetNaturalNumber();
        }

        static int GetTime()
        {
            Console.Write("Введите время таймера (в секундах): ");
            return GetNaturalNumber();
        }

        static int GetRandomPassword()
        {
            Console.WriteLine("Создаю случайный пароль(числа от 1 до 14)...");
            int password = new Random().Next(1, 15);
            Thread.Sleep(1000);
            Console.WriteLine("Случайный пароль создан!");
            Thread.Sleep(1000);
            return password;
        }

        static void StartNotify()
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

        static void StartTimer()
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

        static void GuessPassword()
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

        static int GetNaturalNumber()
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

        static void Notify()
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

        static void PrintColorText(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        static void NewGameRequestMenu()
        {
            Console.WriteLine("Введите цифру:");
            Console.WriteLine("1, если хотите начать новую игру");
            Console.WriteLine("2, если хотите выйти из игры");
        }

        static void SetNewGameRequestResult(int number = 0)
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
