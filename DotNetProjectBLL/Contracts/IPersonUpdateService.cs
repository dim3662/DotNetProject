using System.Threading.Tasks;
using DotNetProject.Models;

namespace DotNetProject.DotNetProjectBLL.Contracts
{
    public interface IPersonUpdateService
    {
        Task<Person> UpdateAsync(PersonUpdateModel person);
    }
}