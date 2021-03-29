using System;
using System.Collections.Generic;

namespace DotNetProject.DotNetProjectBLL.Contracts
{
    public interface ISecretBLL
    {
        Secret createNew(string password, Message message, string lifeTime, DateTime createdAt);

        Secret getById(Guid id);

        string getRealLifeTime();

        ICollection<Secret> getAll();
    }
}