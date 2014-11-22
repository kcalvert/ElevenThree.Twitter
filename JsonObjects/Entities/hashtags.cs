using System;

namespace ElevenThree.Twitter.JsonObjects.Entities
{
    public class hashtags
    {
        public string text { get; set; }
        public int[] indices { get; set; }

        /// <summary>
        /// returns name
        /// </summary>
        /// <returns></returns>
        public string GetText()
        {
            return text;
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



    }
}
