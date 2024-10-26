using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;
using LibreOpenAI.OpenAi;
using LibreOpenAIUnitTestProject.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreOpenAIUnitTestProject.Base;
using LibreOpenAI.DAL;
using Moq;
using LibreOpenAI.Exceptions.OpenAI;

namespace LibreOpenAIUnitTestProject
{
    [TestClass]
    public class OpenAiExceptionsUnitTest : OpenAiUnitTestBase
    {
        //* 
#if DEBUG

        [TestMethod]
        public async Task OpenAiExceptionsUnitTest_ApiKeyMaxTokensExceded()
        {
            IRequestBody request = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = new OpenAI();

            try
            {
                IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

                Assert.IsTrue(false, "An Exception was expected.");
            }
            catch (LibreOpenAITooManyRequestsException ex)
            {
                Assert.IsTrue(true);
            }     
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAITooManyRequestsException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

#endif
        // */
    }
}
