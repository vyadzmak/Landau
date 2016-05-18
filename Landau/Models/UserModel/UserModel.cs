using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.UserModel
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Roles { get; set; }
        public int RolesForDb { get; set; }
        public string Right { get; set; }
        public int ClientId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string NameOrganisation { get; set; }
        public int RegistrationNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int DocumentId { get; set; }


    }
}