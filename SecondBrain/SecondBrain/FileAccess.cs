namespace SecondBrain; 
//the dynamically working File Class, which represents all file access values. 
public class FileAccess{
    private string fileName; 

    public FileAccess(string f){
        fileName = f; 
       
        if (!File.Exists(fileName)){
            //Console.WriteLine("Creating new file. First use.");
            File.Create(fileName); 
        }
        else{
            //Console.WriteLine("File exists. Loading data");

        }
    }

    public void publish(String value){
        File.AppendAllText(fileName, value);
    }


    public string getLine(int i){
        string[] arrLine = File.ReadAllLines(this.fileName);
        return arrLine[i];
    }

   public List<Source> loadExistingSources(){
       List<Source> allData = new List<Source>(); 
       using(var reader = new StreamReader(fileName)){
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(',');
            //refactor the below line of code for different data types eventually - write a polymorphic method
            if(values.Length == 5){
                string[] begin= values[4].Split("/");
                DateTime beginDate = new DateTime(int.Parse(begin[0]),int.Parse(begin[1]), int.Parse(begin[2]));
                Source temp = new Source(values[0], values[1], values[2], double.Parse(values[3]),beginDate);
                allData.Add(temp);
            }
        }
       }
       return allData; 
    }

    public List<Goal> loadExistingGoals(){
           List<Goal> allGoals= new List<Goal>(); 
       using(var reader = new StreamReader(fileName)){
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(',');
            //refactor the below line of code for different data types eventually - write a polymorphic method
            if(values.Length == 4){
                string[] begin = values[2].Split("/");
                string[] end = values[3].Split("/");
                Goal temp = new Goal(values[0], bool.Parse(values[1]), new DateTime(int.Parse(begin[0]),int.Parse(begin[1]), int.Parse(begin[2])), new DateTime(int.Parse(end[0]), int.Parse(end[1]),int.Parse(end[2])));
                allGoals.Add(temp);
            }
        }
       }
       return allGoals; 
    }

    public string getFileName(){
        return fileName; 
    }

    public void editFile(string newText, int line_to_edit){
        List<string> arrLine = new List<String>(File.ReadAllLines(this.fileName));
        for(int index = 0; index<arrLine.Count; index++){
            if(string.IsNullOrWhiteSpace(arrLine[index])){
                arrLine.Remove(arrLine[index]);
            }
        }
        arrLine[line_to_edit] = newText;
        File.WriteAllLines(this.fileName, arrLine);
    }

    public int getLastLineNumber(){
        string[] arrLine = File.ReadAllLines(this.fileName);
        return arrLine.Length-1;
    }

}