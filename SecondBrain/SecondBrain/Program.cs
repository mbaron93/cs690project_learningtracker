﻿namespace SecondBrain;

using System.IO; 
using Spectre.Console; 

class Program
{
    

    static void Main(string[] args)
    {
        DataManager dm = new DataManager("Sources.csv");
        string[] options = new String[] {
            "Add a source", "Edit a source", "Set a Goal", "View Learning Data", "Exit"};
        UI u = new UI(options, dm); 
        //changed home calls here to avoid unit testing from messing up constructors
        u.home(); 
        
    }
    
}

