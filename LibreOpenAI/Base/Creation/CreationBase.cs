﻿using LibreOpenAI.DAL;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using LibreOpenAI.OpenAi.Settings;

namespace LibreOpenAI.Base.Creation
{
    public abstract class CreationBase : ICreationBase
    {
        private IOpenAiData openAiData;
        private readonly Uri openAiUrl;
        protected IOpenAiSettings settings;
        protected readonly JsonSerializerSettings jsonSettings = DAL.OpenAiData.jsonSettings;

        protected CreationBase(IOpenAiSettings settings, Uri openAiUrl)
        {
            this.settings = settings;
            this.openAiUrl = openAiUrl;
        }

        public IOpenAiData OpenAiData
        {
            get
            {
                if (openAiData == null)
                {
                    openAiData = new OpenAiData(settings);
                }

                return openAiData;
            }
            set
            {
                openAiData = value;
            }
        }

        public async Task<dynamic> CreateDynamic(dynamic request)
        {
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            dynamic response = await CreateDynamic(requestJson);

            return response;
        }

        public async Task<dynamic> CreateDynamic(string requestJson)
        {
            string responseBody = await CreateJson(requestJson);
            dynamic response = JToken.Parse(responseBody);

            return response;
        }

        public async Task<string> CreateJson(dynamic request)
        {
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            string response = await CreateJson(requestJson);
            return response;
        }

        public async Task<string> CreateJson(string requestJson)
        {
            string response = await CreateJson(requestJson, openAiUrl);
            return response;
        }

        public async Task<string> CreateJson(string requestJson, Uri openAiUrl)
        {
            string response = await OpenAiData.PostChatGptResponseJson(requestJson, openAiUrl);
            return response;
        }
    }
}
