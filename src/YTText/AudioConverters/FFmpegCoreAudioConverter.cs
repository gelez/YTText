using FFMpegCore;

namespace YTText.AudioConverters;

internal class FFmpegCoreAudioConverter : IAudioConverter
{
    public void ConvertToWhisperFormat(string inputFilePath, string outputAudioFilePath)
    {
        //  thats implementation of command
        //      ffmpeg -i input.mp3 -ar 16000 -ac 1 -c:a pcm_s16le output.wav
        FFMpegArguments
            .FromFileInput(inputFilePath)
            .OutputToFile(outputAudioFilePath, false, options => options
                .WithCustomArgument("-ar 16000 -ac 1 -c:a pcm_s16le"))
                .ProcessSynchronously();
    }
}