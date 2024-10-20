namespace LibreOpenAI.Exceptions
{
    internal class LibreOnepStreamOptionsException : Exception
    {
        public LibreOnepStreamOptionsException() : base("ERROR: Only set stream_options when you set stream in true.")
        {
        }
    }
}
