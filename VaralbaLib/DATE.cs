using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaralbaLib
{
    public static class DATE
    {
        public static string GetTime()
        {
            TimeSpan time = DateTime.Now.TimeOfDay;
            return $"{time.Hours}:{time.Minutes} pm";
        }
    }
}
