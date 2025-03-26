namespace SecondBrain; 

//The source class, which represents each information source
public class Source{
   private string title; 
   private string author; 
   private string notes; 
   private double amount; 

   public Source(string t, string a, string n, double amount){
    title = t; 
    author = a; 
    notes = n; 
    this.amount = amount; 
   }

   public Source(string t, string a, string n){
    title = t; 
    author = a; 
    notes = n; 
    this.amount = 100.0; 
   }
   
   public string getTitle(){
    return title; 
   }
   public string getAuthor(){
    return author; 
   }
   public string getNotes(){
    return notes; 
   }
   public double getAmount(){
    return amount; 
   }
   public string toString(){
    return "Title: "+title+"\nAuthor: "+author+"\nNotes: "+notes+"\nAmount: "+getAmount(); 
   }
}
