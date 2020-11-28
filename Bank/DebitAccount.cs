using System;
using System.Runtime.Serialization;

namespace Bank
{
    [DataContract]
    internal class DebitAccount : Account
    {
        public DebitAccount()
        {
        }
    }
}
