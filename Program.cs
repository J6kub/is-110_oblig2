using Oblig2_Library;

static class LibraryOppgave
{
    
    static void Main()
    {
        List<Bok> booker = new List<Bok>()
        {
            new Roman("Joe", "Potatoes on dem trees", 1998, 696969696, "Fantasy"),
            new Fagbok("Stian Greni", "Psychological Awesomeness of Apes", 2024, 694208473, "Nature"),
            new Roman("J.K. Rowling", "The Wandering Wizard", 2001, 123456789, "Fantasy"),
            new Fagbok("Carl Sagan", "The Cosmos and Beyond", 1980, 987654321, "Science"),
            new Roman("George Orwell", "Future Shadows", 1949, 112233445, "Dystopian"),
            new Roman("Stian Greni", "The day i got electrocuted", 2014, 126308473, "Electricity"),
            new Fagbok("Stephen Hawking", "Black Holes and Time Warps", 1994, 556677889, "Physics"),
            new Roman("Leo Tolstoy", "The Eternal Struggle", 1869, 998877665, "Historical Fiction")
        };
        
        Library Biblio = new Library(booker);
        while (true)
        {
            try
            {
                Biblio.ShowMainMenu();
            }
            catch
            {
                Console.Clear();
            }
        }
        
        
    }
}