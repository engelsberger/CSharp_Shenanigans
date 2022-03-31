//Create a class MorseCode which contains all morse codes and their Unicode equivalent.
public class MorseCode
{
    public char decoded;
    public string encoded;

    public MorseCode(char decoded, string encoded)
    {
        this.decoded = decoded;
        this.encoded = encoded;
    }
}


class Program
{
    //contains all morse codes predefined in SetMorseCodes()
    MorseCode[] morseCodeData = SetMorseCodes();
    
    
    public string TextToMorseCode(string text)
    {
        //#1 SIMPLE CONVERSION - ONELINER

        return string.Join(" ", text.ToUpper().Select(chIn => string.Join("", morseCodeData.Where(code => code.decoded.Equals(chIn)).Select(code => code.encoded))));

        /* STEP 1: text.ToUpper().Select(chIn => ...)
         * Makes text case-insensitive and runs through every char with Select().
         * Select() contains a lambda expression which takes the current char as input.
         * 
         * STEP 2: morseCodeData.Where(code => code.decoded.Equals(chIn)).Select(code => code.encoded)
         * This code is located within the Select() from STEP 1 so it runs for every char in the input text.
         * morseCodeData                Takes predefined morse code data
         * .Where(code =>               Sets a condition with a lambda expression (runs through every morse code)
         * code.decoded.Equals(chIn))   Checks if current code.decoded value equals the current char from input text
         * .Select                      Selects all morse codes where the .Where() condition is true
         * (code => code.encoded)       selects the encoded string from given morse code and returns an IEnumerable<string>
         * 
         * STEP 3: string.Join("", STEP2)
         * Since we get an IEnumerable of type string from STEP 2, we need to convert it to a string.
         * This is done with string.Join(). 
         * 
         * STEP 4: return string.Join(" ", PREVIOUSSTEPS)
         * From the previous steps we get an IEnumerable of type string which contains all converted characters.
         * Just join it to a single string with space as separator and job done.
         */



        //#2 SIMPLE CONVERSION - EASIER TO UNDERSTAND

        string output = string.Empty;
        foreach(char c in text.ToUpper())
        {
            foreach(MorseCode code in morseCodeData)
            {
                if(code.decoded.Equals(c))
                {
                    output += code.encoded + " ";
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
         * STEP 3: foreach(MorseCode code in morseCodeData)
         * This code is within STEP 2, so it will run through all MorseCodes for each char in text.
         * 
         * STEP 4: if(code.decoded.Equals(c))
         * Set the condition that the decoded part of a morse code must be equal to the current char.
         * 
         * STEP 5: output += code.encoded + " "; break;
         * If condition in STEP 4 is fullfilled, add the encoded part of the current morse code to our output
         * and break the MorseCode-foreach-loop (since one char has only one counterpart in morse code alphabet)
         * 
         * STEP 6: return output.Trim();
         * Trim the output (removes excess spaces at beginning and end of the string) and return it. Job done.
         */
    }
    
    
    public static MorseCode[] SetMorseCodes()
    {
        return new MorseCode[]
        {
            //Letters
            new MorseCode('A', ".-"),
            new MorseCode('B', "-..."),
            new MorseCode('C', "-.-."),
            new MorseCode('D', "-.."),
            new MorseCode('E', "."),
            new MorseCode('F', "..-."),
            new MorseCode('G', "--."),
            new MorseCode('H', "...."),
            new MorseCode('I', ".."),
            new MorseCode('J', ".---"),
            new MorseCode('K', "-.-"),
            new MorseCode('L', ".-.."),
            new MorseCode('M', "--"),
            new MorseCode('N', "-."),
            new MorseCode('O', "---"),
            new MorseCode('P', ".--."),
            new MorseCode('Q', "--.-"),
            new MorseCode('R', ".-."),
            new MorseCode('S', "..."),
            new MorseCode('T', "-"),
            new MorseCode('U', "..-"),
            new MorseCode('V', "...-"),
            new MorseCode('W', ".--"),
            new MorseCode('X', "-..-"),
            new MorseCode('Y', "-.--"),
            new MorseCode('Z', "--.."),

            //Numbers
            new MorseCode('0', "-----"),
            new MorseCode('1', ".----"),
            new MorseCode('2', "..---"),
            new MorseCode('3', "...--"),
            new MorseCode('4', "....-"),
            new MorseCode('5', "....."),
            new MorseCode('6', "-...."),
            new MorseCode('7', "--..."),
            new MorseCode('8', "---.."),
            new MorseCode('9', "----."),

            //Punctuation
            new MorseCode('.', ".-.-.-"),
            new MorseCode(',', "--..--"),
            new MorseCode('?', "..--.."),
            new MorseCode('\'', ".----."),
            new MorseCode('!', "-.-.--"),
            new MorseCode('/', "-..-."),
            new MorseCode('(', "-.--."),
            new MorseCode('[', "-.--."),
            new MorseCode('{', "-.--."),
            new MorseCode(')', "-.--.-"),
            new MorseCode(']', "-.--.-"),
            new MorseCode('}', "-.--.-"),
            new MorseCode('&', ".-..."),
            new MorseCode(':', "---..."),
            new MorseCode(';', "-.-.-."),
            new MorseCode('=', "-...-"),
            new MorseCode('+', ".-.-."),
            new MorseCode('-', "-....-"),
            new MorseCode('_', "..--.-"),
            new MorseCode('\'', ".-..-."),
            new MorseCode('$', "...-..-"),
            new MorseCode('@', ".--.-."),

            //Non-Latin extensions
            new MorseCode('À', ".--.-"),
            new MorseCode('Å', ".--.-"),
            new MorseCode('Ä', ".-.-"),
            new MorseCode('Ą', ".-.-"),
            new MorseCode('Æ', ".-.-"),
            new MorseCode('Ć', "-.-.."),
            new MorseCode('Ĉ', "-.-.."),
            new MorseCode('Ç', "-.-.."),
            new MorseCode('Ĥ', "----"),
            new MorseCode('Š', "----"),
            new MorseCode('Đ', "..-.."),
            new MorseCode('É', "..-.."),
            new MorseCode('Ę', "..-.."),
            new MorseCode('È', ".-..-"),
            new MorseCode('Ł', ".-..-"),
            new MorseCode('Ĝ', "--.-."),
            new MorseCode('Ĵ', ".---."),
            new MorseCode('Ń', "--.--"),
            new MorseCode('Ñ', "--.--"),
            new MorseCode('Ó', "---."),
            new MorseCode('Ö', "---."),
            new MorseCode('Ø', "---."),
            new MorseCode('Ś', "...-..."),
            new MorseCode('Ŝ', "...-."),
            new MorseCode('Þ', ".--.."),
            new MorseCode('Ü', "..--"),
            new MorseCode('Ŭ', "..--"),
            new MorseCode('Ź', "--..-."),
            new MorseCode('Ż', "--..-")
        };
    }
}
