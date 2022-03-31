/* CONTAINS TWO FUNCTIONS:
 * 
 * public string AlphabetPositionsToLetters(string positions)
 * public string AlphabetPositionsToLetters(int[] positions)
 *
 * You can simply copy both into your code and use whichever you like.
 * (This is called overloading a fuction, see https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/member-overloading)
 */


public string AlphabetPositionsToLetters(string positions)
{

    /* #1 SIMPLE CONVERSION FROM STRING INPUT - ONELINER
     * 
     * Assumes numbers are separated with spaces
     * Ignores parts that contain non-number characters
     */

    //return string.Join("", positions.Split(' ').Where(str => int.TryParse(str, out int num)).Select(pos => (char)(int.Parse(pos) + 'a' - 1)));



    /* #2 SIMPLE CONVERSION FROM STRING INPUT - ROBUST
     * 
     * Does not require clean input
     * Non-number characters are passed on 1:1, except spaces after a number
     */

    string converted = string.Empty;
    string numTemp = string.Empty;

    foreach(char c in positions)
    {
        if (char.IsNumber(c) && numTemp.Length < 2)
        {
            numTemp += c;
            continue;
        }
        else if (numTemp != string.Empty)
        {
            int pos = int.Parse(numTemp);
            if (pos >= 1 && pos <= 26) converted += (char)(pos + 'a' - 1);
            else converted += pos.ToString();
            numTemp = string.Empty;

            if (c.Equals(' ')) continue;
            else if (char.IsNumber(c))
            {
                numTemp += c;
                continue;
            }
        }

        converted += c.ToString();
    }
    if (numTemp != string.Empty)
    {
        int pos = int.Parse(numTemp);
        if (pos >= 1 && pos <= 26) converted += (char)(pos + 'a' - 1);
        else converted += pos.ToString();
    }

    return converted;
}

public string AlphabetPositionsToLetters(int[] positions)
{
    /* #1 SIMPLE CONVERSION FROM INT ARRAY INPUT - ONELINER
     */

    return string.Join("", positions.Select(i => i + 'a' - 1));
}
