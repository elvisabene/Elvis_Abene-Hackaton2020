using System;

namespace Princess
{
    internal class Field
    {
        public bool[,] IsBomb { get; set;} = new bool[12, 23];
        private const char bomb = ' ';
        private const char empty = ' ';
        private const char notBomb = '0';
        private const char wall = '#';

        public Field()
        {
            char[] bombCollection = new char[10];
            for(int i = 0; i < 10; i++)
            {
                bombCollection[i] = bomb;
            }
            Random randomSetBomb = new Random();
            int setBombCase = 1;
            char [,] field = new char[12, 23];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    bool notStartOrEnd = (i != 1 && j != 2) || (i != 10 && j != 20);
                    bool hasBombs = Array.Exists(bombCollection, x => x == bomb);
                    if ( i == 0 || j == 0 || i == 11 || j == 22)
                    {
                        if (j % 2 == 0)
                        {
                            Console.Write(wall);
                        }
                        else
                        {
                            Console.Write(empty);
                        }
                    }
                    else
                    {
                        if (notStartOrEnd && randomSetBomb.Next(1,9) == setBombCase && j % 2 == 0 && hasBombs)
                        {
                            Console.Write(bomb);
                            IsBomb[i, j] = true;
                            int index = Array.FindLastIndex(bombCollection, x => x == bomb);
                            bombCollection[index] = notBomb;
                        }
                        else
                        {
                            Console.Write(empty);
                        }
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
