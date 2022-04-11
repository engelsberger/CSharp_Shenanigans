public string TextToMorseCode(string text)
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



    //#1 SIMPLE CONVERSION - ONELINER

    return string.Join(" ", text.ToUpper().Select(ch => string.Join("", morseCodeData.Where(code => code.Split(' ')[0].Equals(ch.ToString())).Select(code => code.Split(' ')[1]))));

    /* STEP 1: text.ToUpper().Select(ch => ...)
     * Makes text case-insensitive and runs through every char with Select().
     * Select() contains a lambda expression which takes the current char as input.
     * 
     * STEP 2: morseCodeData.Where(code => code.Split(' ')[0].Equals(ch.ToString()).Select(code => code.Split(' ')[1])
     * This code is located within the Select() from STEP 1 so it runs for every char in the input text.
     * morseCodeData                Takes predefined morse code data
     * .Where(code =>               Sets a condition with a lambda expression (runs through every string in morseCodeData)
     * code.Split(' ')[0]           Takes the Unicode part of the morse code
     * .Equals(ch.ToString())       and compares it to the input char (ToString() because code.Split(' ')[0] returns a string
     * .Select(code =>              Runs through all morse codes where the .Where() condition is true
     * code.Split(' ')[1])          selects the corresponding encoded string from morseCodeData and returns it in an IEnumerable<string>
     * 
     * STEP 3: string.Join("", STEP2)
     * Since we get an IEnumerable of type string from STEP 2, we need to convert it to a single string.
     * This is done with string.Join(). 
     * 
     * STEP 4: return string.Join(" ", PREVIOUSSTEPS)
     * From the previous steps we get an IEnumerable of type string which contains all converted characters.
     * Just join it to a single string with space as separator and job done.
     */



    //#2 SIMPLE CONVERSION - EASIER TO UNDERSTAND

    string output = string.Empty;
    foreach (char ch in text.ToUpper())
    {
        foreach (string code in morseCodeData)
        {
            if (code.Split(' ')[0].Equals(ch.ToString()))
            {
                output += code.Split(' ')[1] + " ";
                break;
            }
        }
    }
    return output.Trim();

    /* STEP 1: string output = string.Empty;
     * Declare an empty string to which we will add the converted data bit by bit.
     * 
     * STEP 2: foreach(char c in text.ToUpper())
     * Make text case-insensitive and run through every char in text.
     * 
     * STEP 3: foreach(string code in morseCodeData)
     * This code is within STEP 2, so it will run through all MorseCodes for each char in text.
     * 
     * STEP 4: if (code.Split(' ')[0].Equals(ch.ToString()))
     * Set the condition that the Unicode part of the given morse code must be equal to the current char.
     * 
     * STEP 5: output += code.Split(' ')[1] + " ";
     * If condition in STEP 4 is fullfilled, add the encoded part of the current morse code data to our output
     * and break the morseCodeData-foreach-loop (since one char has only one counterpart in morse code alphabet)
     * 
     * STEP 6: return output.Trim();
     * Trim the output (removes excess spaces at beginning and end of the string) and return it. Job done.
     */
}
