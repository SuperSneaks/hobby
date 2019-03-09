using System;
using System.Collections.Generic;

namespace HuntingAppRazor.Models
{
    public partial class Hunts
    {
        public Hunts()
        {
            Sightings = new HashSet<Sightings>();
        }

        public Guid Uuid { get; set; }
        public Guid UserUuid { get; set; }
        public Guid StandUuid { get; set; }
        public DateTime HuntStart { get; set; }
        public DateTime HuntEnd { get; set; }
        public int? BucksSeen { get; set; }
        public int? DoesSeen { get; set; }
        public int? UnknownSeen { get; set; }
        public string SightDetails { get; set; }
        public string Notes { get; set; }

        public virtual Stands StandUu { get; set; }
        public virtual Users Uu { get; set; }
        public virtual ICollection<Sightings> Sightings { get; set; }
    }
}
