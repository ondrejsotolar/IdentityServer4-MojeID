using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TechniServIT.MyeID.epoxid.Services
{
    public class WebEncoder
    {
        public SymmetricSecurityKey EncodeOidcClientSecret(string clientSecret)
        {
            var keyAsBytes = Encoding.UTF8.GetBytes(clientSecret);
            return new SymmetricSecurityKey(keyAsBytes);
        }

        //public string GetBasicAuthCredentialHeaderValue(string clientId, string clientSecret)
        //{
        //    var credentials = Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}");
        //    return $"Basic {Convert.ToBase64String(credentials)}";
        //}

        public AuthenticationHeaderValue GetBasicAuthCredentialHeaderValue(string clientId, string clientSecret)
        {
            var credentials = Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}");
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
        }
    }
}
