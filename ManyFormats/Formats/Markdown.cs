using System;
using System.Collections.Generic;

namespace ManyFormats.Formats
{
    public class Markdown : Format
    {
        private readonly Dictionary<HeadingSize, string> headingSizePrefixes;
        private readonly Dictionary<ListBullets, string> listBulletsPrefixes;
        private readonly Dictionary<Alignment, string> alignmentMap;

        public Markdown() : this("Markdown") { }

        public Markdown(string name) : base(name)
        {
            headingSizePrefixes = new Dictionary<HeadingSize, string>()
            {
                [HeadingSize.Largest] = "# ",
                [HeadingSize.Large] = "## ",
                [HeadingSize.Medium] = "### ",
                [HeadingSize.Small] = "#### ",
                [HeadingSize.Smallest] = "##### ",
            };

            listBulletsPrefixes = new Dictionary<ListBullets, string>()
            {
                [ListBullets.Dash] = "- ",
                [ListBullets.Asterisk] = "* ",
                [ListBullets.Plus] = "+ ",
            };

            alignmentMap = new Dictionary<Alignment, string>()
            {
                [Alignment.Left] = "left",
                [Alignment.Centre] = "center",
                [Alignment.Right] = "right",
            };
        }

        public override string Bold(string text)
        {
            return $"**{text}**";
        }

        public override string Code(string text, CodeMode mode = CodeMode.Inline)
        {
            switch (mode)
            {
                case CodeMode.Block:
                    return $"```{Environment.NewLine}{text}{Environment.NewLine}```";

                default:
                case CodeMode.Inline:
                    return $"`{text}`";
            }
        }

        public override string Heading(string text, HeadingSize size = HeadingSize.Largest)
        {
            return headingSizePrefixes[size] + text;
        }

        public override string Image(string link, int height = -1, int width = -1, Alignment align = Alignment.Left)
        {
            var strAlign = alignmentMap[align];
            return $"<img src=\"{link}\""
                + (height > -1 ? $" height=\"{height}\"" : "")
                + (width > -1 ? $" width=\"{width}\"" : "")
                + $" align=\"{strAlign}\""
                + $" />";
        }

        public override string Italic(string text, ItalicMode mode = ItalicMode.Default)
        {
            switch (mode)
            {
                default:
                case ItalicMode.Default:
                    return $"*{text}*";

                case ItalicMode.Nested:
                    return $"_{text}_";
            }
        }

        public override string Link(string text, string link)
        {
            return $"[{text}]({link})";
        }

        public override string List(ListBullets bullet, int indent = 0, bool spacedItems = false, params string[] items)
        {
            var list = string.Empty;
            var tabs = new string('\t', indent);
            for (int i = 0; i < items.Length; i++)
            {
                if (spacedItems && i > 0) list += Preferences.NewLine;
                var itemText = items[i];
                list += tabs;
                if (bullet == ListBullets.Number)
                {
                    list += $"{i + 1}. ";
                }
                else
                {
                    list += listBulletsPrefixes[bullet];
                }
                list += itemText;
                list += Preferences.NewLine;
            }
            return list;
        }

        public override string Quote(string text)
        {
            return $"> {text}";
        }

        public override string Strikethrough(string text)
        {
            return $"~~{text}~~";
        }

        public override string Subscript(string text)
        {
            return $"<sub>{text}</sub>";
        }

        public override string Superscript(string text)
        {
            return $"<sup>{text}</sup>";
        }

        public override string Task(string text, bool complete = false)
        {
            return $"[{(complete ? "x" : " ")}] {text}";
        }

        public override string Align(string text, Alignment align)
        {
            var strAlign = alignmentMap[align];
            return $"<p align=\"{strAlign}\">{text}</p>";
        }
    }
}
