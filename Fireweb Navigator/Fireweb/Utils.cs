using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography;
using Gecko;
using DevComponents.DotNetBar;
using System.IO;

namespace Fireweb
{
    public class ActiveInstance
    {
        public GeckoWebBrowser Browser;
        public SuperTabItem Tab;

        public ActiveInstance(GeckoWebBrowser wb, SuperTabItem tb)
        {
            Browser = wb;
            Tab = tb;
        
        }
    }
    /// <summary>
    /// An useful class to read/write/delete/count registry keys
    /// </summary>
    public static class TrecoRegistryManager
    {
        private static bool showError = false;
        /// <summary>
        /// A property to show or hide error messages 
        /// (default = false)
        /// </summary>
        public static bool ShowError
        {
            get { return showError; }
            set { showError = value; }
        }

        private static string subKey = "SOFTWARE\\" + Application.ProductName + "\\Informations";
        /// <summary>
        /// A property to set the SubKey value
        /// (default = "SOFTWARE\\" + Application.ProductName.ToUpper())
        /// </summary>
        public static string SubKey
        {
            get { return subKey; }
            set { subKey = value; }
        }

        private static RegistryKey baseRegistryKey = Registry.LocalMachine;
        /// <summary>
        /// A property to set the BaseRegistryKey value.
        /// (default = Registry.LocalMachine)
        /// </summary>
        public static RegistryKey BaseRegistryKey
        {
            get { return baseRegistryKey; }
            set { baseRegistryKey = value; }
        }



        /// <summary>
        /// To read a registry key.
        /// input: KeyName (string)
        /// output: value (string) 
        /// </summary>
        public static string Read(string YSubkey, string KeyName)
        {
            string str = (string)Registry.GetValue(YSubkey, KeyName, KeyName);
            return str;

        }

        /// <summary>
        /// To write into a registry key.
        /// input: KeyName (string) , Value (object)
        /// output: true or false 
        /// </summary>
        public static bool Write(string KeyName, object Value)
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                // I have to use CreateSubKey 
                // (create or open it if already exits), 
                // 'cause OpenSubKey open a subKey as read-only
                RegistryKey sk1 = rk.CreateSubKey(subKey);
                // Save the value
                sk1.SetValue(KeyName.ToUpper(), Value);

