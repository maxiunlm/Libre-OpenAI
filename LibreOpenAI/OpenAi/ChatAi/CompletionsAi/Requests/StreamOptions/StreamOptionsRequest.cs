using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.StreamOptions
{
    public class StreamOptionsRequest : IStreamOptionsRequest
    {
        public bool? IncludeUsage { get; set; }
    }
}
