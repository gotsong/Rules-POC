using System;
using System.Workflow.Activities.Rules;
using Rules.ExternalRuleSetService;


namespace Rules.ExternalRuleSetHandler
{
    public class RuleSetHandler
    {
        public static string RuleSetName { get; set; }

        private static string _ruleSetName { get; set; }
//        public RuleSetHandler(string ruleSetName)
//        {
//            LoadRuleSet(ruleSetName);
//        }

        public static void LoadRuleSet(string ruleSetName)
        {
            if (string.IsNullOrEmpty(ruleSetName))
                throw new Exception("Ruleset name cannot be null or empty.");
            if (!string.Equals(_ruleSetName, ruleSetName))
            {
                _ruleSetName = ruleSetName;

                //TODO: Needs refactoring into a rule cache to minimize database traffic for production
                var ruleService = new ExternalRuleSetService.ExternalRuleSetService();
                 RuleSet = ruleService.GetRuleSet(new RuleSetInfo(ruleSetName));
                if (RuleSet == null)
                {
                    throw new Exception(
                        "RuleSet could not be loaded. Make sure the connection string and ruleset name are correct.");
                }
            }
        }

        public static RuleSet RuleSet { get; private set; }

        public static void ExecuteRuleSet(object targetType)
        {            
            if (RuleSet != null)
            {                
                var validator = new RuleSetValidation(targetType, RuleSet);
                var ruleExecution = validator.ValidateRuleSet(targetType);
                ExecuteRule(ruleExecution);
            }

        }

        private static void ExecuteRule(RuleExecution ruleExecution)
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