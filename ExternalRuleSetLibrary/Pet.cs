using System.Globalization;
using Rules.ExternalRuleSetHandler;

namespace Rules.ExternalRuleSetLibrary
{
    public class Pet:ModelBase<Pet>
    {
        public Pet() : base(new RuleSetHandler("Pets")) 
        { }

        public Pet(string firstName, string lastName, Gender gender, bool hasOwner, FoodType food, PetType petType)
                : base(new RuleSetHandler("Pets"))
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            HasOwner = hasOwner;
            Food = food;
            TPetType = petType;
        }

        public enum PetType
        {
            Dog,
            Cat,
            Fish,
            GuineaPig,
            Bird,
            Monkey
        }

        public enum FoodType
        {
            Bananas,
            Dogfood,
            Catfood,
            Birdseed,
            Fishfood
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public bool HasOwner { get; set; }

        public FoodType Food { get; set; }

        public PetType TPetType { get; set; }

        public override int CompareTo(Pet other)
        {
            if (other.FirstName != FirstName) _messages.Add("FirstName has changed to " + FirstName);
            if (other.LastName != LastName) _messages.Add("LastName has changed to " + LastName);
            if (other.Gender != Gender) _messages.Add("Gender has changed to " + Gender.ToString());
            if (other.HasOwner != HasOwner) _messages.Add("HasOwner has changed to " + HasOwner.ToString(CultureInfo.InvariantCulture));
            if (other.Food != Food) _messages.Add("Food has changed to " + Food);
            if (other.TPetType != TPetType) _messages.Add("PetType has changed to " + TPetType);

            return 0;
        }
    }
}