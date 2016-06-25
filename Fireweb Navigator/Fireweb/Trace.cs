using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gecko;
using System.Drawing;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Globalization;

namespace Fireweb
{
    internal class FHistoryEntry
    {
        public DateTime Visited;
        public string Url;
        public string Title;

        public FHistoryEntry(string url, string title, DateTime dt)
        {
            Visited = dt;
            Url = url;
            Title = title;
        }
    }
   internal static class Trace
    {
       internal static SQLiteConnection DTB;
       internal static string BuildConString(string dbfile, int cachesize, int version, int maxpagecount, int pagesize, bool pooling, bool Sync)
       {
           SQLiteConnectionStringBuilder wdbcons = new SQLiteConnectionStringBuilder();
           wdbcons.CacheSize = cachesize;
           wdbcons.DataSource = dbfile;
           wdbcons.Version = version;
           wdbcons.MaxPageCount = maxpagecount;
           wdbcons.PageSize = pagesize;
           wdbcons.Password = "df3.x9a3irh,gw9oè";
           wdbcons.Pooling = pooling;
           wdbcons.JournalMode = SQLiteJournalModeEnum.Off;
           if (Sync)
           {
               wdbcons.SyncMode = SynchronizationModes.Full;
           }
           else
           {
               wdbcons.SyncMode = SynchronizationModes.Off;
           }
           wdbcons.FailIfMissing = true;
           return wdbcons.ConnectionString;
       }
       public static void Initialize()
       {
           try
           {
               DTB = new SQLiteConnection(BuildConString(Application.StartupPath + @"\Data.sqlite", 8192, 3, 8192, 8192, false, false));
               DTB.Open();
           }
           catch
           {

           }
       }
       public static void Close()
       {
           try
           {
               DTB.Close();
           }
           catch
           {

           }
       }
       static string Normalize(string text, bool reverse)
       {
           if(reverse)
               return text.Replace("<arsslensoft-quote>","'");
           else
           return text.Replace("'", "<arsslensoft-quote>");
       }
       public static void AddUrl(string Url, string Title)
       {
           try
           {
               using (SQLiteTransaction trans = DTB.BeginTransaction())
               {

                   using (SQLiteCommand addKeysCmd = new SQLiteCommand(DTB))
                   {
                       string sqlIns = "INSERT INTO history (url, title, visited) VALUES('" + Normalize(Url, false) + "', '" + Normalize(Title, false) + "', '" + DateTime.Now.ToString("d", DateTimeFormatInfo.InvariantInfo) + " " + DateTime.Now.ToString("t", DateTimeFormatInfo.InvariantInfo) + "');";
                           addKeysCmd.CommandText = sqlIns;
                           addKeysCmd.ExecuteNonQuery();
                   }
                   trans.Commit();
               }
           }
           catch
           {

           }
       }
       public static void RemoveUrl(string Url)
       {
           try
           {
               using (SQLiteCommand cmd = new SQLiteCommand(DTB))
               {
                   cmd.CommandText = "DELETE FROM history WHERE url='"+Normalize(Url,false)+"';";
                   cmd.ExecuteNonQuery();
               }
           }
           catch
           {

           }
       }
       public static List<string> GetUrlList(string key, int max)
       {
           List<string> lst = new List<string>();
           try
           {
             
               using (SQLiteCommand cmd = new SQLiteCommand(DTB))
               {
                   cmd.CommandText = "SELECT url FROM history WHERE url LIKE '%" + Normalize(key, false) + "%';";
                  SQLiteDataReader rdr = cmd.ExecuteReader();
                  int i = 0;
                  while (rdr.Read() && max > i)
                  {
                    i++;
                    lst.Add(Normalize((string)rdr["url"], true));
                  }
               }
              

           }
           catch
           {

           }
           return lst;
       }
       public static List<FHistoryEntry> GetUrlListByDate(DateTime date)
       {
     
               List<FHistoryEntry> lst = new List<FHistoryEntry>();
               try
               {

                   using (SQLiteCommand cmd = new SQLiteCommand(DTB))
                   {
                       cmd.CommandText = "SELECT * FROM history WHERE visited LIKE '" + Normalize(date.ToString("d", DateTimeFormatInfo.InvariantInfo), false) + "%';";
                       SQLiteDataReader rdr = cmd.ExecuteReader();

                       while (rdr.Read())
                       {
                           string url = (string)rdr["url"];
                           string title = (string)rdr["title"];
                           lst.Add(new FHistoryEntry(Normalize(url, true), Normalize(title, true), DateTime.Parse((string)rdr["visited"], DateTimeFormatInfo.InvariantInfo)));

                       }
               }


               }
               catch
               {

               }
               return lst;
   
       }
       public static List<FHistoryEntry> GetAll()
       {
        
               List<FHistoryEntry> lst = new List<FHistoryEntry>();
               try
               {

                   using (SQLiteCommand cmd = new SQLiteCommand(DTB))
                   {
                       cmd.CommandText = "SELECT * FROM history;";
                       SQLiteDataReader rdr = cmd.ExecuteReader();

                       while (rdr.Read())
                       {
                           string date = ((string)rdr["visited"]);
                           lst.Add(new FHistoryEntry(Normalize((string)rdr["url"], true), Normalize((string)rdr["title"], true), DateTime.Parse(date, DateTimeFormatInfo.InvariantInfo)));

                       }
                   }


               }
               catch
               {

               }
               return lst;
         
       }
       public static void ClearHistory()
       {
           try
           {
               using (SQLiteTransaction trans = DTB.BeginTransaction())
               {
                   using (SQLiteCommand cmd = new SQLiteCommand(DTB))
                   {
                       cmd.CommandText = "DROP TABLE history;";
                       cmd.ExecuteNonQuery();
                       cmd.CommandText = "CREATE VIRTUAL TABLE history USING FTS3(url TEXT, title TEXT, visited TEXT);";
                       cmd.ExecuteNonQuery();
                   }

               }
           }
           catch
           {

           }
       }


