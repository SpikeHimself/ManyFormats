﻿namespace ManyFormats
{
    public enum HeadingSize
    {
        Largest,
        Large,
        Medium,
        Small,
        Smallest,
    }

    public enum FontSize : int
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
    }

    public enum FontName
    {
        Arial,
        ComicSansMs,
        CourierNew,
        Georgia,
        LucidaSansUnicode,
        Tahoma,
        TimesNewRoman,
        TrebuchetMs,
        Verdana,
    }

    public enum ItalicMode
    {
        Default,
        Nested,
    }

    public enum CodeMode
    {
        Inline,
        Block,
    }

    public enum ListBullets
    {
        Dash,
        Asterisk,
        Plus,
        Number,
    }

    public enum Alignment
    {
        Unspecified,
        Left,
        Centre,
        Right,
    }
}
