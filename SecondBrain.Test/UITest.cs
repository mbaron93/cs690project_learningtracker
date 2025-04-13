namespace SecondBrain;

public class UITest{
    UI ui; 
    string[] options = new String[] {"Add a source", "Edit a source", "Set a Goal", "View Learning Data", "Exit"};
    DataManager dm = new DataManager(); 
    GoalManager gm = new GoalManager("TestUIGoal.csv"); 

    public UITest( ){
        ui = new UI(options, dm, gm);
    }

    [Fact]
    public void TestGetOptions()
    {
        Assert.Equal(options, ui.getOptions());
    }

    [Fact]
    public void TestSetOptions()
    {
        String[] options2 = new String[]{"Choose a source", "Add an option"};
        ui.setOptions(options2);
        Assert.Equal(options2, ui.getOptions());
    }

    /*Return to test if I can get this up and running
    [Fact]
    public void TestHome(){
        Assert.Equal(ui.home(), true);
    }
    */
}