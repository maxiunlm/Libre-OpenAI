namespace LibreOpenAI.Exceptions.OpenAI
{
    public class LibreOpenAiUnexpectedException : Exception
    {
        public LibreOpenAiUnexpectedException(Exception inner)
            : base("An unexpected error occurred while processing the request to the OpenAI API.", inner)
        { }
    }
}