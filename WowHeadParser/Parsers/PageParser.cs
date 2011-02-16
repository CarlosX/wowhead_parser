using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace WowHeadParser.Parsers
{
    public abstract class PageParser : IDisposable
    {
        private StreamWriter writer;
        private object m_synckObj = new object();
        private string m_url;

        public PageParser(string fileName, uint flag)
        {
            this.Flag = flag;
            this.writer = new StreamWriter(fileName, false, Encoding.UTF8);
            this.writer.AutoFlush = true;
        }

        protected void Write(object content)
        {
            lock (this.m_synckObj)
            {
                this.writer.Write(string.Format(CultureInfo.InvariantCulture, content.ToString()));
                this.writer.Flush();
            }
        }

        protected void Write(string format, params object[] args)
        {
            lock (this.m_synckObj)
            {
                this.writer.Write(string.Format(CultureInfo.InvariantCulture, format, args));
                this.writer.Flush();
            }
        }

        protected void WriteLine(object content)
        {
            lock (this.m_synckObj)
            {
                this.writer.WriteLine(content);
                this.writer.Flush();
            }
        }

        protected void WriteLine(string format, params object[] args)
        {
            lock (this.m_synckObj)
            {
                this.writer.WriteLine(string.Format(CultureInfo.InvariantCulture, format, args));
                this.writer.Flush();
            }
        }

        public void Dispose()
        {
            if (this.writer != null)
            {
                lock (this.m_synckObj)
                { 
                    this.writer.Close();
                }
            } 
            this.writer = null;
        }

        public abstract void Parse(KVP entry);

        public string Url 
        {
            get { return m_url; }
            set { this.m_url = "http://www." + value; }
        }

        public uint Flag { get; private set; }

        public string Content { get; set; }
    }
}
