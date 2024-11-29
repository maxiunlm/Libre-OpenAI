﻿using System.Net.Http.Headers;

namespace LibreOpenAI.DAL.Http
{
    public interface IHttpClient
    {
        HttpRequestHeaders DefaultRequestHeaders { get; }
        Task<HttpResponseMessage> PostAsync(Uri? requestUri, HttpContent? content);
    }

}
