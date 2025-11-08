namespace BleepBloop;

public static class CharEncoding
{
    private static Dictionary<char, char[]> encodings = new() //This dictionary contains encoding information
    {
        {'C', ['A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z']},
        {'L', ['a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z']},
        {'N', ['1','2','3','4','5','6','7','8','9','0']},
        {'P', ['.',',','!','?']},
        {'S', [' ','~','`','@','#','$','%','^','&','*','(',')','_','-','+','=','|','\\','{','}','[',']',':',';','"','\'','<','>','/']}
    };

    //Why does char[] not have an IndexOf() function?
    private static int GetIndex(char[] arr, int index)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == index)
            {
                return i;
            }
        }
        return -1;
    }

    public static string Encode(string input)
    {
        List<char> content = input.ToList();
        string output = "";

        //Parses and encodes text
        while (content.Count > 0)
        {
            if (encodings['C'].Contains(content[0]))
            {
                output += $"C{Convert.ToString(GetIndex(encodings['C'], content[0]))}";
                content.RemoveAt(0);
            }
            else if (encodings['L'].Contains(content[0]))
            {
                output += $"L{Convert.ToString(GetIndex(encodings['L'], content[0]))}";
                content.RemoveAt(0);
            }
            else if (encodings['N'].Contains(content[0]))
            {
                output += $"N{Convert.ToString(GetIndex(encodings['N'], content[0]))}";
                content.RemoveAt(0);
            }
            else if (encodings['P'].Contains(content[0]))
            {
                output += $"P{Convert.ToString(GetIndex(encodings['P'], content[0]))}";
                content.RemoveAt(0);
            }
            else if (encodings['S'].Contains(content[0]))
            {
                output += $"S{Convert.ToString(GetIndex(encodings['S'], content[0]))}";
                content.RemoveAt(0);
            }
            else //Unrecognized character found
            {
                Console.Error.WriteLine($"Error!\nUnrecognized character found in input: {content[0]}\nBleepBoop currently does not support this character.");
                Environment.Exit(1);                
            }
        }

        return output;
    }

    public static string Decode(string input)
    {
        char[] encodingNotation = encodings.Keys.ToArray();

        List<char> content = input.ToList();
        string output = "";

        //Parses and decodes text
        while (content.Count > 0)
        {
            if (encodingNotation.Contains(content[0]))
            {
                char notation = content[0];

                content.RemoveAt(0);

                string charIndexBuild = "";

                if (content.Count == 0) break;

                while (content.Count > 0 && char.IsDigit(content[0]))
                {
                    charIndexBuild += content[0];
                    content.RemoveAt(0);
                }

                int charIndex = Convert.ToInt32(charIndexBuild);

                output += encodings[notation][charIndex];
            }
        }

        return output;
    }
}