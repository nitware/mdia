using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Mdia.Mobile.Converters
{
    public class NairaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal price = (decimal)value;
            return "₦ " + price.ToString("n");

            //return "₦ " + price.ToString("n");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal price = 0;
            string priceWithNairaSign = (string)value;

            if (!string.IsNullOrWhiteSpace(priceWithNairaSign))
            {
                string justPrice = priceWithNairaSign.Replace("₦", "").Replace(" ", "");
                price = decimal.Parse(justPrice);
            }

            return price;
        }



    }


}
