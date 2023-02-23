using AdoNetCarWebpage.Models;

namespace AdoNetCarWebpage.Repository
{
    public interface IPersonRepository
    {
        public Task<List<Person>> GetPerson();
        public Task<Person> GetPersonById(int PersonId);
        public Task<int> Create(Person person);
        public Task<int> Update(Person person);
        public Task<int> Delete(int PersonId);

    }
}
