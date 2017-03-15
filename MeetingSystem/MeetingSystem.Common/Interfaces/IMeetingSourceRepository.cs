using System;
using System.Collections.Generic;
using System.Text;
using MeetingSystem.Entities;

namespace MeetingSystem.Interfaces
{
    public interface IMeetingSourceRepository
    {
        IEnumerable<Meeting> GetMeetings(DateTime startingStartDateTime, DateTime endStartDateTime);
    }
}
