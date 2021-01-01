using internetProgramming_TeemProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace internetProgramming_TeemProject.Models
{
    public class AccountDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public AccountType Type { get; set; }
    }
    public enum UserLogOnStatus
    {
        Failed,
        User,
        DontExist
    }
}
