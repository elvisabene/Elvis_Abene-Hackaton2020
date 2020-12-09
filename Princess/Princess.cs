using System;

namespace Princess
{
    internal class Princess : Character
    {
        public Princess()
        {
            charModel = 'P';
            Console.ForegroundColor = ConsoleColor.Magenta;
            SetStartPosition(20, 10);
            Console.ResetColor();
        }
    }
}
