using System;
using System.Collections.Generic;

#nullable disable

namespace LtiBank.Models
{
    public partial class Transaction
    {
        public int Transactionno { get; set; }
        public int Accountno { get; set; }
        public int Benaccountno { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string Remarks { get; set; }

        public virtual Account AccountnoNavigation { get; set; }
        public virtual Benificiary BenaccountnoNavigation { get; set; }
    }
}
