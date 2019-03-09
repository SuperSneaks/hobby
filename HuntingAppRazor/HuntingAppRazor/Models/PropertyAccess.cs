using System;
using System.Collections.Generic;

namespace HuntingAppRazor.Models
{
    public partial class PropertyAccess
    {
        public Guid UsersUuid { get; set; }
        public Guid PropertyUuid { get; set; }
        public Guid Id { get; set; }

        public virtual Properties PropertyUu { get; set; }
        public virtual Users UsersUu { get; set; }
    }
}
