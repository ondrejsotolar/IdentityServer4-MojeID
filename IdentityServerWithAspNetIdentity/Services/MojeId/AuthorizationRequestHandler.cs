using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechniServIT.MyeID.epoxid.Models.MojeId.Json;

namespace TechniServIT.MyeID.epoxid.Services.MojeId
{
    public class AuthorizationRequestHandler
    {
        private OidcUrlHelper _urlHelper;
        private WebEncoder _webEncoder;

        public AuthorizationRequestHandler()
        {
            _urlHelper = new OidcUrlHelper(); // TODO OS: use DI
            _webEncoder = new WebEncoder(); // TODO OS: use DI
        }

        // TODO OS: handle unsuccessfull attempt
        public async Task<AccessToken> RetrieveAccessToken(string redirectUri, string clientId, string clientSecret, StringValues code, string domain)
        {
            var hc = new HttpClient();
            hc.DefaultRequestHeaders.Authorization = 
                    _webEncoder.GetBasicAuthCredentialHeaderValue(clientId, clientSecret);

            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", code),
                new KeyValuePair<string, string>("redirect_uri", redirectUri),
            };


            var response = await hc.PostAsync(_urlHelper.ComposeTokenEndpointUrl(domain), new FormUrlEncodedContent(pairs));
            var responseString = await response.Content.ReadAsStringAsync();
            var responseWithoutBackslash = responseString.Replace(@"\", string.Empty);
            var accessToken = JsonConvert.DeserializeObject<AccessToken>(responseWithoutBackslash);

            return accessToken;
            

            //using (var wc = new WebClient())
            //{
            //    wc.Headers[HttpRequestHeader.Authorization] = 
            //        _webEncoder.GetBasicAuthCredentialHeaderValue(clientId, clientSecret);

            //    var reqParams = new NameValueCollection();
            //    reqParams.Add("grant_type", "authorization_code");
            //    reqParams.Add("code", code);
            //    reqParams.Add("redirect_uri", redirectUri);

            //    var response = wc.UploadValues(_urlHelper.ComposeTokenEndpointUrl(domain), "POST", reqParams);
            //    var responseString = UnicodeEncoding.UTF8.GetString(response);
            //    var responseWithoutBackslash = responseString.Replace(@"\", string.Empty);
            //    var accessToken = JsonConvert.DeserializeObject<AccessToken>(responseWithoutBackslash);

            //    return accessToken;
            //}
        }
    }
}
