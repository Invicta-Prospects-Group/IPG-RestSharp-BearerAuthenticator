using RestSharp;
using RestSharp.Authenticators;

namespace IPG.RestSharp.BearerAuthenticator
{
    public class BearerAuthenticator : IAuthenticator
    {
        private readonly string accessToken;

        /// <summary>
        /// Creates a new instance of the BearerAuthentication class.
        /// </summary>
        /// <param name="accessToken">The access token to use for Bearer authentication in the RestRequest / RestClient.</param>
        public BearerAuthenticator(string accessToken)
        {
            this.accessToken = accessToken;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            request.AddOrUpdateParameter("Authorization", "Bearer " + accessToken, ParameterType.HttpHeader);
        }
    }
}
