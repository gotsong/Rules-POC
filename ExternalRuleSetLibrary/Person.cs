using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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

        public override int CompareTo(Person other)
        {
            if(other.FirstName != FirstName) _messages.Add("FirstName has changed to " + FirstName);
            if (other.MiddleName != MiddleName) _messages.Add("MiddleName has changed to " + MiddleName);
            if (other.LastName != LastName) _messages.Add("LastName has changed to " + LastName);
            if (other.Gender != Gender) _messages.Add("Gender has changed to " + Gender.ToString());
            if (other.HasPet != HasPet) _messages.Add("HasPet has changed to " + HasPet.ToString(CultureInfo.InvariantCulture));
            if (other.IsSingle != IsSingle) _messages.Add("IsSingle has changed to " + IsSingle.ToString(CultureInfo.InvariantCulture));            

            return 0;
        }
    }
}