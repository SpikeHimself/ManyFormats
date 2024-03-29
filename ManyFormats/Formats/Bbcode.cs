﻿using System.Collections.Generic;

namespace ManyFormats.Formats
{
    public class Bbcode : Format
    {
        private readonly Dictionary<HeadingSize, FontSize> headingToFontSizeMap;
        private readonly Dictionary<FontName, string> fontsToFontNameMap;

        public Bbcode() : this("BBCode") { }

        public Bbcode(string name) : base(name)
        {
            headingToFontSizeMap = new Dictionary<HeadingSize, FontSize>()
            {
                [HeadingSize.Largest] = FontSize.Six,
                [HeadingSize.Large] = FontSize.Five,
                [HeadingSize.Medium] = FontSize.Four,
                [HeadingSize.Small] = FontSize.Three,
                [HeadingSize.Smallest] = FontSize.Two,
            };

            fontsToFontNameMap = new Dictionary<FontName, string>()
            {
                [FontName.Arial] = "Arial",
                [FontName.ComicSansMs] = "Comic Sans MS",
                [FontName.CourierNew] = "Courier New",
                [FontName.Georgia] = "Georgia",
                [FontName.LucidaSansUnicode] = "Lucida Sans Unicode",
                [FontName.Tahoma] = "Tahoma",
                [FontName.TimesNewRoman] = "Times New Roman",
                [FontName.TrebuchetMs] = "Trebuchet MS",
                [FontName.Verdana] = "Verdana",
            };
        }

        public override string Size(string text, FontSize size = FontSize.Two)
        {
            return $"[size={(int)size}]{text}[/size]";
        }

        /// <summary>
        /// BBCode does not have a headings format, so we use Size() and Bold() to achieve a similar effect.
        /// </summary>
        /// <param name="text">The text to format</param>
        /// <param name="size">The HeadingSize to use to determine the size of the text</param>
        /// <returns>Bolded text of a FontSize similar to the given HeadingSize</returns>
        public override string Heading(string text, HeadingSize size = HeadingSize.Largest)
        {
            return Size(Bold(text), headingToFontSizeMap[size]);
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
            return $"[color={colour}]{text}[/color]";
        }

        public override string Image(string uri, int height = -1, int width = -1, Alignment align = Alignment.Unspecified)
        {
            return Align($"[img]{uri}[/img]", align);
        }

        public override string Italic(string text, ItalicMode mode = ItalicMode.Default)
        {
            return $"[i]{text}[/i]";
        }

        public override string Link(string text, string uri)
        {
            return $"[url={uri}]{text}[/url]";
        }

        public override string List(ListBullets bullet, int indent = 0, bool spacedItems = false, params string[] items)
        {
            var list = string.Empty;
            for (var i = 0; i <= indent; i++)
            {
                list += "[list";
                if (bullet == ListBullets.Number) list += "=1";
                list += "]";
                if (i == indent) list += Preferences.NewLine;
            }

            for (var i = 0; i < items.Length; i++)
            {
                if (spacedItems && i > 0) list += Preferences.NewLine;
                var item = items[i];
                list += "[*]" + item + Preferences.NewLine;
            }

            for (var i = 0; i <= indent; i++)
            {
                list += "[/list]";
            }

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

        public override string Underline(string text)
        {
            return $"[u]{text}[/u]";
        }

        public override string Font(string text, FontName font)
        {
            return $"[font={fontsToFontNameMap[font]}]{text}[/font]";
        }

        public string Font(string text, string fontName)
        {
            return $"[font={fontName}]{text}[/font]";
        }

        public override string Align(string text, Alignment align = Alignment.Unspecified)
        {
            if (align == Alignment.Unspecified)
            {
                return text;
            }

            var strAlign = AlignmentMap[align];
            return $"[{strAlign}]{text}[/{strAlign}]";
        }
    }
}
