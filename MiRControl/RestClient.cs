using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web;

namespace MiRControl
{
    public class RestClient
    {
        public string GET(string url,string svcCredentials)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Timeout = 5000;
            myRequest.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}",svcCredentials);
            string ReturnXml = null;
            try
            {
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                ReturnXml = reader.ReadToEnd();

                var rsp = myRequest.GetResponse() as HttpWebResponse;
                var httpStatusCode = (int)rsp.StatusCode;

                reader.Close();
                myResponse.Close();
            }
            catch(WebException ex)
            {
                Console.WriteLine("Error occured when trying to create a response"+ex.Message);
            }
            return ReturnXml;
        }
        public string GET(string url)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Timeout = 5000;
            //myRequest.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", svcCredentials);
            string ReturnXml = null;
            try
            {
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                ReturnXml = reader.ReadToEnd();

                var rsp = myRequest.GetResponse() as HttpWebResponse;
                var httpStatusCode = (int)rsp.StatusCode;

                reader.Close();
                myResponse.Close();
            }
            catch (WebException ex)
            {
                Console.WriteLine("Error occured when trying to create a response" + ex.Message);
            }
            return ReturnXml;
        }

        public string POST(string body, string url, string svcCredentials)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Timeout = 5000;
            byte[] buf = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(body);

            myRequest.Method = "POST";
            myRequest.ContentLength = buf.Length;
            myRequest.ContentType = "application/json";
            myRequest.AllowAutoRedirect = true;
            myRequest.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", svcCredentials);

            Stream newStream = myRequest.GetRequestStream();
            newStream.Write(buf, 0, buf.Length);
            newStream.Close();
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string ReturnXml = reader.ReadToEnd();

            reader.Close();
            myResponse.Close();
            return ReturnXml;
        }
    }
}
