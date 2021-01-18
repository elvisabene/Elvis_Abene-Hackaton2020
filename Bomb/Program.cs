using System;

namespace Bomb
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (Game.NewGameRequested)
            {
                Game.Start();
            }
        }
    }
}
