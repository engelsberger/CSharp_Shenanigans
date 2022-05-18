/* Takes a string of 0 and 1 (how a morse code is transmitted via telegraph) and converts it into readable text.
 * No input validation.
 */

class Program
{
    public static int attempts = 3;
    public static Dictionary<string, string> morseCodeData = new Dictionary<string, string>() {
        // Standard letters
        {".-", "A"},
        {"-...", "B"},
        {"-.-.", "C"},
        {"-..", "D"},
        {".", "E"},
        {"..-.", "F"},
        {"--.", "G"},
        {"....", "H"},
        {"..", "I"},
        {".---", "J"},
        {"-.-", "K"},
        {".-..", "L"},
        {"--", "M"},
        {"-.", "N"},
        {"---", "O"},
        {".--.", "P"},
        {"--.-", "Q"},
        {".-.", "R"},
        {"...", "S"},
        {"-", "T"},
        {"..-", "U"},
        {"...-", "V"},
        {".--", "W"},
        {"-..-", "X"},
        {"-.--", "Y"},
        {"--..", "Z"},

        // Numbers
        {"-----", "0"},
        {".----", "1"},
        {"..---", "2"},
        {"...--", "3"},
        {"....-", "4"},
        {".....", "5"},
        {"-....", "6"},
        {"--...", "7"},
        {"---..", "8"},
        {"----.", "9"},

        // Punctuation
        {".-.-.-", "."},
        {"--..--", ","},
        {"..--..", "?"},
        {".----.", "'"},
        {"-.-.--", "!"},
        {"-..-.", "/"},
        {"-.--.", "("},
        {"-.--.-", ")"},
        {".-...", "&"},
        {"---...", ":"},
        {"-.-.-.", ";"},
        {"-...-", "="},
        {".-.-.", "+"},
        {"-....-", "-"},
        {"..--.-", "_"},
        {".-..-.", "\""},
        {"...-..-", "$"},
        {".--.-.", "@"},

        // Non-latin extensions
        {".--.-", "À"},
        {".-.-", "Ä"},
        {"-.-..", "Ć"},
        {"----", "Š"},
        {"..-..", "Đ"},
        {".-..-", "È"},
        {"--.-.", "Ĝ"},
        {".---.", "Ĵ"},
        {"--.--", "Ñ"},
        {"---.", "Ö"},
        {"...-...", "Ś"},
        {"...-.", "Ŝ"},
        {".--..", "Þ"},
        {"..--", "Ü"},
        {"--..-.", "Ź"},
        {"--..-", "Ż"}
    };

    static void Main(string[] args)
    {
        string message = "0011001110001011000111010110001010110";

        string[] standardizedMsg = DecodeBits(message);
        foreach(string msg in standardizedMsg) { Console.WriteLine(msg); }

        string[] decodedMsg = DecodeMorse(standardizedMsg);
        foreach(string msg in decodedMsg) { Console.WriteLine(msg); }
    }

