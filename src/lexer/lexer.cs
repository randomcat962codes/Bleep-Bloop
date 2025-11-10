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
        DynamicType,

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
    private static Dictionary<string, Token.TokenType> reservedKeywords = new() 
    {
        {"TXT", Token.TokenType.TextType},
        {"LST", Token.TokenType.ListType},
        {"DCT", Token.TokenType.DictionaryType},
        {"DYN", Token.TokenType.DynamicType}
    };

    public static Token[] Parse(string input)
    {
        int index = 0;
        List<Token> output = new();

        void Advance() => index++;
        void BuildToken(Token.TokenType type, string value) => output.Add(new Token(type, value));

        while (index < input.Length)
        {
            if (input[index] == ' ' || input[index] == '\t' || input[index] == '\0') Advance();
            //Single char tokens
            else if (input[index] == '<')
            {
                BuildToken(Token.TokenType.OpenTypeIdentifier, "<");
                Advance();
            }
            else if (input[index] == '>')
            {
                BuildToken(Token.TokenType.CloseTypeIdentifier, ">");
                Advance();
            }
            else if (input[index] == '"') BuildToken(Token.TokenType.Quote, "\"");
            else if (input[index] == ':') BuildToken(Token.TokenType.Colon, ":");
            else if (input[index] == ',') BuildToken(Token.TokenType.Seperator, ",");
            else if (input[index] == '{') BuildToken(Token.TokenType.OpenBracket, "{");
            else if (input[index] == '}') BuildToken(Token.TokenType.CloseBracket, "}");
            else if (input[index] == '[') BuildToken(Token.TokenType.OpenSquareBracket, "[");
            else if (input[index] == ']') BuildToken(Token.TokenType.CloseSquareBracket, "]");
            //Multi-char tokens
            else
            {
                string buffer = "";

                while (index < input.Length && !"<>\":,{}[] ".Contains(input[index]))
                {
                    buffer += input[index];
                    Advance();
                }

                if (!string.IsNullOrWhiteSpace(buffer))
                {
                    if (reservedKeywords.ContainsKey(buffer))
                    {
                        BuildToken(reservedKeywords[buffer], buffer);
                    }
                    else
                    {
                        output.Add(new Token(Token.TokenType.Identifier, buffer));
                    }
                }
            }
        }

        return output.ToArray();
    }
}
