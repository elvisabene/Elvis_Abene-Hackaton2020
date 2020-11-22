using System;

namespace Bank
{
    internal static class Message
    {
        public static void Print(string message, string typeMessage)
        {
            ConsoleColor textColor = ConsoleColor.White;
            switch (typeMessage)
            {
                case "Error": textColor = ConsoleColor.Red; break;
                case "Warning": textColor = ConsoleColor.DarkYellow; break;
                case "Success": textColor = ConsoleColor.Green; break;
            }
            Console.ForegroundColor = textColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
