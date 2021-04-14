using DotNetProjectClient.Request.Create;

namespace DotNetProjectClient.Request.Update
{
    public class PersonUpdateDTO : SecretCreateDTO
    {
        public int Id { get; set; }
    }
}