                return true;
            }
            catch (Exception e)
            {
                // AAAAAAAAAAARGH, an error!
                ShowErrorMessage(e, "Writing registry " + KeyName.ToUpper());
                return false;
            }
        }


        /// <summary>
        /// To delete a registry key.
        /// input: KeyName (string)
        /// output: true or false 
        /// </summary>
        public static bool DeleteKey(string KeyName)
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.CreateSubKey(subKey);
                // If the RegistrySubKey doesn't exists -> (true)
                if (sk1 == null)
                    return true;
                else
                    sk1.DeleteValue(KeyName);

                return true;
            }
            catch (Exception e)
            {
                // AAAAAAAAAAARGH, an error!
                ShowErrorMessage(e, "Deleting SubKey " + subKey);
                return false;
            }
        }



        /// <summary>
        /// To delete a sub key and any child.
        /// input: void
        /// output: true or false 
        /// </summary>
        public static bool DeleteSubKeyTree()
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(subKey);
                // If the RegistryKey exists, I delete it
                if (sk1 != null)
                    rk.DeleteSubKeyTree(subKey);

                return true;
            }
            catch (Exception e)
            {
                // AAAAAAAAAAARGH, an error!
                ShowErrorMessage(e, "Deleting SubKey " + subKey);
                return false;
            }
        }


        /// <summary>
        /// Retrive the count of subkeys at the current key.
        /// input: void
        /// output: number of subkeys
        /// </summary>
        public static int SubKeyCount()
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(subKey);
                // If the RegistryKey exists...
                if (sk1 != null)
                    return sk1.SubKeyCount;
                else
                    return 0;
            }
            catch (Exception e)
            {
                // AAAAAAAAAAARGH, an error!
                ShowErrorMessage(e, "Retriving subkeys of " + subKey);
                return 0;
            }
        }



        /// <summary>
        /// Retrive the count of values in the key.
        /// input: void
        /// output: number of keys
        /// </summary>
        public static int ValueCount()
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(subKey);
                // If the RegistryKey exists...
                if (sk1 != null)
                    return sk1.ValueCount;
                else
                    return 0;
            }
            catch (Exception e)
            {
                // AAAAAAAAAAARGH, an error!
                ShowErrorMessage(e, "Retriving keys of " + subKey);
                return 0;
            }
        }


        private static void ShowErrorMessage(Exception e, string Title)
        {
            if (showError == true)
                DevComponents.DotNetBar.MessageBoxEx.Show(e.Message,
                                Title
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Error);
        }
    }
    public static class RegisterBrowser
    {
        static string appopen = Application.ExecutablePath;
        static string args = "sRcU0S+Xz7DQf1FmqkCI+Q==";
        static string paranthese = "OucFa56XU3E=";
        public static void Register()
        {
            bool isftpreg = false;
            bool ishttpsreg = false;
            bool ishttpreg = false;
            Check(ref isftpreg, ref ishttpreg, ref ishttpsreg);

        }
        public static void RegisterHttp(string ais)
        {
            string appvalue = Utils.Decrypt(paranthese) + Application.ExecutablePath + Utils.Decrypt(paranthese) + Utils.Decrypt(args);
            MakeBackup();
            Registry.SetValue(@"HKEY_CLASSES_ROOT\http\shell\open\command", "", appvalue);
        }
        public static void RegisterHttps(string ais)
        {
            string appvalue = Utils.Decrypt(paranthese) + Application.ExecutablePath + Utils.Decrypt(paranthese) + Utils.Decrypt(args);
            MakeBackup();
            Registry.SetValue(@"HKEY_CLASSES_ROOT\https\shell\open\command", "", appvalue);
        }
        public static void RegisterFtp(string ais)
        {
            string appvalue = Utils.Decrypt(paranthese) + Application.ExecutablePath + Utils.Decrypt(paranthese) + Utils.Decrypt(args);
            MakeBackup();
            Registry.SetValue(@"HKEY_CLASSES_ROOT\ftp\shell\open\command", "", appvalue);

        }
        public static void CheckResult(bool FTP, bool HTTP, bool HTTPS)
        {
            bool _alertshown = false;
            if (FTP == false)
            {
                if (_alertshown == false)
                {
                    System.Windows.Forms.DialogResult result = DevComponents.DotNetBar.MessageBoxEx.Show(@"Fireweb Navigator is not your default browser \nWould you like to register it ?", "Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        RegisterFtp("cmVnaXN0ZXJhcHBhc2RlZmF1bHRicm93c2Vy");
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            else
            {

            }
            if (HTTP == false)
            {
                if (_alertshown == false)
                {
                    System.Windows.Forms.DialogResult result = DevComponents.DotNetBar.MessageBoxEx.Show(@"Fireweb Navigator is not your default browser \nWould you like to register it ?", "Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        RegisterHttp("cmVnaXN0ZXJhcHBhc2RlZmF1bHRicm93c2Vy");
                    }
                    else
                    {

                    }
                }
                else
                {
                    RegisterHttp("cmVnaXN0ZXJhcHBhc2RlZmF1bHRicm93c2Vy");
                }
            }
            else
            {

            }
            if (HTTPS == false)
            {
                if (_alertshown == false)
                {
                    System.Windows.Forms.DialogResult result = DevComponents.DotNetBar.MessageBoxEx.Show(@"Fireweb Navigator is not your default browser \nWould you like to register it ?", "Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        RegisterHttps("cmVnaXN0ZXJhcHBhc2RlZmF1bHRicm93c2Vy");
                    }
                    else
                    {

                    }
                }
                else
                {
                    RegisterHttps("cmVnaXN0ZXJhcHBhc2RlZmF1bHRicm93c2Vy");
                }

            }
            else
            {

            }
        }
        public static void MakeBackup()
        {
            string httpbackup = (string)Registry.GetValue(@"HKEY_CLASSES_ROOT\http\shell\open\command", "", "");
            string httpsbackup = (string)Registry.GetValue(@"HKEY_CLASSES_ROOT\https\shell\open\command", "", "");
            string ftpbackup = (string)Registry.GetValue(@"HKEY_CLASSES_ROOT\ftp\shell\open\command", "", "");
            string[] lines = { "-http=" + httpbackup, "-https=" + httpsbackup, "-ftp=" + ftpbackup };
            File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Fireweb Navigator\temp\registry.backup", lines);
        }
        public static void Check(ref bool isftpreg, ref bool ishttpreg, ref bool ishttpsreg)
        {
            string http = (string)Registry.GetValue(@"HKEY_CLASSES_ROOT\http\shell\open\command", "", "");
            string https = (string)Registry.GetValue(@"HKEY_CLASSES_ROOT\https\shell\open\command", "", "");
            string ftp = (string)Registry.GetValue(@"HKEY_CLASSES_ROOT\ftp\shell\open\command", "", "");
            if (http.Contains(Application.ExecutablePath))
            {
                ishttpreg = true;
            }
            else
            {
                ishttpreg = false;
            }

            if (https.Contains(Application.ExecutablePath))
            {
                ishttpsreg = true;
            }
            else
            {
                ishttpsreg = false;
            }
            if (ftp.Contains(Application.ExecutablePath))
            {
                isftpreg = true;
            }
            else
            {
                isftpreg = false;
            }

            CheckResult(isftpreg, ishttpreg, ishttpsreg);
        }

        static string _key;
        static string _pid;

        public static string Key
        {
            get { return _key; }
        }
        public static string ProductID
        {
            get { return _pid; }
        }
        public static string MachineName
        {
            get { return Environment.MachineName; }
        }
        private static void WriteID(string skey)
        {
            string text = "                             Arsslensoft Foundation                           " + Environment.NewLine + "*******************************************************************" + Environment.NewLine + " Machine Name : " + Environment.MachineName + Environment.NewLine + " OS Version : " + Environment.OSVersion.VersionString + Environment.NewLine + " System Directory : " + Environment.SystemDirectory + Environment.NewLine + " UserName : " + Environment.UserName + Environment.NewLine + " Key : " + skey + Environment.NewLine + " Version : 5.0";
            File.WriteAllText(Application.StartupPath + @"\" + Key + ".txt", text);
            using (StreamWriter str = new StreamWriter(Application.StartupPath + @"\" + Key + ".txt", true))
            {
                str.WriteLine("");
                str.WriteLine("Plugins Manager version : 5.0");
                str.WriteLine("Arsslensoft Language Runtime version : 5.0");
                str.WriteLine("ASPL platforms : x70 en-US / x80 fr-FR / x90 ar-TN");
                str.WriteLine("Fireweb Database driver version : 2.0");
                str.WriteLine("Custom Language Compiler version : 5.0");
                str.WriteLine("Configuration file provider version : 5.0");
                str.WriteLine("Application Help Document reader version : 5.0");
                str.WriteLine("FEXA version : 5.0");
                str.WriteLine("FNI/FNA version : 5.0");
                str.WriteLine("Registry version : 5.0");
                str.WriteLine("Encryption/Decryption : Data Encryption Standard/ Advanced Encryption Standard");
                str.WriteLine("Controls : Dev");
                str.WriteLine("Treco AutoComplete version : 5.0");
                str.WriteLine("Treco Component version : 5.0");
                str.WriteLine("Treco Base Engine version : 2.0");
                str.WriteLine("Treco Base Engine : Gecko");
                str.WriteLine("Treco Security Namespace : Treco.Security");
                str.WriteLine("Treco GUID : 2d144611-62c5-4eb8-a0ae-8a1617949dcc");
                str.WriteLine("ASPREF : 5.0");
                str.WriteLine("ArgumentParser : 5.0");
                str.WriteLine("SettingsParser : 5.0");
                str.WriteLine("SpellChecker : 5.0");
                str.WriteLine("Treco International : 5.0");
                str.WriteLine("");
                str.WriteLine("APPLICATION_WORKS = TRUE");
                str.Close();
            }
        }

    }
    public static class Utils
    {
        public static string ToBase64(string inputstring)
        {
            byte[] byt = System.Text.Encoding.UTF8.GetBytes(inputstring);

            string result = Convert.ToBase64String(byt);
            return result;
        }
        public static string FromBase64(string encodedstring)
        {
            byte[] b = Convert.FromBase64String(encodedstring);

            string result = System.Text.Encoding.UTF8.GetString(b);
            return result;
        }
        public static string Encrypt(string originalString)
        {

            if (String.IsNullOrEmpty(originalString))
            {
                throw new ArgumentNullException
                       ("The string which needs to be encrypted can not be null.");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);

        }
        public static string Decrypt(string cryptedString)
        {

            if (String.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException
                   ("The string which needs to be decrypted can not be null.");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream
                    (Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();


        }
        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("6xtnEvty");

        private static string CreateMd5(string input)
        {
            StringBuilder buffer = new StringBuilder();

            MD5 md5 = MD5CryptoServiceProvider.Create();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] outputBytes = md5.ComputeHash(inputBytes);

            foreach (byte b in outputBytes)
            {
                buffer.AppendFormat("{0:x2}", b);
            }

            return buffer.ToString();
        }
        static WebClient wb = new WebClient();
        public static void TranslateDocument(GeckoWebBrowser wb,string language)
        {
            try
            {

                string jso = "function googleTranslateElementInit()" + " { new google.translate.TranslateElement({  " + "pageLanguage: '" + language + "'" + "  }, 'google_translate_element');" + "}";

                GeckoElement el = wb.Document.CreateElement("DIV");
                el.SetAttribute("id", "google_translate_element");
                wb.Document.Body.AppendChild(el);
                GeckoElement sco = wb.Document.CreateElement("SCRIPT");
                sco.TextContent = jso;
                wb.Document.Body.AppendChild(sco);

                GeckoElement sct = wb.Document.CreateElement("SCRIPT");
                sct.SetAttribute("src", "http://translate.google.com/translate_a/element.js?cb=googleTranslateElementInit");
                wb.Document.Body.AppendChild(sct);
            }
            catch
            {

            }
        }
        public static Bitmap GetFavicon(Uri Url)
        {
            Bitmap _favicon = Fireweb.Properties.Resources.lock_arrow;
            string cachedir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Fireweb Navigator\FCACHE\";
            if (!Directory.Exists(cachedir))
                Directory.CreateDirectory(cachedir);
            try
            {

                if (Url == null)
                {

                }
                else if (Url.ToString().StartsWith("about:"))
                {

                }

                else if (Url.Host.StartsWith("arsslensoft.tk"))
                {
                    wb.DownloadFile("http://www.arsslensoft.tk/sites/default/files/favicon.png", cachedir + CreateMd5(Url.Host) + ".fcache");
                    Bitmap bitmap4 = new Bitmap(cachedir + Url.Host + ".fcache");
                    _favicon = bitmap4;
                }
                else if (Url.Host.StartsWith("www.arsslensoft.tk"))
                {
                    wb.DownloadFile("http://www.arsslensoft.tk/sites/default/files/favicon.png", cachedir + CreateMd5(Url.Host) + ".fcache");
                    Bitmap bitmap4 = new Bitmap(cachedir + CreateMd5(Url.Host) + ".fcache");
                    _favicon = bitmap4;
                }
                else
                {

                    if (System.IO.File.Exists(cachedir + CreateMd5(Url.Host) + ".fcache"))
                    {
                        string sfile = cachedir + CreateMd5(Url.Host) + ".fcache";
                        if (sfile != null)
                        {
                            Bitmap bitmp = new Bitmap(sfile);
                            _favicon = bitmp;
                        }
                        else
                        {
                        }


                    }
                    else
                    {
                        string urel = "http://g.etfv.co/" + Url.AbsoluteUri;
                   
                        wb.DownloadFile(urel, cachedir + CreateMd5(Url.Host) + ".fcache");
                        Bitmap bitmap2 = new Bitmap(cachedir + CreateMd5(Url.Host) + ".fcache");
                        _favicon = bitmap2;
                    }
                }
                return _favicon;
            }
            catch
            {
                return Fireweb.Properties.Resources.lock_arrow;
            }
            finally
            {
            }

        }
    }
}
