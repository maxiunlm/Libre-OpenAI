namespace LibreOpenAI.Exceptions
{
    public class LibreOpenAiRequiredContentException : Exception
    {
        public LibreOpenAiRequiredContentException(string role) : base($"ERROR: The contents of the {role} message is mandatory.")
        {
            if (role == null)
            {
                throw new ArgumentNullException("The 'role' parameter is mandatory.");
            }
        }
    }
}
