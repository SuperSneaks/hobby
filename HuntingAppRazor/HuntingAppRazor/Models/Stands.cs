using System;
using System.Collections.Generic;

namespace HuntingAppRazor.Models
{
    public partial class Stands
    {
        public Stands()
        {
            Hunts = new HashSet<Hunts>();
        }

        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public Guid PropertyUuid { get; set; }
        public byte[] FrontImg { get; set; }
        public byte[] BackImg { get; set; }
        public byte[] LeftImg { get; set; }
        public byte[] RightImg { get; set; }

        public virtual Properties PropertyUu { get; set; }
        public virtual ICollection<Hunts> Hunts { get; set; }
    }
}
