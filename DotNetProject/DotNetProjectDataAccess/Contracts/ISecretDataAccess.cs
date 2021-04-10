﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetProject.Contracts;
using DotNetProject.Models;

namespace DotNetProject.DotNetProjectDataAccess.Contracts
{
    public interface ISecretDataAccess
    {
        Task<Secret> InsertAsync(SecretUpdateModel employee);
        Task<IEnumerable<Secret>> GetAsync();
        Task<Secret> GetAsync(ISecretIdentity employeeId);
        
        Task<Secret> GetByAsync(ISecretContainer secretId);
        Task<Secret> UpdateAsync(SecretUpdateModel employee);
    }
}