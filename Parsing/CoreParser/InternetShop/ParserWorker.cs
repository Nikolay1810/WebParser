using AngleSharp.Parser.Html;
using CoreParser.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreParser.InternetShop
{
    public class ParserWorker<T> : IParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;
        HtmlLoader loader;

        #region Properties

        public IParser<T> Parser
        {
            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }
        }

        public IParserSettings Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }

        #endregion
        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSettings settings):this(parser)
        {
            this.parserSettings = settings;
        }

        public async Task<List<T>> Start()
        {
            return await Worker();
        }
        
        private async Task<List<T>> Worker()
        {
            List<T> prodList = new List<T>();
            for (int i = parserSettings.StartPoint; i < parserSettings.EndPoint; i++)
            {
                var source = loader.GetSourceByPageId(i);
                var docParser = new HtmlParser();

                var document = await docParser.ParseAsync(source);
                prodList.AddRange(parser.Parse(document, parserSettings));
            }
            return prodList;
        }
    }
}
