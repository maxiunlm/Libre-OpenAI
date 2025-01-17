using LibreOpenAI.OpenAi.AudioAi.SpeechAi;
using LibreOpenAI.OpenAi.AudioAi.TranscriptionsAi;
using LibreOpenAI.OpenAi.AudioAi.TranslationsAi;

namespace LibreOpenAI.OpenAi.AudioAi
{
    /// <summary>
    /// Learn how to turn audio into text or text into audio. 
    /// Related guide: Speech to text
    /// <see cref="https://platform.openai.com/docs/api-reference/audio"/>
    /// <seealso cref="https://platform.openai.com/docs/guides/speech-to-text"/>
    /// </summary>
    public interface IAudio
    {
        /// <summary>
        /// Generates audio from the input text.
        /// <see cref="https://platform.openai.com/docs/api-reference/audio/createSpeech"/>
        /// </summary>
        ISpeech Speech { get; set; }
        /// <summary>
        /// Transcribes audio into the input language.
        /// <see cref="https://platform.openai.com/docs/api-reference/audio/createTranscription"/>
        /// </summary>
        ITranscriptions Transcriptions { get; set; }
        /// <summary>
        /// Translates audio into English.
        /// <see cref="https://platform.openai.com/docs/api-reference/audio/createTranslation"/>
        /// </summary>
        ITranslations Translations { get; set; }
    }
}