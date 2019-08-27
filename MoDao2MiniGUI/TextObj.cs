using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoDao2MiniGUI
{
    public class TEXT
    {
        public List<TextObject> Objects { get; set; }
    }
    public class TextObject
    {

        public int paraSpacing { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  TextChildren[] children { get; set; }

    }
    public class TextChildren
    {
        /// <summary>
        /// 收费站标题
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int boldType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fontFamily { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fontWeight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fontSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string color { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fontStyle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string textDecoration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int lineHeight { get; set; }
    }
}
