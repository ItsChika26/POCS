using System.Drawing.Imaging;

namespace LauncherApp
{
    public static class Utils
    {
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
