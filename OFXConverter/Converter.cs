using System;
//using System.Data;
//using System.Configuration;
using System.Linq;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Runtime;

namespace FinancerData
{
    public static class ImportOfx
    {
        public static XElement ToXElement(string pathToOfxFile)
        {
            if (!System.IO.File.Exists(pathToOfxFile))
            {
                throw new FileNotFoundException();
            }

            //use LINQ TO GET ONLY THE LINES THAT WE WANT
            var tags = from line in File.ReadAllLines(pathToOfxFile)
                       where line.Contains("<STMTTRN>") ||
                       line.Contains("<TRNTYPE>") ||
                       line.Contains("<DTPOSTED>") ||
                       line.Contains("<TRNAMT>") ||
                       line.Contains("<FITID>") ||
                       line.Contains("<CHECKNUM>") ||
                       line.Contains("<MEMO>")
                       select line;


            XElement el = new XElement("root");
            XElement son = null;
            //StreamWriter sr= new StreamWriter(@"C:\Users\David\Desktop\Money\OFXConvertTest.xml");
            foreach (var l in tags)
            {
                if (l.IndexOf("<STMTTRN>") == -1)
                {
                    son = new XElement("STMTTRN");
                    el.Add(son);
                    continue;
                }

                var tuple = new Tuple<string,string>[](getTagName(l));
                var elSon = new XElement(tuple.Item1);
                elSon.Value = getTagValue(1);
                son.Add(elSon);
            }
            using (StreamWriter sr = new StreamWriter(@"C:\Users\David\Desktop\Money\OFXConvertTest.xml"))
            {
                sr.WriteLine(el.ToString());
                sr.Flush();
                sr.Close();
            }
            return el;

        }
        /// <summary>
        /// Get the Tag name to create an Xelement
        /// </summary>
        /// <param name="line">One line from the file</param>
        /// <returns></returns>
        private static Tuple<string, string>[] getTagName(string line)
        {
            bool column = true;
            while (column == true)
            {
                int pos_init =  1;
                int pos_end = line.IndexOf(">");
                pos_end = pos_end - pos_init;
                if (line.Substring(pos_init, pos_end) == "STMTTRN" || line.Substring(pos_init, pos_end) == "TRNTYPE" || line.Substring(pos_init, pos_end) == "DTPOSTED" ||
                    line.Substring(pos_init, pos_end) == "TRNAMT" || line.Substring(pos_init, pos_end) == "FITID" || line.Substring(pos_init, pos_end) == "CHECKNUM" ||
                    line.Substring(pos_init, pos_end) == "MEMO")
                {
                    return new Tuple<string,string>(line.Substring(pos_init, pos_end), line.Replace(line.Substring((pos_init - 1), (pos_end + 2)), ""));
                }
                else
                {
                    line = line.Replace(line.Substring((pos_init - 1), (pos_end + 2)), "");
                }
            }return new Tuple<string,string>("the","end");
            
        }
        /// <summary>
        /// Get the value of the tag to put on the Xelement
        /// </summary>
        /// <param name="line">The line</param>
        /// <returns></returns>
        private static string getTagValue(string line)
        {
            int pos_init = line.IndexOf(">") + 1;
            string retValue = line.Substring(pos_init).Trim();
            if (retValue.IndexOf("[") != -1)
            {
                //date--lets get only the 8 date digits
                retValue = retValue.Substring(0, 8);
            }
            return retValue;
        }
    }
}
