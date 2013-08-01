using System.Collections.Generic;
//using Rules.ExternalRuleSetHandler;
using Rules.ExternalRuleSetLibrary;
using FactoryGirl.NET;
using Faker.Extensions;
using Faker;

namespace Rules.ExternalRuleSetTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        private void Run()
        {
            //Build random list of 10 persons
            FactoryGirl.NET.FactoryGirl.ClearFactoryDefinitions();
            FactoryGirl.NET.FactoryGirl.Define(() => new Person
                                                         {
                                                             FirstName = Faker.Name.First(),
                                                             LastName = Faker.Name.Last(),
                                                             MiddleName = Faker.Name.First(),
                                                             Gender = Gender.Male,
                                                             HasPet = Faker.BooleanFaker.Boolean(),
                                                             IsSingle = Faker.BooleanFaker.Boolean(),
                                                         }   
                                                         );
            var persons = FactoryGirl.NET.FactoryGirl.Build<Person>();

            FactoryGirl.NET.FactoryGirl.ClearFactoryDefinitions();
            FactoryGirl.NET.FactoryGirl.Define(() => new Pet
                                                         {
                                                             FirstName = Faker.Name.First(),
                                                             LastName =  Faker.Name.Last(),
                                                             TPetType = Faker.EnumFaker.SelectFrom<Pet.PetType>(),
                                                             Food = Faker.EnumFaker.SelectFrom<Pet.FoodType>(),
                                                             Gender = Faker.EnumFaker.SelectFrom<Gender>(),
                                                             HasOwner = Faker.BooleanFaker.Boolean()
                                                         }
                                                        );

            var pets = FactoryGirl.NET.FactoryGirl.Build<Pet>();

            //Run Rules against a fake collection of People

            //Run Rules against a fake collection of Pets
        }
    }
}
