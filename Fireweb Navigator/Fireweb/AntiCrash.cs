using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Fireweb
{
   public static class AntiCrash
    {
       public static void Report(Exception ex)
       {
           try
           {
               using (StreamWriter str = new StreamWriter(Application.StartupPath + @"\Error.txt", true))
               {
                   str.WriteLine("---------------------------------------------------------------------");
                   str.WriteLine(ex.Message);
                   str.WriteLine(ex.Source);
                   str.WriteLine(ex.StackTrace);
               }
           }
           catch
           {

           }
       }
    }
}
