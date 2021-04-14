using System;
using DotNetProject.Contracts;

namespace DotNetProject.Models
{
    public class PersonUpdateModel : IPersonIdentity, ISecretContainer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public int? SecretId { get; }
    }
}