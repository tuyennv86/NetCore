using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace NetCoreApp.Utilities.Helpers
{
    public static class ImageHelper
    {
        public static Bitmap ResizeImage(Stream streamImage, int maxWidth, int maxHeight)
        {
            Bitmap originalImage = new Bitmap(streamImage);
            int newWidth = originalImage.Width;
            int newHeight = originalImage.Height;
            double aspectRatio = (double)originalImage.Width / (double)originalImage.Height;

            if (aspectRatio <= 1 && originalImage.Width > maxWidth)
            {
                newWidth = maxWidth;
                newHeight = (int)Math.Round(newWidth / aspectRatio);
            }
            else if (aspectRatio > 1 && originalImage.Height > maxHeight)
            {
                newHeight = maxHeight;
                newWidth = (int)Math.Round(newHeight * aspectRatio);
            }

            Bitmap newImage = new Bitmap(originalImage, newWidth, newHeight);

            Graphics g = Graphics.FromImage(newImage);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.DrawImage(originalImage, 0, 0, newImage.Width, newImage.Height);

            originalImage.Dispose();

            return newImage;
        }
        public static void ResizeImage(Image image, string fileName, string pathUrl)
        {
            //string name = Path.GetFileNameWithoutExtension(fileToUpload.FileName);
            //var ext = Path.GetExtension(fileToUpload.FileName);
            //string myfile = name + ext;

            //try
            //{
            //using (Image image = Image.FromStream(fileToUpload.InputStream, true, false))
            //{

            var path = Path.Combine(pathUrl, fileName);
            try
            {
                //Size can be change according to your requirement 
                float thumbWidth = 270F;
                float thumbHeight = 180F;
                //calculate  image  size
                if (image.Width > image.Height)
                {
                    thumbHeight = ((float)image.Height / image.Width) * thumbWidth;
                }
                else
                {
                    thumbWidth = ((float)image.Width / image.Height) * thumbHeight;
                }

                int actualthumbWidth = Convert.ToInt32(Math.Floor(thumbWidth));
                int actualthumbHeight = Convert.ToInt32(Math.Floor(thumbHeight));
                var thumbnailBitmap = new Bitmap(actualthumbWidth, actualthumbHeight);
                var thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
                thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, actualthumbWidth, actualthumbHeight);
                thumbnailGraph.DrawImage(image, imageRectangle);
                var ms = new MemoryStream();
                thumbnailBitmap.Save(path, ImageFormat.Jpeg);
                ms.Position = 0;
                GC.Collect();
                thumbnailGraph.Dispose();
                thumbnailBitmap.Dispose();
                image.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //return myfile;
        }
        public static byte[] ResizeToBytes(string filename)
        {
            Bitmap img = new Bitmap(filename);
            double oldwidth = img.Width;
            double oldheight = img.Height;
            double newheight;
            double newwidth;
            if (oldwidth > oldheight)
            {
                newwidth = 765;
                newheight = 765 * (oldheight / oldwidth);
            }
            else
            {
                newheight = 765;
                newwidth = 765 * (oldwidth / oldheight);
            }
            Bitmap imgout = new Bitmap(img, (int)newwidth, (int)newheight);
            img.Dispose();
            imgout.Save(filename, ImageFormat.Jpeg);
            imgout.Dispose();

            FileStream f = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            int size = (int)f.Length;
            byte[] MyData = new byte[f.Length + 1];
            f.Read(MyData, 0, size);
            f.Close();
            return MyData;
        }
        public static string Convert_ImageTo_Base64(string path)
        {

            string filename = path;
            FileStream f = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            int size = (int)f.Length;
            byte[] MyData = new byte[f.Length + 1];
            f.Read(MyData, 0, size);
            f.Close();
            return Convert.ToBase64String(MyData);
        }
        public static Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
            imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;

        }
        public static string ImageToBase64(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
        
    }
}
