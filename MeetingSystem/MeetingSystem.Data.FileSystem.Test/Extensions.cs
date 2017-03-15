using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHelperExtensions;

namespace MeetingSystem.Data.FileSystem.Test
{
    public static class Extensions
    {
        public static string CreateMeeting(this string city)
        {
            return city.CreateMeeting(28.GetRandom(1), 4.GetRandom(1), 16.GetRandom(9), 5.GetRandom(1));
        }

        public static string CreateMeeting(this string city, int startDay, int numberOfDays, int startHour, int lengthHours)
        {
            return $"{startDay},{numberOfDays},{startHour},{lengthHours},{city}\r\n";
        }

    }
}
