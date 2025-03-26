namespace SecondBrain; 

using System.IO; 
using Spectre.Console; 


//UI Class is not working in separate file right now

public class UI{
  //dynamically update different pages over time depending on the class. 
      private string[] options; 
      DataManager dm; 

      public UI(String[] options, DataManager dm){
        this.options = options; 
        this.dm = dm; 
         this.home(); 
      }

      public void home(){
       var choice = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("What do you want to do?")
        .PageSize(10)
        .AddChoices(options));
         Console.WriteLine("You picked: "+choice);

         /**refactor to match with options depending on variability**/
         if(choice == options[0]){
            AddUI addui = new AddUI(dm); 
         }
         if(choice == options[1]){
            EditUI editui = new EditUI(dm); 
         }
         if(choice == options[2]){
            GoalUI goalui = new GoalUI(dm);
         }
         if(choice == options[3]){
            ReportUI reportUI = new ReportUI(dm); 
         }
         if(choice != options[4]){
            this.home(); 
         }
      }
     
}



