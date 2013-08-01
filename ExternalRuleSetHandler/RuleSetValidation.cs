using System;
using System.Diagnostics;
using System.Workflow.Activities.Rules;
using System.Workflow.ComponentModel.Compiler;

namespace ExternalRuleSetHandler
{
    public class RuleSetValidation
    {
        private Type _targetType;
        private RuleSet _ruleSet;

        public RuleSetValidation(Type targetType,RuleSet ruleSet)
        {
            _targetType = targetType;
        }

        public RuleExecution ValidateRuleSet(Type targetType)
        {
            _targetType = targetType;

            RuleValidation ruleValidation = new RuleValidation(_targetType, null);
            if (!_ruleSet.Validate(ruleValidation))
            {
                string errors = "";
                foreach (ValidationError validationError in ruleValidation.Errors)
                    errors = errors + validationError.ErrorText + "\n";
                Debug.WriteLine("Validation Errors \n" + errors);
                return null;
            }
            else
            {
                return new RuleExecution(ruleValidation, _targetType);
            }
        }         
    }
}