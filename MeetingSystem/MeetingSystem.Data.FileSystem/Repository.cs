using System;
using System.Collections.Generic;
using MeetingSystem.Entities;
using MeetingSystem.Interfaces;
using System.Linq;

namespace MeetingSystem.Data.FileSystem
{
    public class Repository : IMeetingSourceRepository
    {
        string _filePath;
        public Repository(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<Entities.Meeting> GetMeetings(DateTime startingStartDateTime, DateTime endStartDateTime)
        {
            if (String.IsNullOrWhiteSpace(_filePath))
                throw new Exceptions.DataUnavailableException("No file path specified");

            return new Month(_filePath)
                .Where(m => m.StartDateTime >= startingStartDateTime
                    && m.StartDateTime < endStartDateTime);
        }
    }
}
