namespace BleepBloop;

public class Token
{
    public enum TokenType
    {
        //Mark finished identifiers with a coment saying "done" when they are handled.
        //The comments here will be removed before finalizing the code.
        OpenTypeIdentifier, //done
        CloseTypeIdentifier, //done

        TextType,
        ListType,
        DictionaryType,
        DynamicType,

        Quote, //done
        Colon, //done
        Seperator, //done

        OpenBracket, //done
        CloseBracket, //done

        OpenSquareBracket, //done
        CloseSquareBracket, //done

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
            output.Add(new Token(type, value));
            output.RemoveAt(0);
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
                
            }
        }

        return output;
    }
}