using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace WowHeadParser
{
    public class RequestState : IDisposable
    {
        public event EventHandler OnDispose;

        public HttpWebRequest  Request  { get; private set; }
        public HttpWebResponse Response { get; set; }
        public KVP Entry                { get; private set; }

        public string GetContent()
        {
            if (Response == null)
                throw new ArgumentNullException("Reasponse");

            return new StreamReader(this.Response.GetResponseStream()).ReadToEnd(); 
        }

        public RequestState(string url, KVP entry)
        {
            this.Request = (HttpWebRequest)WebRequest.Create(url);
            this.Request.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/534.6 (KHTML, like Gecko) Chrome/7.0.503.0 Safari/534.6";
            this.Request.Method    = "POST";
            this.Entry             = entry;
            Console.WriteLine("Create request: " + url);
        }

        ~RequestState()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (OnDispose != null)
            {
                OnDispose(this, new EventArgs());
            }
        }
    }
}