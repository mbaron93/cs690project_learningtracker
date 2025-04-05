namespace SecondBrain;

public class UITest{
    UI ui; 
    string[] options = new String[] {"Add a source", "Edit a source", "Set a Goal", "View Learning Data", "Exit"};
    DataManager dm = new DataManager(); 

    public UITest( ){
        ui = new UI(options, dm);
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

}