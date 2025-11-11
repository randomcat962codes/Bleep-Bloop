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

        void AddToOutput(char notation)
        {
            output += $"{notation}{Convert.ToString(GetIndex(encodings[notation], content[0]))}";
            content.RemoveAt(0);
        }

        //Parses and encodes text
        while (content.Count > 0)
        {
            if (encodings['C'].Contains(content[0])) AddToOutput('C');
            else if (encodings['L'].Contains(content[0])) AddToOutput('L');
            else if (encodings['N'].Contains(content[0])) AddToOutput('N');
            else if (encodings['P'].Contains(content[0])) AddToOutput('P');
            else if (encodings['S'].Contains(content[0])) AddToOutput('S');
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
            else //There was an error parsing the content
            {
                Console.Error.WriteLine("There was an error decoding content.\nPlease make sure the content is formatted correcly and actually encoded.\nOtherwise, your on your own. I have no idea what's wrong.");
                Environment.Exit(2);
            }
        }

        return output;
    }
}