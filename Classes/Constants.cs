using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    /// <summary>
    /// Using constants to avoid magic string and magic numbers
    /// </summary>
    internal static class Constants
    {
        public const int HoursCellValue = 5;
        public const int MinutesCellValue = 5;
        public const int TopMinutesCellsCount = 11;
        public const int Quarters = 3;
        public const string Red = "R";
        public const string Yellow = "Y";
        public const string Off = "O";
    }
}
