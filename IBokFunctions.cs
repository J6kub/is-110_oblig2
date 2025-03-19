namespace Oblig2_Library;

public interface IBokFunctions
{
    bool LoanBook();
    bool ReturnBook();
    string AvailableString();
    void ShowInfo();
    string GetInfo();
}