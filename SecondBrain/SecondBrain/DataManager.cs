namespace SecondBrain; 

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

    public string toCSV(Source s){
      String str = s.getAuthor()+","+s.getTitle()+","+s.getNotes()+","+s.getAmount()+","; 
      DateTime start = s.getStart(); 
      str+=start.Year+"/"+start.Month+"/"+start.Day+"\n"; 
      return str; 
    }

    public void printAllSources(){
        int source = 0; 
        foreach(Source a in allSources){
            source++; 
            Console.WriteLine("Source #"+source+":");
            Console.WriteLine(a.toString());
        }
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
                fileaccess.editFile("\n", i );
                allSources.Remove(s); 
                return true;
            }
        }
        return false; 
        
    }

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