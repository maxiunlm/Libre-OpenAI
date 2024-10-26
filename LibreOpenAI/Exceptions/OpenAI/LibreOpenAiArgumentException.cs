namespace LibreOpenAI.Exceptions.OpenAI
{
    public class LibreOpenAiArgumentException : ArgumentException
    {
        public LibreOpenAiArgumentException(ArgumentException inner)
            : base("Argument error: Invalid parameters in the request. Check message content or request configuration.", inner)
        { }
    }
}