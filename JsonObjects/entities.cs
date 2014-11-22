using System;

using ElevenThree.Twitter.JsonObjects.Entities;

namespace ElevenThree.Twitter.JsonObjects
{
    public class entities
    {
        public hashtags[] hashtags { get; set; }
        public urls[] urls { get; set; }

        /// <summary>
        /// returns hashtags
        /// </summary>
        /// <returns></returns>
        public hashtags[] GetHashTags()
        {
            return hashtags;
        }

        /// <summary>
        /// returns urls
        /// </summary>
        /// <returns></returns>
        public urls[] GeUrls()
        {
            return urls;
        }



    }
}
