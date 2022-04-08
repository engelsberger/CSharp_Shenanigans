/* TAKES TWO INTEGERS AS STRINGS AND ADDS THEM
 *
 * This function does not have a limit to the size of the given numbers.
 * Returns null if input is invalid.
 */

static string Add(string a, string b)
{
    System.Numerics.BigInteger aInt;
    System.Numerics.BigInteger bInt;

    if(!System.Numerics.BigInteger.TryParse(a, out aInt)) return null;
    if(!System.Numerics.BigInteger.TryParse(b, out bInt)) return null;

    return (aInt + bInt).ToString();
}
