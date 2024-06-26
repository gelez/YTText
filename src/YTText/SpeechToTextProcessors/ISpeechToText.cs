namespace YTText.SpeechToText;

internal interface ISpeechToText
{
    void ProcessAudioToText(string audioPath, string outputTextPath);
}