using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using WowHeadParser.Parsers;
using System.Reflection;

namespace WowHeadParser
{
    public partial class FrmMain : Form
    {
        private Queue<KVP>  m_queue;
        private Type        m_parser;
        private List<Type>  m_loader;
        private Thread      m_thread;
        private Downloader  downloader;

        public FrmMain()
        {
            InitializeComponent();

            RichTextBoxWriter.Instance.OutputBox = this.rtbConsole;
            m_queue = new Queue<KVP>();

            Console.WriteLine("Starting WowHead Parser...");

            m_loader = new List<Type>();

            foreach (Type type in Assembly.GetAssembly(typeof(PageParser)).GetTypes())
            {
                if (type.IsSubclassOf(typeof(PageParser)))
                {
                    m_loader.Add(type);
                    cbParser.Items.Add(type.Name);
                    Console.WriteLine("  >> {0}", type.Name);
                }
            }
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbParser.SelectedIndex == -1)
                    throw new Exception("Parser do not selected!");

                if (m_queue.Count == 0)
                    throw new Exception("Queue is empty!");

                if (m_thread != null)
                    throw new Exception("Alredy runung...");

                ConstructorInfo cInfo = m_parser.GetConstructor(new Type[] { typeof(uint)    });
                PageParser parser = (PageParser)cInfo.Invoke(new object[]  { GetSubparsers() });

                this.downloader = new Downloader(parser, m_queue);
                this.downloader.OnProgressChanged += new DownloaderProgressHandler(downloader_OnProgressChanged);

                this.downloader.Locale     = cbLocale.Text.Trim();
                this.downloader.Delay      = (int)nudDelay.Value;
                this.downloader.MaxThreads = (int)nudThreads.Value;

                this.m_thread = new Thread(this.downloader.StartAsunc);
                this.m_thread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void downloader_OnProgressChanged(object sender, EventProgress e)
        {
            Action f = () =>
            {
                if (e.State == ProgressState.Start)
                {
                    progressBar1.Visible = true;
                    progressBar1.Value = 0;
                    labelProgress.Visible = true;
                    labelProgress.Text = string.Empty;
                }
                else if (e.State == ProgressState.Complete)
                {
                    progressBar1.Visible = false;
                    labelProgress.Visible = false;
                }
                else
                {
                    if (e.Percent >= 0 && e.Percent <= 100)
                        progressBar1.Value = e.Percent;
                    labelProgress.Text = e.ToString();
                }
            };

            if (progressBar1.InvokeRequired)
                progressBar1.BeginInvoke(f);
            else
                f();
        }

        private void cbParser_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbSubParsers.Items.Clear();

            if (cbParser.SelectedIndex > -1)
            {
                m_parser = m_loader[cbParser.SelectedIndex];

                var subparsers = m_parser.GetNestedType("SubParsers");
                if (subparsers != null)
                {
                    int index = 0;
                    foreach (var sub in Enum.GetValues(subparsers))
                    {
                        clbSubParsers.Items.Add(sub.ToString());
                        clbSubParsers.SetItemChecked(index++, true);
                    }
                }
            }
        }

        private uint GetSubparsers()
        {
            uint subParsers = 0;
            for (int i = 0; i < clbSubParsers.Items.Count; ++i)
            {
                if (clbSubParsers.GetItemChecked(i))
                {
                    subParsers += (uint)1 << i;
                }
            }

            return subParsers; 
        }

        private void bShowOpenFileDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = tbListEntrys.Text;
            dialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbListEntrys.Text = dialog.FileName;
                if (File.Exists(dialog.FileName))
                {
                    /*
                     * list.txt:
                     *      Key Val; Key Val;
                     *      Key - entry of parsed element
                     *      Val - additional parametr
                     * 
                     * exchample:
                     *      123 12; 456 2;
                     */
                    m_queue.Clear();
                    foreach (string entry in File
                        .ReadAllText(dialog.FileName)
                        .Split(new [] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        m_queue.Enqueue(new KVP(entry));
                    }
                    Console.WriteLine("Loading {0} elements", m_queue.Count);
                }
            }
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            if (downloader != null)
            {
                downloader.Dispose();
            }
            if (m_thread != null)
            {
                m_thread.Abort();
                m_thread = null;
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            bStop_Click(null, null);
        }

        private void nudThreads_ValueChanged(object sender, EventArgs e)
        {
            if (this.downloader != null)
                this.downloader.MaxThreads = (int)nudThreads.Value;
        }

        private void nudDelay_ValueChanged(object sender, EventArgs e)
        {
            if (this.downloader != null)
                this.downloader.Delay = (int)nudDelay.Value;
        }
    }
}