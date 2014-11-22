using System;

using ElevenThree.Twitter.Utilities;

namespace ElevenThree.Twitter.JsonObjects
{
    /// <summary>
    /// the core json response that every response derives from
    /// </summary>
    public class basejson
    {
        public long id { get; set; }

        /// <summary>
        /// returns id
        /// </summary>
        /// <returns></returns>
        public long GetId()
        {
            return id;
        }





    }
}
