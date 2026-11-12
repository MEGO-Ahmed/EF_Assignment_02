using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Assignment_02
{
    public class Badge
    {
        public int Id { get; set; }
        public string BadgeNumber { get; set; } = string.Empty;
        public DateTime IssuedAt { get; set; }
        public BadgeTier Tier { get; set; }

        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; } = null!;
    }
}
