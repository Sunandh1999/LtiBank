using System;
using System.Collections.Generic;

#nullable disable

namespace LtiBank.Models
{
    public partial class Benificiary
    {
        public Benificiary()
        {
            Transactions = new HashSet<Transaction>();
        }

        public string Name { get; set; }
        public int Benaccountno { get; set; }
        public int Accountno { get; set; }
        public string Nickname { get; set; }

        public virtual Account AccountnoNavigation { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
