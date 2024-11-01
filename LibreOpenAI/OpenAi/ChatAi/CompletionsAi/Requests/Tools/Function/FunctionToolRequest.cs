using LibreOpenAI.Exceptions;
using System.Text.RegularExpressions;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Function
{
    public class FunctionToolRequest : IFunctionToolRequest
    {
        private const int maxNameLength = 64;
        public string Description { get; set; } = string.Empty;
        public bool MustThrowNameRegexException { get; set; }
        private string name = string.Empty;
        public required string Name
        {
            get => name;
            set
            {
                name = GetNameValue(value, MustThrowNameRegexException);
            }
        }
        public object? Parameters { get; set; }
        public bool? Strict { get; set; }

        public static string GetNameValue(string value, bool mustThrowNameRegexException)
        {
            string result = (value ?? string.Empty);
            int maxLength = result.Length > maxNameLength ? maxNameLength : result.Length;
            result = result.Substring(0, maxLength);

            if (mustThrowNameRegexException)
            {
                string pattern = @"^[a-zA-Z0-9_-]+$";
                bool isValid = Regex.IsMatch(result, pattern);

                if (!isValid)
                {
                    throw new LibreOpenAiNameRegexException();
                }
            }

            return result;
        }
    }
}
