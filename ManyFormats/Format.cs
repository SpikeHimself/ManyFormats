using System;
using System.Collections.Generic;

namespace ManyFormats
{
    public abstract class Format
    {
        public virtual string Name { get; set; }
        public FormatPreferences Preferences { get; set; }

        protected readonly Dictionary<Alignment, string> AlignmentMap;

        protected Format(string name, FormatPreferences prefs)
        {
            AlignmentMap = new Dictionary<Alignment, string>()
            {
                [Alignment.Unspecified] = string.Empty,
                [Alignment.Left] = "left",
                [Alignment.Centre] = "center",
                [Alignment.Right] = "right",
            };

            Name = name;
            Preferences = prefs;
        }

        protected Format(string name) : this(name, FormatPreferences.DefaultPreferences)
        {
        }

        protected string NotImplemented(string input, string func)
        {
            switch (Preferences.NotImplementedHandling)
            {
                default:
                case FormatPreferences.NotImplementedHandlingOptions.ThrowException:
                    throw new NotImplementedException($"This implementation of `{Name}` does not support `{func}`");
                case FormatPreferences.NotImplementedHandlingOptions.ReturnInput:
                    return input;
                case FormatPreferences.NotImplementedHandlingOptions.Skip:
                    return string.Empty;
            }
        }

        public virtual string Heading(string text, HeadingSize size = HeadingSize.Largest)
        {
            return NotImplemented(text, nameof(Heading));
        }

        public virtual string Size(string text, FontSize size = FontSize.Two)
        {
            return NotImplemented(text, nameof(Size));
        }

        public virtual string Bold(string text)
        {
            return NotImplemented(text, nameof(Bold));
        }

        public virtual string Italic(string text, ItalicMode mode = ItalicMode.Default)
        {
            return NotImplemented(text, nameof(Italic));
        }

        public virtual string Underline(string text)
        {
            return NotImplemented(text, nameof(Underline));
        }

        public virtual string Strikethrough(string text)
        {
            return NotImplemented(text, nameof(Strikethrough));
        }

        public virtual string Colour(string text, string colour)
        {
            return NotImplemented(text, nameof(Colour));
        }

        public virtual string Subscript(string text)
        {
            return NotImplemented(text, nameof(Subscript));
        }

        public virtual string Superscript(string text)
        {
            return NotImplemented(text, nameof(Superscript));
        }

        public virtual string Quote(string text)
        {
            return NotImplemented(text, nameof(Quote));
        }

        public virtual string Code(string text, CodeMode mode = CodeMode.Inline)
        {
            return NotImplemented(text, nameof(Code));
        }

        public virtual string Link(string text, string uri)
        {
            return NotImplemented(text, nameof(Link));
        }

        public virtual string Image(string uri, int height = -1, int width = -1, Alignment align = Alignment.Left)
        {
            return NotImplemented(uri, nameof(Image));
        }

        public virtual string List(ListBullets bullet, int indent = 0, bool spacedItems = false, params string[] items)
        {
            return NotImplemented(string.Join(", ", items), nameof(List));
        }

        public virtual string Task(string text, bool complete = false)
        {
            return NotImplemented(text, nameof(Task));
        }

        public virtual string Font(string text, FontName font)
        {
            return NotImplemented(text, nameof(Font));
        }

        public virtual string Align(string text, Alignment align = Alignment.Unspecified)
        {
            return NotImplemented(text, nameof(Align));
        }
    }
}
