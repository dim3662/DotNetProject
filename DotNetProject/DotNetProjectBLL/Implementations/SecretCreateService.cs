using System.Threading.Tasks;
using DotNetProject.DotNetProjectBLL.Contracts;
using DotNetProject.DotNetProjectDataAccess.Contracts;
using DotNetProject.Models;

namespace DotNetProject.DotNetProjectBLL.Implementations
{
    public class SecretCreateService : ISecretCreateService
    {
         private ISecretDataAccess SecretDataAccess { get; }
        private IMessageGetService MessageGetService { get; }

        public SecretCreateService(ISecretDataAccess secretDataAccess, IMessageGetService messageGetService)
        {
            this.SecretDataAccess = secretDataAccess;
            this.MessageGetService = messageGetService;
        }

        public async Task<Secret> CreateAsync(SecretUpdateModel secret)
        {
            await this.MessageGetService.ValidateAsync(secret);

            return await this.SecretDataAccess.InsertAsync(secret);
        }
    }
}