using BleepBloop;
using SimpleEncoding;

// I don't know why errors are showing in intellisense.
// The program runs fine.

// This will create a file in the running direcctory called "output".
// It parses the content in test.save (an example file,) and shows the results there.

List<Token> test = Lexer.Parse(File.ReadAllText("test.save"));

string[] lines = new string[test.Count];

for (int i = 0; i < lines.Length; i++)
{
    lines[i] = $"{test[i].Value()} | {test[i].Type()}";
}

File.WriteAllLines("output", lines);