namespace LibreOpenAI.Exceptions
{
    public class LibreOpenAiRequiredContentException : Exception
    {
        public LibreOpenAiRequiredContentException(string role, string type) : base($"ERROR: The {type} content of the {role} message is mandatory.")
        {
            if (role == null)
            {
                throw new ArgumentNullException($"[type: {type}] The 'role' parameter is mandatory.");
            }
        }
    }
}
