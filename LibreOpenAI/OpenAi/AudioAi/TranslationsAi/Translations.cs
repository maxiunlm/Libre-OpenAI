using LibreOpenAI.Base.Creation;
using LibreOpenAI.OpenAi.Settings;

namespace LibreOpenAI.OpenAi.AudioAi.TranslationsAi
{
    public class Translations : CreationBase, ITranslations
    {
        public Translations(IOpenAiSettings settings) : base(settings, settings.OpenAiUrlAudioTranslations)
        {
        }
    }
}
