namespace SecondBrain.Test;

public class FileAccessTest
{
    FileAccess fm; 
    String testString = "hey, another, test, 30"; 
    int nextLineInt; 

    
    public FileAccessTest(){
        fm = new FileAccess("TestFile.csv");
    }

  

    [Fact]
    public void TestEditFile(){
        String testString2 = "Howdy,how,are,56";
        fm.editFile(testString2,fm.getLastLineNumber());
        string retrieved = fm.getLine(fm.getLastLineNumber()); 
        Assert.Equal(testString2,retrieved);
    }


    [Fact]
    public void TestPublishCorrectly()
    {
        fm.publish(testString); 
        String retrieved = fm.getLine(fm.getLastLineNumber());
        Assert.Equal(testString, retrieved);

    }

    [Fact]
    public void TestFileName(){
        string fileName = fm.getFileName(); 
        Assert.Equal(fileName, "TestFile.csv");
    }

    [Fact]
    public void TestLoadSources(){
        string[] arrLine = File.ReadAllLines("TestFile.csv");
        for(int index = 0; index<arrLine.Length; index++){
            fm.editFile("test,test,test,"+index,index);
        }
        List<Source> allSources = fm.loadExistingSources(); 
        for(int index = 0; index<allSources.Count; index++){
            Assert.Equal(index, allSources[index].getAmount());
        }

    }

}