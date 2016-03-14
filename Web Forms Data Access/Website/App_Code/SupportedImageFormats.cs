using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.ServiceModel;

namespace WebClient.UI.Handlers
{
    public abstract class SupportedImageFormats
    {
        private static SortedDictionary<Guid, string> _ImageFormats = null;

        public static SortedDictionary<Guid, string> ImageFormats
        {
            get
            {
                if (_ImageFormats == null)
                {
                    _ImageFormats = new SortedDictionary<Guid, string>();
                    // Set up the dictionary 
                    _ImageFormats.Add(ImageFormat.Bmp.Guid, "image/bmp");
                    _ImageFormats.Add(ImageFormat.Emf.Guid, "image/emf");
                    _ImageFormats.Add(ImageFormat.Exif.Guid, "image/exif");
                    _ImageFormats.Add(ImageFormat.Gif.Guid, "image/gif");
                    _ImageFormats.Add(ImageFormat.Jpeg.Guid, "image/jpeg");
                    _ImageFormats.Add(ImageFormat.Png.Guid, "image/png");
                    _ImageFormats.Add(ImageFormat.Tiff.Guid, "image/tiff");
                    _ImageFormats.Add(ImageFormat.Wmf.Guid, "image/wmf");
                }
                return _ImageFormats;
            }
        }
    }
}