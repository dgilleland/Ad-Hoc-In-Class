using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindEntities
{
    /// <summary>
    /// The Supplier class represents a row of data from the Suppliers table
    /// in the NorthwindExtended database.
    /// </summary>
    /// <remarks>
    /// This class contains computed properties which parse the Supplier.HomePage information
    /// for the Northwind Traders database.
    /// The HomePage data of the Suppliers table stores up to four pieces 
    /// of information in the following format: displayText#address#subAddress#screentip
    /// <para>
    /// 1) The HomePage data of the Suppliers table stores up to four pieces 
    /// of information in the following format: 
    /// <code>displayText#address#subAddress#screentip</code></para>
    /// <para>Each piece of the Hyperlink field storage format can be up to 
    /// 2,000 characters. The maximum length of the entire Hyperlink field 
    /// value is 6,000 characters.</para>
    /// 
    /// <list>
    ///    <listheader>See <a href="http://msdn.microsoft.com/en-us/library/aa188212(office.10).aspx">http://msdn.microsoft.com/en-us/library/aa188212(office.10).aspx</a></listheader>
    /// <term>displaytext
    /// <description>(Required: No)
    /// <para>The text the user sees in the Hyperlink field in a table, 
    ///       or in a text box bound to the Hyperlink field. You can set 
    ///       the display text to any text string. For example, you may 
    ///       want the display text to be a descriptive name for the Web 
    ///       site or object specified by the address and subaddress. If 
    ///       you do not specify display text, Access displays the value 
    ///       of address instead.</para></description>
    /// </term>
    /// <term>address         
    /// <description>(Required: Yes, unless subaddress points to an object in the current database (.mdb) file.)
    /// <para>A valid URL that points to a page or file on the Internet 
    ///       or an intranet, or the path to a file on a local hard drive 
    ///       or LAN. If you enter a path on a LAN, you can omit a mapped 
    ///       drive letter and use the universal naming convention (UNC) 
    ///       format: \\server\share\path\filename. This prevents the path 
    ///       from becoming invalid if the database is later copied to 
    ///       another computer’s hard drive or into a shared network folder.</para></description>
    /// </term>
    /// <term>subaddress
    /// <description>(Required: No)
    /// <para>The location within a file or document; for example, a database 
    ///       object, such as a form or report. When referring to a database 
    ///       object, the name of the object should be preceded by its type: 
    ///       Table, Query, Form, Report, Macro, or Module. Other possible 
    ///       values for subaddress include a bookmark in a Microsoft Word 
    ///       document, an anchor in an HTML document, a Microsoft PowerPoint 
    ///       slide, or a cell in a Microsoft Excel worksheet.</para></description>
    /// </term>
    /// <term>screentip
    /// <description>(Required: No)
    /// <para>The text that appears when you rest the pointer over a hyperlink.</para></description>
    /// </term>
    /// </list>
    /// </remarks>
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string HomePageText { get; set; }
        public string HomePageUrl { get; set; }
    }
}
