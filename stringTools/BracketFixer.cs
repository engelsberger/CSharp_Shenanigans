/* TAKES A STRING AND ATTEMPTS TO FIX ITS BRACKETS
 *
 * Will return the corrected string
 * - "bad" brackets (closers without an opener) will be removed
 * - adds missing closing brackets at the end

public string BracketFixer(string s)
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
                if (parantehses < 0) { parantehses = 0; s = s.Remove(i, 1); }
                break;
            case '[':
                square++;
                break;
            case ']':
                square--;
                if (square < 0) { square = 0; s = s.Remove(i, 1); }
                break;
            case '<':
                angle++;
                break;
            case '>':
                angle--;
                if (angle < 0) { angle = 0; s = s.Remove(i, 1); }
                break;
            case '{':
                curly++;
                break;
            case '}':
                curly--;
                if (curly < 0) { curly = 0; s = s.Remove(i, 1); }
                break;
        }
    }

    string missingBrackets = "";
    if (parantehses != 0) missingBrackets += string.Concat(Enumerable.Repeat(parantehses > 0 ? ")" : "(", parantehses));
    if (square != 0) missingBrackets += string.Concat(Enumerable.Repeat(square > 0 ? "]" : "[", square));
    if (angle != 0) missingBrackets += string.Concat(Enumerable.Repeat(angle > 0 ? ">" : "<", angle));
    if (curly != 0) missingBrackets += string.Concat(Enumerable.Repeat(curly > 0 ? "}" : "{", curly));

    return s + missingBrackets;
}
