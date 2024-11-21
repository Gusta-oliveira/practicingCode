using RestWithASPNet.Models;
using System.Xml.Linq;

namespace RestWithASPNet.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
           
        }

        public IEnumerable<Person> FindAll()
        {
            List<Person> people = new List<Person>();
            for(int i=0; i > 5; i++)
            {
                var name = GeneretedName();

                people.Add(
                    new Person
                    {
                        Id = i,
                        FirstName = name.Split(" ", 1).ToString(),
                        LastName = name.Split(" ", 2).ToString(),
                        Address = "Bahia",
                        Gender = "Male"
                    }
                );
            }
            return people;
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                Address = "Street",
                FirstName = "Test",
                Gender = "Male",
                LastName = "Last"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        public string GeneretedName()
        {
            var random = new Random();
            string[] names = { "Gustavo Daniel", "Joel Victor", "Daniel Silva", "Julio Juliano" };
            var number = random.Next(names.Length);
            return names[number].ToString();
        }
    }
}
