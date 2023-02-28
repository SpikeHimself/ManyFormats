using System;

namespace ManyFormats
{

    public abstract class Format
    {
        protected Preferences Preferences { get; }

        public Format()
        {
            Preferences = Preferences.DefaultPreferences;
        }

        protected string NewLine()
        {
            switch (Preferences.LineEnding)
            {
                default:
                case Preferences.LineEndingOptions.Automatic:
                    return Environment.NewLine;
                case Preferences.LineEndingOptions.Mac:
                    return "\r";
                case Preferences.LineEndingOptions.Unix:
                    return "\n";
                case Preferences.LineEndingOptions.Windows:
                    return "\r\n";
            }
        }

        protected string NotImplemented(string input, string notImplementedMessage)
        {
            switch (Preferences.NotImplementedHandling)
            {
                default:
                case Preferences.NotImplementedHandlingOptions.ThrowException:
                    throw new NotImplementedException(notImplementedMessage);
                case Preferences.NotImplementedHandlingOptions.ReturnInput:
                    return input;
                case Preferences.NotImplementedHandlingOptions.Skip:
                    return string.Empty;
            }
        }

        private string CreateNotImplementedMessage(string name)
        {
            return "This implementation does not support " + name;
        }

        public virtual string Heading(string text, FontSize size = FontSize.Largest)
        {
            return NotImplemented(text, CreateNotImplementedMessage("Heading"));
        }

        public string Size(string text, FontSize size = FontSize.Largest)
        {
            return Heading(text, size);
        }

        public virtual string Bold(string text)
        {
            return NotImplemented(text, CreateNotImplementedMessage("Bold"));
        }

        public virtual string Italic(string text, ItalicMode mode = ItalicMode.Default)
        {
            return NotImplemented(text, CreateNotImplementedMessage("Italic"));
        }

        public virtual string Underline(string text)
        {
            return NotImplemented(text, CreateNotImplementedMessage("Underline"));
        }

        public virtual string Strikethrough(string text)
        {
            return NotImplemented(text, CreateNotImplementedMessage("Strikethrough"));
        }

        public virtual string Colour(string text, string colour)
        {
            return NotImplemented(text, CreateNotImplementedMessage("Colour"));
        }

        public virtual string Subscript(string text)
        {
            return NotImplemented(text, CreateNotImplementedMessage("Subscript"));
        }

        public virtual string Superscript(string text)
        {
            return NotImplemented(text, CreateNotImplementedMessage("Superscript"));
        }

        public virtual string Quote(string text)
        {
            return NotImplemented(text, CreateNotImplementedMessage("Quote"));
        }

        public virtual string Code(string text, CodeMode mode = CodeMode.Inline)
        {
            return NotImplemented(text, CreateNotImplementedMessage("Code"));
        }

        public virtual string Link(string text, string link)
        {
            return NotImplemented(text, CreateNotImplementedMessage("Link"));
        }

        public virtual string Image(string link, int height = -1, int width = -1, string align = "")
        {
            return NotImplemented(link, CreateNotImplementedMessage("Image"));
        }

        public virtual string List(ListBullets bullet, int indent = 0, params string[] items)
        {
            return NotImplemented(string.Join(", ", items), CreateNotImplementedMessage("List"));
        }

        public virtual string Task(string text, bool complete = false)
        {
            return NotImplemented(text, CreateNotImplementedMessage("Task"));
        }
    }
}
