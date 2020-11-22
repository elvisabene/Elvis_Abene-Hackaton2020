using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using System.Text;

namespace Bank
{
    [DataContract]
    [KnownType(typeof(CreditAccount))]
    [KnownType(typeof(DebitAccount))]
    [KnownType(typeof(Card))]
    internal class Client
    {
        public Client(string fullName)
        {
            FullName = fullName;
            AccountList = new List<Account>();
        }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public List<Account> AccountList { get; set; }

        public void PrintInfo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Имя: {FullName}");
            Console.WriteLine("Информация о счетах:");
            int counter = 1;
            if (AccountList.Count == 0)
            {
                Console.WriteLine("Счета отсутствуют.");
            }
            else
            {
                foreach (Account account in AccountList)
                {
                    string creditMessage = null;
                    string typeAccount = null; ;
                    if (account is CreditAccount)
                    {
                        typeAccount = "кредитного";
                        if ((account as CreditAccount).CreditSum > 0)
                        {
                            creditMessage = $"Непогашенный кредит: {(account as CreditAccount).CreditSum} ден. ед.";
                        }
                    }
                    else
                    {
                        typeAccount = "дебеттового";
                    }
                    int cardCount = account.CardList is null ? 0 : account.CardList.Count;

                    Console.WriteLine($"{counter++}.\tНомер {typeAccount} счета: {account.Number}" +
                                      $"\n\tСумма на счете: {account.Sum} ден. ед." +
                                      $"\n\tКоличество привязанных карт: {cardCount}" +
                                      $"\n\t{creditMessage}");
                }
            }
            Console.ResetColor();
        }
    }
}
