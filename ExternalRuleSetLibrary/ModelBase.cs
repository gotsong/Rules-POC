using System;
using Rules.ExternalRuleSetHandler;
using System.Collections.Generic;

namespace Rules.ExternalRuleSetLibrary
{
    public class ModelBase<T>:IComparable<T>
    {
        private RuleSetHandler _handler;

        public ModelBase(RuleSetHandler handler)
        {
            _handler = handler;
        }

        public void ExecuteRules()
        {
            _handler.ExecuteRuleSet(this);
        }

        public int CompareTo(T other)
        {
            throw new NotImplementedException();
        }
    }
}