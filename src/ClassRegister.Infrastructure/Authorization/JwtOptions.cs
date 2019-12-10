namespace ClassRegister.Infrastructure.Authorization
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public bool ValidateLifetime { get; set; }
    }
}