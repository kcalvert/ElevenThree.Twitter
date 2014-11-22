using System;
using System.IO;
using System.Net;

using ElevenThree.Tools;

using ElevenThree.Twitter.JsonObjects.Statuses;
using ElevenThree.Twitter.Utilities;

using log4net;

using Newtonsoft.Json;

namespace ElevenThree.Twitter.Statuses
{
    public class UserTimeline
    {
        ILog log = LogManager.GetLogger(typeof(UserTimeline));

        public OAuth OAuthObj { get; private set; }
        public string ScreenName { get; private set; }
        public long SinceId { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_OAuth"></param>
        /// <param name="_ScreenName"></param>
        /// <param name="_SinceId"></param>
        public UserTimeline(OAuth _OAuthObj, string _ScreenName, long _SinceId = 0)
        {
            OAuthObj = _OAuthObj;
            ScreenName = _ScreenName;
            SinceId = _SinceId;
        }

        /// <summary>
        /// performs the action of getting the timeline
        /// </summary>
        /// <returns></returns>
        public user_timeline[] Get()
        {
            user_timeline[] utl;

            string uri = TwitterConstants.API_URL +
                            "statuses/user_timeline.json?" +
                                "screen_name=" + ScreenName +
                                (SinceId > 0 ? "&since_id=" + SinceId : string.Empty) +
                                "&trim_user=false" +
                                "&include_entities=true" +
                                "&include_rts=false" +
                                "&exclude_replies=true"
                                ;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            req.Headers.Add("Authorization", OAuthObj.GetAuthentication()); // add oauth to request
            req.Method = "Get";

            log.Debug("Request => " + uri);

            using (WebResponse resp = req.GetResponse())
            using (var reader = new StreamReader(resp.GetResponseStream()))
            {
                utl = JsonConvert.DeserializeObject<user_timeline[]>(reader.ReadToEnd());
            }

            log.Debug("Response => " + utl.ToString() + " [length = " + utl.Length + "]");

            return utl;
        }







    }
}