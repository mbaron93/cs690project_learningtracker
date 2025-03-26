namespace SecondBrain;

using System.IO; 
using Spectre.Console; 


class Program
{
    

    static void Main(string[] args)
    {
        string[] options = new String[] {
            "Add a source", "Edit a source", "Set a Goal", "View Learning Data"};
        UI u = new UI(options); 
        DataManager dm = new DataManager("StoredInfo.csv");
        
    }
    
}

public class UI{
  //dynamically update different pages over time depending on the class. 
      private string[] options; 

      public UI(String[] options){
        this.options = options; 
         this.home(); 
      }

      public void home(){
       var optionno = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Which option will you select!?")
        .PageSize(10)
        .AddChoices(options));
         Console.WriteLine("You picked: "+optionno);
        if()
      }

      public void addSource(){
        
      }

      public void editSource(){

      }

      public void addGoal(){

      }

      public void seeGoals(){

      }

      
}



