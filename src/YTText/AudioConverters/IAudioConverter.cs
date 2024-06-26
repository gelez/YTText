namespace YTText.AudioConverters;

internal interface IAudioConverter
{
    public void ConvertToWhisperFormat(string inputFilePath, string outputAudioFilePath);
}