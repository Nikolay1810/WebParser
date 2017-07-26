using AngleSharp.Dom.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreParser.Structure
{
    public interface IParser<T> where T:class
    {
        List<T> Parse(IHtmlDocument document, IParserSettings settings);
    }
}
