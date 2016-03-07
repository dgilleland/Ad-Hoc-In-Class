using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace WebClient.UI.Handlers
{
    /// <summary> 
    /// AbstractStreamableImage is an abstract base class for images 
    /// that can be written to the <see cref="HttpResponse">HttpResponse</see> object. 
    /// </summary> 
    /// <remarks> 
    /// AbstractStreamableImage is an abstract base class for images 
    /// that can be written to the <see cref="HttpResponse">HttpResponse</see> 
    /// object of the current <see cref="HttpContext">HttpContext</see>. 
    /// Derived classes will need to implement the StreamableImage property 
    /// to return an <see cref="Image">Image</see> object that can be streamed 
    /// through the <see cref="HttpResponse">HttpResponse</see> object supplied 
    /// to the public <see cref="AbstractStreamableImage.Write">Write</see> 
    /// method of this class. 
    /// </remarks> 
    public abstract class AbstractStreamableImage
    {
        /// <summary>This field contains a <see cref="SortedDictionary(Of Guid, String)"/>.</summary> 
        private static SortedDictionary<Guid, string> _ImageFormats = null;

        /// <summary> 
        /// ImageFormats is a <see cref="SortedDictionary(Of GUID, String)">SortedDictionary</see> 
        /// that maps <see cref="ImageFormat">ImageFormat</see> types to strings that describe 
        /// the <see cref="HttpResponse.ContentType" />. 
        /// </summary> 
        /// <value></value> 
        /// <returns></returns> 
        /// <remarks> 
        /// This code is taken and adapted from Code OnTime. Specifically, see the following URL: 
        /// http://blog.codeontime.com/2008/09/working-with-binary-large-objects-blob.html 
        /// </remarks> 
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

        /// <summary> 
        /// The field representing the <see cref="System.Drawing.Image">Image</see> 
        /// object to be streamed to the browser. 
        /// </summary> 
        /// <remarks> 
        /// This field is initialized to null (Nothing in VB). 
        /// </remarks> 
        protected System.Drawing.Image _StreamableImage = null;

        /// <summary> 
        /// The <see cref="System.Drawing.Image">Image</see> object to be 
        /// streamed to the browser. 
        /// </summary> 
        /// <value></value> 
        /// <returns></returns> 
        /// <remarks> 
        /// Derived classes must override this property and provide an 
        /// implementation that returns an Image object. Derived classes 
        /// may, optionally, use the <see cref="_StreamableImage">_StreamableImage</see> 
        /// field for storing the object as a field of the class for memory or 
        /// performance optimizations (such as lazy-loading). 
        /// </remarks> 
        public abstract Image StreamableImage
        {
            get;
        }

        /// <summary> 
        /// The format of the image. 
        /// </summary> 
        /// <value></value> 
        /// <returns></returns> 
        /// <remarks> 
        /// This property, by default, returns the raw format of the 
        /// <see cref="StreamableImage">StreamableImage</see>. This can 
        /// be over-ridden by the derived class to enforce a preferred 
        /// <see cref="ImageFormat">ImageFormat</see>. 
        /// </remarks> 
        protected virtual ImageFormat Format
        {
            get { return StreamableImage.RawFormat; }
        }

        /// <summary> 
        /// This method facilitates writing the <see cref="Image">Image</see> 
        /// object to the output stream of the <see cref="HttpResponse">HttpResponse</see> 
        /// object. 
        /// </summary> 
        /// <param name="Response"></param> 
        /// <remarks> 
        /// This method facilitates writing the <see cref="Image">Image</see> 
        /// object to the output stream of the <see cref="HttpResponse">HttpResponse</see> 
        /// object. 
        /// This method is the only public method exposed by the 
        /// <see cref="AbstractStreamableImage" /> base class. 
        /// It first saves the <see cref="StreamableImage" /> 
        /// to a <see cref="MemoryStream" /> where it is then 
        /// converted to a Byte array using the <see cref="MemoryStream" />. 
        /// The <see cref="HttpResponse" /> object's 
        /// <see cref="HttpResponse.ContentType">ContentType</see> is set to 
        /// the <see cref="Format" /> (an ImageFormat value) defined in this 
        /// class. 
        /// </remarks> 
        public void Write(HttpResponse Response)
        {
            if (Response == null)
            {
                throw new ArgumentNullException("Response", "HttpResponse is null.");
            }

            MemoryStream Stream = new MemoryStream();
            Image Item = StreamableImage;
            Item.Save(Stream, Format);
            byte[] Buffer = Stream.ToArray();
            Response.ContentType = ImageFormats[Format.Guid];
            Response.OutputStream.Write(Buffer, 0, Buffer.Length);
        }
    }
}