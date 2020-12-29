using System;

namespace Bomb
{
    class Program
    {
        static void Main(string[] args)
        {
            while (Game.NewGameRequested)
            {
                Game.Start();
            }
        }
    }
}
