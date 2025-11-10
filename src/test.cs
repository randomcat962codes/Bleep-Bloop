using BleepBloop;
using SimpleEncoding;

class Program
{
    static void Main()
    {
        List<Token> test = Lexer.Parse(File.ReadAllText("test.save"));
        foreach (Token token in test)
        {
            Console.WriteLine($"{token.Type()} {token.Value()}");
        }
    }
}