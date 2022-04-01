using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LtiBank.Models
{
    public partial class Admin
    {
       // [Key]
        public string Adminid { get; set; }
        public string Password { get; set; }
    }
}
