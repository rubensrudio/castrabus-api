namespace CastraBus.Common.Singleton
{
    public class JwtOptions
    {
        public String Issuer { get; set; }
        public String Audience { get; set; }
        public String SigningKey { get; set; }
        public Int64 ExpirationSeconds { get; set; }
    }
}
