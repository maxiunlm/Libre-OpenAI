using LibreOpenAI.Base.Creation;
using LibreOpenAI.OpenAi.Settings;

namespace LibreOpenAI.OpenAi.AudioAi.SpeechAi
{
    public class Speech : CreationBase, ISpeech
    {
        public Speech(IOpenAiSettings settings) : base(settings, settings.OpenAiUrlAudioSpeech)
        {
        }
    }
}
