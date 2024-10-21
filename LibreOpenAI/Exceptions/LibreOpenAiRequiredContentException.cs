namespace LibreOpenAI.Exceptions
{
    internal class LibreOpenAiRequiredContentException : Exception
    {
        public LibreOpenAiRequiredContentException(string role) : base($"ERROR: The contents of the {role} message.")
        {
            if (role == null)
            {
                throw new ArgumentNullException("The 'role' parameter is mandatory.");
            }
        }
    }
}
