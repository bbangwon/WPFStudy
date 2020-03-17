using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfTreeView
{
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (DirectoryItemType)value;

            var image = "file.png";

            if (type == DirectoryItemType.Drive)
                image = "drive.png";
            else if (type == DirectoryItemType.Folder)
                image = "folder-closed.png";           

            return new BitmapImage(new Uri($"pack://application:,,,/Images/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
