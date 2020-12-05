using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Bank
{
    internal static class Data
    {
        public static Client currentClient;
        public static Account selectedAccount;
        public static List<Client> clientList = new List<Client>();
        private static char filesep = Path.DirectorySeparatorChar;
        private static string datapath = $"..{filesep}..{filesep}..{filesep}data.json";
        private static readonly DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(clientList.GetType());

        public static void AddClient(Client client)
        {
            clientList.Add(client);
            currentClient = client;
            SerializeClients();
        }

        public static void ReadClientsFromFile()
        {
            DeserializeClients();
        }

        public static void AddAccount(Account account)
        {
            currentClient.AccountList.Add(account);
            SerializeClients();
            Message.Print("Счет успешно создан.", "Success");
        }

        public static void AddCard()
        {
            Console.WriteLine("Выберите счет к которому нужно приввязать карту:");
            if (currentClient.AccountList.Count == 0)
            {
                Message.Print("У вас нету счетов!", "Warning");
                return;
            }
            int counter = 0;
            foreach (Account account in currentClient.AccountList)
            {
                Console.WriteLine($"{++counter}. {account.Number}");
            }
            int result = Validation.GetMenuResult(counter);
            selectedAccount = currentClient.AccountList[result - 1];
            selectedAccount.CardList.Add(new Card());
            SerializeClients();
            Message.Print("Карта успешно добавлена.", "Success");
        }

        public static void SerializeClients()
        {
            using (FileStream stream = new FileStream(datapath, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(stream, clientList);
            }
        }

        public static void DeserializeClients()
        {
            using (FileStream stream = new FileStream(datapath, FileMode.OpenOrCreate))
            {
                if (stream.Length != 0)
                {
                    clientList = jsonFormatter.ReadObject(stream) as List<Client>;
                }
            }
        }
    }
}
