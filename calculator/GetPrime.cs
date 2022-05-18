// Get prime numbers until a given maximum

public static IEnumerable<int> GetPrime(int max)
{
    bool[] notPrime = new bool[max];
    long current = 2;

    while(current < notPrime.Length)
    {
        if (!notPrime[current])
        {
            yield return (int)current;

            for (long i = current * current; i < notPrime.Length; i += current) {
                notPrime[i] = true;
            }
        }

        current++;
    }
}
