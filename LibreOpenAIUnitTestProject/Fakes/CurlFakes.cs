﻿namespace LibreOpenAIUnitTestProject.Fakes
{
    internal class CurlFakes
    {
        public const string curlRetrieveBatchResponse = @"{
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
}
";
        public const string curlDeleteFileResponse = @"{
  ""id"": ""file-abc123"",
  ""object"": ""file"",
  ""deleted"": true
}
";
        public const string curlPostCreateUploadResponse = @"{
  ""id"": ""upload_abc123"",
  ""object"": ""upload"",
  ""bytes"": 2147483648,
  ""created_at"": 1719184911,
  ""filename"": ""training_examples.jsonl"",
  ""purpose"": ""fine-tune"",
  ""status"": ""pending"",
  ""expires_at"": 1719127296
}
";
    }
}
