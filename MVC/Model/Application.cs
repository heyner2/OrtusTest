using System;
using System.Collections.Generic;

#nullable disable

namespace DigicelApps.Models
{
    public partial class Application
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Deparment { get; set; }
        public int Category { get; set; }
        public string Owner { get; set; }

        public virtual Category CategoryNavigation { get; set; }
    }
}
