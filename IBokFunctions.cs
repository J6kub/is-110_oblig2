namespace Oblig2_Library;

public class IBokFunctions
{
    public bool Available = true;

   

    public bool LoanBook()
    {
        if (this.Available == true)
        {
            this.Available = false;
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
        this.Available = true;
        //Console.WriteLine("The book is now returned to library!");
        return true;
    }

    protected string AvailableString()
    {
        if (this.Available == true)
        {
            return "Available";
        }
        else
        {
            return "Not Available";
        }
    }
}