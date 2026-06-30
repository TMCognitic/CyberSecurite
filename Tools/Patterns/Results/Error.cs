namespace Tools.Patterns.Results
{
    public class Error
    {
        public static Error Create (string message)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(message, nameof(message));
            return new Error(message);
        }

        private Error(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
