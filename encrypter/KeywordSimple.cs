/* ENCRYPTION WITH A KEYWORD
 *
 * Targeted towards treasure hunts. Works as following:
 * For every letter text[n] in text adds the alphabet position of corresponding letter key[n] (if text.Length > key.Length key gets repeated)
 * Ex: letter 'a', key letter 'e' => a(1) + e(5) = f(6)
 * If output letter is greater 26, just loop back to start (ex: 27 becomes a(1))
 * Happy treasure hunting!
 */

public string KeywordEncrypt(string text, string key)
{
    key = key.ToLower();
    string output = string.Empty;
    int i = 0;
    foreach(char c in text.ToLower())
    {
        output += char.IsLetter(c) ? (c + (key[i] - 'a' + 1) <= 'z' ? (char)(c + (key[i] - 'a' + 1)) : (char)(c + (key[i] - 'a' + 1) - 26)) : c;
        i = i + 1 < key.Length ? i + 1 : 0;
    }
    return output;
}

public string KeywordDecrypt(string text, string key)
{
    key = key.ToLower();
    string output = string.Empty;
    int i = 0;
    foreach (char c in text.ToLower())
    {
        output += char.IsLetter(c) ? (c - (key[i] - 'a' + 1) >= 'a' ? (char)(c - (key[i] - 'a' + 1)) : (char)(c - (key[i] - 'a' + 1) + 26)) : c;
        i = i + 1 < key.Length ? i + 1 : 0;
    }
    return output;
}
