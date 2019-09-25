using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace OFXConverter
{
    public static class TryAgainConverter
    {
        
        public static void DataPrinting(string pathToOfxFile)
        {
            if (!System.IO.File.Exists(pathToOfxFile))
            {
                throw new FileNotFoundException();
            }
            StreamReader read = null;
            //string ofxFile = "";
            FileStream fs = File.Open(pathToOfxFile, FileMode.Open, FileAccess.Read);
            read = new StreamReader(fs, true);

            bool inLoop = true;
            string temp = read.ReadToEnd();
            using (StreamWriter sr = new StreamWriter(@"C:\Users\David\Desktop\Money\OFXConvertTest.xml"))
            {
                sr.WriteLine("Type\tDate Posted\tTransaction Ammount\tName");
                while (inLoop == true)
                {
                    int sorter = temp.IndexOf("<STMTTRN>");
                    if (sorter > 0)
                    {
                        int a = temp.IndexOf("<TRNTYPE>") + 9;
                        temp = temp.Substring(a).Trim();
                        int pos_init1 = temp.IndexOf("<");
                        string tranType = temp.Substring(0, pos_init1);

                        int b = temp.IndexOf("<DTPOSTED>") + 10;
                        temp = temp.Substring(b).Trim();
                        int pos_init2 = temp.IndexOf("<");
                        string dtPosted = temp.Substring(0, pos_init2 - 6);

                        int c = temp.IndexOf("<TRNAMT>") + 8;
                        temp = temp.Substring(c).Trim();
                        int pos_init3 = temp.IndexOf("<");
                        string trAmount = temp.Substring(0, pos_init3);

                        int f = temp.IndexOf("<NAME>") + 6;
                        temp = temp.Substring(f).Trim();
                        int pos_init6 = temp.IndexOf("<");
                        string name = temp.Substring(0, pos_init6);
                        
                        sr.WriteLine($"{tranType}\t{dtPosted}\t{trAmount}\t\t\t{name}\n");
                    }
                    else
                    {
                        sr.Flush();
                        sr.Close();
                        inLoop = false;
                    }
                }
            }
        }
    }
}
