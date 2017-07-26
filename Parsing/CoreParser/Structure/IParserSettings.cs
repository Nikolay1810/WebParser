using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreParser.Structure
{
    public interface IParserSettings
    {
        string Url { get; set; }
        string TagCatalog { get; set; }
        string TagName { get; set; }
        string TagParentImage { get; set; }
        string TagPrice { get; set; }
        string TagDescription { get; set; }
        string Prefix { get; set; } 
        int StartPoint { get; set; }
        int EndPoint { get; set; }
    }
}
