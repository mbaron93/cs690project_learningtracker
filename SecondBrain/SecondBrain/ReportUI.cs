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

    public void printGoals(List<Goal> goals){
         var table = new Table(); 
         table.AddColumn("Goal Name");
         table.AddColumn("Completed");
         table.AddColumn("Complete By");
        foreach(Goal a in goals){
            DateTime dt = a.getCompleteBy(); 
            table.AddRow(new string[]{a.getDesc(), ""+a.getCompleted(),""+dt.Month + "/"+dt.Day + "/"+dt.Year});
        }
        AnsiConsole.Write(table);

    }

    public void reportAllGoals(){
        Console.WriteLine("Here are all of your goals"); 
        List<Goal> allGoals = gm.getAllGoals(); 
        printGoals(allGoals);
    }

    public void reportGoalProgress(){
        double percGoalsComplete = gm.fractionGoalsComplete()*100.0; 
        Console.WriteLine("You have completed "+percGoalsComplete+ "% of your learning goals!");
        Console.WriteLine("Here are some goals you could work on to better yourself!"); 
        List<Goal> incGoals = gm.incompleteGoals(); 
        printGoals(incGoals);
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
