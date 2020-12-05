using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Bank
{
    [DataContract]
    internal class CreditAccount : Account
    {
        [DataMember]
        public int CreditSum { get; set; } = 0;
        public CreditAccount()
        {
        }
    }
}
