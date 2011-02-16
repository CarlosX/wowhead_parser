using System;
using System.Text.RegularExpressions;

namespace WowHeadParser.Parsers
{
    [ParserName("Page Text")]
    public class PageTextParser : PageParser
    {
        public enum SubParsers : uint
        {
            Default
        }

        public PageTextParser(uint flag)
            : base("page_text.sql", flag) 
        {
            this.Url = @"wowhead.com/object=";
        }

        public override void Parse(KVP entry)
        {
            Regex reg = new Regex(@"new Book\({ parent: '.+', pages: \['(?<test>.+)'\]}\)", RegexOptions.Multiline); 
            MatchCollection matches = reg.Matches(Content);

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                var typeStr = groups["test"].Value ?? string.Empty;
                var pages   = typeStr.Split(new[] { @"','" }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < pages.Length; ++i)
                {
                    WriteLine(@"INSERT IGNORE INTO `page_text` VALUES ({0}, '{1}', {2});",
                        entry.Val + i,
                        pages[i].HTMLEscapeSumbols(),
                        i < pages.Length - 1 ? entry.Val + i + 1 : 0);
                }
            }
        }
    }
}
