using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using HandyControl.Tools;

namespace EducationProcess.HandyDesktop.Tools.Converter
{
    public class BoolEvenPairToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
                if (boolValue)
                    return "чс.";
                else
                    return "зн.";
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
