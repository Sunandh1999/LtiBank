using System;
using System.Collections.Generic;

#nullable disable

namespace LtiBank.Models
{
    public partial class Account
    {
        public Account()
        {
            Benificiaries = new HashSet<Benificiary>();
            Transactions = new HashSet<Transaction>();
        }

        public int Rid { get; set; }
        public int Accountno { get; set; }
        public int Balance { get; set; }
        public string Name { get; set; }

        public virtual Register RidNavigation { get; set; }
        public virtual ICollection<Benificiary> Benificiaries { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
