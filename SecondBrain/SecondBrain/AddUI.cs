namespace SecondBrain; 

using System.IO; 
using Spectre.Console; 

public class AddUI{
    DataManager dm; 

    public AddUI(DataManager dm){
        this.dm = dm; 
        this.start(); 
    }

    public void start(){
        Console.WriteLine("Add Source Page");
        //choosing a source type will influence which type of constructor is used here
        var sourceType = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Is this a book or an article?")
            .PageSize(10)
            .AddChoices("Book", "Article"));


        //The Author, title and notes are stored here now
        Console.WriteLine("Enter Title Name:");
        String title = Console.ReadLine();

        Console.WriteLine("Enter Author Name:");
        String author = Console.ReadLine();

        Console.WriteLine("What did you think of this? What will you want to reflect on later and look back on? ");
        String notes = Console.ReadLine();

        double amount = -1.0; 
        //For articles, check the percent of the article that has been read
        if(sourceType == "Article"){
            Console.WriteLine("What percent of the article have you read? Enter a value between 0 and 100");
            amount = double.Parse(Console.ReadLine());
            while(amount< 0 || amount >100.0){
                Console.WriteLine("You didn't enter an amount between 0 and 100.0. Please try again on the percent of the article you completed.");
                amount = double.Parse(Console.ReadLine());
            }
        //for print publications, take in a total chapters and chapters read, than calculate a percent to use in the constructor
        }else{
            Console.WriteLine("How many chapters are in this book? (whole number of at least zero)");
            int totalChapters; 
            try{
              totalChapters = int.Parse(Console.ReadLine());
            }catch(FormatException e){
              Console.WriteLine("Couldn't you have put a number in! Try again");
              totalChapters = int.Parse(Console.ReadLine());
            }
            while(totalChapters<=0){
                Console.WriteLine("You didn't enter an amount of chapters greater than zero. Please try again.");
                totalChapters = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("How many chapters have you read so far? Enter a value less than the total chapters in the book.");
            int readChapters = int.Parse(Console.ReadLine());
            while(readChapters<0 || readChapters>totalChapters) {
                Console.WriteLine("You didn't enter an appropriate amount. Please try again.");
                readChapters = int.Parse(Console.ReadLine());
            }
        amount = readChapters*100.0/totalChapters; 
        }//end of logic to determine percentage read
    
        //create and add source to list. Then, return home to the original value
        Source created = new Source(title, author, notes, amount);
        dm.addNewSource(created);
        Console.WriteLine(title + " was added to the database!");
    }
}