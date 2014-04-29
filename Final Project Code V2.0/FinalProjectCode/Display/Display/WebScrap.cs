using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Display
{
    class WebScrap
    {
        List<string> badwords = new List<string>()
            {"the","and","The","is","a","to","of"};
        
        public WebScrap()
        {


            WebClient w = new WebClient();
            string webaddress;
            using (StreamReader reader = new StreamReader("thisonelads2.txt"))
            {
                webaddress = reader.ReadLine();
            }
            try
            {

                String s = w.DownloadString(webaddress);
                Regex x = new Regex("<[^>]*>");
                //String target = s.replaceAll("(?i)<td[^>]*>", " ").replaceAll("\\s+", " ").trim();
                String ss = x.Replace(s, " ");

                using (StreamWriter writer = new StreamWriter("webOutput.txt"))
                {
                    writer.WriteLine(ss);
                }
            }
            catch
            {
                using (StreamWriter writer = new StreamWriter("webOutput.txt"))
                {
                    writer.WriteLine("Error incorrect URL Return to menu");
                }
                
            }
            
        }

        public WebScrap(String URL)
        {
            WebClient w = new WebClient();
            String s = w.DownloadString(URL);
            Regex x = new Regex("<[^>]*>");
            //String target = s.replaceAll("(?i)<td[^>]*>", " ").replaceAll("\\s+", " ").trim();
            String ss = x.Replace(s, " ");

            using (StreamWriter writer = new StreamWriter("webOutput.txt"))
            {
                writer.WriteLine(ss);
            }
        }

    }
}
