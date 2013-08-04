using System;
using Rules.ExternalRuleSetHandler;
using System.Collections.Generic;

namespace Rules.ExternalRuleSetLibrary
{
    public abstract class ModelBase<T>:IComparable<T>
    {
        public List<string> _messages = new List<string>();

        //private RuleSetHandler _handler;

        protected ModelBase(string ruleSetName)
        {
            RuleSetHandler.LoadRuleSet(ruleSetName);
        }

        public void ExecuteRules()
        {
            RuleSetHandler.ExecuteRuleSet(this);
        }

        public abstract int CompareTo(T other);
    }
}