    // Takes a string of 0s and 1s and converts it into a standardized morse code string (with dots, dashes and spaces (1 for letters, 3 for words))
    public static string[] DecodeBits(string bits)
    {
        // Check if there is a message at all
        if (!bits.Contains('1')) return null; ;

        // First assign the different bit values to 2 clusters
        string[] dotsNdashes = bits.Split('0', StringSplitOptions.RemoveEmptyEntries);
        List<string> cluster1 = dotsNdashes.Take(dotsNdashes.Length / 2).ToList();
        List<string> cluster2 = dotsNdashes.Skip(dotsNdashes.Length / 2).ToList();

        // Then use the k-means algorithm to sort the values into dots and dashes
        // https://visualstudiomagazine.com/articles/2013/12/01/k-means-data-clustering-using-c.aspx?m=2
        bool sorted = false;
        int count = 0;
        while (!sorted)
        {
            // Calculate means of each cluster
            float mean1 = (float)cluster1.Select(c => c.Length).Sum() / cluster1.Count;
            float mean2 = (float)cluster2.Select(c => c.Length).Sum() / cluster2.Count;

            // Assign all elements to their closest mean
            sorted = true;
            for (int i = 0; i < cluster1.Count; i++)
            {
                if (Math.Abs(cluster1[i].Length - mean2) < Math.Abs(cluster1[i].Length - mean1))
                {
                    cluster2.Add(cluster1[i]);
                    cluster1.Remove(cluster1[i]);
                    sorted = false;
                }
            }
            for (int i = 0; i < cluster2.Count; i++)
            {
                if (Math.Abs(cluster2[i].Length - mean1) < Math.Abs(cluster2[i].Length - mean2))
                {
                    cluster1.Add(cluster2[i]);
                    cluster2.Remove(cluster2[i]);
                    sorted = false;
                }
            }

            // Failsafe
            if (count < 1000) count++;
            else break;
        }

        // Attempt to get a standardized message from the given bits
        string[] standardizedMsg = new string[attempts];
        List<int> dotLength = cluster1[0].Length < cluster2[0].Length ? cluster1.Select(c => c.Length).Distinct().ToList() : cluster2.Select(c => c.Length).Distinct().ToList();
        List<int> dashLength = cluster1[0].Length < cluster2[0].Length ? cluster2.Select(c => c.Length).Distinct().ToList() : cluster1.Select(c => c.Length).Distinct().ToList();
        bool standardized = false;
        int attemptsDone = 0;
        count = 0;

        while (!standardized)
        {
            Console.WriteLine();
            foreach(int d in dotLength) { Console.Write(d + " "); }
            Console.WriteLine();
            foreach(int d in dashLength) { Console.Write(d + " "); }
            Console.WriteLine();

            // Convert the input bits to a standardized morse code message
            char current = '1';
            string msg = string.Empty;
            string temp = string.Empty;
            foreach (char c in bits.Trim('0'))
            {
                if (c != current)
                {
                    if (temp.Contains('0') && dashLength.Count == 0) msg += " ";
                    else if (temp.Contains('0') && dashLength.Contains(temp.Length)) msg += " ";
                    else if (temp.Contains('0') && temp.Length > dashLength.Max()) msg += "   ";
                    else if (temp.Contains('1') && dotLength.Count > 0 && dotLength.Contains(temp.Length)) msg += ".";
                    else if (temp.Contains('1') && dashLength.Count > 0 && dashLength.Contains(temp.Length)) msg += "-";

                    temp = string.Empty;
                    current = c;
                }

                temp += c;
            }

            if (dotLength.Contains(temp.Length)) msg += ".";
            else if (dashLength.Contains(temp.Length)) msg += "-";

            // Check if the found letters exist
            bool shift = false;
            standardized = true;
            foreach (string letter in msg.Split(" ", StringSplitOptions.RemoveEmptyEntries))
            {
                Console.WriteLine(letter + " KeyOK: " + morseCodeData.ContainsKey(letter));
                if (!morseCodeData.ContainsKey(letter))
                {
                    shift = true;
                    standardized = false;
                    break;
                }
            }

            if (standardized && attemptsDone < attempts)
            {
                standardizedMsg[attemptsDone] = msg;

                shift = true;
                standardized = false;
                attemptsDone++;
            }

            if (shift)
            {
                // Shift values between dot- and dashLength
                if (count % 2 == 0)
                {
                    for (int i = 0; i < count + 1; i++)
                    {
                        if (dashLength.Count == 0) break;
                        dotLength.Add(dashLength.Min());
                        dashLength.Remove(dashLength.Min());
                    }
                }
                else
                {
                    for (int i = 0; i < count + 1; i++)
                    {
                        if (dotLength.Count == 0) break;
                        dashLength.Add(dotLength.Max());
                        dotLength.Remove(dotLength.Max());
                    }
                }
            }

            // Failsafe
            if (count < 1000) count++;
            else break;
        }

        // Return standardized message
        return standardizedMsg.Where(s => s != "").ToArray();
    }

    // Takes a standardized morse code string and returns a readable text
    public static string[] DecodeMorse(string[] morseCode)
    {
        if (morseCode == null) return null;

        string[] decodedMsg = new string[morseCode.Length];

        for(int i = 0; i < morseCode.Length; i++)
        {
            string decoded = string.Empty;
            string[] words = morseCode[i].Split("   ");

            foreach (string word in words)
            {
                foreach (string letter in word.Split(" "))
                {
                    decoded += morseCodeData[letter];
                }
                decoded += " ";
            }

            decodedMsg[i] = decoded;
        }

        return decodedMsg;
    }
}
