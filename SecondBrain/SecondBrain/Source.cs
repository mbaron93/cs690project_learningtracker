namespace SecondBrain; 

using System; 

//The source class, which represents each information source
public class Source{
   private string title; 
   private string author; 
   private string notes; 
   private double amount; 
   public DateTime started; 

    public Source(string t, string a, string n, double amount, DateTime s){
    title = t; 
    author = a; 
    notes = n; 
    this.amount = amount; 
    started = s;
   }

   public Source(string t, string a, string n, double amount){
    title = t; 
    author = a; 
    notes = n; 
    this.amount = amount; 
    started = DateTime.Now; 
   }

   public Source(string t, string a, string n){
    title = t; 
    author = a; 
    notes = n; 
    this.amount = 100.0; 
    started = DateTime.Now; 
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
    return "Title: "+title+"\nAuthor: "+author+"\nNotes: "+notes+"\nAmount: "+getAmount() + "\nStarted on "+started.Month + "/"+started.Day; 
   }
   public DateTime getStart(){
      return started; 
   }
   public void setNote(string note){
      this.notes = note; 
   }
   public void setAmount(double amount){
      this.amount=amount; 
   }
}
