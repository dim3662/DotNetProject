using System.Threading.Tasks;
using DotNetProject.Contracts;

namespace DotNetProject.DotNetProjectBLL.Contracts
{
    public interface IMessageGetService
    {
        Task ValidateAsync(IMessageContainer messageContainer);
    }
}