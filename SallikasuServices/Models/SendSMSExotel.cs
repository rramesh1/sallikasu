using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace SallikasuServices.Models
{
 
    public class SendSMSExotel
    {
        private string SID = null;
        private string token = null;

        public SendSMSExotel(string SID, string token)
        {
            this.SID = SID;
            this.token = token;
        }

        public string execute(string from, string to, string Body)
        {
            Dictionary<string, string> postValues = new Dictionary<string, string>();
            postValues.Add("From", from);
            postValues.Add("To", to);
            postValues.Add("Body", Body);

            String postString = "";

            foreach (KeyValuePair<string, string> postValue in postValues)
            {
                postString += postValue.Key + "=" + HttpUtility.UrlEncode(postValue.Value) + "&";
            }
            postString = postString.TrimEnd('&');
            /*
            * Allow self signed certificates and such
            */
            ServicePointManager.ServerCertificateValidationCallback = delegate {
                return true;
            };
            string smsURL = "https://twilix.exotel.in/v1/Accounts/<Your Exotel Sid>/Sms/send";
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(smsURL);
            objRequest.Credentials = new NetworkCredential(this.SID, this.token);
            objRequest.Method = "POST";
            objRequest.ContentLength = postString.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";
            // post data is sent as a stream                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
            StreamWriter opWriter = null;
            opWriter = new StreamWriter(objRequest.GetRequestStream());
            opWriter.Write(postString);
            opWriter.Close();

            // returned values are returned as a stream, then read into a string                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            string postResponse = null;
            using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
            {
                postResponse = responseStream.ReadToEnd();
                responseStream.Close();
            }

            return (postResponse);
        }

        public static void Main(string[] args)
        {
            //SendSMS s = new SendSMS ("YourExotelSID", "YourExotelToken");
            //string response = s.execute ("Your Exotel VN", "Customer's Phone no", "Message to send");
            //Console.WriteLine (response);
        }
    }
    
}