using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MoDao2MiniGUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var aaa = "";
            var oj= Newtonsoft.Json.JsonConvert.DeserializeObject(aaa);

            if (args.Length > 0) Console.WriteLine("请输入墨刀路径");
            string modaodir = args.Length > 0 ? args[0] : Console.ReadLine();
            Console.WriteLine("墨刀路径" + modaodir);
            string modaoindex = System.IO.Path.Combine(modaodir, "data/project.js");
            if (!System.IO.File.Exists(modaoindex))
            {
                Console.WriteLine("未找到data/project.js");
            }
            else
            {
                string indexhtml = System.IO.File.ReadAllText(modaoindex);
                string mbdatatag = "window.MBData =";
                string jsontemplates = indexhtml.Substring(indexhtml.IndexOf(mbdatatag) + mbdatatag.Length);
                JObject jObject=JObject.Parse( jsontemplates);
                var objs = jObject["widgets"].ToArray();
      
                string[] keynames = Properties.Resources.KeyName.Split('\r', '\n');
                List<string> ctlcode = new List<string>();
                List<string> ctlids = new List<string>();
                int labelcount = 0;
                foreach (var item in objs)
                {
                    var wt = item.ToObject<widget>();
                    var keyname = from st in keynames where Check(wt, st) select st;
                    var idname = keyname.Any() ? keyname.FirstOrDefault().Split(new char[] { ' ', (char)160 }, StringSplitOptions.RemoveEmptyEntries)[1] : string.Empty;
                    if (string.IsNullOrEmpty(idname))
                    {
                        idname = wt.display_name.ToUpper();
                    }
                    switch (wt.name)
                    {
                        case "image_view":

                            break;
                        case "button":
                            {
                                string buttoncode = $"{{CTRL_BUTTON, WS_VISIBLE | BS_PUSHBUTTON | WS_TABSTOP, {wt.left}, {wt.top}, {wt.width}, {wt.height}, ID_{idname}, \"{wt.GetText()}\",0 }}";
                                string keyvalue = Properties.Resources.KEYMAP_CT.Substring(Properties.Resources.KEYMAP_CT.IndexOf(idname));
                                keyvalue = keyvalue.Substring(keyvalue.IndexOf("=<") + 2, keyvalue.IndexOf(">") - keyvalue.IndexOf("=<") - 2);
                                ctlcode.Add(buttoncode);
                                ctlids.Add($"#define ID_{idname} {1000 + int.Parse(keyvalue)}");
                            }
                            break;
                        case "label":
                            {
                                string lablecode = $"{{CTRL_STATIC, WS_VISIBLE | SS_CENTER, {wt.left},{wt.top},  {wt.width}, {wt.height}, ID_{idname}, \"{wt.GetText()}\",0 }}";
                                ctlcode.Add(lablecode);
                                labelcount++;
                                ctlids.Add($"#define ID_{idname} {1200 + labelcount}");
                            }
                            break;
                        case "rich_text":
                            {
                                string lablecode = $"{{CTRL_STATIC, WS_VISIBLE | SS_CENTER, {wt.left},{wt.top},  {wt.width}, {wt.height}, ID_{idname}, \"{wt.GetText()}\",0 }}";
                                ctlcode.Add(lablecode);
                                labelcount++;
                                ctlids.Add($"#define ID_{idname} {1200 + labelcount}");
                            }
                            break;
                        case "rounded_rect":

                            break;
                        default:
                            Console.WriteLine(wt.name);
                            break;
                    }
                }
                string code = "#ifndef _APPUI_H_\r\n#define _APPUI_H_\r\n";
                foreach (var item in ctlids)
                {
                    code += item + "\r\n";
                }
                code +=  "\r\n";
                code += "static CTRLDATA CtrlYourTaste[] = \r\n{";
                for (int i = 0; i < ctlcode.Count; i++)
                {
                    code += "\r\n";
                    code += ctlcode[i];
                    if (i +1< ctlcode.Count)
                    {
                        code += ",";
                    }
                }
                code += "};\r\n#endif";


                System.IO.File.WriteAllText("appui.h", code, Encoding.GetEncoding(936));
            }
        }

        private static bool Check(widget wt, string st)
        {
            return !string.IsNullOrEmpty(st) && wt != null && !string.IsNullOrEmpty(wt.GetText()) && st.Trim().Split(new char[] { ' ', (char)160 }, StringSplitOptions.RemoveEmptyEntries)[0].Equals(wt.GetText().Replace(" ", "").Replace("" + (char)160, "").Trim());
        }
     
    }
}
