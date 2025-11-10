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

    public static List<Token> Parse(string input)
    {
        List<char> content = input.ToList();
        List<Token> output = new(); 

        //Used to add the token to the output and remove the last processed character from the list
        void BuildToken(Token.TokenType type, string value)
        {
            content.Add(new Token(type, value));
            content.RemoveAt(0);
        }

        while (content.Count > 0)
        {
            //Single char tokens
            if (content[0] == '<') BuildToken(Token.TokenType.OpenTypeIdentifier, "<");
            else if (content[0] == '>') BuildToken(Token.TokenType.CloseTypeIdentifier, ">");
            else if (content[0] == '"') BuildToken(Token.TokenType.Quote, "\"");
            else if (content[0] == ':') BuildToken(Token.TokenType.Colon, ":");
            else if (content[0] == ',') BuildToken(Token.TokenType.Seperator, ",");
            else if (content[0] == '{') BuildToken(Token.TokenType.OpenBracket, "{");
            else if (content[0] == '}') BuildToken(Token.TokenType.CloseBracket, "}");
            else if (content[0] == '[') BuildToken(Token.TokenType.OpenSquareBracket, "[");
            else if (content[0] == ']') BuildToken(Token.TokenType.CloseSquareBracket, "]");
            //Multi-char tokens
            else
            {
                string buffer = "";

                while (content.Count > 0 && !"<>\":,{}[]".Contains(content[0]))
                {
                    buffer += content[0];
                    content.RemoveAt(0);
                }

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

        return output;
    }
}
