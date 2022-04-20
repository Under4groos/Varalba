using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace VaralbaLib
{
    public static class SImageSource
    {
        public static BitmapImage GetImage(string url) {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(url, UriKind.Absolute);
            bitmap.DecodePixelWidth = bitmap.DecodePixelWidth / 4;
            bitmap.DecodePixelHeight = bitmap.DecodePixelHeight / 4;

            bitmap.EndInit();
            return bitmap;
        }
    }
}
