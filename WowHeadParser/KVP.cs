using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowHeadParser
{
    public class KVP
    {
        public uint Key { get; private set; }
        public uint Val { get; private set; }

        public KVP(uint key, uint val)
        {
            this.Key = key;
            this.Val = val;
        }

        public KVP(string src)
        {
            string[] arr = src.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            uint k = 0, v = 0;

            if (arr.Length > 0)
                uint.TryParse(arr[0], out k);

            if (arr.Length > 1)
                uint.TryParse(arr[1], out v);
            
            this.Key = k;
            this.Val = v;
        }
    }
}
