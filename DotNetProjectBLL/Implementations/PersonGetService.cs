using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetProject.Contracts;
using DotNetProject.DotNetProjectBLL.Contracts;
using DotNetProject.DotNetProjectDataAccess.Contracts;

namespace DotNetProject.DotNetProjectBLL.Implementations
{
    public class PersonGetService : IPersonGetService
    {
        private IPersonDataAccess PersonDataAccess { get; }

        public PersonGetService(IPersonDataAccess personDataAccess)
        {
            this.PersonDataAccess = personDataAccess;
        }

        public Task<IEnumerable<Person>> GetAsync()
        {
            return this.PersonDataAccess.GetAsync();
        }

        public Task<Person> GetAsync(IPersonIdentity person)
        {
            return this.PersonDataAccess.GetAsync(person);
        }

        public async Task ValidateAsync(IPersonContainer personContainer)
        {
            if (personContainer == null)
            {
                throw new ArgumentNullException(nameof(personContainer));
            }

            var person = await this.GetBy(personContainer);

            if (personContainer.PersonId.HasValue && person == null)
            {
                throw new InvalidOperationException($"Person not found by id {personContainer.PersonId}");
            }
        }

        private async Task<Person> GetBy(IPersonContainer personContainer)
        {
            return await this.PersonDataAccess.GetByAsync(personContainer);
        }
    }
    
}