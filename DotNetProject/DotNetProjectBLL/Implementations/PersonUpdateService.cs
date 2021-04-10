using System.Threading.Tasks;
using DotNetProject.DotNetProjectBLL.Contracts;
using DotNetProject.DotNetProjectDataAccess.Contracts;
using DotNetProject.Models;

namespace DotNetProject.DotNetProjectBLL.Implementations
{
    public class PersonUpdateService : IPersonUpdateService
    {
        private IPersonDataAccess PersonDataAccess { get; }
        private ISecretGetService SecretGetService { get; }

        public PersonUpdateService(IPersonDataAccess personDataAccess, ISecretGetService secretGetService)
        {
            this.PersonDataAccess = personDataAccess;
            this.SecretGetService = secretGetService;
        }

        public async Task<Person> UpdateAsync(PersonUpdateModel person)
        {
            await this.SecretGetService.ValidateAsync(person);

            return await this.PersonDataAccess.UpdateAsync(person);
        }
    }
    
}