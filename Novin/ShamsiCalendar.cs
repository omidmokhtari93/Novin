using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using cmms;

namespace Novin
{
    public class ShamsiCalendar
    {
        public enum CulterType { En, Fa };
        public static DateTime Shamsi2Miladi(string _date)
        {
            try
            {
                var datevalue = _date.Split('/').ToArray();
                int years = Convert.ToInt16(datevalue[0]);
                int month = Convert.ToInt16(datevalue[1]);
                var dt = datevalue[2].Split(' ').ToArray();
                int day = Convert.ToInt16(dt[0]);
                var h = 0;
                var d = 0;
                try
                {
                    if (dt[1] != null)
                    {
                        var time = dt[1].Split(':').ToArray();
                        h = int.Parse(time[0]);
                        d = int.Parse(time[1]);
                    }
                }
                catch
                {
                    // ignored
                }

                var psc = new PersianCalendar();
                var date = psc.ToDateTime(years, month, day, h, d, 0, 0);
                return date;
            }
            catch
            {
                var dt = new DateTime();
                return dt;
            }
        }
        public static void ChangCulter(CulterType cu)
        {
            switch (cu)
            {
                case CulterType.En:
                    var CU = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentCulture = CU;
                    Thread.CurrentThread.CurrentUICulture = CU;
                    break;
                case CulterType.Fa:
                    var PC = new PersianCulture();
                    Thread.CurrentThread.CurrentCulture = PC;
                    Thread.CurrentThread.CurrentUICulture = PC;
                    break;
            }
        }

        public static string ShamsiDateTime()
        {
            ChangCulter(CulterType.Fa);
            var today = DateTime.Now;
            var tarikh = today.ToString("yyyy/MM/dd");
            return tarikh;
        }
        public static string Miladi2Shamsi(DateTime date)
        {
            ChangCulter(CulterType.Fa);
            var pc = Convert.ToDateTime(date);
            var tarikh = pc.ToString("yyyy/MM/dd");
            return tarikh;
        }
    }
}