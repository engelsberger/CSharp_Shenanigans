/* TAKES A STRING AND CHECKS ITS BRACKETS
 *
 * Returns "Bracket check successful" on successful check,
 * returns "Missing brackets: xxxx" if brackets can simply be added at the end of the string
 * returns "Bad bracket "x" at index x" the first bad bracket detected (a "bad" bracket is a closing one without an opening one before)

static string BracketChecker(string s)
{
    int parantehses = 0;    // ()
    int square = 0;         // []
    int angle = 0;          // <>
    int curly = 0;          // {}

    for(int i = 0; i < s.Length; i++)
    {
        switch (s[i])
        {
            case '(': 
                parantehses++;
                break;
            case ')':
                parantehses--;
                break;
            case '[':
                square++;
                break;
            case ']':
                square--;
                break;
            case '<':
                angle++;
                break;
            case '>':
                angle--;
                break;
            case '{':
                curly++;
                break;
            case '}':
                curly--;
                break;
        }

        if (parantehses < 0 || square < 0 || angle < 0 || curly < 0) return "Bad bracket \"" + s[i] + "\" at index " + i.ToString();
    }

    string missingBrackets = string.Empty;
    if (parantehses != 0) missingBrackets += string.Concat(Enumerable.Repeat(parantehses > 0 ? ")" : "(", parantehses));
    if (square != 0) missingBrackets += string.Concat(Enumerable.Repeat(square > 0 ? "]" : "[", square));
    if (angle != 0) missingBrackets += string.Concat(Enumerable.Repeat(angle > 0 ? ">" : "<", angle));
    if (curly != 0) missingBrackets += string.Concat(Enumerable.Repeat(curly > 0 ? "}" : "{", curly));

    return missingBrackets != string.Empty ? "Missing brackets: " + missingBrackets.Trim() : "Bracket check successful";
}
