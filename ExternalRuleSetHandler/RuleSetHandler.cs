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
        private RuleSet _ruleSet;

        public void LoadRuleSet(string ruleSetName)
        {
            var serializer = new WorkflowMarkupSerializer();
            if (string.IsNullOrEmpty(ruleSetName))
                throw new Exception("Ruleset name cannot be null or empty.");
            if (!string.Equals(RuleSetName, ruleSetName))
            {
                _ruleSetName = ruleSetName;

                var ruleService = new ExternalRuleSetService();
                var ruleSet = ruleService.GetRuleSet(new RuleSetInfo(ruleSetName));
                if (ruleSet == null)
                {
                    throw new Exception("RuleSet could not be loaded. Make sure the connection string and ruleset name are correct.");
                }
            }
        }

        public string RuleSetName
        {
            get { return _ruleSetName; }
            set { _ruleSetName = value; }
        }

        public RuleSet RuleSet
        {
            get { return _ruleSet; }
        }
    }
}