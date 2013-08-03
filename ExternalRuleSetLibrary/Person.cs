using System.Collections;
using System.Collections.Generic;
using Rules.ExternalRuleSetHandler;

namespace Rules.ExternalRuleSetLibrary
{
    public enum Gender{Male,Female}

    public class Person:ModelBase<Person>
    {
        public Person():base(new RuleSetHandler("People"))
        {
        }

        public Person(string firstName, string lastName, string middleName, Gender gender, bool hasPet, bool isSingle)
            : base(new RuleSetHandler("People"))
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Gender = gender;
            HasPet = hasPet;
            IsSingle = isSingle;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public Gender Gender { get; set; }

        public bool HasPet { get; set; }

        public bool IsSingle { get; set; }
    }
}