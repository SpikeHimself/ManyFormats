using System;

namespace ManyFormats
{
    public class FormatPreferences
    {
        public enum LineEndingOptions
        {
            Automatic,
            Mac,
            Unix,
            Windows,
        }

        public enum NotImplementedHandlingOptions
        {
            ThrowException,
            ReturnInput,
            Skip
        }
        
        public static FormatPreferences DefaultPreferences = new FormatPreferences();

        public LineEndingOptions LineEnding { get; set; }

        public NotImplementedHandlingOptions NotImplementedHandling { get; set; }

        public string NewLine
        {
            get
            {
                switch (LineEnding)
                {
                    default:
                    case FormatPreferences.LineEndingOptions.Automatic:
                        return Environment.NewLine;
                    case FormatPreferences.LineEndingOptions.Mac:
                        return "\r";
                    case FormatPreferences.LineEndingOptions.Unix:
                        return "\n";
                    case FormatPreferences.LineEndingOptions.Windows:
                        return "\r\n";
                }
            }
        }

        public FormatPreferences()
        {
            LineEnding = LineEndingOptions.Automatic;
            NotImplementedHandling = NotImplementedHandlingOptions.ThrowException;
        }
    }
}
