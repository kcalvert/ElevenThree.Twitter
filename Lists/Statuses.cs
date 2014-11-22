using System;
using System.IO;
using System.Net;

using ElevenThree.Tools;

using ElevenThree.Twitter.JsonObjects.Lists;
using ElevenThree.Twitter.Utilities;

using log4net;

using Newtonsoft.Json;

namespace ElevenThree.Twitter.Lists
{
    public class Statuses
    {
        ILog log = LogManager.GetLogger(typeof(Statuses));

        public OAuth OAuthObj { get; private set; }
        public string ListId { get; private set; }
        public long SinceId { get; private set; }
        public int Count { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_OAuth"></param>
        /// <param name="_ListId"></param>
        /// <param name="_SinceId"></param>
        public Statuses(OAuth _OAuthObj, string _ListId, long _SinceId = 0, int _Count = 0)
        {
            OAuthObj = _OAuthObj;
            ListId = _ListId;
            SinceId = _SinceId;
            Count = _Count;
        }

        /// <summary>
        /// performs the action of getting the timeline
        /// </summary>
        /// <returns></returns>
        public statuses[] Get()
        {
            statuses[] ss;

            string uri = TwitterConstants.API_URL + 
                            "lists/statuses.json?" + 
                                "list_id=" + ListId +
                                (SinceId > 0 ? "&since_id=" + SinceId : string.Empty) +
                                (Count > 0 ? "&count=" + Count : string.Empty) +
                                "&include_entities=true" + 
                                "&include_rts=false" // no retweets
                                ;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            req.Headers.Add("Authorization", OAuthObj.GetAuthentication()); // add oauth to request
            req.Method = "Get";

            log.Debug("Request => " + uri);

            using (WebResponse resp = req.GetResponse())
            using (var reader = new StreamReader(resp.GetResponseStream()))
            {
                ss = JsonConvert.DeserializeObject<statuses[]>(reader.ReadToEnd());
            }

            log.Debug("Response => " + ss.ToString() + " [length = " + ss.Length + "]");

            return ss;
        }

        




    }
}