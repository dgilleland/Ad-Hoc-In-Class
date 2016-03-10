using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindEntities.Common
{
    /// <summary>
    /// The ImageHelper class helps to compensate for the OLE Header
    /// that appears at the start of legacy image data stored in the
    /// Northwinds database.
    /// </summary>
    /// <remarks>
    /// <para>The ImageHelper class helps to compensate for the OLE Header
    /// that appears at the start of legacy image data stored in the
    /// Northwinds database.</para>
    /// <para>For example, the following notes referencing the Categories
    /// table will actually apply to other tables in Northwinds that store
    /// images (such as the Photo column of the Employees table).</para>
    /// <list><listheader>Footnotes:</listheader>
    /// <item>The Picture column of the Categories table contains data that was
    /// originally entered in Microsoft Access. Those images contained an
    /// OLE header of 78 bytes that were not part of the actual image but
    /// were added to facilitate Access' handling of images.
    /// As such, those 78 bytes need to be stripped from the image in order
    /// to create a valid System.Drawing.Image object. For more deatils,
    /// see http://www.codeguru.com/vb/vb_internet/aspnet/print.php/c16095</item>
    /// 
    /// <item>About the Picture column of the Categories table, the following 
    /// was posted on a tutorial at www.Asp.Net:
    /// Note: In Microsoft SQL Server 2000 and earlier versions, 
    /// the varbinary data type had a maximum limit of 8,000 bytes. 
    /// To store up to 2 GB of binary data the image data type needs 
    /// to be used instead. With the addition of MAX in SQL Server 2005, 
    /// however, the image data type has been deprecated. It’s still 
    /// supported for backwards compatibility, but Microsoft has 
    /// announced that the image data type will be removed in a future 
    /// version of SQL Server.
    /// If you are working with an older data model you may see the 
    /// image data type. The Northwind database’s Categories table has 
    /// a Picture column that can be used to store the binary data of 
    /// an image file for the category. Since the Northwind database has 
    /// its roots in Microsoft Access and earlier versions of SQL Server, 
    /// this column is of type image.</item></list>
    /// </remarks>
    internal class ImageHelper
    {
        // See http://www.codeguru.com/vb/vb_internet/aspnet/print.php/c16095
        private static Byte[] _OleHeader = { 21, 28, 47, 0, 2, 0, 0, 0, 13, 0, 14, 0, 20, 0, 33, 0, 255, 255, 255, 255, 66, 105, 116, 109, 97, 112, 32, 73, 109, 97, 103, 101, 0, 80, 97, 105, 110, 116, 46, 80, 105, 99, 116, 117, 114, 101, 0, 1, 5, 0, 0, 2, 0, 0, 0, 7, 0, 0, 0, 80, 66, 114, 117, 115, 104, 0, 0, 0, 0, 0, 0, 0, 0, 0, 160, 41, 0, 0 };
        public static Byte[] OleHeader
        {
            get
            {
                return _OleHeader;
            }
        }

        public static bool HasOleHeader(Byte[] rawPicture)
        {
            bool hasHeader = true;
            if (rawPicture != null && rawPicture.Length > OleHeader.Length)
                for (int index = 0; index <= OleHeader.Length - 1; index++)
                {
                    if (OleHeader[index] != rawPicture[index])
                    {
                        hasHeader = false;
                        break;
                    }
                }
            else
                hasHeader = false;
            return hasHeader;
        }

        public static Byte[] AddOleHeader(Byte[] rawPicture)
        {
            if (rawPicture == null || rawPicture.Length == 0)
                throw new ArgumentException("RawPicture is null or empty.", "RawPicture");
            if (!HasOleHeader(rawPicture))
            {
                List<byte> picture = new List<byte>(OleHeader);
                picture.AddRange(rawPicture);
                rawPicture = picture.ToArray();
            }
            return rawPicture;
        }
    }
}
