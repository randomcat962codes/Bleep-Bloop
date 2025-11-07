namespace BleepBloop;

private static class encoding
{
    private static Dictionary<char, char[]> encodings = new() //This dictionary contains encoding information
    {
        {'C', ['A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z']},
        {'L', ['a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z']},
        {'N', ['1','2','3','4','5','6','7','8','9','0']},
        {'P', ['.',',','!','?']},
        {'S', [' ','~','`','@','#','$','%','^','&','*','(',')','_','-','+','=','|','\\','{','}','[',']',':',';','"','\'','<','>','/']}
    };

    public static string Encode(string input)
    {
        char[] content = input.ToList();
        string output = "";

        //Parses text and converts it
        while (content.Count > 0)
        {
            if (content[0] == 'C')
            {

            }
            else if (content[0] == 'L')
            {

            }
            else if (content[0] == 'N')
            {

            }
            else if (content[0] == 'P')
            {

            }
            else if (content[0] == 'S')
            {

            }
        }
    }
}