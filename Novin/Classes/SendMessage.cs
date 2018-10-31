using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using rijndael;

namespace Novin.Classes
{
    public class Sendsms
    {
        public static void ToAdmin(string message , string phone)
        {
            var e = SmsStructure(phone);
            WebRequestpost(e.UrlAddress , e.Authentication + message);
        }
        public static void ToCustomer(string cusPassword , string cusPhone)
        {

        }
        public static Structure SmsStructure(string phone)
        {
            var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["novin"].ConnectionString);
            const string initVector = "F4568dgbdfgtt444";
            const string key = "rdf48JH4";
            var messageStructure= new Structure();
            var re = new RijndaelEnhanced(key, initVector);
            cnn.Open();
            var getSmsPanelData = new SqlCommand("SELECT [username],[password],[address]FROM [dbo].[sms]",cnn);
            var r = getSmsPanelData.ExecuteReader();
            if (r.Read())
            {
                messageStructure.Authentication = $"username={re.Decrypt(r["username"].ToString())}" +
                                                  $"&password={re.Decrypt(r["password"].ToString())}&to=+98{phone}&text=";
                messageStructure.UrlAddress= r["address"].ToString();
            }
            cnn.Close();
            return messageStructure;
        }
        public static string WebRequestpost(string url, string parameter)
        {
            var outStr = "";
            var buffer = Encoding.ASCII.GetBytes(parameter);
            var webReq = (HttpWebRequest)WebRequest.Create(url);
            webReq.Method = "POST";
            webReq.ContentType = "application/x-www-form-urlencoded";
            webReq.ContentLength = buffer.Length;
            var postData = webReq.GetRequestStream();
            postData.Write(buffer, 0, buffer.Length);
            postData.Close();
            var webResp = (HttpWebResponse)webReq.GetResponse();
            var answer = webResp.GetResponseStream();
            var answerr = new StreamReader(answer, Encoding.UTF8);
            if (outStr != "") { }
            outStr = answerr.ReadToEnd();
            return outStr;
        }
        public class Structure
        {
            public string Authentication { get; set; }
            public string UrlAddress { get; set; }
        }
    }
}