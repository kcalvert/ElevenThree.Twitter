using System;

namespace ElevenThree.Twitter.JsonObjects.Entities
{
    public class urls
    {
        public string expanded_url { get; set; }
        public string url { get; set; }
        public int[] indices { get; set; }
        public string display_url { get; set; }

        /// <summary>
        /// returns expanded url
        /// </summary>
        /// <returns></returns>
        public string GetExpandedUrl()
        {
            return expanded_url;
        }

        /// <summary>
        /// returns url
        /// </summary>
        /// <returns></returns>
        public string GetUrl()
        {
            return url;
        }
        
        /// <summary>
        /// get start position
        /// </summary>
        /// <returns></returns>
        public int GetStart()
        {
            return indices[0];
        }

        /// <summary>
        /// get end position
        /// </summary>
        /// <returns></returns>
        public int GetEnd()
        {
            return indices[1];
        }
        
        /// <summary>
        /// returns display url
        /// </summary>
        /// <returns></returns>
        public string GetDisplayUrl()
        {
            return display_url;
        }





    }
}
