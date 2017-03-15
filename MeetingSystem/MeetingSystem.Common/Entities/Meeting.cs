using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingSystem.Entities
{
    public class Meeting
    {
        public Guid Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public Single LengthHours { get; set; }
        public int NumberOfDays { get; set; }
        public string City { get; set; }

    }
}
