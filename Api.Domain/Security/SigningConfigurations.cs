using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace Api.Domain.Security
{
    public class SigningConfigurations
    {
        public SecurityKey Key { get; set; }
        public SigningCredentials SigningCredentials{ get; set; }
        public SigningConfigurations()
        {
            using(var provider = new RSACryptoServiceProvider(2048)) /*Using é usado para criar uma instancia e depois descarta-lo da memoria assim que usar. A provider deixará de exisitr depois que sair daqui*/
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }

    }
}
