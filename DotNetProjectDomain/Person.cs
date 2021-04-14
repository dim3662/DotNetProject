using DotNetProject.Contracts;

namespace DotNetProject
{
    public class Person : ISecretContainer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public Secret Secret { get; set; }
        
        int? ISecretContainer.SecretId => this.Secret.Id;
    }
}