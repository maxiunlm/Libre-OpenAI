namespace LibreOpenAI.DAL.Http
{
    public interface IHttpClient: IHttpClientAi
    {
        Task<HttpResponseMessage> PutAsync(Uri? requestUri, HttpContent? content);
        Task<HttpResponseMessage> PatchAsync(Uri? requestUri, HttpContent? content);
        Task<HttpResponseMessage> DeleteAsync(Uri? requestUri);
    }
}
