using System;
using System.Collections.Generic;

namespace ManyFormats.Formats
{
    public class Markdown : Format
    {

        private Dictionary<FontSize, string> fontSizePrefixes;
        private Dictionary<ListBullets, string> listBulletsPrefixes;

        public Markdown()
        {
            fontSizePrefixes = new Dictionary<FontSize, string>()
            {
                [FontSize.Largest] = "# ",
                [FontSize.Larger] = "## ",
                [FontSize.Large] = "## ",
                [FontSize.Medium] = "### ",
                [FontSize.Small] = "#### ",
                [FontSize.Smallest] = "##### ",
            };

            listBulletsPrefixes = new Dictionary<ListBullets, string>()
            {
                [ListBullets.Dash] = "- ",
                [ListBullets.Asterisk] = "* ",
                [ListBullets.Plus] = "+ ",
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

        public override string Colour(string text, string colour)
        {
            throw new NotImplementedException("This implementation of Markdown does not support colours");
        }

        public override string Heading(string text, FontSize size = FontSize.Largest)
        {
            return fontSizePrefixes[size] + text;
        }

        public override string Image(string link, int height = -1, int width = -1, string align = "")
        {
            return $"<img src=\"{link}\""
                + (height > -1 ? $" height=\"{height}\"" : "")
                + (width > -1 ? $" width=\"{width}\"" : "")
                + (!string.IsNullOrEmpty(align) ? $" align=\"{align}\"" : "")
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

        public override string List(ListBullets bullet, int indent = 0, params string[] items)
        {
            var list = string.Empty;
            var tabs = new string('\t', indent);
            for (int i = 1; i < items.Length; i++)
            {
                var itemText = items[i];
                list += tabs;
                if (bullet == ListBullets.Number)
                {
                    list += $"{i}. ";
                }
                else
                {
                    list += listBulletsPrefixes[bullet];
                }
                list += itemText;
                list += Environment.NewLine;
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

        public override string Underline(string text)
        {
            throw new NotImplementedException("This implementation of Markdown does not support underlining");
        }
    }
}
