namespace LibreOpenAI.Exceptions
{
    public class LibreOnepAiTemperatureXorTopPException: Exception
    {
        public LibreOnepAiTemperatureXorTopPException():base("ERROR: We recommend altering temperature or top_p but not both.")
        {
        }
    }
}
