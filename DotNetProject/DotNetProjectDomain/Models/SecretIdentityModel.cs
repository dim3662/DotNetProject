using DotNetProject.Contracts;

namespace DotNetProject.Models
{
    public class SecretIdentityModel : ISecretIdentity
    {
        public int Id { get; }

        public SecretIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}