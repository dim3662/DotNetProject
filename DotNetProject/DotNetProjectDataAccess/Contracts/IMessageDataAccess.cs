using System.Threading.Tasks;
using DotNetProject.Contracts;

namespace DotNetProject.DotNetProjectDataAccess.Contracts
{
    public interface IMessageDataAccess
    {
        Task<Message> GetByAsync(IMessageContainer messageId);
    }
}