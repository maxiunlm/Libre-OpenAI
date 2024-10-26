namespace LibreOpenAI.Exceptions.OpenAI
{
    public class LibreOpenAiTaskCanceledException : TaskCanceledException
    {
        public LibreOpenAiTaskCanceledException(TaskCanceledException inner)
            : base("Request timed out: The API request took too long to respond. Consider increasing the timeout.", inner)
        { }
    }
}