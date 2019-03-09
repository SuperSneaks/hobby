using System;
using System.Collections.Generic;

namespace HuntingAppRazor.Models
{
    public partial class Users
    {
        public Users()
        {
            PropertyAccess = new HashSet<PropertyAccess>();
        }

        public Guid Uuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }

        public virtual Hunts Hunts { get; set; }
        public virtual ICollection<PropertyAccess> PropertyAccess { get; set; }
    }
}
