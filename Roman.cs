namespace Oblig2_Library;

public class Roman : Bok 
{
    public string genre {get; set;} 
    public Roman(string author, string title, int year, int isbm, string _genre) : base(author, title, isbm, year)
    {
        genre = _genre;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"[{ISBM}] {author} - {title} - {genre} - {year} - Novel - {AvailableString()}");
    }

    public override string GetInfo()
    {
        return $"[{ISBM}] {author} - {title} - {genre} - {year} - Novel - {AvailableString()}";
    }
}