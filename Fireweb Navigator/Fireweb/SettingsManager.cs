using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Fireweb
{
   public static class SettingsManager
    {


       public static bool BlockPopup
       {
           get
           {
               return bool.Parse(sprefs["blockpopup"]);
           }
           set
           {
               sprefs["blockpopup"] = value.ToString();
           }
       }
       public static bool AutoComplete
       {
           get
           {
               return bool.Parse(sprefs["autofill"]);
           }
           set
           {
               sprefs["autofill"] = value.ToString();
           }
       }
       public static string SE
       {
           get
           {
               return sprefs["se"];
           }
           set
           {
               sprefs["se"] = value;
           }
       }
       public static string Home
       {
           get
           {
               return sprefs["home"];
           }
           set
           {
               sprefs["home"] = value;
           }
       }
       public static bool AllowDNS
       {
           get
           {
               return bool.Parse(sprefs["dns"]);
           }
           set
           {
               sprefs["dns"] = value.ToString();
           }
       }
       public static bool AllowMeta
       {
           get
           {
               return bool.Parse(sprefs["meta"]);
           }
           set
           {
               sprefs["meta"] = value.ToString();
           }
       }
       public static bool AllowPlugin
       {
           get
           {
               return bool.Parse(sprefs["plugin"]);
           }
           set
           {
               sprefs["plugin"] = value.ToString();
           }
       }
       public static bool AllowImage
       {
           get
           {
               return bool.Parse(sprefs["img"]);
           }
           set
           {
               sprefs["img"] = value.ToString();
           }
       }
       public static bool AllowJS
       {
           get
           {
               return bool.Parse(sprefs["js"]);
           }
           set
           {
               sprefs["js"] = value.ToString();
           }
       }
       public static bool AllowSubframe
       {
           get
           {
               return bool.Parse(sprefs["sframe"]);
           }
           set
           {
               sprefs["sframe"] = value.ToString();
           }
       }
       public static bool AllowFirewebPlugin
       {
           get
           {
               return bool.Parse(sprefs["fnplugin"]);
           }
           set
           {
               sprefs["fnplugin"] = value.ToString();
           }
       }
       public static bool RegisterDefalut
       {
           get
           {
               return bool.Parse(sprefs["rd"]);
           }
           set
           {
               sprefs["rd"] = value.ToString();
           }
       }
       public static bool Turbo
       {
           get
           {
               return bool.Parse(sprefs["turbo"]);
           }
           set
           {
               sprefs["turbo"] = value.ToString();
           }
       }
       public static bool Glass
       {
           get
           {
               return bool.Parse(sprefs["gl"]);
           }
           set
           {
               sprefs["gl"] = value.ToString();
           }
       }
       public static void Default()
       {
           List<string> lst = new List<string>();
           lst.Add(@"blockpopup=True");
           lst.Add(@"autofill=True");
           lst.Add(@"se=http://www.google.com/search?q=");
           lst.Add(@"home=http://www.google.com");
           lst.Add(@"dns=True");
           lst.Add(@"meta=True");
           lst.Add(@"js=True");
           lst.Add(@"plugin=True");
           lst.Add(@"fnplugin=True");
           lst.Add(@"sframe=True");
           lst.Add(@"rd=True");
           lst.Add(@"img=True");
           lst.Add(@"turbo=True");
           lst.Add(@"gl=False");

           Write(Application.StartupPath + @"\Conf\Config.fconf", lst);
       }

       public static void Save()
       {
           try
           {
               List<string> lst = new List<string>();
               foreach (KeyValuePair<string, string> pair in sprefs)
                   lst.Add(pair.Key + "=" + pair.Value);

               Write(Application.StartupPath + @"\Conf\Config.fconf", lst);
           }
           catch
           {

           }
       }
       public static void Write(string file, List<string> prefs)
       {
           try
           {
               using (StreamWriter str = new StreamWriter(Application.StartupPath + @"\d.tmp", true))
               {
                   foreach (string pref in prefs)
                   {
                       str.WriteLine(pref);
                   }
                   str.Close();
               }
               string code = File.ReadAllText(Application.StartupPath + @"\d.tmp");

               File.WriteAllText(file, code);
               File.Delete(Application.StartupPath + @"\d.tmp");
           }
           catch
           {

           }
           finally
           {

           }
       }
       static Dictionary<string, string> sprefs;
       public static void Initialize(string confile)
       {
           try
           {
               if (!File.Exists(confile))
                   Default();


               sprefs = new Dictionary<string, string>();
               Regex reg = new Regex(@"=", RegexOptions.IgnoreCase | RegexOptions.Compiled);

               using (StreamReader sr = new StreamReader(confile))
               {
                   while (sr.Peek() >= 0)
                   {
                       string[] t = reg.Split(sr.ReadLine(), 2);
                       sprefs.Add(t[0], t[1]);
                   }
               }
           }
           catch (Exception ex)
           {
               AntiCrash.Report(ex);
           }
       }
       public static void Initialize()
       {
           try
           {
               if (!File.Exists(Application.StartupPath + @"\Conf\Config.fconf"))
                   Default();


               sprefs = new Dictionary<string, string>();
               Regex reg = new Regex(@"=", RegexOptions.IgnoreCase | RegexOptions.Compiled);

               using (StreamReader sr = new StreamReader(Application.StartupPath + @"\Conf\Config.fconf"))
               {
                   while (sr.Peek() >= 0)
                   {
                       string[] t = reg.Split(sr.ReadLine(), 2);
                       sprefs.Add(t[0], t[1]);
                   }
               }
           }
           catch (Exception ex)
           {
               AntiCrash.Report(ex);
           }
       }
     }
}
