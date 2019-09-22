using System;

namespace OFXConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string webSite = new string("c://Users/David/Desktop/Money/usaa_money.ofx");
            FinancerData.ImportOfx.ToXElement(webSite);
        }
    }
}
