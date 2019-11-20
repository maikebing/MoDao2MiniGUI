using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoDao2MiniGUI
{
    public class widget
    {
        /// <summary>
        /// 
        /// </summary>
        public string cid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string screen_cid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int timestamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string display_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int left { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int top { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int width { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int height { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string gid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string link_cids { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string v { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string locked { get; set; }
        /// <summary>
        /// [{"paraSpacing":5,"children":[{"text":"收费站标题","boldType":0,"fontFamily":"SourceHanSansSC","fontWeight":"regular","fontSize":14,"color":"rgba(255, 255, 255, 1)","fontStyle":"normal","textDecoration":"none","lineHeight":21}]}]
        /// </summary>
        public Newtonsoft.Json.Linq.JToken text { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ha { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string va { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int z { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string th { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int lh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string td { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int bo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int i { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int o { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Newtonsoft.Json.Linq.JToken text_shadow { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ro { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int primary_fixed { get; set; }
        /// <summary>
        /// 

        /// 
        /// </summary>
        [JsonProperty("fixed")]
        public bool fixed_ { get; set; }
        /// <summary>
        /// Fixed_type
        /// </summary>
        public int fixed_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ani_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ani_delay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ani_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ani_duration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string clip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int size_type
        {
            get; set;
        }
    }
}
 