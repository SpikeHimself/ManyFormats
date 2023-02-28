namespace ManyFormats
{
    public class Preferences
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

        public LineEndingOptions LineEnding { get; set; }
        public NotImplementedHandlingOptions NotImplementedHandling { get; set; }

        public static Preferences DefaultPreferences = new Preferences();

        public Preferences()
        {
            LineEnding = LineEndingOptions.Automatic;
            NotImplementedHandling = NotImplementedHandlingOptions.ThrowException;
        }

    }
}
