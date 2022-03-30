public string LettersToAlphabetPosition(string text)
{

    // #1 CONVERT LETTERS TO ALPHABET POSITION SEPARATED WITH SPACE - IGNORE NON-LETTER CHARACTERS

    return string.Join(" ", text.ToLower().Where(char.IsLetter).Select(c => c - 'a' + 1));

    /* #1 STEP 1: text.ToLower()
     * Convert all letters to lower case, since in Unicode char 'a' has a different position than char 'A'
     * 
     * #1 STEP 2: #1STEP1.Where(char.IsLetter)
     * Get every char in string "text" that is categorized as a Unicode letter (this also includes
     * special letters like ø or ñ, but for these the calculated position in the alphabet won't be correct)
     * 
     * #1 STEP 3: #1STEP2.Select(c => c)
     * .Select() will be executed for each char c found by the .Where() function.
     * "c" is simply the variable name you give the char, you can also name this "x" or "geoff".
     * The "=>" indicates a so called lambda expression, which basically takes input parameters on the left
     * and a code sequence on the right and puts out a type IEnumerable<>, which can be seen
     * as a list containing all output values.
     * (WARNING: type "IEnumerable<>" is not the same as type "List<>", for more info here check microsoft docs)
     * 
     * #1 STEP 4: #1STEP2.Select(c => c - 'a' + 1)
     * Input (from lambda expression): char 'c'. Expected Output: alphabet position as integer
     * We can get that by simply subtracting char 'a' from our input char and adding 1.
     * This converts the char variables to their relative integers according to the ASCII list
     * Ex: input is 'c'
     *     'd' - 'a' + 1    >int value for 'd' is 100 and 'a' is 97 (check ASCII list)
     *     100 - 97 + 1 = 2  >output value for input 'd' is 4 - alphabet position found
     * 
     * #1 STEP 5: string.Join(" ", #1STEP4);
     * .Join() gets all output values and joins them together to a string, different values separated by
     * a whitespace. The separation string can be anything, from nothing "" to full descriptions "\r\nNext:"
     * 
     * #1 STEP 6: return #1STEP5
     * Returns the string we got from the string.Join() function. Job done.
     */



    //#2 ADD A LINEBREAK AFTER A WORD - ONELINER

    return string.Join("\r\n", text.ToLower().Split(' ').Select(word => string.Join(" ", word.Where(char.IsLetter).Select(c => c - 'a' + 1))));

    /* #2 STEP 1: text.ToLower().Split(' ')
     * Get input text and convert it to lower case letters (to make the code case insensitive).
     * string.Split() returns a string array where the original array is split by the specified char (in this case whitespace)
     * 
     * #2 STEP 2: #2STEP1.Select(word => #1)
     * .Select() gets a string array from .Split() and runs through every string in there.
     * Lambda expression as mentioned in #1 STEP 3 has input variable "word" as string and does for each word
     * basically the same thing #1 does (convert letters to alphabet positions).
     * 
     * #2 STEP 3: string.Join("\r\n", #2STEP2)
     * Gets an IEnumerator<string> (which can be treated as list here - not the same though) containing the
     * converted words, puts them together and puts linebreaks in between.
     * 
     * #2 STEP 4: return #2STEP3
     * Returns the converted words separated by a linebreak. Job done.
     */



    //#2 ADD A LINEBREAK AFTER A WORD - WRITTEN EASIER TO UNDERSTAND

    string[] words = text.ToLower().Split(' ');
    IEnumerable<string> convertedWords = words.Select(word =>
    {
        IEnumerable<int> alphabetValues = word.Where(char.IsLetter).Select(c => c - 'a' + 1);
        string convertedWord = string.Join(" ", alphabetValues);
        return convertedWord;
    });
    string output = string.Join("\r\n", convertedWords);
    return output;

    /* words:
     * A string array containing the (lowercase) input string split by spaces
     * 
     * convertedWords:
     * An IEnumerable<string> containing strings with the converted words. Basically ran Method #1 over
     * every word in string[] words and put the output strings together here.
     * 
     * alphabetValues: (created for every word in string[] words)
     * An IEnumerable of type int, containing the integer alphabet position for each letter in a word.
     * Determined by using Method #1.
     * 
     * convertedWord: (created for every word in string[] words)
     * A string containing the alphabet positions for each letter in a word, separated by spaces.
     * 
     * output:
     * contains the full output, where each converted word is separated by a linebreak.
     */



    //#3 CONVERT LETTERS TO ALPHABET POSITION SEPARATED WITH SPACE - KEEP NON-LETTER CHARACTERS

    return string.Join("", text.ToLower().Select(c => char.IsLetter(c) ? ((c - 'a' + 1).ToString() + " ") : c.ToString())).Trim();

    /* #3 STEP 1: text.ToLower().Select(c => c)
     * Make text case insensitive and run a lambda expression over every single character in the input string.
     * 
     * #3 STEP 2: char.IsLetter(c) ? doThis : doThat
     * Checks if input character (gotten from the lambda expression) is considered a Unicode letter and decides
     * what to do. This line of code can be read as:
     * IF char.IsLetter(c) THEN doThis OTHERWISE doThat
     * 
     * #3 STEP 3: ? (c - 'a' + 1).ToString() + " "
     * Executed if char.IsLetter(c) is true.
     * (c - 'a' + 1) explained in #1 STEP 4
     * Convert it to a string so the output IEnumerable from .Select() (#3 STEP 1) is of type string
     * and add a space so the different numbers are separated (easier to read)
     * 
     * #3 STEP 4: : c.ToString()
     * Executed if char.IsLetter(c) is false.
     * Simply converts the char to a string (to match IEnumerable type).
     * 
     * #3 STEP 5: string.Join("", STEP1(c => char.IsLetter(c) ? STEP3 : STEP4))
     * The IEnumerable handed over by STEP1 contains every converted letter as well as all non-letter characters
     * in order. Just join them together without a separator.
     * 
     * #3 STEP 6: return STEP5.Trim();
     * .Trim() removes any excess space chars at beginning and end of the output string.
     * Return that and job done.
     */
}
