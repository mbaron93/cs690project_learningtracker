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

   public List<Source> loadExistingSources(){
       List<Source> allData = new List<Source>(); 
       using(var reader = new StreamReader(fileName)){
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(',');
            //refactor the below line of code for different data types eventually - write a polymorphic method
            Source temp = new Source(values[0], values[1], values[2], double.Parse(values[3]));
            allData.Add(temp);
        }
       }
       return allData; 
    }

    public string getFileName(){
        return fileName; 
    }
}