using System.Collections.Generic;
using Rules.ExternalRuleSetHandler;
using Rules.ExternalRuleSetLibrary;
using FactoryGirl.NET;
using Faker.Extensions;
using Faker;

namespace Rules.ExternalRuleSetTestClient
{
    class Program
    {
        private List<Person> _persons;
        private List<Pet> _pets;

        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        private void Run()
        {
            var handler = new RuleSetHandler();            
            
            GenerateFakes(10);

            //Run Rules against a fake collection of People
            foreach(var person in _persons)
            {
                handler.ExecuteRuleSet("People", person);
            }

            //Run Rules against a fake collection of Pets
            foreach (var pet in _pets)
            {
                handler.ExecuteRuleSet("Pets", pet);
            }
        }

        private void GenerateFakes(int count)
        {
            _persons = new List<Person>();
            _pets = new List<Pet>();

            for (var i = 1; i <= count;i++)
            {
                FactoryGirl.NET.FactoryGirl.ClearFactoryDefinitions();
                FactoryGirl.NET.FactoryGirl.Define(() => new Person
                                                             {
                                                                 FirstName = Name.First(),
                                                                 LastName = Faker.Name.Last(),
                                                                 MiddleName = Faker.Name.First(),
                                                                 Gender = Gender.Male,
                                                                 HasPet = Faker.BooleanFaker.Boolean(),
                                                                 IsSingle = Faker.BooleanFaker.Boolean(),
                                                             });
                        
                var person = FactoryGirl.NET.FactoryGirl.Build<Person>();
                _persons.Add(person);

                FactoryGirl.NET.FactoryGirl.ClearFactoryDefinitions();
                FactoryGirl.NET.FactoryGirl.Define(() => new Pet
                {
                    FirstName = Faker.Name.First(),
                    LastName = Faker.Name.Last(),
                    TPetType = Faker.EnumFaker.SelectFrom<Pet.PetType>(),
                    Food = Faker.EnumFaker.SelectFrom<Pet.FoodType>(),
                    Gender = Faker.EnumFaker.SelectFrom<Gender>(),
                    HasOwner = Faker.BooleanFaker.Boolean()
                });

                var pet = FactoryGirl.NET.FactoryGirl.Build<Pet>();         
                _pets.Add(pet);

            }
        }

    }
}
