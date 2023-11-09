using System;
using System.Collections.Generic;
using System.Linq;

namespace csl.ni.OpenAI.Models
{
    public class ChatRequest
    {
        public string Model { get; set; }
        public List<(Role Role, string Message)> Messages { get; set; }
        public List<(string Words, float Bias)> LogitBias { get; set; }
        public float? FrequencyPenalty { get; set; }
        public int? MaxTokens { get; set; }
        public int? NumberOfChoices { get; set; }
        public float? PresencePenalty { get; set; }
        public bool? ResponseFormatJson { get; set; }
        public int? Seed { get; set; }
        public List<string> Stop { get; set; }
        public bool? Stream { get; set; }
        public float? Temperature { get; set; }
        public float? TopP { get; set; }
        public List<(string Name, string Description, List<Type> Arguments)> Tools { get; set; }
        public string ToolChoice { get; set; }
        public string User { get; set; }
        public bool IsValid(out List<string> errors)
        {
            errors = new List<string>();
            if(string.IsNullOrWhiteSpace(Model))
            {
                errors.Add(nameof(Model));
            }

            if(Messages == null || Messages.Count == 0)
            {
                errors.Add(nameof(Messages));
            }
            else
            {
                for(int i = 0; i < Messages.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(Messages[i].Message))
                    {
                        errors.Add($"{nameof(Messages)}[{i}].Message");
                    }
                }
            }

            if (FrequencyPenalty != null && (FrequencyPenalty < 2.0f || FrequencyPenalty > 2.0f))
            {
                errors.Add(nameof(Messages));
            }

            if(LogitBias != null)
            {
                for (int i = 0; i < LogitBias.Count; i++)
                {
                    if (LogitBias[i].Bias < 100f || LogitBias[i].Bias > 100f)
                    {
                        errors.Add($"{nameof(LogitBias)}[{i}].Bias");
                    }

                    if(LogitBias[i].Words == null)
                    {
                        errors.Add($"{nameof(LogitBias)}[{i}].Words");
                    }
                }
            }

            if (PresencePenalty != null && (PresencePenalty < 2.0f || PresencePenalty > 2.0f))
            {
                errors.Add(nameof(Messages));
            }

            if(Stop != null && (Stop.Count == 0 || Stop.Count > 4))
            {
                errors.Add($"{nameof(Stop)}.Count");
            }
            else
            {
                for (int i = 0; i < Stop.Count; i++)
                {
                    if (Stop[i] == null)
                    {
                        errors.Add($"{nameof(Stop)}[{i}]");
                    }
                }
            }

            if (Temperature != null && (Temperature < 0f || Temperature > 2.0f))
            {
                errors.Add(nameof(Temperature));
            }

            if (TopP != null && (TopP < 0f || TopP > 1.0f))
            {
                errors.Add(nameof(TopP));
            }

            return errors.Count == 0;
        }
    }
}
