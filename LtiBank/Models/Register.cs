using System;
using System.Collections.Generic;

#nullable disable

namespace LtiBank.Models
{
    public partial class Register
    {
        public Register()
        {
            Accounts = new HashSet<Account>();
        }

        public int Rid { get; set; }
        public int Accountno { get; set; }
        public string Userid { get; set; }
        public string Password { get; set; }
        public string Transactionpass { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
