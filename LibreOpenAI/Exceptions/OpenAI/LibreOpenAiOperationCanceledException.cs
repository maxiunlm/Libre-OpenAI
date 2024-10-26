namespace LibreOpenAI.Exceptions.OpenAI
{
    public class LibreOpenAiOperationCanceledException : OperationCanceledException
    {
        public LibreOpenAiOperationCanceledException(OperationCanceledException inner)
            : base("Operation canceled: The request was canceled, possibly due to a cancellation token.", inner)
        { }
    }
}