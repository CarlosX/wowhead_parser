using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WowHeadParser.Parsers
{
    public class QuestParser : PageParser
    {
        public enum SubParsers : uint
        {
            RequestItemsText = 0x0001,
            OfferRewardText = 0x0002,
            Unk2 = 0x0004,
        }

        public QuestParser(uint flag)
            : base("quest_statement.sql", flag)
        {
            this.Url = @"wowhead.com/quest=";
        }

        public override void Parse(KVP entry)
        {
            if (   (Flag & (uint)SubParsers.RequestItemsText) != 0 
                || (Flag & (uint)SubParsers.OfferRewardText)  != 0)
                ParseQuestTexts(entry);
        }

        private void ParseQuestTexts(KVP entry)
        {
            Regex reg = new Regex(
                           @"<div id=""lknlksndgg-(?<type>\w+)"" style=""display: none"">(?<text>.+)\n",
                           RegexOptions.Multiline);

            MatchCollection matches = reg.Matches(Content);

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                var type = groups["type"].Value ?? string.Empty;
                var text = groups["text"].Value ?? string.Empty;

                switch (type.ToLower())
                {
                    case "progress":
                        if ((Flag & (uint)SubParsers.RequestItemsText) != 0)
                            WriteLine("UPDATE `quest_template` SET `RequestItemsText` = '{0}' WHERE `entry` = {1};",
                                text.HTMLEscapeSumbols(), entry.Key);
                        break;
                    case "completion":
                        if ((Flag & (uint)SubParsers.OfferRewardText) != 0)
                            WriteLine("UPDATE `quest_template` SET `OfferRewardText` = '{0}' WHERE `entry` = {1};",
                                text.HTMLEscapeSumbols(), entry.Key);
                        break;
                }
            }
        }
    }
}
