using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechniServIT.MyeID.epoxid.Services.MojeId
{
    public class UrlHelperBase
    {
        const string HttpsPrefix = "https://";

        public string ComposeHttpsUrl(string insecureUrl)
        {
            if (string.IsNullOrEmpty(insecureUrl) || insecureUrl.StartsWith(HttpsPrefix))
                return insecureUrl;

            return $"{HttpsPrefix}{insecureUrl}";
        }
    }

    public class OidcUrlHelper : UrlHelperBase
    {
        public string CallbackPathRelative => "/signin-oidc";

        public string ComposeTokenEndpointUrl(string domain)
        {
            return ComposeHttpsUrl($"{domain}/token/");
        }

        public string ComposeLogoutUrl(string logoutUri, string clientId, string redirectUri)
        {
            return ComposeHttpsUrl($"{logoutUri}?client_id={clientId}&returnTo={Uri.EscapeDataString(redirectUri)}");
        }
    }
}
