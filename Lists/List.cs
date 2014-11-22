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
    public class List
    {
        ILog log = LogManager.GetLogger(typeof(List));

        public OAuth OAuthObj { get; private set; }
        public string ScreenName { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_OAuth"></param>
        /// <param name="_ListId"></param>
        /// <param name="_SinceId"></param>
        public List(OAuth _OAuthObj, string _ScreenName)
        {
            OAuthObj = _OAuthObj;
            ScreenName = _ScreenName;
        }

        /// <summary>
        /// performs the action of getting the timeline
        /// </summary>
        /// <returns></returns>
        public list[] Get()
        {
            list[] ll;

            string uri = TwitterConstants.API_URL + 
                            "lists/list.json?" + 
                                "screen_name=" + ScreenName;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            req.Headers.Add("Authorization", OAuthObj.GetAuthentication()); // add oauth to request
            req.Method = "Get";

            log.Debug("Request => " + uri);

            using (WebResponse resp = req.GetResponse())
            using (var reader = new StreamReader(resp.GetResponseStream()))
            {
                ll = JsonConvert.DeserializeObject<list[]>(reader.ReadToEnd());
            }

            log.Debug("Response => " + ll.ToString() + " [length = " + ll.Length + "]");

            Log(ll);

            return ll;
        }

        /// <summary>
        /// logs each node of the lists object
        /// </summary>
        /// <param name="ll"></param>
        private void Log(list[] ll)
        {
            foreach (list l in ll)
                log.Info("id => + " + l.GetId() + " / slug => " + l.GetSlug() + " / name => " + l.GetName());
        }        




    }
}