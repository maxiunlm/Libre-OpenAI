using LibreOpenAI.OpenAi.AudioAi.SpeechAi;
using LibreOpenAI.OpenAi.AudioAi.TranscriptionsAi;
using LibreOpenAI.OpenAi.AudioAi.TranslationsAi;
using LibreOpenAI.OpenAi.Settings;

namespace LibreOpenAI.OpenAi.AudioAi
{
    public class Audio : IAudio
    {
        public Audio(IOpenAiSettings settings)
        {
            Speech = new Speech(settings);
            Transcriptions = new Transcriptions(settings);
            Translations = new Translations(settings);
        }

        public ISpeech Speech { get; set; }
        public ITranscriptions Transcriptions { get; set; }
        public ITranslations Translations { get; set; }
    }
}
