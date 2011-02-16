using System;

namespace WowHeadParser.Parsers
{
    public class ParserNameAttribute : Attribute
    {
        public string Name { get; private set; }

        public ParserNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}