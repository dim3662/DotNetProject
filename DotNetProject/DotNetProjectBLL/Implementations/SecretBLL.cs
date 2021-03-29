using System;
using System.Collections.Generic;
using DotNetProject.DotNetProjectBLL.Contracts;

namespace DotNetProject.DotNetProjectBLL.Implementations
{
    public class SecretBLL : ISecretBLL
    {
        private readonly IMessageBLL messageBll;

        public SecretBLL(IMessageBLL messageBll)
        {
            this.messageBll = messageBll;
        }

        public Secret createNew(string password, Message message, string lifeTime, DateTime createdAt)
        {
            var result = new Secret();
            result.Password = password;
            result.Message = message;
            result.Lifetime = lifeTime;
            result.CreatedAt = createdAt;
            return result;
        }

        public Secret getById(Guid id)
        {
            throw new NotImplementedException();
        }

        public string getRealLifeTime()
        {
            throw new NotImplementedException();
        }

        public ICollection<Secret> getAll()
        {
            throw new NotImplementedException();
        }
    }
}