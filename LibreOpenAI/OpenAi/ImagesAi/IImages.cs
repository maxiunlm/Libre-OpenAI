using LibreOpenAI.DAL;

namespace LibreOpenAI.OpenAi.ImagesAi
{
    /// <summary>
    /// Given a prompt and/or an input image, the model will generate a new image. Related guide: Image generation
    /// </summary>
    /// <see cref="https://platform.openai.com/docs/api-reference/images"/>
    /// <seealso cref="https://platform.openai.com/docs/guides/images"/>
    public interface IImages
    {
        IOpenAiData OpenAiData { get; set; }

        /// <summary>
        /// Creates a variation of a given image.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <returns>Returns a list of image objects.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/images/createVariation"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/images/object"/>
        Task<dynamic> CreateVariationDynamic(dynamic request);
        /// <summary>
        /// Creates a variation of a given image.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <returns>Returns a list of image objects.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/images/createVariation"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/images/object"/>
        Task<dynamic> CreateVariationDynamic(string requestJson);
        /// <summary>
        /// Creates a variation of a given image.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <returns>Returns a list of image objects.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/images/createVariation"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/images/object"/>
        Task<string> CreateVariationJson(dynamic request);
        /// <summary>
        /// Creates a variation of a given image.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <returns>Returns a list of image objects.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/images/createVariation"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/images/object"/>
        Task<string> CreateVariationJson(string requestJson);
        /// <summary>
        /// Creates a variation of a given image.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <returns>Returns a list of image objects.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/images/createVariation"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/images/object"/>
        Task<string> CreateVariationJson(string requestJson, Uri openAiUrl);
        /// <summary>
        /// Creates an edited or extended image given an original image and a prompt.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <returns>Returns a list of image objects.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/images/createEdit"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/images/object"/>
        Task<dynamic> EditDynamic(dynamic request);
        /// <summary>
        /// Creates an edited or extended image given an original image and a prompt.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <returns>Returns a list of image objects.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/images/createEdit"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/images/object"/>
        Task<dynamic> EditDynamic(string requestJson);
        /// <summary>
        /// Creates an edited or extended image given an original image and a prompt.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <returns>Returns a list of image objects.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/images/createEdit"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/images/object"/>
        Task<string> EditJson(dynamic request);
        /// <summary>
        /// Creates an edited or extended image given an original image and a prompt.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <returns>Returns a list of image objects.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/images/createEdit"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/images/object"/>
        Task<string> EditJson(string requestJson);
        /// <summary>
        /// Creates an edited or extended image given an original image and a prompt.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <returns>Returns a list of image objects.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/images/createEdit"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/images/object"/>
        Task<string> EditJson(string requestJson, Uri openAiUrl);
        /// <summary>
        /// Creates an image given a prompt.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <returns>Returns a list of image objects.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/images/create"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/images/object"/>
        Task<dynamic> GenerateDynamic(dynamic request);
        /// <summary>
        /// Creates an image given a prompt.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <returns>Returns a list of image objects.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/images/create"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/images/object"/>
        Task<dynamic> GenerateDynamic(string requestJson);
        /// <summary>
        /// Creates an image given a prompt.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <returns>Returns a list of image objects.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/images/create"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/images/object"/>
        Task<string> GenerateJson(dynamic request);
        /// <summary>
        /// Creates an image given a prompt.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <returns>Returns a list of image objects.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/images/create"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/images/object"/>
        Task<string> GenerateJson(string requestJson);
        /// <summary>
        /// Creates an image given a prompt.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <returns>Returns a list of image objects.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/images/create"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/images/object"/>
        Task<string> GenerateJson(string requestJson, Uri openAiUrl);
    }
}