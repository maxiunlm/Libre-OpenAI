namespace LibreOpenAI.DAL.Http
{
    public interface IHttpExtensionClient: IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(Uri? requestUri);
    }
}
