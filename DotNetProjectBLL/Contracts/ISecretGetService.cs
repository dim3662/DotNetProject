using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetProject.Contracts;

namespace DotNetProject.DotNetProjectBLL.Contracts
{
    public interface ISecretGetService
    {
        Task<IEnumerable<Secret>> GetAsync();
        Task<Secret> GetAsync(ISecretIdentity secret);
        Task ValidateAsync(ISecretContainer secretContainer);
    }
}