using Microsoft.Extensions.Configuration;

namespace EventHub.Core.Utilities.JWT
{
    public class JwtHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOption tokenOption;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            tokenOption = Configuration.GetSection("TokenOption").Get<TokenOption>();
        }
    }
}
