using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bank
{
    [DataContract]
    internal abstract class Account
    {
        private static int id;
        protected Account()
        {
            Number = Guid.NewGuid();
            ID = id++;
            Sum = 0;
            CardList = new List<Card>();
        }
        [DataMember]
        public Guid Number { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int Sum { get; set; }
        [DataMember]
        public List<Card> CardList { get; set; }
    }
}
