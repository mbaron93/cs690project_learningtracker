namespace SecondBrain; 

using System.IO; 
using Spectre.Console; 

public class ReportUI{
    DataManager dm; 

    public ReportUI(DataManager dm){
        this.dm = dm; 
        this.start(); 
    }

    public void start(){
        Console.WriteLine("View Learning Data and See Progress Page");
        dm.printAllSources();
    }

}