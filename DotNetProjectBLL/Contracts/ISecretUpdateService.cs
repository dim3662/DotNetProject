using System.Threading.Tasks;
using DotNetProject.Models;

namespace DotNetProject.DotNetProjectBLL.Contracts
{
    public interface ISecretUpdateService
    {
        Task<Secret> UpdateAsync(SecretUpdateModel secret);
    }
}