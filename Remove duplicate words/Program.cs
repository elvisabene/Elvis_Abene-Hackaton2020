using System;
using System.Text;

namespace Remove_duplicate_words
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Console.WriteLine($"Текст без повторяющихся слов:\n{RemoveDuplicateWords(text)}");

            Console.ReadKey();
        }

        private static StringBuilder RemoveDuplicateWords(string text)
        {
            string[] words = text.Split(".,!?-:; ".ToCharArray());
            int length = words.Length;
            for (int i = 0; i < length; i++)
            {
                int counter = 0;
                int[] indexes = new int[length];
                for (int j = 0; j < length; j++)
                {
                    if (words[i] == words[j])
                    {
                        counter++;
                        if (counter > 1)
                        {
                            indexes[i] = j;
                        }
                    }
                }
                if (counter > 1)
                {
                    for (int j = 0; j < length; j++)
                    {
                        if (indexes[j] != 0)
                        {
                            words[indexes[j]] = null;
                        }
                    }
                }
            }
            StringBuilder textWithoutDuplicateWords = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                if (!String.IsNullOrEmpty(words[i]))
                {
                    textWithoutDuplicateWords.Append($"{words[i]} ");
                }
            }
            return textWithoutDuplicateWords;
        }
    }
}
