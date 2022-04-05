/* CONVERTS WRITTEN OUT NUMBERS TO THEIR INT VALUES
 *
 * For example: "four thousand sixty-two" will be converted to 4062.
 * Minimum number is zero, maximum number is a billion (inclusive). Everything above or below will be clamped.
 * Has input validation, if any word does not represent a number it will return -1.
 * Exception: "and" can be added (ex. four hundred and twenty) and still be valid.
 */

public static int ParseInt(string s)
{
    // Assign numbers to certain words
    string[] numData = new string[] {
        "1 one", "2 two", "3 three", "4 four", "5 five",
        "6 six", "7 seven", "8 eight", "9 nine",
        "10 ten", "20 twenty", "30 thirty", "40 fourty", "50 fifty",
        "60 sixty", "70 seventy", "80 eighty", "90 ninety"
    };

    // Special cases
    if (s.ToLower().Contains("zero") || s.ToLower().Contains("minus")) return 0;
    if (s.ToLower().Contains("billion")) return 1000000000;

    // Validate Input
    if (s.ToLower().Split(' ').Where(s => 
        numData.Where(n => s.Contains('-') ? (n.Contains(s.Split('-')[0]) && numData.Where(m => m.Contains(s.Split('-')[1])).Count() > 0) : n.Contains(s)).Count() == 0
        && !s.Equals("hundred") && !s.Equals("thousand") && !s.Equals("million") && !s.Equals("and"))
        .Count() > 0) return -1;


    // START CONVERSION
    string[] input = s.ToLower().Split(' ').Where(s => !s.Equals("and")).ToArray();
    int output = 0;
    int mod = 0;    // 0 .. one, 1 .. hundred, 2 .. thousand, 3 .. hundred thousand, 4 .. million, 5 .. hundred million

    for (int i = input.Length - 1; i >= 0; i--)
    {
        int num = 0;

        if (!input[i].Equals("hundred") && !input[i].Equals("thousand") && !input[i].Equals("million"))
        {
            num = input[i].Contains("-")
                    ? int.Parse(numData.Where(s => s.Split(' ')[1].Equals(input[i].Split('-')[0])).Select(s => s.Split(' ')[0]).First())
                      + int.Parse(numData.Where(s => s.Split(' ')[1].Equals(input[i].Split('-')[1])).Select(s => s.Split(' ')[0]).First())
                    : int.Parse(numData.Where(s => s.Split(' ')[1].Equals(input[i])).Select(s => s.Split(' ')[0]).First());
        }
        else
        {
            mod = input[i].Equals("hundred") ? 1 : input[i].Equals("thousand") ? 2 : input[i].Equals("million") ? 4 : 0;
            if (input[i].Equals("hundred") && i + 1 < input.Length && input[i + 1].Equals("thousand")) mod = 3;
            if (input[i].Equals("hundred") && i + 1 < input.Length && input[i + 1].Equals("million")) mod = 5;
        }

        output += num * (mod == 1 ? 100 : mod == 2 ? 1000 : mod == 3 ? 100000 : mod == 4 ? 1000000 : mod == 5 ? 100000000 : 1);
    }

    return output;
}
