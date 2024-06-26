using YTText;

namespace YTTextTest;

public class ProgramTest
{
    [SetUp]
    public void Setup()
    {
    }

    [TearDown]
    public void TearDown()
    {
    }

    

    //  Better test the app on relatively uncommon language.
    //  You may compare the quality of results with default YT subtitles and will be surprised.
    //  YouTube URI to test. https://www.youtube.com/watch?v=fFY7pAVnIGcd

    [Test]
    public void Program_ValidInput_MustWorkCorrectly()
    {
        // Arrange
        string ytLink = "https://www.youtube.com/watch?v=fFY7pAVnIGcd";
        string filesName = "testName";

        // Act 
        Program.Process(ytLink, filesName);

        // Assert
        Assert.That(File.Exists(filesName + ".mp4"));
        Assert.That(File.Exists(filesName + ".wav"));
        Assert.That(File.Exists(filesName + ".txt"));
    }

}