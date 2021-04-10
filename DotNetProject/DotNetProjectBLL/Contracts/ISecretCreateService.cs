using System.Threading.Tasks;
using DotNetProject.Models;

namespace DotNetProject.DotNetProjectBLL.Contracts
{
    public interface ISecretCreateService
    {
        Task<Secret> CreateAsync(SecretUpdateModel employee);
    }
}