using System;


namespace YTText;


internal static class Commands
{
    public static Uri YTLink { get; private set; } = null!;

    /// <summary>
    /// HowTo use YtText Tool
    ///     Tool produce text from youtube videos
    /// 
    /// </summary>
    /// <param name="link">-l, link to youtube video</param>
    public static void GetParams(Uri link) => YTLink = link;
}

