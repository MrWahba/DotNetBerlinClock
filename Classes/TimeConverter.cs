using BerlinClock.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    /// <summary>
    /// Class contains calculation of berlin clock
    /// </summary>
    public class TimeConverter : ITimeConverter
    {

        #region Fields & Propeties

        private int hours;
        private int minutes;
        private int seconds;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize instance 
        /// </summary>
        /// 
        public TimeConverter()
        {

        }

        public TimeConverter(int hours, int minutes, int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Take time as hh:mm:ss string and return Berlin Clock
        /// </summary>
        /// <param name="aTime">String in hh:mm:ss format</param>
        /// <returns>String in Berlin Clock format</returns>
        public string convertTime(string aTime)
        {
            string[] berlinTime = new string[5];
            // Assert valid time
            TimeSpan timeSpan = new TimeSpan();
            if (TimeSpan.TryParse(aTime, out timeSpan))
            {
                // assuming time format hh:mm:ss
                string[] timeParts = aTime.Split(':');
                hours = int.Parse(timeParts[0]);
                minutes = int.Parse(timeParts[1]);
                seconds = int.Parse(timeParts[2]);

                berlinTime[0] = GetSeconds();
                berlinTime[1] = GetTopHours();
                berlinTime[2] = GetBottomHours();
                berlinTime[3] = GetTopMinutes();
                berlinTime[4] = GetBottomMinutes();

                return string.Join("\r\n", berlinTime);
            }
            else
            {
                return Properties.Resources.InvalidTime;
            }
        }

        #endregion

        #region Internal Method

        /// <summary>
        /// Calculates second lamp as following: 
        /// if seconds is even returns Yellow
        /// otherwise returns Off
        /// </summary>
        /// <returns>Y: if even
        /// or O: if odd</returns>
        internal string GetSeconds()
        {
            return seconds % 2 == 0 ? Constants.Yellow : Constants.Off;
        }

        /// <summary>
        /// Calculates top hour lamps as following:
        /// Each cell equal to 5 hours 
        /// if hours in range 5:9 then return equal ROOO
        /// else if hours in range 10:14 then return equal RROO
        /// else if hours in range 15:19 then return equal RRRO
        /// else if hours in range 20:23 then return equal RRRR
        /// </summary>
        /// <returns></returns>
        internal string GetTopHours()
        {
            string topHours = string.Empty;
            for (int i = 1; i < Constants.HoursCellValue; i++)
            {
                topHours += ((hours / Constants.HoursCellValue) >= i) ? Constants.Red : Constants.Off;
            }
            return topHours;
        }

        /// <summary>
        /// Calculates bottom hour lamps as following:
        /// Each cell equal to an hour
        /// if hours modulus 5 equals 1 then return equal ROOO
        /// else if hours modulus 5 equals 2 then return equal RROO
        /// else if hours modulus 5 equals 3 then return equal RRRO
        /// else if hours modulus 5 equals 4 then return equal RRRR
        /// </summary>
        /// <returns></returns>
        internal string GetBottomHours()
        {
            string bottomHours = string.Empty;
            for (int i = 1; i < Constants.HoursCellValue; i++)
            {
                bottomHours += ((hours % Constants.HoursCellValue) >= i) ? Constants.Red : Constants.Off;
            }
            return bottomHours;
        }

        /// <summary>
        /// Calculate top minutes lambs and fill red lamb in quarters 
        /// It contains 11 lamb that present from 5-55 minute
        /// </summary>
        /// <returns></returns>
        internal string GetTopMinutes()
        {
            string topMinutes = string.Empty;
            for (int i = 1; i <= Constants.TopMinutesCellsCount; i++)
            {
                topMinutes += ((minutes / Constants.MinutesCellValue) >= i) ? ((i % Constants.Quarters == 0) ? Constants.Red : Constants.Yellow) : Constants.Off;
            }
            return topMinutes;
        }

        /// <summary>
        /// Calculate 4 minutes remaining like from 1-4, 6-9, ......, 56-59
        /// </summary>
        /// <returns></returns>
        internal string GetBottomMinutes()
        {
            string bottomMinutes = string.Empty;
            for (int i = 1; i < Constants.MinutesCellValue; i++)
            {
                bottomMinutes += ((minutes % Constants.MinutesCellValue) >= i) ? Constants.Yellow : Constants.Off;
            }
            return bottomMinutes;
        }

        #endregion

    }
}
