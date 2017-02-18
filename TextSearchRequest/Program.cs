using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TextSearchRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            if ( args.Length < 2)
            {
                System.Console.WriteLine("Usage: TextSearchRequest.exe -l Locality -c City -p PostalCode ");
                return;
            }
            string tLocality = "";
            String tCity = "";
            String tPostalCode = "";
            string arg="";
            
            for ( int i=0; i < args.Length; i++)
            {
                switch(args[i].ToUpper())
                {
                    case "-L":
                        tLocality = args[++i].ToUpper();
                        break;
                    case "-C":
                        tCity = args[++i].ToUpper();
                        break;
                    case "-P":
                        tPostalCode = args[++i].ToUpper();
                        break;
                    default:
                        System.Console.WriteLine("Usage: TextSearchRequest.exe -l Locality -c City -p PostalCode ");
                        return;
                }
            }
            if ( tCity.Length == 0)
            {
                System.Console.WriteLine("Usage: TextSearchRequest.exe -l Locality -c City -p PostalCode ");
                return;
            }
            if ( tLocality.Length == 0 && tPostalCode.Length == 0)
            {
                System.Console.WriteLine("Usage: TextSearchRequest.exe -l Locality -c City -p PostalCode ");
                return;
            }
            TextSearchController tcontroller = new TextSearchController();

            tcontroller.process(tLocality, tCity, tPostalCode);
        }
    }
}
