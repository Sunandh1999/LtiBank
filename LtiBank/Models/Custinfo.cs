using System;
using System.Collections.Generic;

#nullable disable

namespace LtiBank.Models
{
    public partial class Custinfo
    {
        public int Cid { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public long Mobile { get; set; }
        public string Email { get; set; }
        public long Aadhar { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
        public string Occupation { get; set; }
    }
}
