using System.Threading.Tasks;
using DotNetProject.Models;

namespace DotNetProject.DotNetProjectBLL.Contracts
{
    public interface IPersonCreateService
    {
        Task<Person> CreateAsync(PersonUpdateModel employee);
    }
}