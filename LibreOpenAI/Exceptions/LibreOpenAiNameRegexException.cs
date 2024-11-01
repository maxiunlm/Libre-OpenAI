namespace LibreOpenAI.Exceptions
{
    public class LibreOpenAiNameRegexException : Exception
    {
        public LibreOpenAiNameRegexException() : base("ERROR: The 'name' property must be a-z, A-Z, 0-9, or contain underscores and dashes, with a maximum length of 64..")
        {
        }
    }
}
