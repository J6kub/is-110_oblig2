namespace Oblig2_Library;

public abstract class Bok : IBokFunctions
{
    public string author { get; set; }
    public string title {get; set;}
    public int ISBM {get; set;}
    public int year {get; set;}
    public bool Available {get; set;} = true;

    public Bok(string _author, string _title, int _ISBM, int _year)
    {
        author = _author;
        title = _title;
        ISBM = _ISBM;
        year = _year;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"[{ISBM}] {author} - {title} - {year} - X - {AvailableString()}");
    }

    public virtual string GetInfo()
    {
        return $"[{ISBM}] {author} - {title} - {year} - X - {AvailableString()}";
    }
    
    public bool LoanBook()
    {
        if (Available == true)
        {
            Available = false;
            //Console.WriteLine("The book is now loaned to you!");
            return true;
        }
        else
        {
            //Console.WriteLine("Book not available");
            return false;
        }
        
    }
    
    public bool ReturnBook()
    {
        Available = true;
        //Console.WriteLine("The book is now returned to library!");
        return true;
    }

    public string AvailableString()
    {
        if (Available == true)
        {
            return "Available";
        }
        else
        {
            return "Not Available";
        }
    }
}