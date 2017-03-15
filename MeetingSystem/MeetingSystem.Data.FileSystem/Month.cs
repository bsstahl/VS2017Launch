using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingSystem.Data.FileSystem
{
    internal class Month : List<Meeting>
    {
        string _inputFilePath;
        DateTime _firstDayOfMonth;

        internal Month(string inputFilePath)
        {
            _inputFilePath = inputFilePath;
            _firstDayOfMonth = GetFirstDayOfTheMonth(inputFilePath);
            this.Load();
        }

        internal void Load()
        {
            const string sep = "\r\n";
            string data = string.Empty;

            try
            {
                data = System.IO.File.ReadAllText(_inputFilePath);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw new MeetingSystem.Exceptions.DataUnavailableException($"Data file {_inputFilePath} not found", ex);
            }

            var dataLines = data.Split(sep.ToCharArray());
            foreach (var dataLine in dataLines)
            {
                if (!string.IsNullOrWhiteSpace(dataLine))
                    this.Add(new Meeting(dataLine, _firstDayOfMonth));
            }
        }

        private DateTime GetFirstDayOfTheMonth(string inputFile)
        {
            string firstOfMonthText = string.Empty;
            string fileName = System.IO.Path.GetFileNameWithoutExtension(inputFile);

            int fnLength = fileName.Length;
            if (fnLength > 6)
            {
                string monthName = fileName.Substring(0, 3);
                string yearText = fileName.Substring(fnLength - 4, 4);
                firstOfMonthText = $"01-{monthName}-{yearText}";
            }

            DateTime result;
            if (DateTime.TryParse(firstOfMonthText, out result))
                return result;
            else
                throw new Exceptions.DataUnavailableException($"{fileName} is not a valid month and year combination");
        }

    }
}
