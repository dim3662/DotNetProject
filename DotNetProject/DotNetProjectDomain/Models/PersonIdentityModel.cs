using DotNetProject.Contracts;

namespace DotNetProject.Models
{
    public class PersonIdentityModel  : IPersonIdentity
    {
        public int Id { get; }

        public PersonIdentityModel(int id)
        {
            this.Id = id;
        }
    }

}