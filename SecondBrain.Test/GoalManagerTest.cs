namespace SecondBrain.test; 

public class GoalManagerTest{
    GoalManager gm;
    GoalManager gmAddEdit;  

    public GoalManagerTest(){
        gm = new GoalManager("GoalManagerTest.csv"); 
        gmAddEdit = new GoalManager("GoalAddAndEdit.csv");
    }


    //getAllGoals
    [Fact]
    public void testGetAllGoals(){
        Assert.Equal(gm.getAllGoals().Count, 3);
    }

    //addGoal - uses add edit to avoid using the pre-existing CSV for other file system
    [Fact]
    public void TestAddGoal(){
        Goal g = new Goal("Climb Mt. Everest", new DateTime(2025, 1, 1));
        gmAddEdit.addGoal(g);
        Goal returned = gmAddEdit.returnGoal(gmAddEdit.getAllGoals().Count-1);
        Assert.Equal(g.getDesc(), returned.getDesc());
    }


    //toCSV Test
    [Fact]
    public void testGoalDataCSV(){
        List<Goal> goals = gm.getAllGoals(); 
        Goal g = goals[0]; 
        String s = g.getDesc()+",";
        if(g.getCompleted()){
        s+="true,";
        } else{
        s+="false,";
        }
        s+=g.getStartDate().Year+"/"+g.getStartDate().Month+"/"+g.getStartDate().Day+",";
        s+=g.getCompleteBy().Year+"/"+g.getCompleteBy().Month+"/"+g.getCompleteBy().Day+"\n";
        Assert.Equal(gm.goalDataCSV(goals[0]),s);
    }

    //getAllGoalDescs()
    [Fact]
    public void getAllGoalDescs(){
        List<Goal> goals = gm.getAllGoals(); 
        List<String> allDescs = gm.getAllGoalDescs(); 
        int index=0; 
        Assert.Equal(goals.Count, allDescs.Count);
        foreach(Goal g in goals){
            Assert.Equal(g.toString(), allDescs[index]);
            index++;
        }
        
    }

    //incompleteGoals
    [Fact]
    public void TestIncompleteGoals(){
        List<Goal> incgoals= gm.incompleteGoals();
        foreach(Goal g in incgoals){
            Assert.Equal(g.getCompleted(), false);
        }
    }

    //editGoal
    [Fact]
    public void TestEditGoal(){
        if(gmAddEdit.getAllGoals().Count!=0){
            Goal g = gmAddEdit.getAllGoals()[0];
            if(g!= null){
                g.setDesc("Watch the sunset");
                gmAddEdit.editGoal(g); 
                Assert.Equal(g.getDesc(), gmAddEdit.getAllGoals()[0].getDesc());
            }
        }
    }

    //fractionGoalsComplete
    public void TestFractionGoalsComplete(){
        Assert.Equal(gm.fractionGoalsComplete(), 1.0/3);
    }
}