namespace LibreOpenAI.Exceptions
{
    public class LibreOpenAiRequiredToolCallIdException : Exception
    {
        public LibreOpenAiRequiredToolCallIdException(string role) : base($"ERROR: The tool_call_id of the {role} message is mandatory.")
        {
            if (role == null)
            {
                throw new ArgumentNullException("The 'role' parameter is mandatory.");
            }
        }
    }
}
