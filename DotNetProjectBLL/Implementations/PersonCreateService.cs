using System.Threading.Tasks;
using DotNetProject.DotNetProjectBLL.Contracts;
using DotNetProject.DotNetProjectDataAccess.Contracts;
using DotNetProject.Models;

namespace DotNetProject.DotNetProjectBLL.Implementations
{
    public class PersonCreateService : IPersonCreateService
    {
        private IPersonDataAccess PersonDataAccess { get; }
        private ISecretGetService SecretGetService { get; }

        public PersonCreateService(IPersonDataAccess personDataAccess, ISecretGetService secretGetService)
        {
            this.PersonDataAccess = personDataAccess;
            this.SecretGetService = secretGetService;
        }

        public async Task<Person> CreateAsync(PersonUpdateModel person)
        {
            await this.SecretGetService.ValidateAsync(person);

            return await this.PersonDataAccess.InsertAsync(person);
        }
    }
}