namespace EventHub.Core.Utilities.JWT
{
    public class TokenOption
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Expiration { get; set; }
        public string SecretKey { get; set; }
    }
}
