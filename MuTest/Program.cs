using MuTest.Domain;
using System;

namespace MuTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var mutator1 = new MutatorFactory<Person>()
                          .AddMutation(p => p.FirstName, "Joe")
                          .AddMutation(p => p.LastName, "Blow")
                          .AddMutation(p => p.Email, "j.b@email.com")
                          .AddMutation(p => p.Address, "123 Main St")
                          .AddMutation(p => p.Birthday, new DateTime(1980, 1, 1))
                          .AddMutation(p => p.Age, 21)
                          .Build();

            var person1 = mutator1.Apply(Person.Default);
            Console.WriteLine(person1.ToString());


            var mutator2 = new MutatorFactory<Person>()
                          .AddMutation(p => p.FirstName, "Martin")
                          .AddMutation(p => p.Birthday, p => p.Birthday?.AddDays(1), options => { options.If = p => p.Age > 25; })
                          .Build();

            var person2 = mutator2.Apply(person1.Value);
            Console.WriteLine(person2.ToString());
        }
    }
}