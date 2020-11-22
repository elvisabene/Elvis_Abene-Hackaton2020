using System;

namespace Bank
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Data.ReadClientsFromFile();
            LogIn();
            MainMenu();
        }

        private static void LogIn()
        {
            Console.WriteLine("Bank. Для выбора пункта меню введите его номер.");
            Console.WriteLine("Пройдите авторизацию.");
            while (true)
            {
                string fullName = Validation.GetName("Введите ваше имя:");
                foreach (Client client in Data.clientList)
                {
                    if (fullName == client.FullName)
                    {
                        Data.currentClient = client;
                        return;
                    }
                }
                Message.Print("Такого клиента нет! Выберите следующее действие:", "Warning");
                Console.WriteLine("1. Добавить меня как нового клиента.");
                Console.WriteLine("2. Ввести полное имя заново.");
                Range range = 1..3;
                switch (Validation.GetMenuResult(2))
                {
                    case 1:
                        {
                            Data.AddClient(new Client(fullName));
                            return;
                        }
                    case 2:
                        {
                            break;
                        }
                }
            }
        }

        private static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Создать счет");
                Console.WriteLine("2. Создать карту");
                Console.WriteLine("3. Провести операцию");
                Console.WriteLine("4. Клиентская информация");
                Console.WriteLine("5. Выход из приложения");
                switch (Validation.GetMenuResult(5))
                {
                    case 1:
                        {
                            CreateAccountMenu();
                            break;
                        }
                    case 2:
                        {
                            Data.AddCard();
                            break;
                        }
                    case 3:
                        {
                            OperationMenu();
                            break;
                        }
                    case 4:
                        {
                            Data.currentClient.PrintInfo();
                            break;
                        }
                    case 5: return;
                }
            }
        }

        private static void CreateAccountMenu()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Создать кредитный счет");
            Console.WriteLine("2. Создать дебеттовый счет");
            Console.WriteLine("3. В главное меню");
            switch (Validation.GetMenuResult(3))
            {
                case 1:
                    {
                        Data.AddAccount(new CreditAccount());
                        break;
                    }
                case 2:
                    {
                        Data.AddAccount(new DebitAccount());
                        break;
                    }
                case 3:
                    {
                        return;
                    }
            }
        }

        private static void OperationMenu()
        {
            Console.WriteLine("1. Положить деньги на счет");
            Console.WriteLine("2. Снять деньги со счета");
            Console.WriteLine("3. Перевести деньги на свой счет");
            Console.WriteLine("4. Перевести деньги на чужой счет");
            Console.WriteLine("5. Взять кредит");
            Console.WriteLine("6. Погасить кредит");
            Console.WriteLine("7. В главное меню");
            switch (Validation.GetMenuResult(7))
            {
                case 1:
                    {
                        Operation.PutTo();
                        return;
                    }
                case 2:
                    {
                        Operation.WithdrawFrom();
                        return;
                    }
                case 3:
                    {
                        Operation.Transfer();
                        return;
                    }
                case 4:
                    {
                        Operation.TransferToAnotherClient();
                        return;
                    }
                case 5:
                    {
                        Operation.TakeCredit();
                        return;
                    }
                case 6:
                    {
                        Operation.RepayLoan();
                        return;
                    }
                case 7:
                    {
                        return;
                    }
            }
        }
    }
}
