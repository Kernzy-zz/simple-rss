using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleRSS
{

    public class RSS
    {
        /// <summary>
        /// Gets RSS feed from passed URL
        /// </summary>
        /// /// <returns>
        /// Returns list of RSS 'feed' objects containing (title), (link), (pubDate) & (description) properties.
        /// </returns>
        public static List<feed> getFeed(string _RssFeedUrl)
        {

            List<feed> feeds = new List<feed>();
            try
            {
                XDocument xDoc = new XDocument();
                xDoc = XDocument.Load(_RssFeedUrl);
                var items = (from x in xDoc.Descendants("item")
                             select new
                             {
                                 title = x.Element("title").Value,
                                 link = x.Element("link").Value,
                                 pubDate = x.Element("pubDate").Value,
                                 description = x.Element("description").Value
                             });
                if (items != null)
                {
                    foreach (var i in items)
                    {
                        feed f = new feed
                        {
                            title = i.title,
                            link = i.link,
                            pubDate = i.pubDate,
                            description = i.description
                        };

                        feeds.Add(f);
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }


            return feeds;
        }



    }

    public class feed
    {
        public string link { get; set; }
        public string description { get; set; }
        public string pubDate { get; set; }
        public string title { get; set; }

    }
}

