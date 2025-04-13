namespace SecondBrain; 

public class Goal{
    private string goalDesc; 
    private bool completed; 
    private DateTime started;
    private DateTime completeBy;  

public Goal(string goalDesc, DateTime completeBy){
    this.goalDesc = goalDesc; 
    this.completeBy = completeBy; 
    completed = false; 
    started = DateTime.Now; 
}

public Goal(string goalDesc, bool completed, DateTime started, DateTime completeBy){
    this.goalDesc = goalDesc; 
    this.completeBy = completeBy; 
    this.started=started; 
    this.completed=completed; 
}

public void completeGoal(){
    completed = true; 
}

public string getDesc(){
    return goalDesc; 
}

public void setDesc(string s){
    goalDesc = s; 
}

public bool getCompleted(){
    return completed; 
}

public DateTime getStartDate(){
    return started; 
}

public DateTime getCompleteBy(){
    return completeBy; 
}

public void setCompleteBy(DateTime completeBy){
    this.completeBy=completeBy; 
}

public string toString(){
    String str = "You started the goal of "+goalDesc + " on ";
    str+= started.Year+"/"+started.Month+"/"+started.Day;
    if(this.completed==false){
       str+=" and hope to finish by ";
    }else{
       str+=" and you finished it on ";
    }
    str+=+ completeBy.Year+"/"+completeBy.Month + "/"+completeBy.Day; 
    return str; 
}

}