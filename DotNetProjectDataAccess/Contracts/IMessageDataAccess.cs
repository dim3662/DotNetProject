using System.Threading.Tasks;
using DotNetProject.Contracts;
using DotNetProject.DotNetProjectDataAccess.Entities;

namespace DotNetProject.DotNetProjectDataAccess.Contracts
{
    public interface IMessageDataAccess
    {
        Task<Message> GetByAsync(IMessageContainer messageId);
    }
}