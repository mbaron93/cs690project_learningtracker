namespace SecondBrain; 

using System.IO; 
using Spectre.Console; 

public class GoalUI{
    DataManager dm; 

    public GoalUI(DataManager dm){
        this.dm = dm; 
        this.start(); 
    }

    public void start(){
        Console.WriteLine("Add a Goal Page");
    }

}