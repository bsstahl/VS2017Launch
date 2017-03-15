using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;
using System.Linq;

namespace MeetingSystem.Data.FileSystem.Test
{
    [TestClass]
    public class Repository_GetMeetings_UsingFakesShould
    {
        public TestContext TestContext { get; set; }


        [TestMethod, ExpectedException(typeof(MeetingSystem.Exceptions.PermissionException))]
        public void ThrowAMeetingSystemPermissionExceptionIfAnIoSecurityExceptionOccurs()
        {
            using (ShimsContext.Create())
            {
                System.IO.Fakes.ShimFile.ReadAllTextString =
                    p => throw new System.Security.SecurityException();

                var sourceRepo = new MeetingSystem.Data.FileSystem.Repository("April2017.abc");
                var meetings = sourceRepo.GetMeetings(DateTime.MinValue, DateTime.MaxValue);
            }
        }

    }
}
