using System.Drawing.Imaging;
using System.Net.Sockets;
using LauncherApp.Properties;

namespace LauncherApp
{
    public static class Utils
    {
        public static byte[] DefaultImage = BytesFromBitmap(Resources.c0589be1b84c602dae8e97419541708d, ImageFormat.Jpeg);
        public static Bitmap BitmapFromBytes(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return new Bitmap(ms);
            }
        }
        public static byte[] BytesFromBitmap(Bitmap bitmap, ImageFormat format)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, format);
                return stream.ToArray();
            }
        }
    }
}
