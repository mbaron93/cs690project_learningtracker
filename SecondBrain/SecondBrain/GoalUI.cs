namespace SecondBrain; 

using System.IO; 
using Spectre.Console; 

public class GoalUI{
    GoalManager gm; 
    DataManager dm; 
    string[] goalOptions = {"Add a New Goal", "Edit existing goals", "Change Overall Source Goal", "Return to Home"};

    public GoalUI(GoalManager gm, DataManager dm){
        this.gm=gm; 
        this.dm = dm; 
        this.start(); 
    }

    public void start(){
        Console.Clear(); 
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
        if(sourceType==goalOptions[2]){
            this.overallSourceGoal();
        }
    }

    public void addGoal(){
        Console.Clear(); 
        Console.WriteLine("What is your goal?");
        String goalDesc = Console.ReadLine();
        goalDesc = UI.validateInfo(goalDesc);

        DateTime completeBy = this.getDateFromUser(); 
        Goal temp = new Goal(goalDesc, completeBy);
        gm.addGoal(temp);
    }

    public void editGoal(){
        Console.Clear(); 
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

    public void overallSourceGoal(){
        Console.WriteLine("Your overall source goals is "+dm.getGoalNumSources()+" sources. What would you like to change it to? Enter 0 to leave it unchanged.");
        int amount = -1; 
        while(amount<=0){
            try{
                amount = int.Parse(Console.ReadLine());
                if(amount == 0){
                    return; 
                }
            }catch(FormatException f){
                Console.WriteLine("This requires an integer input.");
            }
            if(amount < 0){
                Console.WriteLine("Please try again with a positive whole number of sources.");
            }
        }
        dm.setGoalNumSources(amount);
    }
    //this can be used in multiple settings to get and update the program. 
    public DateTime getDateFromUser(){
        Console.WriteLine("Type the number of the month you'd like to complete it by.");
        int month = 0; 
        while(month <=0 || month >=13){
            try{
                month = int.Parse(Console.ReadLine());
            }
            catch(FormatException e){
            }
            if(month <=0 || month>=13){
                Console.WriteLine("Use the whole numbers 1-12 to represent the month, please!");
            }
        }

        Console.WriteLine("Enter the date in that month you'd like to complete it by.");
        int date = 0;
        while(date<=1 || date>=31){
            try{
                date = int.Parse(Console.ReadLine());
            }
            catch(FormatException e){
            
            }
            if(date<=1 || date>=31){
                Console.WriteLine("Use the whole numbers 1-30 to represent the date, please!");
            }
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