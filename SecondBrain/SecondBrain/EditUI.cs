namespace SecondBrain; 

using System.IO; 
using Spectre.Console; 

public class EditUI{
    DataManager dm; 

    public EditUI(DataManager dm){
        this.dm = dm; 
        this.start(); 
    }

    public void start(){
        Console.Clear(); 
        Console.WriteLine("Edit a Source Page");
        List<string> allTitles = dm.allTitles();
        allTitles.Add("Go back to home");
         string sourceName = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Which source will you change?")
            .PageSize(10)
            .AddChoices(allTitles));

        Console.Clear(); 
        if(!string.Equals(sourceName, "Go back to home")){
        var editOrRemove = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Do you want to edit the source or remove it")
            .PageSize(10)
            .AddChoices(new []{"Edit a Source", "Remove a Source"}));
            if(string.Equals(editOrRemove, "Edit a Source")){
                this.edit(sourceName);
            }
            if(string.Equals(editOrRemove, "Remove a Source")){
                this.remove(sourceName);
            }

        }
    }

    public void edit(string sourceName){
        //find current source in Database
        Source s = dm.getSourceByTitle(sourceName);
        Console.Clear(); 

        //prompt whihc parts to change dynamically
         string noteChange = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Would you like to change your note?")
            .PageSize(10)
            .AddChoices(new [] {"Yes", "No"}));
        if(string.Equals("Yes",noteChange)){
            //if changed, update note value
            Console.WriteLine("Enter your new note");
            string note = Console.ReadLine(); 
            s.setNote(note);
        }

        //prompt ot update progress change
        Console.Clear(); 
         string progressChange = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Would you like to update your progress?")
            .PageSize(10)
            .AddChoices(new [] {"Yes", "No"}));
        if(string.Equals("Yes",progressChange)){
            Console.Clear(); 
            //if change, update amount completed
           Console.WriteLine("What percent have you completed? Enter a value between 0 and 100");
            double amount = double.Parse(Console.ReadLine());
            while(amount< 0 || amount >100.0){
                Console.WriteLine("You didn't enter an amount between 0 and 100.0. Please try again on the percent of the article you completed.");
                amount = double.Parse(Console.ReadLine());
            }
            s.setAmount(amount);
        }

        dm.editSource(s);
        

    }
    public void remove(string sourceName){
        Console.Clear(); 
        dm.removeSource(sourceName);
        Console.WriteLine(sourceName + "removed");
    }

}