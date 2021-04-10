using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetProject.Contracts;
using DotNetProject.Models;

namespace DotNetProject.DotNetProjectDataAccess.Contracts
{
    public interface IPersonDataAccess
    {
        Task<Person> InsertAsync(PersonUpdateModel person);
        Task<IEnumerable<Person>> GetAsync();
        Task<Person> GetAsync(IPersonIdentity personId);

        Task<Person> GetByAsync(IPersonContainer personId);
        
        Task<Person> UpdateAsync(PersonUpdateModel person);
    }
}