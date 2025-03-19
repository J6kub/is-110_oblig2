namespace Oblig2_Library;

public class Fagbok : Bok
{
    public string fag {get; set;} 
    public Fagbok(string author, string title, int year, int isbm, string _fag) : base(author, title, isbm, year)
    {
        fag = _fag;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"[{ISBM}] {author} - {title} - {fag} - {year} - Science - {AvailableString()}");
    }

    public override string GetInfo()
    {
        return $"[{ISBM}] {author} - {title} - {fag} - {year} - Science - {AvailableString()}";
    }
}