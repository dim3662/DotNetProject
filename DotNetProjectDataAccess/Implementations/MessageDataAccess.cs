using System.Threading.Tasks;
using AutoMapper;
using DotNetProject.Contracts;
using DotNetProject.DotNetProjectDataAccess.Context;
using DotNetProject.DotNetProjectDataAccess.Contracts;
using DotNetProject.DotNetProjectDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetProject.DotNetProjectDataAccess.Implementations
{
    public class MessageDataAccess : IMessageDataAccess
    {
        private SecretDirectoryContext Context { get; }
        private IMapper Mapper { get; }
        
        public MessageDataAccess(SecretDirectoryContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<Message> GetByAsync(IMessageContainer department)
        {
            return department.MessageId.HasValue 
                ? this.Mapper.Map<Message>(await this.Context.Messages.FirstOrDefaultAsync(x => x.Id == department.MessageId)) 
                : null;
        }
    }
    
}