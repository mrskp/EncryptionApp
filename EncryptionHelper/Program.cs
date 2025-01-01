namespace EncryptionHelper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            try
            {
                // Prompt user for input for PrimeMode
                Console.Write("Enter start value for PrimeMode: ");
                string startInput = Console.ReadLine();
                Console.Write("Enter end value for PrimeMode: ");
                string endInput = Console.ReadLine();

                IMode primeMode = new PrimeMode();
                //primeMode.Initialize(new Dictionary<string, string> { { "START", "1" }, { "END", "11" } });
                primeMode.Initialize(new Dictionary<string, string> { { "START", startInput }, { "END", endInput } });
                Console.WriteLine($"Number of primes: {primeMode.Execute()}");

                // Prompt user for input for EncryptionMode
                Console.Write("Enter path to mapping file for EncryptionMode like (C:\\Users\\hpwork\\desktop\\mapping.txt): ");
                string mappingFile = Console.ReadLine();
                Console.Write("Enter path to words file for EncryptionMode like (C:\\Users\\hpwork\\desktop\\words.txt): ");
                string wordsFile = Console.ReadLine();
                Console.Write("Enter path to output encrypted file for EncryptionMode liek (C:\\Users\\hpwork\\desktop\\encrypted.txt): ");
                string encryptedFile = Console.ReadLine();

                IMode encryptionMode = new EncryptionMode();
                encryptionMode.Initialize(new Dictionary<string, string> {
                    { "MAPPINGFILE", mappingFile },
                    { "WORDSTOENCRYPT", wordsFile },
                    { "ENCRYPTEDFILE", encryptedFile }
                });
                //encryptionMode.Initialize(new Dictionary<string, string> {
                //    { "MAPPINGFILE", @"C:\Users\hpwork\desktop\mapping.txt" },
                //    { "WORDSTOENCRYPT", @"C:\Users\hpwork\desktop\words.txt" },
                //    { "ENCRYPTEDFILE", @"C:\Users\hpwork\desktop\encrypted.txt" }
                //});

                Console.WriteLine($"Number of encrypted words: {encryptionMode.Execute()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
