using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Landau.Models.UserLoginsModel
{
    public class UserLoginsModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Login { get; set; }
       [StringLength(60, MinimumLength = 3)]
        public string Password { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool IsLocked { get; set; }

    }
}