/* TAKES ANY TEXT AND COUNTS THE FREQUENCY OF EACH WORD
 *
 * Returns a List with the frequency of all words in the given text, sorted by frequency.
 * Punctuations are treated as whitespaces, except an apostroph that belongs to a word (so "it's" != "its").
 */

public List<string> WordCountToList(string input)
{
    List<string> cleanInput = string.Join("", input.ToLower().Select(c => (char.IsPunctuation(c) && !c.Equals('\'')) ? ' ' : c))
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Where(s => s.Count(c => c == '\'') <= 1 && !s.Equals("'"))
                                    .OrderBy(s => s).ToList();
    List<string> countedInput = new List<string>();

    if (cleanInput.Count <= 1) return cleanInput;

    int count = 1;
    for (int i = 0; i < cleanInput.Count; i++)
    {
        if(i + 1 == cleanInput.Count)
        {
            countedInput.Add(count.ToString() + " " + cleanInput[i]);
            break;
        }

        if (cleanInput[i].Equals(cleanInput[i + 1])) count++;
        else
        {
            countedInput.Add(count.ToString() + " " + cleanInput[i]);
            count = 1;
        }
    }

    return countedInput.OrderByDescending(s => int.Parse(s.Split(' ')[0])).ToList();
}
