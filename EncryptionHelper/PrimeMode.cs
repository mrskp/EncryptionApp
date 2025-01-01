using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EncryptionHelper
{
    public class PrimeMode : IMode
    {
        private int Start;
        private int End;

        public PrimeMode()
        {
        }

        public void Initialize(Dictionary<string, string> config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config), "Configuration dictionary cannot be null.");

            if (!config.ContainsKey("START") || !config.ContainsKey("END"))
                throw new ArgumentException("Configuration must contain START and END keys.");

            if (!int.TryParse(config["START"], out Start) || !int.TryParse(config["END"], out End))
                throw new FormatException("START and END values must be integers.");
        }

        public int Execute()
        {
            if (Start >= End)
                throw new InvalidOperationException("Start value must be less than the end value.");

            return GetPrimeCountInRange(Start, End);
        }

        // Function to find all prime numbers in the range [m, n]
        private int GetPrimeCountInRange(int start, int end)
        {
            // Get the boolean array representing prime numbers up to n
            bool[] isPrime = SieveOfEratosthenes(end);

            // Count the number of primes in the range [m, n]
            int count = 0;
            for (int i = start + 1; i < end; i++)
            {
                if (isPrime[i])
                    count++;
            }

            return count;
        }

        // Function to implement the Sieve of Eratosthenes to find primes up to 'n'. Time Complexity = O(n*LogLogn)
        private bool[] SieveOfEratosthenes(int n)
        {
            // Create a boolean array "prime[0..n]" and initialize all entries as true.
            // A value in prime[i] will be false if 'i' is not prime, otherwise true.
            bool[] prime = new bool[n + 1];
            for (int i = 0; i <= n; i++)
                prime[i] = true;

            // Mark 0 and 1 as non-prime
            prime[0] = false;
            prime[1] = false;

            // Loop through numbers from 2 to sqrt(n) to mark their multiples as non-prime
            for (int p = 2; p * p <= n; p++)
            {

                // If prime[p] is still true, it means 'p' is prime
                if (prime[p])
                {

                    // Mark all multiples of p greater than or equal to p^2 as non-prime
                    // Numbers less than p^2 would have already been marked as non-prime
                    for (int i = p * p; i <= n; i += p)
                        prime[i] = false;
                }
            }

            return prime;
        }

        // NOT USED because of higher time complexity of O(n*SQRT(n)). SieveOfEratosthenes algorithm is used instead.
        // Function to check if a number is prime
        public bool IsPrime(int n)
        {
            if (n <= 1)
                return false;

            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }
    }
}
