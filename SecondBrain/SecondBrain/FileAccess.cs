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
            if(values.Length == 4){
                Source temp = new Source(values[0], values[1], values[2], double.Parse(values[3]));
                allData.Add(temp);
            }
        }
       }
       return allData; 
    }

    public string getFileName(){
        return fileName; 
    }

    public void editFile(string newText, int line_to_edit){
        string[] arrLine = File.ReadAllLines(this.fileName);
        arrLine[line_to_edit] = newText;
        File.WriteAllLines(this.fileName, arrLine);
    }

    public int getLastLineNumber(){
        string[] arrLine = File.ReadAllLines(this.fileName);
        return arrLine.Length-1;
    }
}