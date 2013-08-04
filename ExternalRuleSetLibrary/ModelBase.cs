using System;
using Rules.ExternalRuleSetHandler;
using System.Collections.Generic;

namespace Rules.ExternalRuleSetLibrary
{
    public abstract class ModelBase<T>:IComparable<T> where T : new()
    {
        public List<string> _messages = new List<string>();

        public T ModelOriginal { get; set; }

        protected ModelBase(string ruleSetName)
        {
//            ModelOriginal = new T();
            RuleSetHandler.LoadRuleSet(ruleSetName);
        }

        public void ExecuteRules()
        {
            RuleSetHandler.ExecuteRuleSet(this);
        }

        public abstract int CompareTo(T other);
    }
}