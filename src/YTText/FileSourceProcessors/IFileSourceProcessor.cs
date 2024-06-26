namespace YTText.FileSourceProcessor;

internal interface IFileSourceProcessor
{
    public void PrepareFile(string inputFileLocation, string copyFileLocation);
}