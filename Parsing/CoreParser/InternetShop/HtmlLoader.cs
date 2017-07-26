using CoreParser.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreParser.InternetShop
{
    class HtmlLoader
    {
        readonly WebClient webClient;

        readonly string url;

        public HtmlLoader(IParserSettings settings)
        {
            webClient = new WebClient();
            if(settings.Url.Last() == '/')
                url = $"{settings.Url}{settings.Prefix}/";
            else
                url = $"{settings.Url}/{settings.Prefix}/";
        }

        public string GetSourceByPageId(int id)
        {
            string source = null;
            
            try
            {
                var currentUrl = url.Replace("CurrentId", id.ToString());
                source = webClient.DownloadString(currentUrl);
            }
            catch (Exception ex)
            {
            }
            
            return source;
        }
    }
}
