namespace LibreOpenAI.Exceptions
{
    public class LibreOpenAiStreamOptionsException : Exception
    {
        public LibreOpenAiStreamOptionsException() : base("ERROR: Only set stream_options when you set stream in true.")
        {
        }
    }
}
