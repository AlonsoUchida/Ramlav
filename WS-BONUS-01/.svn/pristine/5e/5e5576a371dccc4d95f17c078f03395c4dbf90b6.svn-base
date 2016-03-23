using System;
using System.Globalization;

namespace Bonus.Common.Util
{
    public class DateFormats
    {
        public DateTime formatearFecha(string fecha)
        {
           var formats = new[] {
                  "yyyy.MM.dd HH:mm:ss",
                  "yyyy-MM-dd HH:mm:ss",
                  "yyyy/MM/dd HH:mm:ss",
                  "yyyy.MM.dd hh:mm:ss",
                  "yyyy-MM-dd hh:mm:ss",
                  "yyyy/MM/dd hh:mm:ss",
                  "dd.MM.yyyy HH:mm:ss",
                  "dd-MM-yyyy HH:mm:ss",
                  "dd/MM/yyyy HH:mm:ss",
                  "dd.MM.yyyy hh:mm:ss",
                  "dd-MM-yyyy hh:mm:ss",
                  "dd/MM/yyyy hh:mm:ss"
                };

            return DateTime.ParseExact(fecha, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
        }
    }
}
