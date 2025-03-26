namespace SecondBrain;

using System.IO; 

class Program
{
    static void Main(string[] args)
    {
        UI u = new UI(); 
        DataManager dm = new DataManager("StoredInfo.csv");
        dm.printAllSources(); 
    }


}



