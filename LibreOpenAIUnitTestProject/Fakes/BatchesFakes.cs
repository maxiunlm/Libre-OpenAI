﻿namespace LibreOpenAIUnitTestProject.Fakes
{
    internal class BatchesFakes
    {
        public const string resquestBatchId = "batch_abc123";
        public const string resquestCreate = @"{
    ""input_file_id"": ""file-abc123"",
    ""endpoint"": ""/v1/chat/completions"",
    ""completion_window"": ""24h""
  }";
        public const string responseCreate = @"{
  ""id"": ""batch_abc123"",
  ""object"": ""batch"",
  ""endpoint"": ""/v1/chat/completions"",
  ""errors"": null,
  ""input_file_id"": ""file-abc123"",
  ""completion_window"": ""24h"",
  ""status"": ""validating"",
  ""output_file_id"": null,
  ""error_file_id"": null,
  ""created_at"": 1711471533,
  ""in_progress_at"": null,
  ""expires_at"": null,
  ""finalizing_at"": null,
  ""completed_at"": null,
  ""failed_at"": null,
  ""expired_at"": null,
  ""cancelling_at"": null,
  ""cancelled_at"": null,
  ""request_counts"": {
    ""total"": 0,
    ""completed"": 0,
    ""failed"": 0
  },
  ""metadata"": {
    ""customer_id"": ""user_123456789"",
    ""batch_description"": ""Nightly eval job"",
  }
}";
        // GET: https://api.openai.com/v1/batches/{batch_id}
        public const string responseRetrieve = @"{
  ""id"": ""batch_abc123"",
  ""object"": ""batch"",
  ""endpoint"": ""/v1/completions"",
  ""errors"": null,
  ""input_file_id"": ""file-abc123"",
  ""completion_window"": ""24h"",
  ""status"": ""completed"",
  ""output_file_id"": ""file-cvaTdG"",
  ""error_file_id"": ""file-HOWS94"",
  ""created_at"": 1711471533,
  ""in_progress_at"": 1711471538,
  ""expires_at"": 1711557933,
  ""finalizing_at"": 1711493133,
  ""completed_at"": 1711493163,
  ""failed_at"": null,
  ""expired_at"": null,
  ""cancelling_at"": null,
  ""cancelled_at"": null,
  ""request_counts"": {
    ""total"": 100,
    ""completed"": 95,
    ""failed"": 5
  },
  ""metadata"": {
    ""customer_id"": ""user_123456789"",
    ""batch_description"": ""Nightly eval job"",
  }
}";
        // POST: https://api.openai.com/v1/batches/{batch_id}/cancel
        public const string responseCancel = @"{
  ""id"": ""batch_abc123"",
  ""object"": ""batch"",
  ""endpoint"": ""/v1/chat/completions"",
  ""errors"": null,
  ""input_file_id"": ""file-abc123"",
  ""completion_window"": ""24h"",
  ""status"": ""cancelling"",
  ""output_file_id"": null,
  ""error_file_id"": null,
  ""created_at"": 1711471533,
  ""in_progress_at"": 1711471538,
  ""expires_at"": 1711557933,
  ""finalizing_at"": null,
  ""completed_at"": null,
  ""failed_at"": null,
  ""expired_at"": null,
  ""cancelling_at"": 1711475133,
  ""cancelled_at"": null,
  ""request_counts"": {
    ""total"": 100,
    ""completed"": 23,
    ""failed"": 1
  },
  ""metadata"": {
    ""customer_id"": ""user_123456789"",
    ""batch_description"": ""Nightly eval job"",
  }
}";
        // GET: https://api.openai.com/v1/batches
        public const string responseList = @"{
  ""object"": ""list"",
  ""data"": [
    {
      ""id"": ""batch_abc123"",
      ""object"": ""batch"",
      ""endpoint"": ""/v1/chat/completions"",
      ""errors"": null,
      ""input_file_id"": ""file-abc123"",
      ""completion_window"": ""24h"",
      ""status"": ""completed"",
      ""output_file_id"": ""file-cvaTdG"",
      ""error_file_id"": ""file-HOWS94"",
      ""created_at"": 1711471533,
      ""in_progress_at"": 1711471538,
      ""expires_at"": 1711557933,
      ""finalizing_at"": 1711493133,
      ""completed_at"": 1711493163,
      ""failed_at"": null,
      ""expired_at"": null,
      ""cancelling_at"": null,
      ""cancelled_at"": null,
      ""request_counts"": {
        ""total"": 100,
        ""completed"": 95,
        ""failed"": 5
      },
      ""metadata"": {
        ""customer_id"": ""user_123456789"",
        ""batch_description"": ""Nightly job"",
      }
    },
  ],
  ""first_id"": ""batch_abc123"",
  ""last_id"": ""batch_abc456"",
  ""has_more"": true
}";
    }
}
