using System;
using System.Globalization;
using System.Windows.Data;

namespace NTTS.UI.WPF.Converters
{
    public class StringToPagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return value;
            }

            return new Uri($"../../Views/Pages/{value.ToString()}.xaml", UriKind.Relative);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
