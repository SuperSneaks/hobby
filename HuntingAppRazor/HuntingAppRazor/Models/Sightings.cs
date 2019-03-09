using System;
using System.Collections.Generic;

namespace HuntingAppRazor.Models
{
    public partial class Sightings
    {
        public Guid Uuid { get; set; }
        public Guid HuntUuid { get; set; }
        public DateTime SightDt { get; set; }
        public int? BucksSeen { get; set; }
        public int? DoesSeen { get; set; }
        public int? UnknownSeen { get; set; }
        public string Notes { get; set; }

        public virtual Hunts HuntUu { get; set; }
    }
}
