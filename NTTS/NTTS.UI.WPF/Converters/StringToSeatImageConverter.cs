using System;
using System.Globalization;
using System.Windows.Data;

namespace NTTS.UI.WPF.Converters
{
    public class StringToSeatImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return value;
            }

            if (value.ToString() == "Available")
            {
                return new Uri($"/NTTS.UI.WPF;component/Assets/Icons/SeatIconFree.png", UriKind.Relative);
            }

            if (value.ToString() == "Selected")
            {
                return new Uri($"/NTTS.UI.WPF;component/Assets/Icons/SeatIconSelected.png", UriKind.Relative);
            }
           

            return new Uri($"/NTTS.UI.WPF;component/Assets/Icons/SeatIconOcupied.png", UriKind.Relative);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
