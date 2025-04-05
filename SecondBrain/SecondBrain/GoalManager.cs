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

    public void addGoal(Goal g){
        allGoals.Add(g); 
        fm.publish(this.goalDataCSV(g));
    }

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


    public List<String> getAllGoalDescs(){
        List<String> allDescs = new List<String>(); 
        foreach(Goal g in allGoals){
            allDescs.Add(g.toString());
        }
        return allDescs; 
    }

    public void editGoal(Goal given){
        for(int i = 0; i<allGoals.Count; i++){
            Goal g = allGoals[i];
            if(string.Equals(given.getDesc(), g.getDesc())){
                fm.editFile(this.goalDataCSV(given), i);
            }
        }
        
    }
    
    //Goal analysis data to be fed to Report UI phase
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