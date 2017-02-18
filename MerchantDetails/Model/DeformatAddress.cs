using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchantDetails
{
    public class DeformatAddress
    {

        public static void Process(String inputAddress, out String Address, out String SubDivision,
                                        out string City, out String Zip, out String State, out string Country)
        {
            Address = ""; SubDivision = ""; City = ""; Zip = ""; State = ""; Country = "";
            String[] tAddressParts = inputAddress.Split(',');

            Country = tAddressParts[(tAddressParts.Length - 1)];
            String[] tStateParts = tAddressParts[(tAddressParts.Length - 2)].Split(' ');
            Zip = tStateParts[tStateParts.Length - 1];
            State = tAddressParts[(tAddressParts.Length - 2)].Substring(0, (tAddressParts[(tAddressParts.Length - 2)].Length - Zip.Length));
            City = tAddressParts[(tAddressParts.Length - 3)];
            SubDivision = tAddressParts[(tAddressParts.Length - 4)];
            for (int i = 0; i < tAddressParts.Length - 5; i++)
                Address += tAddressParts[i];

            return;

        }
    }
}