       public static void BookmarkUrl(string url, string title, Image icon)
       {
           try
           {
               string file = Application.StartupPath + @"\BMK\icons\" + DateTime.Now.ToFileTimeUtc().ToString() + ".jpg";
               icon.Save(file);
               using (SQLiteTransaction trans = DTB.BeginTransaction())
               {

                   using (SQLiteCommand addKeysCmd = new SQLiteCommand(DTB))
                   {
                       string sqlIns = "INSERT INTO bookmarks (url, title, visited) VALUES('" + Normalize(url, false) + "', '" + Normalize(title, false) + "', '" + Normalize(file, false) + "');";
                       addKeysCmd.CommandText = sqlIns;
                       addKeysCmd.ExecuteNonQuery();
                   }
                   trans.Commit();
               }
           }
           catch
           {

           }
       }
       public static List<string> GetBookmarks()
       {
           List<string> lst = new List<string>();
           try
           {

               using (SQLiteCommand cmd = new SQLiteCommand(DTB))
               {
                   cmd.CommandText = "SELECT url FROM bookmarks;";
                   SQLiteDataReader rdr = cmd.ExecuteReader();
                   while (rdr.Read()) 
                       lst.Add(Normalize((string)rdr["url"], true));
            
               }


           }
           catch
           {

           }
           return lst;
       }
       public static void RemoveBookmark(string url)
       {
           try
           {
               using (SQLiteCommand cmd = new SQLiteCommand(DTB))
               {
                   cmd.CommandText = "DELETE FROM bookmarks WHERE url='" + Normalize(url, false) + "';";
                   cmd.ExecuteNonQuery();
               }
           }
           catch
           {

           }
       }
       public static void ClearBookmark()
       {
           try
           {
               using (SQLiteTransaction trans = DTB.BeginTransaction())
               {
                   using (SQLiteCommand cmd = new SQLiteCommand(DTB))
                   {
                       cmd.CommandText = "DROP TABLE bookmarks;";
                       cmd.ExecuteNonQuery();
                       cmd.CommandText = "CREATE VIRTUAL TABLE bookmarks USING FTS3(url TEXT, title TEXT, icon TEXT);";
                       cmd.ExecuteNonQuery();
                   }

               }
           }
           catch
           {

           }
       }

       public static void AddAutoComplete(string key, string url, string formname)
       {
           try
           {
               using (SQLiteTransaction trans = DTB.BeginTransaction())
               {

                   using (SQLiteCommand addKeysCmd = new SQLiteCommand(DTB))
                   {
                       string sqlIns = "INSERT INTO autofill (word, destination, url, form) VALUES('" + Normalize(key, false) + "', '" + Normalize(key, false) + "', '" + Normalize(url, false) + "', '" + Normalize(formname, false) + "');";
                       addKeysCmd.CommandText = sqlIns;
                       addKeysCmd.ExecuteNonQuery();
                   }
                   trans.Commit();
               }
           }
           catch
           {

           }
       }
       public static List<string> GetAutoComplete(string key, string url, string formname)
       {
           List<string> lst = new List<string>();
           try
           {
               using (SQLiteCommand cmd = new SQLiteCommand(DTB))
               {
                   cmd.CommandText = "SELECT destination FROM autofill WHERE word LIKE '" + Normalize(key, false) + "%' AND form='" + Normalize(formname, false) + "';";
                   SQLiteDataReader rdr = cmd.ExecuteReader();
            
                   while (rdr.Read() )                      
                       lst.Add(Normalize((string)rdr["destination"], true));
                  
               }
           }
           catch
           {

           }
           return lst;
       }
       public static void ClearAutoComplete()
       {
           try
           {
               using (SQLiteTransaction trans = DTB.BeginTransaction())
               {
                   using (SQLiteCommand cmd = new SQLiteCommand(DTB))
                   {
                       cmd.CommandText = "DROP TABLE autofill;";
                       cmd.ExecuteNonQuery();
                       cmd.CommandText = "CREATE VIRTUAL TABLE autofill USING FTS3(word TEXT, destination TEXT, url TEXT, form TEXT);";
                       cmd.ExecuteNonQuery();
                   }

               }
           }
           catch
           {

           }
       }

       public static void Clear(bool cache, bool cookies,bool history, bool autocomplete, bool bookmarks)
       {
           try
           {
             
               if (history)
                   ClearHistory();
               if (bookmarks)
                   ClearBookmark();

               if (autocomplete)
                   ClearAutoComplete();

               if (cookies)
                   CookieManager.RemoveAll();

               if (cache)
                   Gecko.Cache.CacheService.Clear(Gecko.Cache.CacheStoragePolicy.Anywhere);

           }
           catch
           {

           }
       }
    }
}
