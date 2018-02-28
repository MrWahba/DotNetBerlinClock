using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BerlinClock;
using BerlinClock.Classes;

namespace BerlinClockUnitTest
{
    [TestClass]
    public class BerlinClockUnitTests
    {
        TimeConverter berlinC;

        [TestInitialize]
        public void Initialize()
        {
            berlinC = new TimeConverter();
        }

        [TestMethod]
        public void WhenEnenSecondGetYellow()
        {
            berlinC.convertTime("00:00:10");
            Assert.AreEqual(Constants.Yellow, berlinC.GetSeconds());
        }

        [TestMethod]
        public void WhenOddSecondGetOff()
        {
            berlinC.convertTime("00:00:55");
            Assert.AreEqual(Constants.Off, berlinC.GetSeconds());
        }

        [TestMethod]
        public void WhenHourEqual15GetRRROInTopHoursLamps()
        {
            berlinC.convertTime("15:00:00");
            Assert.AreEqual(Constants.Red + Constants.Red + Constants.Red + Constants.Off
                , berlinC.GetTopHours());
        }

        [TestMethod]
        public void WhenHourEqual0GetOOOOInTopHoursLamps()
        {
            berlinC.convertTime("00:00:00");
            Assert.AreEqual(Constants.Off + Constants.Off + Constants.Off + Constants.Off
                , berlinC.GetTopHours());
        }

        [TestMethod]
        public void WhenHourEqual24GetRRRRInTopHoursLamps()
        {
            berlinC.convertTime("24:00:00");
            Assert.AreEqual(Constants.Red + Constants.Red + Constants.Red + Constants.Red
                , berlinC.GetTopHours());
        }

        [TestMethod]
        public void WhenHourEqual24InBottomHoursLamps()
        {
            berlinC.convertTime("24:00:00");
            Assert.AreEqual(Constants.Red + Constants.Red + Constants.Red + Constants.Red
                , berlinC.GetBottomHours());
        }

        [TestMethod]
        public void WhenHourEqual15GetOOOOInBottomHoursLamps()
        {
            berlinC.convertTime("15:00:00");
            Assert.AreEqual(Constants.Off + Constants.Off + Constants.Off + Constants.Off
                , berlinC.GetBottomHours());
        }

        [TestMethod]
        public void WhenHourEqual17GetRROOInBottomHoursLamps()
        {
            berlinC.convertTime("17:00:00");
            Assert.AreEqual(Constants.Red + Constants.Red + Constants.Off + Constants.Off
                , berlinC.GetBottomHours());
        }

        [TestMethod]
        public void WhenMinuteEqual0Get00000000000InTopMinutesLamps()
        {
            berlinC.convertTime("00:00:00");
            Assert.AreEqual(Constants.Off + Constants.Off + Constants.Off + Constants.Off +
                            Constants.Off + Constants.Off + Constants.Off + Constants.Off +
                            Constants.Off + Constants.Off + Constants.Off
                , berlinC.GetTopMinutes());
        }

        [TestMethod]
        public void WhenMinuteEqual15GetYYR00000000InTopMinutesLamps()
        {
            berlinC.convertTime("00:15:00");
            Assert.AreEqual(Constants.Yellow + Constants.Yellow + Constants.Red + Constants.Off +
                            Constants.Off + Constants.Off + Constants.Off + Constants.Off +
                            Constants.Off + Constants.Off + Constants.Off
                , berlinC.GetTopMinutes());
        }

        [TestMethod]
        public void WhenMinuteEqual55GetYYRYYRYYRYYInTopMinutesLamps()
        {
            berlinC.convertTime("00:55:00");
            Assert.AreEqual(Constants.Yellow + Constants.Yellow + Constants.Red +
                            Constants.Yellow + Constants.Yellow + Constants.Red +
                            Constants.Yellow + Constants.Yellow + Constants.Red +
                            Constants.Yellow + Constants.Yellow
                , berlinC.GetTopMinutes());
        }



        [TestMethod]
        public void WhenMinuteEqual59GetYYYYInBottomMinutesLamps()
        {
            berlinC.convertTime("00:59:00");
            Assert.AreEqual(Constants.Yellow + Constants.Yellow +
                            Constants.Yellow + Constants.Yellow
                , berlinC.GetBottomMinutes());
        }

        [TestMethod]
        public void WhenMinuteEqual30GetOOOOInBottomMinutesLamps()
        {
            berlinC.convertTime("00:30:00");
            Assert.AreEqual(Constants.Off + Constants.Off +
                            Constants.Off + Constants.Off
                , berlinC.GetBottomMinutes());
        }

        [TestMethod]
        public void WhenMinuteEqual22GetYYOOInBottomMinutesLamps()
        {
            berlinC.convertTime("00:22:00");
            Assert.AreEqual(Constants.Yellow + Constants.Yellow +
                            Constants.Off + Constants.Off
                , berlinC.GetBottomMinutes());
        }
    }
}
