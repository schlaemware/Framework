using System.Globalization;
using System.Windows.Data;

namespace SW.Framework.WPF.Converters
{
    [ValueConversion(typeof(Type), typeof(bool), ParameterType = typeof(Type))]
    public class IsSameTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(parameter is Type reference)
            {
                return value.GetType() == reference;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
