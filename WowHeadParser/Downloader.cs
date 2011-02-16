using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using WowHeadParser.Parsers;

namespace WowHeadParser
{
    public delegate void DownloaderProgressHandler(object sender, EventProgress e);

    public class Downloader : IDisposable
    {
        private List<Thread> m_thread;
        private PageParser m_parser;
        private Queue<KVP> m_queue;
        private List<RequestState> m_list;

        public event DownloaderProgressHandler OnProgressChanged;

        public string Locale  { get; set; }
        public int Delay      { get; set; }
        public int MaxThreads { get; set; }

        public Downloader(PageParser parser, Queue<KVP> queue)
        {
            this.m_parser   = parser;
            this.m_queue    = queue;
            this.m_list     = new List<RequestState>();
            this.m_thread   = new List<Thread>();
        }

        public void StartAsunc()
        {
            if (OnProgressChanged != null)
                OnProgressChanged(this, new EventProgress(ProgressState.Start));

            Console.WriteLine("Started parse in {0}", m_parser.Url);

            int total = this.m_queue.Count;
            int current = 0;
            while (this.m_queue.Count > 0)
            {
                if (this.m_list.Count < this.MaxThreads)
                {
                    KVP entry     = this.m_queue.Dequeue();

                    string prefix = string.IsNullOrWhiteSpace(this.Locale) ? "www." : this.Locale;
                    string url    = prefix + this.m_parser.Url + entry.Key;

                    RequestState state = new RequestState(url, entry);
                    state.OnDispose += new EventHandler(state_OnDispose);

                    this.m_list.Add(state);

                    state.Request.BeginGetResponse(new AsyncCallback(RespCallback), state);
                    OnProgressChanged(this, new EventProgress(total, ++current, m_list.Count, url));
                }
                Thread.Sleep(Delay);
            }

            OnProgressChanged(this, new EventProgress(ProgressState.Complete));
        }

        private KVP Dequeue()
        {
            lock (this.m_queue)
            {
                return this.m_queue.Dequeue();
            }
        }

        private void state_OnDispose(object sender, EventArgs e)
        {
            var item = (sender as RequestState);
            if (this.m_list != null && this.m_queue != null)
            {
                if (this.m_list.Contains(item))
                {
                    this.m_list.Remove(item);
                }

                if (this.m_list.Count == 0 && this.m_queue.Count == 0)
                {
                    this.m_parser.Dispose();
                }
            }
        }

        private void RespCallback(IAsyncResult iar)
        {
            RequestState state = (RequestState)iar.AsyncState;
            try
            {
                state.Response   = (HttpWebResponse)state.Request.EndGetResponse(iar);
                m_parser.Content = state.GetContent();
                m_parser.Parse(state.Entry);
                Console.WriteLine("Complete: " + state.Entry.Key);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                state.Dispose();
            }
        }

        ~Downloader()
        {
            Dispose();
        }

        public void Dispose()
        {
            m_parser.Dispose();
            Console.WriteLine("Done");
        }
    }
}
