using System;
using System.Collections.Generic;

namespace HuntingAppRazor.Models
{
    public partial class Properties
    {
        public Properties()
        {
            Stands = new HashSet<Stands>();
        }

        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public virtual ICollection<Stands> Stands { get; set; }
    }
}
