using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Util
{
    public sealed class DateTimeForEach
    {
        public enum StepBy { 
            Year,
            Month,
            Day,
            Hour,
            Min,
            Sec,
            TimeSpan,
        }
        private DateTime _start, _end;

        public DateTimeForEach(DateTime start, DateTime end)
        { }
    }
}
