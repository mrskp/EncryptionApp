
namespace EncryptionHelper
{
    // EncryptionMode implementation
    public class EncryptionMode : IMode
    {
        private Dictionary<char, char> encryptionMap = new();
        private List<string> wordsToEncrypt = new();
        private string encryptedFilePath;

        // Initializes the encryption map and file paths
        // Time Complexity: O(M + W), where M is the number of mappings and W is the number of words
        // Space Complexity: O(M + W), for storing mappings and words
        public void Initialize(Dictionary<string, string> config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config), "Configuration dictionary cannot be null.");

            if (!config.ContainsKey("MAPPINGFILE") || !config.ContainsKey("WORDSTOENCRYPT") || !config.ContainsKey("ENCRYPTEDFILE"))
                throw new ArgumentException("Configuration must contain MAPPINGFILE, WORDSTOENCRYPT, and ENCRYPTEDFILE keys.");

            string mappingFilePath = config["MAPPINGFILE"];
            string wordsFilePath = config["WORDSTOENCRYPT"];
            encryptedFilePath = config["ENCRYPTEDFILE"];

            if (!File.Exists(mappingFilePath))
                throw new FileNotFoundException($"Mapping file not found: {mappingFilePath}");

            if (!File.Exists(wordsFilePath))
                throw new FileNotFoundException($"Words file not found: {wordsFilePath}");

            foreach (var line in File.ReadLines(mappingFilePath))
            {
                var parts = line.Split('|');
                if (parts.Length == 2)
                    encryptionMap[parts[0][0]] = parts[1][0];
                else
                    throw new FormatException("Invalid format in mapping file. Each line must be in the format: letter|replacement");
            }

            wordsToEncrypt = File.ReadLines(wordsFilePath).ToList();
        }

        // Encrypts the words and writes to the encrypted file
        // Time Complexity: O(W*L), where W is the number of words and L is the average length of a word
        // Space Complexity: O(W*L), for storing encrypted words
        public int Execute()
        {
            if (encryptionMap.Count == 0)
                throw new InvalidOperationException("Encryption map is empty. Please initialize properly.");

            if (string.IsNullOrWhiteSpace(encryptedFilePath))
                throw new InvalidOperationException("Encrypted file path is not set.");

            List<string> encryptedWords = new();

            // Loop through each word in the wordsToEncrypt list
            // For each word, iterate through its characters
            // - If the character exists in the encryptionMap, replace it with its mapped value
            // - Otherwise, keep the character as it is
            // Append the encrypted characters to form the encrypted version of the word
            // Add the encrypted word to the encryptedWords list
            foreach (var word in wordsToEncrypt)
            {
                var encryptedWord = "";
                foreach (var c in word)
                {
                    encryptedWord += encryptionMap.ContainsKey(c) ? encryptionMap[c] : c;
                }
                encryptedWords.Add(encryptedWord);
            }

            // Write the word list to the file
            File.WriteAllLines(encryptedFilePath, encryptedWords);

            // Return the number of encrypted words
            return encryptedWords.Count;
        }
    }
}
