using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreParser.Structure
{
    public interface IParserWorker<T> where T:class
    {
        IParser<T> Parser { get; set; }
        IParserSettings Settings { get; set; }
        Task<List<T>> Start();
    }
}
