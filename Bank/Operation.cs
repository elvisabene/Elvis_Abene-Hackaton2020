using System;
using System.Collections.Generic;

namespace Bank
{
    internal static class Operation
    {
        public static void PutTo()
        {
            Account toAccount = ChooseAccount("Положить на счет:");
            toAccount.Sum += Validation.GetSum("");
            Data.SerializeClients();
            Message.Print("Операция проведена успешно.", "Success");
        }

        public static void WithdrawFrom()
        {
            Account fromAccount = ChooseAccount("Снять со счета:");
            int sum = Validation.GetSum("");
            if (fromAccount is DebitAccount && fromAccount.Sum < sum)
            {
                Message.Print("На счете недостаточно средств!", "Error");
            }
            else if (fromAccount.Sum < 0)
            {
                Message.Print("На счете отрицательный баланс!", "Error");
            }
            else
            {
                fromAccount.Sum -= sum;
                Data.SerializeClients();
                Message.Print("Операция проведена успешно.", "Success");
            }
        }

        public static void Transfer()
        {
            Account fromAccount = ChooseAccount("Перевести со счета:");
            Account toAccount = ChooseAccount("На счет:");
            int sum = Validation.GetSum("перевода");
            if (fromAccount is CreditAccount && toAccount is DebitAccount)
            {
                Message.Print("Перевод с кредитного счета на дебеттовый запрещен!", "Error");
            }
            else if (fromAccount.Sum < 0)
            {
                Message.Print("На счете отрицательный баланс!", "Error");
            }
            else if (fromAccount is DebitAccount && fromAccount.Sum < sum)
            {
                Message.Print("На счете недостаточно средств!", "Error");
            }
            else if (fromAccount is CreditAccount && (fromAccount as CreditAccount).CreditSum > 0)
            {
                Message.Print("На счете есть непогашеный кредит!", "Error");
            }
            else
            {
                fromAccount.Sum -= sum;
                toAccount.Sum += sum;
                Data.SerializeClients();
                Message.Print("Операция проведена успешно.", "Success");
            }
        }

        public static void TransferToAnotherClient()
        {
            Client payee = GetPayee();
            if (payee == null) return;
            Account fromAccount = ChooseAccount("Перевести со счета:");
            int counter = 1;
            Console.WriteLine("На счет получателя:");
            foreach (Account account in payee.AccountList)
            {
                Console.WriteLine($"{counter++}. {account.Number}."); ;
            }
            int result = int.Parse(Console.ReadLine()); // проверить на ввод
            Account toAccount = payee.AccountList[result - 1];
            int sum = Validation.GetSum("перевода");
            if (fromAccount is DebitAccount && fromAccount.Sum < sum)
            {
                Message.Print("На вашем счете недостаточно средств!", "Error");
            }
            else if (fromAccount.Sum < 0)
            {
                Message.Print("На счете отрицательный баланс!", "Error");
            }
            else if (fromAccount is CreditAccount && (fromAccount as CreditAccount).CreditSum > 0)
            {
                Message.Print("На счете есть непогашеный кредит!", "Error");
            }
            else
            {
                fromAccount.Sum -= sum;
                toAccount.Sum += sum;
                Data.SerializeClients();
                Message.Print("Операция проведена успешно.", "Success");
            }
        }

        public static void TakeCredit()
        {
            while (true)
            {
                List<Account> creditList = Data.currentClient.AccountList.FindAll(x => x is CreditAccount);
                int counter = 0;
                Console.WriteLine("Выберите кредитный счет:");
                foreach (Account account in creditList)
                {
                    Console.WriteLine($"{++counter}. {account.Number}. Сумма на счете: {account.Sum} ден. ед. ");
                    if ((account as CreditAccount).CreditSum > 0)
                    {
                        Message.Print($"На этом счете есть непогашенный кредит в {(account as CreditAccount).CreditSum} ден. ед.", "Error");
                    }
                }
                int result = Validation.GetMenuResult(counter);
                if ((creditList[result - 1] as CreditAccount).CreditSum > 0)
                {
                    Message.Print($"Вы не погасили другой кредит на этом счете! Выберите другой счет!", "Error");
                }
                else
                {
                    Account toAccount = creditList[result - 1];
                    int creditSum = Validation.GetSum("кредита");
                    (toAccount as CreditAccount).CreditSum += creditSum;
                    toAccount.Sum += creditSum;
                    Data.SerializeClients();
                    Message.Print("Операция проведена успешно.", "Success");
                    break;
                }
            }
        }

        public static void RepayLoan()
        {
            Predicate<Account> match = account => account is CreditAccount && (account as CreditAccount).CreditSum > 0;
            List<Account> creditList = Data.currentClient.AccountList.FindAll(match);
            if (creditList.Count == 0)
            {
                Message.Print("У вас нет непогашенных кредитов!", "Warning");
                return;
            }
            int counter = 0;
            Console.WriteLine("Выберите кредитный счет:");
            foreach (Account account in creditList)
            {
                Console.WriteLine($"{++counter}. {account.Number}. Сумма на счете: {account.Sum} ден. ед. ");
                Message.Print($"На этом счете есть непогашенный кредит в {(account as CreditAccount).CreditSum} ден. ед.", "Error");
            }
            int result = Validation.GetMenuResult(counter);
            int sum = Validation.GetSum("погашения");
            if (sum > creditList[result - 1].Sum)
            {
                Message.Print("На счете недостаточно средств для погашения кредита", "Error");
                return;
            }
            else if (sum > (creditList[result - 1] as CreditAccount).CreditSum)
            {
                creditList[result - 1].Sum -= (creditList[result - 1] as CreditAccount).CreditSum;
                (creditList[result - 1] as CreditAccount).CreditSum = 0;
                Message.Print("Кредит полностью погашен.", "Success");
            }
            else
            {
                creditList[result - 1].Sum -= sum;
                (creditList[result - 1] as CreditAccount).CreditSum -= sum;
                Message.Print("Кредит частично погашен.", "Success");
            }
            Data.SerializeClients();
        }

        public static Account ChooseAccount(string message)
        {
            Console.WriteLine(message);
            int counter = 0;
            foreach (Account account in Data.currentClient.AccountList)
            {
                Console.WriteLine($"{++counter}. {account.Number}. Сумма на счете: {account.Sum} ден. ед.");
            }
            int result = Validation.GetMenuResult(counter);
            return Data.currentClient.AccountList[result - 1];
        }

        private static Client GetPayee()
        {
            Console.WriteLine("Введите полное имя получателя:");
            string payeeName = Validation.GetName("Введите имя получателя:");
            foreach (Client client in Data.clientList)
            {
                if (payeeName == client.FullName)
                {
                    return client;
                }
            }
            Console.WriteLine("Неизвестный получатель!");
            return null;
        }
    }
}
