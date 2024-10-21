namespace LibreOpenAI.Exceptions
{
    public class LibreOpenAiTemperatureXorTopPException: Exception
    {
        public LibreOpenAiTemperatureXorTopPException():base("ERROR: We recommend altering temperature or top_p but not both.")
        {
        }
    }
}
