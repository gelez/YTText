using System;
using System.IO;
using System.Text;
using ConsoleAppFramework;
using YTText.AudioConverters;
using YTText.FileSourceProcessor;
using YTText.SpeechToText;


namespace YTText;

public class Program
{
    static void Main(string[] args)
    {
        ConsoleApp.Run(args, Commands.GetParams);

        Process(Commands.YTLink.ToString(), "ytdefault");
    }

    public static void Process(string ytLink, string filesName)
    {
        string videoFilePath = filesName + ".mp4";
        string audioFilePath = filesName + ".wav";
        string subtitlesFilePath = filesName + ".txt";

        IFileSourceProcessor fsProcessor = new YouTubeDownloader();
        fsProcessor.PrepareFile(ytLink, videoFilePath);

        IAudioConverter audioConverter = new FFmpegCoreAudioConverter();
        audioConverter.ConvertToWhisperFormat(videoFilePath, audioFilePath);

        ISpeechToText speech2Text = new WhisperNetProcessor();
        speech2Text.ProcessAudioToText(audioFilePath, subtitlesFilePath);
    }
}
