using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DotNetProject.Contracts;
using DotNetProject.DotNetProjectDataAccess.Context;
using DotNetProject.DotNetProjectDataAccess.Contracts;
using DotNetProject.DotNetProjectDataAccess.Entities;
using DotNetProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetProject.DotNetProjectDataAccess.Implementations
{
    public class SecretDataAccess  : ISecretDataAccess
    {
        private SecretDirectoryContext Context { get; }
        private IMapper Mapper { get; }
        
        public SecretDataAccess(SecretDirectoryContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<DotNetProject.Secret> InsertAsync(SecretUpdateModel employee)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Secret>(employee));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Secret>(result.Entity);
        }

        public async Task<IEnumerable<Secret>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Secret>>(
                await this.Context.Secrets.Include(x => x.Message).ToListAsync());
        }

        public async Task<Secret> GetAsync(ISecretIdentity employee)
        {
            var result = await this.Get(employee);

            return this.Mapper.Map<Secret>(result);
        }

        public Task<Secret> GetByAsync(ISecretContainer secretId)
        {
            throw new NotImplementedException();
        }

        private async Task<Entities.Secret> Get(ISecretIdentity employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            
            return await this.Context.Secrets.Include(x => x.Message)
                .FirstOrDefaultAsync(x => x.Id == employee.Id);
        }

        public async Task<Secret> UpdateAsync(SecretUpdateModel employee)
        {
            var existing = await this.Get(employee);

            var result = this.Mapper.Map(employee, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Secret>(result);
        }
    }
    
}