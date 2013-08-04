using System;
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
            
            GeneratePersonFakes(10);

            //Run Rules against a fake collection of People
            foreach(var person in _persons)
            {
                person.ModelOriginal = new Person
                                           {
                                               FirstName = person.FirstName,
                                               MiddleName = person.MiddleName,
                                               LastName = person.LastName,
                                               Gender = person.Gender,
                                               HasPet = person.HasPet,
                                               IsSingle = person.IsSingle                                               
                                           };

                person.ExecuteRules();
                person.CompareTo(person.ModelOriginal);

                if(person._messages.Count > 0)
                {
                    Console.WriteLine("Rule changes occured for person {0} {1}",person.FirstName,person.LastName);
                    foreach(var msg in person._messages)
                    {
                        Console.WriteLine("===============================================================================");
                        Console.WriteLine(msg);
                        Console.WriteLine("===============================================================================");
                    }
                }
            }

            GeneratePetFakes(10);
            //Run Rules against a fake collection of Pets
            foreach (var pet in _pets)
            {
                pet.ModelOriginal = new Pet
                                        {
                                            FirstName = pet.FirstName,
                                            LastName = pet.LastName,
                                            TPetType = pet.TPetType,
                                            Gender = pet.Gender,
                                            HasOwner = pet.HasOwner,
                                            Food = pet.Food
                                        };
                pet.ExecuteRules();
                pet.CompareTo(pet.ModelOriginal);

                if (pet._messages.Count > 0)
                {
                    Console.WriteLine("Rule changes occured for pet {0} {1} of type {2}", pet.FirstName, pet.LastName,pet.TPetType.ToString());

                    foreach (var msg in pet._messages)
                    {
                        Console.WriteLine("===============================================================================");
                        Console.WriteLine(msg);
                        Console.WriteLine("===============================================================================");
                    }
                }
            }

            Console.ReadLine();
        }

        private void GeneratePersonFakes(int count)
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

            }
        }

        private void GeneratePetFakes(int count)
        {
            _persons = new List<Person>();
            _pets = new List<Pet>();

            for (var i = 1; i <= count; i++)
            {
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
