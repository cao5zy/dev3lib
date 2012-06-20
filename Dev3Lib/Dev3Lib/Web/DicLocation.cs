using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.IO;
using System.Xml.Linq;

namespace Dev3Lib.Web
{
    public static class DicLocation
    {

        const string fileNameFormat = "dic.{0}.resx";
        const string defaultFileName = "dic.resx";
        const string defaultCultureName = "en-US";

        class cacheItem
        {
            private readonly DateTime _createdTime = DateTime.Now;

            public bool IsExpired
            {
                get
                {
                    return _createdTime.Subtract(DateTime.Now) > TimeSpan.FromHours(1);
                }
            }

            public string Item { get; set; }
        }

        private static Dictionary<string, cacheItem> LanguageCaches
        {
            get
            {
                if (HttpContext.Current.Application["DicLocation_Cache"] == null)
                    HttpContext.Current.Application["DicLocation_Cache"] = new Dictionary<string, cacheItem>();

                return (Dictionary<string, cacheItem>)HttpContext.Current.Application["DicLocation_Cache"];
            }
        }

        private static string GetResourceValue(string key)
        {
            var cultureName = Thread.CurrentThread.CurrentUICulture.Name;
            var languageFolder = HttpContext.Current.Request.MapPath("App_GlobalResources");


            string defaultFullFileName = Path.Combine(languageFolder, defaultFileName);
            string fullFileName = string.Empty;
            if (string.Compare(cultureName, defaultCultureName, StringComparison.OrdinalIgnoreCase) == 0)
            {
                fullFileName = defaultFullFileName;
            }
            else
                fullFileName = Path.Combine(languageFolder, string.Format(fileNameFormat, cultureName));

            if (!File.Exists(fullFileName))
            {
                if (!File.Exists(defaultFullFileName))
                    return null;
                else
                    fullFileName = defaultFullFileName;
            }

            XDocument doc = XDocument.Load(fullFileName);
            var value = (from n in doc.Descendants("data")
                         where string.Compare(n.Attribute("name").Value, key, StringComparison.OrdinalIgnoreCase) == 0
                         select n.Descendants("value").Single().Value)
                   .SingleOrDefault();

            return value;
        }

        public static string GetLanguageValue(string entryKey)
        {
            cacheItem item;
            if (LanguageCaches.TryGetValue(entryKey, out item))
            {
                if (item.IsExpired)
                    LanguageCaches[entryKey] = new cacheItem
                    {
                        Item = GetResourceValue(entryKey)
                    };
                else
                    return item.Item;
            }
            else
            {
                LanguageCaches.Add(entryKey, new cacheItem
                {
                    Item = GetResourceValue(entryKey)
                });
            }

            return LanguageCaches[entryKey].Item;
        }
    }
}
