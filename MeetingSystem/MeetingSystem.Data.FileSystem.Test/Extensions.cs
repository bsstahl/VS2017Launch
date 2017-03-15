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
        static string[] cities = new string[] { "Phoenix AZ", "Dallas TX", "New York NY", "Los Angeles CA" };

        public static Tuple<int, int, int, int, string> CreateMeeting(this string city)
        {
            return city.CreateMeeting(28.GetRandom(1), 4.GetRandom(1), 16.GetRandom(9), 5.GetRandom(1));
        }

        public static Tuple<int, int, int, int, string> CreateMeeting(this string city, int startDay, int numberOfDays, int startHour, int lengthHours)
        {
            return new Tuple<int, int, int, int, string>(startDay, numberOfDays, startHour, lengthHours, city);
        }

        //public static string GetSourceDataRow(this string ignore)
        //{
        //    int startDay = 28.GetRandom(1);
        //    int numberOfDays = 4.GetRandom(1);
        //    int startHour = 16.GetRandom(9);
        //    int lengthHours = 5.GetRandom(1);
        //    string city = cities.GetRandom();

        //    return $"{startDay},{numberOfDays},{startHour},{lengthHours},{city}\r\n";
        //}
    }
}
