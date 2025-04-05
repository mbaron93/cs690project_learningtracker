namespace SecondBrain; 

using System.IO; 
using Spectre.Console; 

public class ReportUI{
    DataManager dm; 
    GoalManager gm; 
    private string[] reportOptions = {"See all sources completed", "View all goals", "View goal progress", "Exit" };
    //Summarize learning progress

    public ReportUI(DataManager dm, GoalManager gm){
        this.dm = dm; 
        this.gm = gm; 
        this.start(); 
    }

    public void start(){
        this.summarize(); 
         var reportOption = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("What more would you like to see?")
            .PageSize(10)
            .AddChoices(reportOptions)); 
        
        if(reportOption == reportOptions[0]){
            Console.WriteLine("Here is every source you've completed!");
            dm.printAllSources();
        }

        if(reportOption == reportOptions[1]){
            this.reportAllGoals(); 
          }
        

        if(reportOption == reportOptions[2]){
            this.reportGoalProgress(); 
          }
        
    }

    public void reportAllGoals(){
        Console.WriteLine("Here are all of your goals"); 
        List<String> allGoals = gm.getAllGoalDescs(); 
        foreach(string g in allGoals){
            Console.WriteLine(g);
        }
    }

    public void reportGoalProgress(){
        double percGoalsComplete = gm.fractionGoalsComplete()*100.0; 
        Console.WriteLine("You have completed "+percGoalsComplete+ "% of your learning goals!");
        Console.WriteLine("Here are some goals you could work on to better yourself!"); 
        List<string> allGoals = gm.incompleteGoals(); 
        foreach(string g in allGoals){
            Console.WriteLine(g);
        }
    }

    public void summarize(){
        Console.WriteLine("You have read "+dm.allTitles().Count + " sources of information! Wow! Keep at it!");
        if(dm.allTitles().Count()>dm.getGoalNumSources()){
            Console.WriteLine("Congrats on meeting your goal of "+dm.getGoalNumSources());
        }else{
            Console.WriteLine("Remember, you have a goal of "+dm.getGoalNumSources()+". Get to it! Read some more!");
        }
        Console.WriteLine("You have set "+gm.getAllGoals().Count+ " reading goals and you have hit "+(100*gm.fractionGoalsComplete())+"% of them.");
  
    }

}
