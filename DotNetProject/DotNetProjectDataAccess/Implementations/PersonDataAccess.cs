using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DotNetProject.Contracts;
using DotNetProject.DotNetProjectDataAccess.Context;
using DotNetProject.DotNetProjectDataAccess.Contracts;
using DotNetProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetProject.DotNetProjectDataAccess.Implementations
{
    public class PersonDataAccess : IPersonDataAccess
    {
        private SecretDirectoryContext Context { get; }
        private IMapper Mapper { get; }

        public PersonDataAccess(SecretDirectoryContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<DotNetProject.Person> InsertAsync(PersonUpdateModel employee)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Person>(employee));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Person>(result.Entity);
        }

        public async Task<IEnumerable<Person>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Person>>(
                await this.Context.Persons.Include(x => x.Secret).ToListAsync());
        }

        public async Task<Person> GetAsync(IPersonIdentity employee)
        {
            var result = await this.Get(employee);

            return this.Mapper.Map<Person>(result);
        }

        public Task<Person> GetByAsync(IPersonContainer personId)
        {
            throw new NotImplementedException();
        }


        private async Task<Entities.Person> Get(IPersonIdentity employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            return await this.Context.Persons.Include(x => x.Secret)
                .FirstOrDefaultAsync(x => x.Id == employee.Id);
        }

        public async Task<Person> UpdateAsync(PersonUpdateModel employee)
        {
            var existing = await this.Get(employee);

            var result = this.Mapper.Map(employee, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Person>(result);
        }
    }
}