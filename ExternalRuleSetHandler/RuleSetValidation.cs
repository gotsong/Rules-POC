using System;
using System.Diagnostics;
using System.Workflow.Activities.Rules;
using System.Workflow.ComponentModel.Compiler;

namespace ExternalRuleSetHandler
{
    public class RuleSetValidation
    {
        private Type _targetType;

        public RuleSetValidation(Type targetType)
        {
            _targetType = targetType;
        }

        private RuleExecution ValidateRuleSet(object targetObject)
        {
            RuleValidation ruleValidation;

            ruleValidation = new RuleValidation(_targetType, null);
            if (!ruleSet.Validate(ruleValidation))
            {
                string errors = "";
                foreach (ValidationError validationError in ruleValidation.Errors)
                    errors = errors + validationError.ErrorText + "\n";
                Debug.WriteLine("Validation Errors \n" + errors);
                return null;
            }
            else
            {
                return new RuleExecution(ruleValidation, targetObject);
            }
        }         
    }
}