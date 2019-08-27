using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoDao2MiniGUI
{
    public static  class WidgetEx
    {
        public static string GetText(this widget wt)
        {
            string txt = wt.text?.Value as string;
            if (string.IsNullOrEmpty(txt))
            {
                return string.Empty;
            }
            else
            {

                var ja = Newtonsoft.Json.JsonConvert.DeserializeObject(txt) as Newtonsoft.Json.Linq.JArray;
              var  childrens = (ja.FirstOrDefault()?.ToObject(typeof(TextObject)) as TextObject)?.children;
                return childrens?.FirstOrDefault()?.text;
            }
        }
        public static TextChildren GetTextChildren(this widget wt)
        {
            string txt = wt.text?.Value as string;
            if (string.IsNullOrEmpty(txt))
            {
                return null;
            }
            else
            {

                var ja = Newtonsoft.Json.JsonConvert.DeserializeObject(txt) as Newtonsoft.Json.Linq.JArray;
                var childrens = (ja.FirstOrDefault()?.ToObject(typeof(TextObject)) as TextObject)?.children;
                return childrens?.FirstOrDefault();
            }
        }
    }
}
