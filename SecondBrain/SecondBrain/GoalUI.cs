namespace SecondBrain; 

using System.IO; 
using Spectre.Console; 

public class GoalUI{
    DataManager dm; 
    GoalManager gm; 
    string[] goalOptions = {"Add a New Goal", "Edit existing goals", "Return to Home"};

    public GoalUI(GoalManager gm){
        this.gm=gm; 
        this.start(); 
    }

    public void start(){
        
        Console.WriteLine("Add a Goal Page.:");
         var sourceType = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("What would you like to do?")
            .PageSize(10)
            .AddChoices(goalOptions)); 
        if(sourceType==goalOptions[0]){
            this.addGoal(); 
        }
        if(sourceType==goalOptions[1]){
            this.editGoal(); 
        }
    }

    public void addGoal(){
        Console.WriteLine("What is your goal?");
        String goalDesc = Console.ReadLine();

        DateTime completeBy = this.getDateFromUser(); 

        Goal temp = new Goal(goalDesc, completeBy);
        gm.addGoal(temp);
    }

    public void editGoal(){

         Console.WriteLine("Edit Goal");
         var goalChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Which goal would you like to edit?")
            .PageSize(10)
            .AddChoices(gm.getAllGoalDescs())); 
        
        string[] editOptions = new string[]{"Mark Completed", "Change Goal Date", "Exit without Changing Any"};

         Console.WriteLine("Edit Goal");
         var editOption = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("How would you like to update your goal?")
            .PageSize(10)
            .AddChoices(editOptions)); 

        Goal goalOfChoice = null; 
        foreach(Goal match in gm.getAllGoals()){
            if(string.Equals(match.toString(),goalChoice)){
              goalOfChoice = match; 
            }
        }

        if(editOption == editOptions[0] && goalOfChoice.getCompleted()==false){
            goalOfChoice.completeGoal(); 
            goalOfChoice.setCompleteBy(DateTime.Now); 
            gm.editGoal(goalOfChoice);
        }
        if(editOption == editOptions[1]){
            DateTime completeBy = this.getDateFromUser(); 
            goalOfChoice.setCompleteBy(completeBy);
            gm.editGoal(goalOfChoice);
        }

    }


    //this can be used in multiple settings to get and update the program. 
    public DateTime getDateFromUser(){
        Console.WriteLine("Type the number of the month you'd like to complete it by.");
        int month; 
        try{
         month = int.Parse(Console.ReadLine());
        }
        catch(FormatException e){
         Console.WriteLine("Use the whole numbers 1-12 to represent the month, please!");
         month = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Enter the date in that month you'd like to complete it by");
        int date;
         try{
         date = int.Parse(Console.ReadLine());
        }
        catch(FormatException e){
         Console.WriteLine("Use the whole numbers 1-30 to represent the date, please!");
         date = int.Parse(Console.ReadLine());
        }

        DateTime dt = DateTime.Now; 
        if(month>DateTime.Now.Month){//if the goal is after the current month within the calendar year, set it to this year
         dt= new DateTime(DateTime.Now.Year, month, date);
        }else{//if the goal is before the current month, give it a date of next year
         dt = new DateTime(DateTime.Now.Year+1, month, date);
        }
        return dt; 
    }

}