/* RETURNS ALL POSSIBLE PERMUTATIONS OF A STRING OF CHARACTERS ORDERED ALPHABETICALLY
 *
 * Permutations are all possible arrangements of the characters.
 * Ex. input "abc", output "abc acb bac bca cab cba"
 * Returns all permutations in one string separated by whitespaces. Maximum length of input string is 10.

public string GetPermutations(string s, int start = -1, int end = -1)
{
    if (start == -1) start = 0;
    if (end == -1) end = s.Length - 1;
    
    if (s.Length > 10) return "Input too long, max 10 characters!";

    if (start == end) return s + " ";

    string p = string.Empty;
    for (int i = start; i <= end; i++)
    {
        if(s[start] != s[i])
        {
            // Swap s[start] and s[i]
            char[] charArray = s.ToCharArray();
            char temp = charArray[start];
            charArray[start] = charArray[i];
            charArray[i] = temp;
            s = new string(charArray);
        }

        p += Permutations(s, start + 1, end);
    }

    return string.Join(" ", p.Split(' ').OrderBy(c => c));
}
