namespace Oblig2_Library;

public class Library
{
    public List<Bok> Booker { get; set; }

    public Library(List<Bok> booker = null)
    {
        if (booker == null)
        {
            Booker = new List<Bok>();
        }
        else
        {
            Booker = booker;
        }
        
    }

    public void ShowMainMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Library, please choose one of the following options:");
        Console.WriteLine("1. Add a new Book");
        Console.WriteLine("2. List of all Books");
        Console.WriteLine("3. Find book by Author");
        Console.WriteLine("4. Find book by Title");
        Console.WriteLine("5. Find book published after year XXXX");
        Console.WriteLine("6. Return books");
        Console.WriteLine("7. Burn a book!");
        Console.WriteLine("Your choice: ");
        int choice = Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
        switch (choice)
        {
            case 1:
                AddBook();
                break;
            case 2:
                ShowBooks(Booker);
                break;
            case 3:
                SearchByAuthor();
                break;
            case 4:
                SearchByTitle();
                break;
            case 5:
                SearchByYear();
                break;
            case 6:
                ReturnBook();
                break;
            case 7:
                BurnBook();
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
        
    }
    
    
    //SUBMENUS
    //Add book
    private struct _Bok
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int ISBN { get; set; }
        public string Secondary { get; set; }
    }
    private void AddBook()
    {
        Console.Clear();
        _Bok TempBok = new _Bok();
        Console.Write("Enter the title of the book: ");
        TempBok.Title = Console.ReadLine();
        Console.Write("Enter the author of the book: ");
        TempBok.Author = Console.ReadLine();
        bool loopify = true;
        while (loopify)
            try
            {
                Console.Write("Enter the year of the book: ");
                TempBok.Year = Convert.ToInt32(Console.ReadLine());
                loopify = false;
            }
            catch
            {
                Console.WriteLine("Year must be a number!");
            }
        TempBok.ISBN = new Random().Next(111111111, 999999999);
        Console.Write("Novel or Science book? ");
        loopify = true;
        while (loopify)
        {
            switch (Console.ReadLine().ToLower())
            {
                case "novel":
                    loopify = false;
                    Console.Write("Genre of the book: ");
                    TempBok.Secondary = Console.ReadLine();
                    Booker.Add(new Roman(TempBok.Author,TempBok.Title,TempBok.Year,TempBok.ISBN,TempBok.Secondary));
                    break;
                case "science":
                    loopify = false;
                    Console.WriteLine("Field of the book: ");
                    TempBok.Secondary = Console.ReadLine();
                    Booker.Add(new Fagbok(TempBok.Author,TempBok.Title,TempBok.Year,TempBok.ISBN,TempBok.Secondary));
                    break;
                default:
                    Console.WriteLine("Invalid input, Try again");
                    Console.WriteLine("Novel or Science book? ");
                    break;
            }
        }
        
        
    }
    
    // Search by Author
    private void SearchByAuthor()
    {
        Console.Clear();
        Console.WriteLine("Enter the author of the book: ");
        string author = Console.ReadLine();
        var sortedBooks = from book in Booker
            where book.author == author
            select book;
        ShowBooks(sortedBooks.ToList());
    }
    private void SearchByTitle()
    {
        Console.Clear();
        Console.WriteLine("Enter the author of the book: ");
        string title = Console.ReadLine();
        var sortedBooks = from book in Booker
            where book.title == title
            select book;
        ShowBooks(sortedBooks.ToList());
    }
    private void SearchByYear()
    {
        Console.Clear();
        Console.WriteLine("Enter the minimum year of the book: ");
        int year = Int32.Parse(Console.ReadLine());
        var sortedBooks = from book in Booker
            where book.year >= year
            select book;
        ShowBooks(sortedBooks.ToList());
    }

    private void ReturnBook()
    {
        Console.Clear();
        var MyBooks = from book in Booker
            where book.Available == false
            select book;
        ShowBooks(MyBooks.ToList(), "return");
    }

    private void BurnBook()
    {
        Console.Clear();
        ShowBooks(Booker.ToList(),"burn");
    }
    
    
    // Search by Title
    
    
    // UI Showing the books
    public void ShowBooks(List<Bok> books, string action = "none")
    {
        if (books.Count == 0) return;
        
        Console.Clear();
        int _index = 1;
        foreach (var book in books)
        {
            Console.WriteLine(_index + " - " + book.GetInfo());
            _index++;
        }

        if (action == "return")
        {
            int toReturn = 0;
            bool loopify = true;
            while (loopify)
            {
                Console.WriteLine("Choose the book you want to return: ");
                try
                {
                    toReturn = Int32.Parse(Console.ReadLine()) - 1;
                    loopify = false;
                }
                catch
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }

            books[toReturn].ReturnBook();
            
            
            Console.WriteLine($"{books[toReturn].title} by {books[toReturn].author} Has been returned, Press any key");
            Console.ReadKey();
            return;
        } 
        else if (action == "burn")
        {
            int toBurn = 0;
            bool loopify = true;
            while (loopify)
            {
                Console.WriteLine("Choose the book you want to burn: ");
                try
                {
                    toBurn = Int32.Parse(Console.ReadLine()) - 1;
                    loopify = false;
                }
                catch
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }
            Bok toBurnBook = books[toBurn];
            Console.WriteLine($"{toBurnBook.title} by {toBurnBook.author} HAS BEEN BURNED TO ASHES!");
            Booker.Remove(toBurnBook);
            Console.WriteLine("Press any key to continue <3");
            Console.ReadKey();
            return;
        }
        
        
        Console.WriteLine("Press enter or type the number of the book you would like to loan!");
        string input = Console.ReadLine();
        if (input == "") return;
        int isbnToLoan;
        try
        {
            isbnToLoan = int.Parse(input) - 1;
            if (books[isbnToLoan].LoanBook())
            {
                Console.WriteLine("Book has been loaned to you! Please take care of it or we will find you and harm your dog!");
            }
            else
            {
                Console.WriteLine("Book is not available!");
            }
        }
        catch
        {
            Console.WriteLine("Invalid Number");
            
        }
        Console.WriteLine("Press Any key to continue");
        Console.ReadKey();

    }

}