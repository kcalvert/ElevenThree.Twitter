using System;

namespace ElevenThree.Twitter.JsonObjects.Lists
{
    /// <summary>
    /// response for lists/list.json request
    /// </summary>
    public class list : basejson
    {
        public string slug { get; set; }
        public string name { get; set; }

        /// <summary>
        /// returns slug
        /// </summary>
        /// <returns></returns>
        public string GetSlug()
        {
            return slug;
        }

        /// <summary>
        /// returns name
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return name;
        }




    }
}
