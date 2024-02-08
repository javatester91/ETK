using Program;

public class MainProgram
{
    public static void Main()
    {
        Console.WriteLine(StringExtensionNew.WithoutExistingSubstringFixed("test", "tes").ToString());
    }
}
