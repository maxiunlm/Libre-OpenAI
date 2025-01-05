namespace LibreOpenAIUnitTestProject.Fakes
{
    internal class FineTuningJobsFakes
    {
        public const string responseListDataType = "message";
        public const string resquestCreateDefault = @"{
    training_file: ""file-abc123""
  }";
        public const string responseCreateDefault = @"{
  ""object"": ""fine_tuning.job"",
  ""id"": ""ftjob-abc123"",
  ""model"": ""gpt-4o-mini-2024-07-18"",
  ""created_at"": 1721764800,
  ""fine_tuned_model"": null,
  ""organization_id"": ""org-123"",
  ""result_files"": [],
  ""status"": ""queued"",
  ""validation_file"": null,
  ""training_file"": ""file-abc123"",
  ""method"": {
    ""type"": ""supervised"",
    ""supervised"": {
      ""hyperparameters"": {
        ""batch_size"": ""auto"",
        ""learning_rate_multiplier"": ""auto"",
        ""n_epochs"": ""auto"",
      }
    }
  }
}";
        public const string resquestCreateEpochs = @"{
    training_file: ""file-abc123"",
    model: ""gpt-4o-mini"",
    method: {
      type: ""supervised"",
      supervised: {
        hyperparameters: {
          n_epochs: 2
        }
      }
    }
  }";
        public const string responseCreateEpochs = @"{
  ""object"": ""fine_tuning.job"",
  ""id"": ""ftjob-abc123"",
  ""model"": ""gpt-4o-mini-2024-07-18"",
  ""created_at"": 1721764800,
  ""fine_tuned_model"": null,
  ""organization_id"": ""org-123"",
  ""result_files"": [],
  ""status"": ""queued"",
  ""validation_file"": null,
  ""training_file"": ""file-abc123"",
  ""hyperparameters"": {""n_epochs"": 2},
  ""method"": {
    ""type"": ""supervised"",
    ""supervised"": {
      ""hyperparameters"": {
        ""batch_size"": ""auto"",
        ""learning_rate_multiplier"": ""auto"",
        ""n_epochs"": 2,
      }
    }
  }
}";
        public const string resquestCreateValidationFile = @"{
    training_file: ""file-abc123"",
    validation_file: ""file-abc123""
  }";
        public const string responseCreateValidationFile = @"{
  ""object"": ""fine_tuning.job"",
  ""id"": ""ftjob-abc123"",
  ""model"": ""gpt-4o-mini-2024-07-18"",
  ""created_at"": 1721764800,
  ""fine_tuned_model"": null,
  ""organization_id"": ""org-123"",
  ""result_files"": [],
  ""status"": ""queued"",
  ""validation_file"": ""file-abc123"",
  ""training_file"": ""file-abc123"",
  ""method"": {
    ""type"": ""supervised"",
    ""supervised"": {
      ""hyperparameters"": {
        ""batch_size"": ""auto"",
        ""learning_rate_multiplier"": ""auto"",
        ""n_epochs"": ""auto"",
      }
    }
  }
}";
        // TODO: CURL: Extensions
        public const string resquestCreateDpo = @"{
    ""training_file"": ""file-abc123"",
    ""validation_file"": ""file-abc123"",
    ""model"": ""gpt-4o-mini"",
    ""method"": {
      ""type"": ""dpo"",
      ""dpo"": {
        ""hyperparameters"": {
          ""beta"": 0.1,
        }
      }
    }
  }";
        // TODO: CURL: Extensions
        public const string responseCreateDpo = @"{
  ""object"": ""fine_tuning.job"",
  ""id"": ""ftjob-abc123"",
  ""model"": ""gpt-4o-mini-2024-07-18"",
  ""created_at"": 1721764800,
  ""fine_tuned_model"": null,
  ""organization_id"": ""org-123"",
  ""result_files"": [],
  ""status"": ""queued"",
  ""validation_file"": ""file-abc123"",
  ""training_file"": ""file-abc123"",
  ""method"": {
    ""type"": ""dpo"",
    ""dpo"": {
      ""hyperparameters"": {
        ""beta"": 0.1,
        ""batch_size"": ""auto"",
        ""learning_rate_multiplier"": ""auto"",
        ""n_epochs"": ""auto"",
      }
    }
  }
}";
        // TODO: CURL: Extensions
        public const string resquestCreateWAndBIntegration = @"{
    ""training_file"": ""file-abc123"",
    ""validation_file"": ""file-abc123"",
    ""model"": ""gpt-4o-mini"",
    ""integrations"": [
      {
        ""type"": ""wandb"",
        ""wandb"": {
          ""project"": ""my-wandb-project"",
          ""name"": ""ft-run-display-name""
          ""tags"": [
            ""first-experiment"", ""v2""
          ]
        }
      }
    ]
  }";
        // TODO: CURL: Extensions
        public const string responseCreateWAndBIntegration = @"{
  ""object"": ""fine_tuning.job"",
  ""id"": ""ftjob-abc123"",
  ""model"": ""gpt-4o-mini-2024-07-18"",
  ""created_at"": 1721764800,
  ""fine_tuned_model"": null,
  ""organization_id"": ""org-123"",
  ""result_files"": [],
  ""status"": ""queued"",
  ""validation_file"": ""file-abc123"",
  ""training_file"": ""file-abc123"",
  ""integrations"": [
    {
      ""type"": ""wandb"",
      ""wandb"": {
        ""project"": ""my-wandb-project"",
        ""entity"": None,
        ""run_id"": ""ftjob-abc123""
      }
    }
  ],
  ""method"": {
    ""type"": ""supervised"",
    ""supervised"": {
      ""hyperparameters"": {
        ""batch_size"": ""auto"",
        ""learning_rate_multiplier"": ""auto"",
        ""n_epochs"": ""auto"",
      }
    }
  }
}";
        // TODO: CURL: Extensions: GET: https://api.openai.com/v1/fine_tuning/jobs/{fine_tuning_job_id}/checkpoints
        public const string responseCreateCheckpoints = @"{
  ""object"": ""list""
  ""data"": [
    {
      ""object"": ""fine_tuning.job.checkpoint"",
      ""id"": ""ftckpt_zc4Q7MP6XxulcVzj4MZdwsAB"",
      ""created_at"": 1721764867,
      ""fine_tuned_model_checkpoint"": ""ft:gpt-4o-mini-2024-07-18:my-org:custom-suffix:96olL566:ckpt-step-2000"",
      ""metrics"": {
        ""full_valid_loss"": 0.134,
        ""full_valid_mean_token_accuracy"": 0.874
      },
      ""fine_tuning_job_id"": ""ftjob-abc123"",
      ""step_number"": 2000,
    },
    {
      ""object"": ""fine_tuning.job.checkpoint"",
      ""id"": ""ftckpt_enQCFmOTGj3syEpYVhBRLTSy"",
      ""created_at"": 1721764800,
      ""fine_tuned_model_checkpoint"": ""ft:gpt-4o-mini-2024-07-18:my-org:custom-suffix:7q8mpxmy:ckpt-step-1000"",
      ""metrics"": {
        ""full_valid_loss"": 0.167,
        ""full_valid_mean_token_accuracy"": 0.781
      },
      ""fine_tuning_job_id"": ""ftjob-abc123"",
      ""step_number"": 1000,
    },
  ],
  ""first_id"": ""ftckpt_zc4Q7MP6XxulcVzj4MZdwsAB"",
  ""last_id"": ""ftckpt_enQCFmOTGj3syEpYVhBRLTSy"",
  ""has_more"": true
}";
        public const string responseList = @"{
  ""object"": ""list"",
  ""data"": [
    {
      ""object"": ""fine_tuning.job.event"",
      ""id"": ""ft-event-TjX0lMfOniCZX64t9PUQT5hn"",
      ""created_at"": 1689813489,
      ""level"": ""warn"",
      ""message"": ""Fine tuning process stopping due to job cancellation"",
      ""data"": null,
      ""type"": ""message""
    },
  ], ""has_more"": true
}";
        public const string resquestListEvents = "ftjob-abc123";
        public const string responseListEvents = @"{
  ""object"": ""list"",
  ""data"": [
    {
      ""object"": ""fine_tuning.job.event"",
      ""id"": ""ft-event-ddTJfwuMVpfLXseO0Am0Gqjm"",
      ""created_at"": 1721764800,
      ""level"": ""info"",
      ""message"": ""Fine tuning job successfully completed"",
      ""data"": null,
      ""type"": ""message""
    },
    {
      ""object"": ""fine_tuning.job.event"",
      ""id"": ""ft-event-tyiGuB72evQncpH87xe505Sv"",
      ""created_at"": 1721764800,
      ""level"": ""info"",
      ""message"": ""New fine-tuned model created: ft:gpt-4o-mini:openai::7p4lURel"",
      ""data"": null,
      ""type"": ""message""
    }
  ],
  ""has_more"": true
}";
        public const string resquestRetrieve = "ftjob-abc123";
        public const string responseRetrieve = @"{
  ""object"": ""fine_tuning.job"",
  ""id"": ""ftjob-abc123"",
  ""model"": ""davinci-002"",
  ""created_at"": 1692661014,
  ""finished_at"": 1692661190,
  ""fine_tuned_model"": ""ft:davinci-002:my-org:custom_suffix:7q8mpxmy"",
  ""organization_id"": ""org-123"",
  ""result_files"": [
      ""file-abc123""
  ],
  ""status"": ""succeeded"",
  ""validation_file"": null,
  ""training_file"": ""file-abc123"",
  ""hyperparameters"": {
      ""n_epochs"": 4,
      ""batch_size"": 1,
      ""learning_rate_multiplier"": 1.0
  },
  ""trained_tokens"": 5768,
  ""integrations"": [],
  ""seed"": 0,
  ""estimated_finish"": 0,
  ""method"": {
    ""type"": ""supervised"",
    ""supervised"": {
      ""hyperparameters"": {
        ""n_epochs"": 4,
        ""batch_size"": 1,
        ""learning_rate_multiplier"": 1.0
      }
    }
  }
}";
        public const string resquestCancel = "ftjob-abc123";
        public const string responseCancel = @"{
  ""object"": ""fine_tuning.job"",
  ""id"": ""ftjob-abc123"",
  ""model"": ""gpt-4o-mini-2024-07-18"",
  ""created_at"": 1721764800,
  ""fine_tuned_model"": null,
  ""organization_id"": ""org-123"",
  ""result_files"": [],
  ""status"": ""cancelled"",
  ""validation_file"": ""file-abc123"",
  ""training_file"": ""file-abc123""
}";
    }
}
