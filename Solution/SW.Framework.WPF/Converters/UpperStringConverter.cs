using System.Globalization;
using System.Windows.Data;

namespace SW.Framework.WPF.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    public class UpperStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string input)
            {
                return input.ToUpper();
            }

            throw new ArgumentException($"input must be a string vlaue, not {value.GetType()}");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
