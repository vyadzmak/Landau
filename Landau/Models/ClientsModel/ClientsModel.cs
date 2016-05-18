using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.ClientsModel
{
    public class ClientsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegistrationNumber { get; set; }
        public bool IsLocked { get; set; }
        public bool IsClient { get; set; }

    }
}