//using NorthwindEntities.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindEntities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture{ get; set; }
        public string PictureMimeType { get; set; }
    }
}
// Footnotes:
// 1) The Picture column of the Categories table contains data that was
//   originally entered in Microsoft Access. Those images contained an
//    OLE header of 78 bytes that were not part of the actual image but
//    were added to facilitate Access' handling of images.
//    As such, those 78 bytes need to be stripped from the image in order
//    to create a valid System.Drawing.Image object. For more details,
//    see http://www.codeguru.com/vb/vb_internet/aspnet/print.php/c16095
//
// 2) About the Picture column of the Categories table, the following 
//    was posted on a tutorial at www.Asp.Net:
//       Note: In Microsoft SQL Server 2000 and earlier versions, 
//       the varbinary data type had a maximum limit of 8,000 bytes. 
//       To store up to 2 GB of binary data the image data type needs 
//       to be used instead. With the addition of MAX in SQL Server 2005,
//       however, the image data type has been deprecated. It’s still 
//       supported for backwards compatibility, but Microsoft has 
//       announced that the image data type will be removed in a future 
//       version of SQL Server.
//
//       If you are working with an older data model you may see the 
//       image data type. The Northwind database’s Categories table has 
//       a Picture column that can be used to store the binary data of 
//       an image file for the category. Since the Northwind database has 
//       its roots in Microsoft Access and earlier versions of SQL Server, 
//       this column is of type image.
