using System;
using System.Diagnostics;
using System.Workflow.Activities.Rules;
using System.Workflow.ComponentModel.Compiler;

namespace Rules.ExternalRuleSetHandler
{
    public class RuleSetValidation
    {
        private object _targetType;
        private RuleSet _ruleSet;

        public RuleSetValidation(object targetType, RuleSet ruleSet)
        {
            _ruleSet = ruleSet;
            _targetType = targetType;
        }

        public RuleExecution ValidateRuleSet(object targetType)
        {
            _targetType = targetType;

            RuleValidation ruleValidation = new RuleValidation(_targetType.GetType(), null);
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