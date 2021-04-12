using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetProject.Contracts;
using DotNetProject.DotNetProjectBLL.Contracts;
using DotNetProject.DotNetProjectDataAccess.Contracts;

namespace DotNetProject.DotNetProjectBLL.Implementations
{
    public class SecretGetService : ISecretGetService
    {
        private ISecretDataAccess SecretDataAccess { get; }

        public SecretGetService(ISecretDataAccess secretDataAccess)
        {
            this.SecretDataAccess = secretDataAccess;
        }

        public Task<IEnumerable<Secret>> GetAsync()
        {
            return this.SecretDataAccess.GetAsync();
        }

        public Task<Secret> GetAsync(ISecretIdentity secret)
        {
            return this.SecretDataAccess.GetAsync(secret);
        }

        public async Task ValidateAsync(ISecretContainer secretContainer)
        {
            if (secretContainer == null)
            {
                throw new ArgumentNullException(nameof(secretContainer));
            }

            var secret = await this.GetBy(secretContainer);

            if (secretContainer.SecretId.HasValue && secret == null)
            {
                throw new InvalidOperationException($"Secret not found by id {secretContainer.SecretId}");
            }
        }

        private async Task<Secret> GetBy(ISecretContainer secretContainer)
        {
            return await this.SecretDataAccess.GetByAsync(secretContainer);
        }
    }
}