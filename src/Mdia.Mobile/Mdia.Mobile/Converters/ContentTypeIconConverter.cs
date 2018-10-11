using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Mdia.Mobile.Converters
{
    public class ContentTypeIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string icon = null;
            int contentTypeId = (int)value;
            switch(contentTypeId)
            {
                case 1:
                    {
                        icon = "pdfFile.png";
                        break;
                    }
                case 2:
                    {
                        icon = "audioFile.png";
                        break;
                    }
                case 3:
                    {
                        icon = "videoFile.png";
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException("No implementation for Content Type Id '" + (int)value + "'");
                    }
            }

            return icon;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }




}
