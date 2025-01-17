using LibreOpenAI.Base.Creation;
using LibreOpenAI.OpenAi.Settings;

namespace LibreOpenAI.OpenAi.AudioAi.TranscriptionsAi
{
    public class Transcriptions : CreationBase, ITranscriptions
    {
        public Transcriptions(IOpenAiSettings settings) : base(settings, settings.OpenAiUrlAudioTranscriptions)
        {
        }
    }
}
