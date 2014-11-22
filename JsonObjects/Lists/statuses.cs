using System;

using ElevenThree.Twitter.Utilities;

namespace ElevenThree.Twitter.JsonObjects.Lists
{
    /// <summary>
    /// response for lists/statuses.json request
    /// </summary>
    public class statuses : basetweet
    {
        public string created_at { get; set; }

        /// <summary>
        /// returns create date
        /// </summary>
        /// <returns></returns>
        public DateTime GetCreatedAt()
        {
            return DateTime.Parse(created_at);
        }





    }
}
