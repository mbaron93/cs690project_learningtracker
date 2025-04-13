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

    //addGoal


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

    //fractionGoalsComplete
}