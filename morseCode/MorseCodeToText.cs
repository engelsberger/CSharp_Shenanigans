public string MorseCodeToText(string morseCode)
{
    //#0 PREDEFINE MORSE CODES

    string[] morseCodeData = new string[]
    {
        //Letters
        "A .-",
        "B -...",
        "C -.-.",
        "D -..",
        "E .",
        "F ..-.",
        "G --.",
        "H ....",
        "I ..",
        "J .---",
        "K -.-",
        "L .-..",
        "M --",
        "N -.",
        "O ---",
        "P .--.",
        "Q --.-",
        "R .-.",
        "S ...",
        "T -",
        "U ..-",
        "V ...-",
        "W .--",
        "X -..-",
        "Y -.--",
        "Z --..",

        //Numbers
        "0 -----",
        "1 .----",
        "2 ..---",
        "3 ...--",
        "4 ....-",
        "5 .....",
        "6 -....",
        "7 --...",
        "8 ---..",
        "9 ----.",

        //Punctuation
        ". .-.-.-",
        ", --..--",
        "? ..--..",
        "' .----.",
        "! -.-.--",
        "/ -..-.",
        "( -.--.",
        "[ -.--.",
        "{ -.--.",
        ") -.--.-",
        "] -.--.-",
        "} -.--.-",
        "& .-...",
        ": ---...",
        "; -.-.-.",
        "= -...-",
        "+ .-.-.",
        "- -....-",
        "_ ..--.-",
        "\" .-..-.",
        "$ ...-..-",
        "@ .--.-.",

        //Non-Latin extensions
        "À .--.-",
        "Å .--.-",
        "Ä .-.-",
        "Ą .-.-",
        "Æ .-.-",
        "Ć -.-..",
        "Ĉ -.-..",
        "Ç -.-..",
        "Ĥ ----",
        "Š ----",
        "Đ ..-..",
        "É ..-..",
        "Ę ..-..",
        "È .-..-",
        "Ł .-..-",
        "Ĝ --.-.",
        "Ĵ .---.",
        "Ń --.--",
        "Ñ --.--",
        "Ó ---.",
        "Ö ---.",
        "Ø ---.",
        "Ś ...-...",
        "Ŝ ...-.",
        "Þ .--..",
        "Ü ..--",
        "Ŭ ..--",
        "Ź --..-.",
        "Ż --..-"
    };



    /* #1 SIMPLE CONVERSION - ONELINER
     * 
     * Requires clean input
     * To use this just uncomment it.
     */

    //return string.Join("", morseCode.Split(' ').Select(code => morseCodeData.Where(data => data.Split(' ')[1].Equals(code)).Select(data => data.Split(' ')[0]).First()));



    /* #2 SIMPLE CONVERSION - ROBUST
     * 
     * Does not require clean input.
     * Non-morse-code characters will be returned 1:1 (except spaces after a morse code character)
     */

    List<string> cleanInput = new List<string>();
    string converted = string.Empty;
    string codeTemp = string.Empty;

    foreach(char c in morseCode)
    {
        if (c == '.' || c == '-')
        {
            codeTemp += c;
            continue;
        }
        else if (codeTemp != string.Empty)
        {
            cleanInput.Add(codeTemp);
            codeTemp = string.Empty;
            if (c.Equals(' ')) continue;
        }

        cleanInput.Add(c.ToString());
    }
    if (codeTemp != string.Empty) cleanInput.Add(codeTemp);

    foreach(string code in cleanInput)
    {
        bool isCode = false;
        foreach(string data in morseCodeData)
        {
            if (data.Split(' ')[1].Equals(code))
            {
                converted += data.Split(' ')[0];
                isCode = true;
                break;
            }
        }
        if (!isCode) converted += code;
    }

    return converted;
}
