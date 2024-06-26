using System;
using System.ComponentModel;
using System.IO;
using VideoLibrary;


namespace YTText.FileSourceProcessor;

internal class YouTubeDownloader : IFileSourceProcessor
{
    private void DownloadVideo(string inputFileLocation, string videoPath)
    {
        if (!Uri.TryCreate(inputFileLocation, UriKind.Absolute, out _)) { throw new ArgumentException("given URI is invalid"); } //TODO: change to normal validation handling

        var yt = YouTube.Default;
        var video = yt.GetVideo(inputFileLocation);
        File.WriteAllBytes(videoPath, video.GetBytes());
    }

    public void PrepareFile(string inputFileLocation, string copyFileLocation)
    {
        DownloadVideo(inputFileLocation, copyFileLocation);
    }
}