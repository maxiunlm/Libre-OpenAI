﻿namespace LibreOpenAI.Exceptions
{
    public class LibreOpenAiWrongContentForException : Exception
    {
        public LibreOpenAiWrongContentForException(string role, string contentType) : base($"ERROR: The 'Content' for '{role}' can't be of '{contentType}' type.")
        {
        }
    }
}
