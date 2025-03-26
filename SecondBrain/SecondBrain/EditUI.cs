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
        Console.WriteLine("Edit a Source Page");
         var sourceType = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Which will you edit?")
            .PageSize(10)
            .AddChoices(dm.allTitles()));
    }

}