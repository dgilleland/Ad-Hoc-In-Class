using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindEntities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public string PictureMimeType { get; set; }
    }
}
