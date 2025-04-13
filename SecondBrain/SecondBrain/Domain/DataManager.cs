namespace SecondBrain; 

using System.IO; 
using Spectre.Console; 

public class DataManager{
    private List<Source> allSources; 
    private string fileName; 
    private FileAccess fileaccess; 
    private int goalNumSources = 100; 

    //default constructor for testing
    public DataManager(){
        fileName="default.csv";
        fileaccess = null; 
        allSources = new List<Source>(); 
    }
    public DataManager(string f){
        fileName = f; 
        fileaccess = new FileAccess(fileName);
        allSources = fileaccess.loadExistingSources(); 
    }

    public void setGoalNumSources(int goalNumSources){
        this.goalNumSources=goalNumSources; 
    }

    public int getGoalNumSources(){
        return goalNumSources; 
    }

    //unit test written
    public string toCSV(Source s){
      String str = s.getAuthor()+","+s.getTitle()+","+s.getNotes()+","+s.getAmount()+","; 
      DateTime start = s.getStart(); 
      str+=start.Year+"/"+start.Month+"/"+start.Day+"\n"; 
      return str; 
    }

    public void printAllSources(){
         var table = new Table(); 
         table.AddColumn("Title");
         table.AddColumn("Author");
         table.AddColumn("Percent Complete");
         table.AddColumn("Started On");
        foreach(Source a in allSources){
            DateTime dt = a.getStart(); 
            table.AddRow(new string[]{a.getTitle(), a.getAuthor(), ""+a.getAmount(),""+dt.Month + "/"+dt.Day + "/"+dt.Year});
        }
        AnsiConsole.Write(table);

    }


    //unit test written
    public void addNewSource(Source s){
        allSources.Add(s);
        fileaccess.publish(toCSV(s)); 
    }

    //unit test written
    public List<String> allTitles(){
        List<String> titles = new List<String>(); 
        foreach(Source a in allSources){
            titles.Add(a.getTitle());
        }
        return titles; 
    }

    //unit test written
    public bool removeSource(string sourceName){
        for(int i = 0; i<allSources.Count; i++){
            Source s = allSources[i];
            if(string.Equals(sourceName, s.getTitle())){
                fileaccess.editFile("", i );
                allSources.Remove(s); 
                return true;
            }
        }
        return false; 
        
    }

    //Test does not work. Not in use! Only used in DataManager testAllTitles. Do not use!
    public void removeAllSources(){
         for(int i = 0; i<allSources.Count; i++){
            fileaccess.editFile("\n",i);
         }
         allSources = new List<Source>(); 
    }


    //unit test written
    public void editSource(Source given){
        for(int i = 0; i<allSources.Count; i++){
            Source s = allSources[i];
            if(string.Equals(given.getTitle(), s.getTitle())){
                fileaccess.editFile(toCSV(given), i);
            }
        }
        
    }

    //unit test written
    public Source getSourceByTitle(string sourceName){
        for(int i = 0; i<allSources.Count; i++){
            Source s = allSources[i];
            if(string.Equals(sourceName, s.getTitle())){
                return s; 
            }
        }
        return null; 
    }


}