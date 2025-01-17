using LibreOpenAI.OpenAi.AudioAi.SpeechAi;
using LibreOpenAI.OpenAi.AudioAi.TranscriptionsAi;
using LibreOpenAI.OpenAi.AudioAi.TranslationsAi;

namespace LibreOpenAI.OpenAi.AudioAi
{
    /// <summary>
    /// Learn how to turn audio into text or text into audio. 
    /// Related guide: Speech to text
    /// </summary>
    /// <see cref="https://platform.openai.com/docs/api-reference/audio"/>
    /// <seealso cref="https://platform.openai.com/docs/guides/speech-to-text"/>
    public interface IAudio
    {
        /// <summary>
        /// Generates audio from the input text.
        /// </summary>
        /// <see cref="https://platform.openai.com/docs/api-reference/audio/createSpeech"/>
        ISpeech Speech { get; set; }
        /// <summary>
        /// Transcribes audio into the input language.
        /// </summary>
        /// <see cref="https://platform.openai.com/docs/api-reference/audio/createTranscription"/>
        ITranscriptions Transcriptions { get; set; }
        /// <summary>
        /// Translates audio into English.
        /// </summary>
        /// <see cref="https://platform.openai.com/docs/api-reference/audio/createTranslation"/>
        ITranslations Translations { get; set; }
    }
}