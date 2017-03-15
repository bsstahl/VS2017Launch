using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingSystem.Data.FileSystem
{
    public class Meeting: Entities.Meeting
    {
        public Meeting(string dataText, DateTime firstDayOfMonth)
        {
            Load(dataText, firstDayOfMonth);
        }

        private void Load(string dataRow, DateTime firstDayOfMonth)
        {
            var items = dataRow.Split(',');
            var startDay = Int32.Parse(items[0]);
            var startHour = Single.Parse(items[2]);

            this.StartDateTime = firstDayOfMonth.AddDays(startDay - 1).Date.AddHours(startHour);
            //this.NumberOfDays = Int32.Parse(items[1]);
            //this.LengthHours = Single.Parse(items[3]);
            //this.City = items[4];
        }
    }
}
