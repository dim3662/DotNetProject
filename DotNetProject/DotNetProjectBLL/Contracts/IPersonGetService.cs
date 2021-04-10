using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetProject.Contracts;

namespace DotNetProject.DotNetProjectBLL.Contracts
{
    public interface IPersonGetService
    {
        Task<IEnumerable<Person>> GetAsync();
        Task<Person> GetAsync(IPersonIdentity person);
    }
}