using System.Net.Http.Headers;

namespace LibreOpenAI.DAL.Http
{
    public interface IHttpExtensionClient: IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(Uri? requestUri);
        Task<HttpResponseMessage> PutAsync(Uri? requestUri, HttpContent? content);
        Task<HttpResponseMessage> PatchAsync(Uri? requestUri, HttpContent? content);
        Task<HttpResponseMessage> DeleteAsync(Uri? requestUri);
    }

}
