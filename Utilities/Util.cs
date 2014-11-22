using System;
using System.Text.RegularExpressions;

using ElevenThree.Twitter.JsonObjects.Entities;

using log4net;

namespace ElevenThree.Twitter.Utilities
{
    public class Util
    {
        static ILog log = LogManager.GetLogger(typeof(Util));

        /// <summary>
        /// returns a text string formatted so that url's are converted to links and hashtags/urls are stripped, if specified
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="hts"></param>
        /// <param name="urls"></param>
        /// <param name="stripHashTags"></param>
        /// <param name="stripUrls"></param>
        /// <returns></returns>
        public static string GetTextFormatted(string msg, hashtags[] hts, urls[] urls, bool stripHashTags = false, bool stripUrls = false)
        {
            msg = stripHashTags ? Strip(msg, hts) : msg;
            msg = stripUrls ? Strip(msg, urls) : msg;

            return ConvertUrlsToLinks(msg);
        }

        /// <summary>
        /// method to convert any url's to a href enabled url's
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string ConvertUrlsToLinks(string msg)
        {
            Regex r = new Regex(@"((www\.|(http|https|ftp|news|file)+\:\/\/)[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])", 
                RegexOptions.IgnoreCase);
            return r.Replace(msg, "<a href=\"$1\">$1</a>");
        }

        /// <summary>
        /// strips hashtags
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="hts"></param>
        /// <returns></returns>
        public static string Strip(string msg, hashtags[] hts)
        {
            // start from the end of the hashtags array and work backwords. that way the indices will remain valid from back to front
            for (int i = hts.Length - 1; i >= 0; i--)
            {
                string before = msg.Substring(0, hts[i].GetStart());
                string after = msg.Substring(hts[i].GetEnd());
                msg = before + after;
            }

            return msg.Trim();
        }

        /// <summary>
        /// strips urls
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="urls"></param>
        /// <returns></returns>
        public static string Strip(string msg, urls[] urls)
        {
            for (int i = 0; i < urls.Length; i++)
                msg = msg.Replace(urls[i].GetDisplayUrl(), string.Empty).Trim();

            return msg.Trim();
        }





    }
}
