/* RETURNS THE RANGE BETWEEN IP ADRESSES
 * 
 * Excluding the last adress. For ex. range between 10.0.0.0 and 10.0.0.50 returns 50.
 * For any invalid inputs it returns -1.
 * This completely ignores subnetting and stuff so not really applicable to a real address range you might see in a company network.
 */

public long IpsBetween(string start, string end)
{
    int[] s = start.Split('.').Select(s => { int.TryParse(s, out int result); return result; }).ToArray();
    int[] e = end.Split('.').Select(s => { int.TryParse(s, out int result); return result; }).ToArray();
    long range = 0;

    // Validate input
    if (s.Length != 4 || e.Length != 4) return -1;
    if (s.Where(i => i > 255).Count() > 0 || e.Where(i => i > 255).Count() > 0) return -1;


    for(int i = 0; i < s.Length; i++)
    {
        // e[^i] == e[e.Length - i]
        range += (e[^(i+1)] - s[^(i+1)]) * Convert.ToInt64(Math.Pow(Convert.ToDouble(256), Convert.ToDouble(i)));
    }

    return range >= 0 ? range : -1;
}
