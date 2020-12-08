using System;

namespace Princess
{
    public enum Step
    {
        Left = -2,
        Right = 2,
        Up = -1,
        Down = 1
    }
    internal class Hero : Character
    {
        private int HP = 10;
        private int leftPosition = 2;
        private int topPosition = 1;
        private int messageLine = 1;

        public Hero()
        {
            charModel = 'H';
            PrintHPInfo();
            SetStartPosition(2, 1);
        }

        public void GetMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    {
                        MoveLeft();
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        MoveUp();
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        MoveRight();
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        MoveDown();
                        break;
                    }
                default:
                    {
                        MoveHero();
                        break;
                    }
            }
        }

        private void MoveRight()
        {
            leftPosition += (int)Step.Right;
            MoveHero();
        }

        private void MoveLeft()
        {
            leftPosition += (int)Step.Left;
            MoveHero();
        }

        private void MoveDown()
        {
            topPosition += (int)Step.Down;
            MoveHero();
        }

        private void MoveUp()
        {
            topPosition += (int)Step.Up;
            MoveHero();
        }

        private void MoveHero()
        {
            CheckBoarder();
            Console.SetCursorPosition(leftPosition, topPosition);
            CheckBomb();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(charModel);
            Console.ResetColor();
            Console.SetCursorPosition(leftPosition, topPosition);
            Game.CheckGameCondition(HP);
        }

        private void CheckBoarder()
        {
            if (topPosition == 0)
            {
                topPosition += (int)Step.Down;
            }
            else if (topPosition == 11)
            {
                topPosition += (int)Step.Up;
            }
            else if (leftPosition == 0)
            {
                leftPosition += (int)Step.Right;
            }
            else if (leftPosition == 22)
            {
                leftPosition += (int)Step.Left;
            }
        }

        private void CheckBomb()
        {
            if (Game.field.IsBomb[topPosition, leftPosition])
            {
                TakeDamage();
                Game.field.IsBomb[topPosition, leftPosition] = false;
                PrintHPInfo();
                MoveHero();
            }
        }

        private void PrintHPInfo()
        {
            Console.SetCursorPosition(30, 0);
            Console.WriteLine($"Очки здоровья: {HP}   ");
        }

        private void TakeDamage()
        {
            var randomDamage = new Random().Next(1, 11);
            HP -= randomDamage;
            Console.SetCursorPosition(30, messageLine++);
            Console.WriteLine($"Вы наступаете на мину и получаете {randomDamage} очков урона.");
            if (HP <= 0)
            {
                HP = 0;
                PrintHPInfo();
            }
        }
    }
}
