using System;

namespace OFXConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string webSite = new string("c://Users/David/Desktop/Money/usaa_money.ofx");
            OFXConverter.TryAgainConverter.DataPrinting(webSite);

            // I created this "converter" to pull certain data fields from a .OFX file for my school project
            // It will work for you as well, but you have to identify the tags in the file to flag and edit the TryAgainConverter class
        }
    }
}