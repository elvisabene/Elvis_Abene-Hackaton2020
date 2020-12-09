using System;

namespace Princess
{
    abstract class Character
    {
        protected char charModel;
        protected void SetStartPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(charModel);
        }
        internal static void SetCursorStartPosition()
        {
            Console.SetCursorPosition(2, 1);
        }
    }
}
