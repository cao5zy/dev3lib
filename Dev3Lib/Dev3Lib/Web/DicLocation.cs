using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.IO;
using System.Xml.Linq;
using System.Web.Caching;

namespace Dev3Lib.Web
{
    public static class DicLocation
    {

        const string fileNameFormat = "dic.{0}.resx";
        const string defaultFileName = "dic.resx";
        const string defaultCultureName = "en-US";

        public static string GetResourceValue(string key)
        {
            key = key.Replace(' ', '_');
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

            var lanDic = HttpContext.Current.Cache.Get(cultureName) as Dictionary<string, string>;
            if (lanDic == null)
            {
                var dic = BuildDicSource(fullFileName);
                HttpContext.Current.Cache.Insert(cultureName, dic, new CacheDependency(fullFileName), Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(30));
                try
                {
                    return dic[key];
                }
                catch (KeyNotFoundException ex)
                {
                    throw new KeyNotFoundException(string.Format("the missing key is {0}", key), ex);
                }
            }
            else
            {
                try
                {
                    return lanDic[key];
                }
                catch (KeyNotFoundException ex)
                {
                    throw new KeyNotFoundException(string.Format("the missing key is {0}", key), ex);
                }
            }
        }

        private static Dictionary<string, string> BuildDicSource(string fullFileName)
        {
            XDocument doc = XDocument.Load(fullFileName);
            Dictionary<string, string> dic = new Dictionary<string, string>();

            foreach (var n in (from m in doc.Descendants("data") select m))
            {
                try
                {
                    dic.Add(n.Attribute("name").Value, n.Descendants("value").Single().Value);
                }
                catch (ArgumentException ex)
                {
                    throw new ArgumentException(string.Format("the key {0} is duplicated", n.Attribute("name").Value), ex);
                }
                catch (InvalidOperationException ex)
                {
                    throw new InvalidOperationException(string.Format("the key {0} has not value", n.Attribute("name").Value), ex);
                }
            }

            return dic;
        }

    }
}
