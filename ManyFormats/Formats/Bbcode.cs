using System;
using System.Collections.Generic;

namespace ManyFormats.Formats
{
    public class Bbcode : Format
    {
        private Dictionary<FontSize, int> headingSizeValues;

        public Bbcode()
        {
            headingSizeValues = new Dictionary<FontSize, int>()
            {
                [FontSize.Largest] = 6,
                [FontSize.Larger] = 5,
                [FontSize.Large] = 4,
                [FontSize.Medium] = 3,
                [FontSize.Small] = 2,
                [FontSize.Smallest] = 1,
            };
        }

        public override string Bold(string text)
        {
            return $"[b]{text}[/b]";
        }

        public override string Code(string text, CodeMode mode = CodeMode.Inline)
        {
            return $"[code]{text}[/code]";
        }

        public override string Colour(string text, string colour)
        {
            return $"[color]{colour}]{text}[/color]";
        }

        public override string Heading(string text, FontSize size = FontSize.Largest)
        {
            var sizeValue = headingSizeValues[size];
            return $"[size={sizeValue}]{text}[/size]";
        }

        public override string Image(string link, int height = -1, int width = -1, string align = "")
        {
            return $"[img]{link}[/img]";
        }

        public override string Italic(string text, ItalicMode mode = ItalicMode.Default)
        {
            return $"[i]{text}[/i]";
        }

        public override string Link(string text, string link)
        {
            return $"[url={link}]{text}[/url]";
        }

        public override string List(ListBullets bullet, int indent = 0, params string[] items)
        {
            var list = "[list";
            if (bullet == ListBullets.Number)
            {
                list += "=1";
            }
            list += "]" + Environment.NewLine;

            foreach (var item in items)
            {
                list += "[*] " + item + Environment.NewLine;
            }
            list += "[/list]";

            return list;
        }

        public override string Quote(string text)
        {
            return $"[quote]{text}[/quote]";
        }

        public override string Strikethrough(string text)
        {
            return $"[s]{text}[/s]";
        }

        public override string Subscript(string text)
        {
            throw new NotImplementedException("This implementation of BBCode does not support subscript");
        }

        public override string Superscript(string text)
        {
            throw new NotImplementedException("This implementation of BBCode does not support superscript");
        }

        public override string Task(string text, bool complete = false)
        {
            throw new NotImplementedException("This implementation of BBCode does not support tasks");
        }

        public override string Underline(string text)
        {
            return $"[u]{text}[/u]";
        }
    }
}
