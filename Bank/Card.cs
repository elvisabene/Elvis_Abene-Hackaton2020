using System;
using System.Runtime.Serialization;

namespace Bank
{
    [DataContract]
    internal class Card
    {
        private static int id;
        public Card()
        {
            ID = id++;
        }
        [DataMember]
        public int ID { get; set; }
    }
}
