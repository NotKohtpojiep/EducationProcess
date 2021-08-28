using System;
using System.Globalization;
using System.Windows.Data;

namespace EducationProcess.HandyDesktop.Tools.Converter
{
    public class StringDayNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                return date.DayOfWeek.ToString();
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
