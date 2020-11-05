using System;

namespace Switch_Statement
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            object ob = new object();
            Console.WriteLine(GetType(ob));
            Console.ReadKey();
        }
        private static string GetType(object arg)
        {
            const string String = "String";
            const string Char = "Char";
            const string Int = "Int32";
            const string Double = "Double";
            const string Byte = "Byte";
            const string Decimal = "Decimal";
            const string Bool = "Boolean";
            const string Float = "Single";
            const string Long = "Int64";
            const string Short = "Int16";
            switch (arg.GetType().Name)
            {
                case String:
                    return $"{arg} is string.";
                case Char:
                    return $"{arg} is char.";
                case Int:
                    return $"{arg} is int.";
                case Double:
                    return $"{arg} is double.";
                case Byte:
                    return $"{arg} is byte.";
                case Decimal:
                    return $"{arg} is decimal.";
                case Bool:
                    return $"{arg} is bool.";
                case Float:
                    return $"{arg} is float.";
                case Long:
                    return $"{arg} is long.";
                case Short:
                    return $"{arg} is short.";
                default:
                    return $"{arg} is unknown type.";
            }
        }
    }
}
