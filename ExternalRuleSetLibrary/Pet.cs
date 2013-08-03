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
    }
}