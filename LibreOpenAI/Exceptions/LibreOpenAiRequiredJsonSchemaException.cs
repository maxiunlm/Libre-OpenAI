namespace LibreOpenAI.Exceptions
{
    public class LibreOpenAiRequiredJsonSchemaException : Exception
    {
        public LibreOpenAiRequiredJsonSchemaException(string type) : base($"ERROR: The json_schema of the {type} message is mandatory.")
        {
            if (type == null)
            {
                throw new ArgumentNullException("The 'type' parameter is mandatory.");
            }
        }
    }
}
