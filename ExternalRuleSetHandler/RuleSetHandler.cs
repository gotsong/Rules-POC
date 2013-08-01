using System;
using System.Workflow.Activities.Rules;
using System.Workflow.ComponentModel.Serialization;
using Microsoft.Samples.Rules.ExternalRuleSetLibrary;
using Microsoft.Samples.Rules.ExternalRuleSetService;

namespace ExternalRuleSetHandler
{
    public class RuleSetHandler
    {
        private string _ruleSetName;

        public void LoadRuleSet(string ruleSetName)
        {
            if (string.IsNullOrEmpty(ruleSetName))
                throw new Exception("Ruleset name cannot be null or empty.");
            if (!string.Equals(_ruleSetName, ruleSetName))
            {
                _ruleSetName = ruleSetName;

                var ruleService = new ExternalRuleSetService();
                 RuleSet = ruleService.GetRuleSet(new RuleSetInfo(ruleSetName));
                if (RuleSet == null)
                {
                    throw new Exception(
                        "RuleSet could not be loaded. Make sure the connection string and ruleset name are correct.");
                }
            }
        }

        public RuleSet RuleSet { get; private set; }

        public void ExecuteRuleSet(Type targetType)
        {
            if (RuleSet != null)
            {                
                var validator = new RuleSetValidation(targetType, RuleSet);
                var ruleExecution = validator.ValidateRuleSet(targetType);
                ExecuteRule(ruleExecution);
            }

        }

        private void ExecuteRule(RuleExecution ruleExecution)
        {
            if (null != ruleExecution)
            {
                RuleSet.Execute(ruleExecution);
            }
            else
            {
                throw new Exception("RuleExecution is null.");
            }
        }
    }
}