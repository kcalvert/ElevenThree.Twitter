using System;

using ElevenThree.Twitter.Utilities;

namespace ElevenThree.Twitter.JsonObjects
{
    /// <summary>
    /// extends the basejson object to a tweet specific response
    /// </summary>
    public class basetweet : basejson
    {
        public string text { get; set; }
        public entities entities { get; set; }
        public user user { get; set; }

        /// <summary>
        /// returns url-to-ahref formatted tweet and strips hashtags/urls, if specified
        /// </summary>
        /// <param name="stripHashTags"></param>
        /// <param name="stripUrls"></param>
        /// <returns></returns>
        public string GetText(bool stripHashTags = false, bool stripUrls = false)
        {
            return Util.GetTextFormatted(text, entities.hashtags, entities.urls, stripHashTags, stripUrls);
        }

        /// <summary>
        /// returns entities
        /// </summary>
        /// <returns></returns>
        public entities GetEntities()
        {
            return entities;
        }

        /// <summary>
        /// returns user object
        /// </summary>
        /// <returns></returns>
        public user GetUser()
        {
            return user;
        }





    }
}
