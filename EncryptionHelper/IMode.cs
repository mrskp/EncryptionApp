namespace EncryptionHelper
{
    public interface IMode
    {
        // Executes the mode-specific operation and returns a result
        int Execute();

        // Initializes the mode with a configuration dictionary
        void Initialize(Dictionary<string, string> config);
    }
}
