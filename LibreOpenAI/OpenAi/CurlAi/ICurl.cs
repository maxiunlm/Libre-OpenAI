
using LibreOpenAI.DAL.Http;
using System.Text.Json.Serialization;

namespace LibreOpenAI.OpenAi.CurlAi
{
    /// <summary>
    /// Replaces a 'curl' command line tool with a C# method. It will help you to solve possible future updates in the OpenAI API.
    /// A good sample of the command line could be the next:
    /// curl https://api.openai.com/v1/models \
    ///   -H "Authorization: Bearer $OPENAI_API_KEY" \
    ///   -H "OpenAI-Organization: org-hRvGopnKF1D2V4hP5N65SoSA" \
    ///   -H "OpenAI-Project: $PROJECT_ID"
    /// </summary>
    /// <see cref="https://platform.openai.com/docs/api-reference/introduction"/>
    public interface ICurl
    {
        [JsonIgnore]
        ICurlClient Client { get; }
        /// <summary>
        /// The 'curl' command line replacement for GET and DELETE methods (basically HTTP methods without body message).
        /// </summary>
        /// <param name="url">It's the URL (as string) that you want to access for your request.</param>
        /// <param name="method">It's the HTTP method (It's thought for GET and DELETE, but you can use every possible method without a body message).</param>
        /// <param name="headers">The headers of the request, for OpenAI you need to use your API KEY (for example: "Authorization: Bearer SET_YOUR_OPENAI_API_KEY_VALUE_HERE").</param>
        /// <returns>A JSON or a list of JSON objects depending on teh Stream Options.</returns>
        Task<HttpResponseMessage> CurlAsync(string url, string method, Dictionary<string, string> headers);
        /// <summary>
        /// The 'curl' command line replacement for GET and DELETE methods (basically HTTP methods without body message).
        /// </summary>
        /// <param name="url">It's the URL (as Uri object) that you want to access for your request.</param>
        /// <param name="method">It's the HTTP method (It's thought for GET and DELETE, but you can use every possible method without a body message).</param>
        /// <param name="headers">The headers of the request, for OpenAI you need to use your API KEY (for example: "Authorization: Bearer SET_YOUR_OPENAI_API_KEY_VALUE_HERE").</param>
        /// <returns>A JSON or a list of JSON objects depending on teh Stream Options.</returns>
        Task<HttpResponseMessage> CurlAsync(Uri url, string method, Dictionary<string, string> headers);
        /// <summary>
        /// The 'curl' command line replacement for POST, PUT and PATCH methods (basically HTTP methods with body).
        /// </summary>
        /// <param name="url">It's the URL (as string) that you want to access for your request.</param>
        /// <param name="method">It's the HTTP method (It's thought for POST, PUT and PATCH, but you can use every possible method without a body message).</param>
        /// <param name="headers">The headers of the request, for OpenAI you need to use your API KEY (for example: "Authorization: Bearer SET_YOUR_OPENAI_API_KEY_VALUE_HERE").</param>
        /// <param name="content">It's the body message, like the Post Data for POST HTTP method</param>
        /// <returns>A JSON or a list of JSON objects depending on teh Stream Options.</returns>
        Task<HttpResponseMessage> CurlAsync(string url, string method, Dictionary<string, string> headers, string content);
        /// <summary>
        /// The 'curl' command line replacement for POST, PUT and PATCH methods (basically HTTP methods with body).
        /// </summary>
        /// <param name="url">It's the URL (as Uri object) that you want to access for your request.</param>
        /// <param name="method">It's the HTTP method (It's thought for POST, PUT and PATCH, but you can use every possible method without a body message).</param>
        /// <param name="headers">The headers of the request, for OpenAI you need to use your API KEY (for example: "Authorization: Bearer SET_YOUR_OPENAI_API_KEY_VALUE_HERE").</param>
        /// <param name="content">It's the body message, like the Post Data for POST HTTP method</param>
        /// <returns>A JSON or a list of JSON objects depending on teh Stream Options.</returns>
        Task<HttpResponseMessage> CurlAsync(Uri url, string method, Dictionary<string, string> headers, string content);
        /// <summary>
        /// The 'curl' command line replacement for POST, PUT and PATCH methods (basically HTTP methods with body).
        /// </summary>
        /// <param name="url">It's the URL (as string) that you want to access for your request.</param>
        /// <param name="method">It's the HTTP method (It's thought for POST, PUT and PATCH, but you can use every possible method without a body message).</param>
        /// <param name="headers">The headers of the request, for OpenAI you need to use your API KEY (for example: "Authorization: Bearer SET_YOUR_OPENAI_API_KEY_VALUE_HERE").</param>
        /// <param name="content">It's the body message, like the Post Data for POST HTTP method</param>
        /// <returns>A JSON or a list of JSON objects depending on teh Stream Options.</returns>
        Task<HttpResponseMessage> CurlAsync(string url, string method, Dictionary<string, string> headers, HttpContent content);
        /// <summary>
        /// The 'curl' command line replacement for POST, PUT and PATCH methods (basically HTTP methods with body).
        /// </summary>
        /// <param name="url">It's the URL (as Uri object) that you want to access for your request.</param>
        /// <param name="method">It's the HTTP method (It's thought for POST, PUT and PATCH, but you can use every possible method without a body message).</param>
        /// <param name="headers">The headers of the request, for OpenAI you need to use your API KEY (for example: "Authorization: Bearer SET_YOUR_OPENAI_API_KEY_VALUE_HERE").</param>
        /// <param name="content">It's the body message, like the Post Data for POST HTTP method</param>
        /// <returns>A JSON or a list of JSON objects depending on teh Stream Options.</returns>
        Task<HttpResponseMessage> CurlAsync(Uri url, string method, Dictionary<string, string> headers, HttpContent content);
    }
}