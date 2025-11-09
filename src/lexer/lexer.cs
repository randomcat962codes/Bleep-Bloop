namespace BleepBloop;

public class Token
{
    public enum TokenType
    {
        OpenTypeIdentifier,
        CloseTypeIdentifier,

        TextType,
        ListType,
        DictionaryType,

        Quote,
        Colon,
        Seperator,

        OpenBracket,
        CloseBracket,

        OpenSquareBracket,
        CloseSquareBracket,

        Identifier,
    }

    private TokenType type;
    public TokenType Type()
    {
        return type;
    }

    private string value;
    public string Value()
    {
        return value;
    }

    public Token(TokenType t, string v)
    {
        type = t;
        value = v;
    }
}

public static class Lexer
{
    
}