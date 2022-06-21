using System;
using System.Collections.Generic;

namespace FirstBankOfSuncoast
{
    class Transaction
    {
        // amount
        public int Amount { get; set; }
        // date
        public DateTime Date = DateTime.Now;
        // memo (Duke NRG, Trans#)
        public string Memo { get; set; }
        // type (withdraw or deposit)
        public string Type { get; set; }
        // account type (C,S)
        public AccountType Account { get; set; }
    }
}