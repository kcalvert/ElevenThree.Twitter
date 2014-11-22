using System;

namespace ElevenThree.Twitter.JsonObjects
{
    public class user
    {
        public string name { get; set; }
        public string screen_name { get; set; }
        public string profile_image_url { get; set; }

        /// <summary>
        /// returns name
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return this.name;
        }

        /// <summary>
        /// returns screen name
        /// </summary>
        /// <returns></returns>
        public string GetScreenName()
        {
            return screen_name;
        }

        /// <summary>
        /// returns profile image url
        /// </summary>
        /// <returns></returns>
        public string GetProfileImageUrl()
        {
            return this.profile_image_url;
        }
    }
}
