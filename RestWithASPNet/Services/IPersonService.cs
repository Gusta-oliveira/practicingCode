using RestWithASPNet.Models;

namespace RestWithASPNet.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        IEnumerable<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
