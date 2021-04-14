using DotNetProjectClient.Request.Create;

namespace DotNetProjectClient.Request.Update
{
    public class SecretUpdateDTO : SecretCreateDTO
    {
        public int Id { get; set; }
    }
}