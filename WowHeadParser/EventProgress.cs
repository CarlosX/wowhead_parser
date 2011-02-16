using System;
using System.Globalization;

namespace WowHeadParser
{
    public class EventProgress : EventArgs
    {
        public int Total            { get; private set; }
        public int Current          { get; private set; }
        public int Percent          { get; private set; }
        public int Threads          { get; private set; }
        public string Message       { get; private set; }
        public ProgressState State  { get; private set; }

        public EventProgress(ProgressState state)
        {
            this.State   = state;
            this.Total   = 0;
            this.Current = 0;
            this.Percent = 0;
            this.Message = string.Empty;
        }

        public EventProgress(int total, int current, int threads, string text)
        {
            this.State   = ProgressState.Runing;
            this.Total   = total;
            this.Current = current;
            this.Percent = (int)((float)current / (float)total * 100f) % 100;
            this.Threads = threads;
            this.Message = text;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture,
                "Active threads: {0}; Progress: {1} / {2} ({3}%) {4}",
                this.Threads, this.Current, this.Total, this.Percent, this.Message);
        }
    }

    public enum ProgressState
    {
        Start,
        Runing,
        Complete,
    }
}
