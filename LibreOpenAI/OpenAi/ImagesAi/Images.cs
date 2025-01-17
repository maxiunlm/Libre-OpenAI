using LibreOpenAI.DAL;
using LibreOpenAI.OpenAi.Settings;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ImagesAi
{
    public class Images : IImages // TODO: Unit Testing
    {
        private IOpenAiData openAiData;
        private readonly Uri openAiUrl;
        protected IOpenAiSettings settings;
        protected readonly JsonSerializerSettings jsonSettings = DAL.OpenAiData.jsonSettings;

        public Images(IOpenAiSettings settings)
        {
            this.settings = settings;
            this.openAiUrl = settings.OpenAiUrlImageGenerations;
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

        public async Task<dynamic> GenerateDynamic(dynamic request)
        {
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            dynamic response = await GenerateDynamic(requestJson);

            return response;
        }

        public async Task<dynamic> GenerateDynamic(string requestJson)
        {
            string responseBody = await GenerateJson(requestJson);
            dynamic response = JToken.Parse(responseBody);

            return response;
        }

        public async Task<string> GenerateJson(dynamic request)
        {
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            string response = await GenerateJson(requestJson);
            return response;
        }

        public async Task<string> GenerateJson(string requestJson)
        {
            string response = await GenerateJson(requestJson, openAiUrl);
            return response;
        }

        public async Task<string> GenerateJson(string requestJson, Uri openAiUrl)
        {
            string response = await OpenAiData.PostChatGptResponseJson(requestJson, openAiUrl);
            return response;
        }

        // TODO: review how to implement for example 'image: fs.createReadStream("otter.png")' in C#
        public async Task<dynamic> EditDynamic(dynamic request)
        {
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            dynamic response = await EditDynamic(requestJson);

            return response;
        }

        public async Task<dynamic> EditDynamic(string requestJson)
        {
            string responseBody = await EditJson(requestJson);
            dynamic response = JToken.Parse(responseBody);

            return response;
        }

        public async Task<string> EditJson(dynamic request)
        {
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            string response = await EditJson(requestJson);
            return response;
        }

        public async Task<string> EditJson(string requestJson)
        {
            Uri openAiUrl = settings.OpenAiUrlImageEdits;
            string response = await EditJson(requestJson, openAiUrl);
            return response;
        }

        public async Task<string> EditJson(string requestJson, Uri openAiUrl)
        {
            string response = await OpenAiData.PostChatGptResponseJson(requestJson, openAiUrl);
            return response;
        }

        // TODO: review how to implement for example 'image: fs.createReadStream("otter.png")' in C#
        public async Task<dynamic> CreateVariationDynamic(dynamic request)
        {
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            dynamic response = await CreateVariationDynamic(requestJson);

            return response;
        }

        public async Task<dynamic> CreateVariationDynamic(string requestJson)
        {
            string responseBody = await CreateVariationJson(requestJson);
            dynamic response = JToken.Parse(responseBody);

            return response;
        }

        public async Task<string> CreateVariationJson(dynamic request)
        {
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            string response = await CreateVariationJson(requestJson);
            return response;
        }

        public async Task<string> CreateVariationJson(string requestJson)
        {
            Uri openAiUrl = settings.OpenAiUrlImageVariations;
            string response = await CreateVariationJson(requestJson, openAiUrl);
            return response;
        }

        public async Task<string> CreateVariationJson(string requestJson, Uri openAiUrl)
        {
            string response = await OpenAiData.PostChatGptResponseJson(requestJson, openAiUrl);
            return response;
        }
    }
}
