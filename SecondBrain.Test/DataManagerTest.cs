namespace SecondBrain.Test; 

public class DataManagerTest{
    DataManager dm; 
    
    public DataManagerTest(){
        dm = new DataManager("DataManagerTest.csv"); 
        Source temp = new Source("Lincoln", "Abraham", "he was number one", 63); 
        dm.addNewSource(temp);
    }

    [Fact]
    public void TestAddAndGetSources(){
        Source temp = new Source("Boil", "Boyle", "It was steamy", 40); 
        dm.addNewSource(temp);
        Source s = dm.getSourceByTitle("Boil"); 
        Assert.Equal(s.Equals(temp),true);
    }

    [Fact]
    public void TestRemoveSource(){
        Assert.Equal(dm.removeSource("Lincoln"), true);
    }

    [Fact]
    public void TestEditSource(){
        Source temp = new Source("Boiling", "Boyle", "It was steamy", 40); 
        dm.addNewSource(temp);
        int amount = 100; 
        temp.setAmount(amount);
        dm.editSource(temp);
        Assert.Equal(amount, dm.getSourceByTitle(temp.getTitle()).getAmount()); 
    }

    [Fact]
    public void TestAllTitles(){
        DataManager allTitleTester = new DataManager("TitleTester.csv"); 
        Source temp = new Source("Gilead","Robinson", "It was great", 100); 
        allTitleTester.addNewSource(temp);
        List<String> titles = allTitleTester.allTitles();
        List<String> checkList = new List<String>(); 
        checkList.Add(temp.getTitle());
        Assert.Equal(titles,checkList );
        allTitleTester.removeAllSources(); 
    }
}