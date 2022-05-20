// Returns the n-th Fibonacci number

public static BigInteger Fibonacci(int n)
{
    BigInteger previous = 0;
    BigInteger current = 1;

    if (n == 0) return previous;
    if (n == 1 || n == -1) return current;

    if (n > 0)
    {
        for (int i = 2; i <= n; i++)
        {
            var sum = current + previous;
            previous = current;
            current = sum;
        }
    }
    else
    {
        for (int i = -2; i >= n; i--)
        {
            var sub = previous - current;
            previous = current;
            current = sub;
        }
    }

    return current;
}
