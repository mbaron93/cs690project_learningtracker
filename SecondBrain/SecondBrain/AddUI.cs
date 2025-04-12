namespace SecondBrain; 

using System.IO; 
using Spectre.Console; 

public class AddUI{
    DataManager dm; 

    public AddUI(DataManager dm){
        this.dm = dm; 
        this.start(); 
    }


    public static double validateArticleAmount(){
        double amount = -1.0; 
            Console.WriteLine("What percent of the article have you read? Enter a value between 0 and 100");
            while(amount< 0 || amount >100.0){
                try{
                    amount = double.Parse(Console.ReadLine());
                }catch(FormatException f){
                    Console.WriteLine("Re-enter a number please");
                }
                if(amount<0 || amount>100.0){
                    Console.WriteLine("You didn't enter an amount between 0 and 100.0. Please try again on the percent of the article you completed.");
                }
            }
        return amount; 
    }
    

    public static double validateBookAmount(){
        //checkTotalChapters
        Console.WriteLine("How many chapters are in this book? (whole number greater than zero)");
        int totalChapters = -1; 
        while(totalChapters<=0){
            try{
                totalChapters = int.Parse(Console.ReadLine());
            }catch(FormatException e){
                Console.WriteLine("Couldn't you have put a number in! Try again");
            }
            if(totalChapters<=0){
                Console.WriteLine("You didn't enter an amount of chapters greater than zero. Please try again.");
            }
        }
        Console.WriteLine("How many chapters have you read so far? Enter a value less than the total chapters in the book.");
        int readChapters = -1; 

        //check readChapters
        while(readChapters<0 || readChapters>totalChapters) {
            try{
                readChapters = int.Parse(Console.ReadLine());
            }catch(FormatException e){
                Console.WriteLine("Please enter a whole number of chapters");
            }
            Console.WriteLine("You didn't enter an appropriate amount. Please try again.");
        }
        return readChapters*100.0/totalChapters; 
        
    }

    public void start(){
        Console.WriteLine("Add Source Page");
        //choosing a source type will influence which type of constructor is used here
        var sourceType = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Is this a book or an article?")
            .PageSize(10)
            .AddChoices("Book", "Article", "Back to Home"));


        //The Author, title and notes are stored here now
        Console.WriteLine("Enter Title Name:");
        String title = Console.ReadLine();
        title = UI.validateInfo(title);

        Console.WriteLine("Enter Author Name:");
        String author = Console.ReadLine();
        author = UI.validateInfo(author); 

        Console.WriteLine("What did you think of this? What will you want to reflect on later and look back on? ");
        String notes = Console.ReadLine();
        notes = UI.validateInfo(notes);

        double amount = -1.0; 

        //percent article email
        if(sourceType == "Article"){
            amount = validateArticleAmount();
        //for print publications, take in a total chapters and chapters read, than calculate a percent to use in the constructor
        }else{
            amount = validateBookAmount(); 
        }//end of logic to determine percentage read
    
        //create and add source to list. Then, return home to the original value
        Source created = new Source(title, author, notes, amount);
        dm.addNewSource(created);
        Console.WriteLine(title + " was added to the database!");
    }
}