using System;
using System.IO;
using System.Threading.Tasks;
using Whisper.net;
using Whisper.net.Ggml;

namespace YTText.SpeechToText;

internal class WhisperNetProcessor : ISpeechToText
{
    private readonly string modelName;
    public WhisperNetProcessor()
    {
        modelName = "ggml-tiny.bin";
    }

    public void ProcessAudioToText(string audioPath, string outputTextPath)
    {
        ConvertAudioToTextWithWhisper(audioPath, outputTextPath);
    }

    private async void ConvertAudioToTextWithWhisper(string audioPath, string outputPath)
    {
        if (!File.Exists(modelName))
        {
            await DownloadModel(modelName, GgmlType.Tiny);
        }

        using var whisperFactory = WhisperFactory.FromPath(modelName);
        using var processor = whisperFactory.CreateBuilder()
                    .WithLanguage("auto")
                    .Build();

        try
        {
            using var outTextFileStream = new FileStream(outputPath, FileMode.Create);
            using var outTextStreamWriter = new StreamWriter(outTextFileStream);
            using var audioFileStream = File.OpenRead(audioPath);
            await foreach (var result in processor.ProcessAsync(audioFileStream))
            {
                outTextStreamWriter.WriteLine($"Lang {result.Language}; {result.Start} -> {result.End}: {result.Text}");
                //Console.WriteLine($"Lang {result.Language}; {result.Start} -> {result.End}: {result.Text}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message); //TODO: change to logging
        }
    }

    private async Task DownloadModel(string fileName, GgmlType ggmlType)
    {
        Console.WriteLine($"Loading Model {fileName}"); //TODO: change to logging
        using var modelStream = await WhisperGgmlDownloader.GetGgmlModelAsync(ggmlType);
        using var fileWriter = File.OpenWrite(fileName);
        await modelStream.CopyToAsync(fileWriter);
    }
}