using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace MeetingSystem.Data.FileSystem.Test
{
    [TestClass, DeploymentItem(@"..\..\..\Data")]
    public class Repository_GetMeetings_Should
    {
        string _sourceDataFile = @".\April2017.csv";

        [TestMethod]
        public void ReturnTheCorrectNumberOfMeetingsForTheApril2017File()
        {
            var startDate = DateTime.Parse("1/1/2017");
            var endDate = DateTime.Parse("12/31/2017");
            var sourceRepo = new MeetingSystem.Data.FileSystem.Repository(_sourceDataFile);
            var meetings = sourceRepo.GetMeetings(startDate, endDate);
            Assert.AreEqual(73, meetings.Count());
        }

        [TestMethod]
        public void ReturnTheCorrectNumberOfMeetingsForAFilteredApril2017File()
        {
            var startDate = DateTime.Parse("4/10/2017");
            var endDate = DateTime.Parse("4/15/2017");
            var sourceRepo = new MeetingSystem.Data.FileSystem.Repository(_sourceDataFile);
            var meetings = sourceRepo.GetMeetings(startDate, endDate);
            Assert.AreEqual(12, meetings.Count());
        }

        [TestMethod]
        public void ReturnTheCorrectStartDateTimeForTheEarliestMeetingOfTheFile()
        {
            DateTime expected = DateTime.Parse("4/1/2017 9:00 AM");

            var startDate = DateTime.MinValue;
            var endDate = DateTime.MaxValue;
            var sourceRepo = new MeetingSystem.Data.FileSystem.Repository(_sourceDataFile);
            var meetings = sourceRepo.GetMeetings(startDate, endDate);
            var actual = meetings.OrderBy(m => m.StartDateTime).First();
            Assert.AreEqual(expected, actual.StartDateTime);
        }

        [TestMethod]
        public void ReturnTheCorrectStartDateTimeForTheLatestMeetingOfTheFile()
        {
            DateTime expected = DateTime.Parse("4/30/2017 2:00 PM");

            var startDate = DateTime.MinValue;
            var endDate = DateTime.MaxValue;
            var sourceRepo = new MeetingSystem.Data.FileSystem.Repository(_sourceDataFile);
            var meetings = sourceRepo.GetMeetings(startDate, endDate);
            var actual = meetings.OrderByDescending(m => m.StartDateTime).First();
            Assert.AreEqual(expected, actual.StartDateTime);
        }

        [TestMethod, ExpectedException(typeof(Exceptions.DataUnavailableException))]
        public void ReturnADataUnavailableExceptionIfTheDataFileIsNotFound()
        {
            string bogusFilePath = "April9999.abc";
            var startDate = DateTime.Now.Date;
            var endDate = startDate.AddDays(1);
            var sourceRepo = new MeetingSystem.Data.FileSystem.Repository(bogusFilePath);
            var meetings = sourceRepo.GetMeetings(startDate, endDate);
        }

    }
}
