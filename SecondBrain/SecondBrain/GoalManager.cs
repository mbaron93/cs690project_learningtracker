namespace SecondBrain; 

public class GoalManager{
    private List<Goal> allGoals = new List<Goal>(); 
    private FileAccess fm; 

    public GoalManager(string fileName){
        fm = new FileAccess(fileName);
        allGoals = fm.loadExistingGoals(); 
    }

    //The section below documents and handles the access and editing of the goals section of the code
    public List<Goal> getAllGoals(){
        return allGoals; 
    }

    //Unit Test Written
    public void addGoal(Goal g){
        allGoals.Add(g); 
        fm.publish(this.goalDataCSV(g));
    }

    public Goal returnGoal(int index){
        return allGoals[index];
    }

    //unit test complete
    public string goalDataCSV(Goal g){
        String s = g.getDesc()+",";
        if(g.getCompleted()){
        s+="true,";
        } else{
        s+="false,";
        }
        s+=g.getStartDate().Year+"/"+g.getStartDate().Month+"/"+g.getStartDate().Day+",";
        s+=g.getCompleteBy().Year+"/"+g.getCompleteBy().Month+"/"+g.getCompleteBy().Day+"\n";
        return s; 
    }


    //unit test complete
    public List<String> getAllGoalDescs(){
        List<String> allDescs = new List<String>(); 
        foreach(Goal g in allGoals){
            allDescs.Add(g.toString());
        }
        return allDescs; 
    }

    //Unit Test Complete
    public List<Goal> incompleteGoals(){
        List<Goal> allDescs = new List<Goal>(); 
        foreach(Goal g in allGoals){
            if(!g.getCompleted()){
                allDescs.Add(g);
            }
        }
        return allDescs; 
    }

    //Unit Test Written
    public void editGoal(Goal given){
        for(int i = 0; i<allGoals.Count; i++){
            Goal g = allGoals[i];
            if(string.Equals(given.getDesc(), g.getDesc())){
                fm.editFile(this.goalDataCSV(given), i);
            }
        }
        
    }
    
    //Goal analysis data to be fed to Report UI phase
    //Unit Test Complete
    public double fractionGoalsComplete(){
        double count = 0; 
        foreach(Goal g in allGoals){
            if(g.getCompleted() == true){
                count+=1.0; 
            }
        }
        return count/allGoals.Count; 
    }




}