using System;
using System.Threading.Tasks;
using DotNetProject.Contracts;
using DotNetProject.DotNetProjectBLL.Contracts;
using DotNetProject.DotNetProjectDataAccess.Contracts;

namespace DotNetProject.DotNetProjectBLL.Implementations
{
    public class MessageGetService : IMessageGetService
    {
        private IMessageDataAccess MessageDataAccess { get; }

        public MessageGetService(IMessageDataAccess messageDataAccess)
        {
            this.MessageDataAccess = messageDataAccess;
        }

        public async Task ValidateAsync(IMessageContainer messageContainer)
        {
            if (messageContainer == null)
            {
                throw new ArgumentNullException(nameof(messageContainer));
            }

            var message = await this.GetBy(messageContainer);

            if (messageContainer.MessageId.HasValue && message == null)
            {
                throw new InvalidOperationException($"Message not found by id {messageContainer.MessageId}");
            }
        }

        private async Task<Message> GetBy(IMessageContainer messageContainer)
        {
            return await this.MessageDataAccess.GetByAsync(messageContainer);
        }
    }
}