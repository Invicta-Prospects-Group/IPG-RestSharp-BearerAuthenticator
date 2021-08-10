using RestSharp;
using RestSharp.Authenticators;
using System;

namespace IPG.RestSharp.BearerAuthenticator
{
    public class BearerAuthenticator : IAuthenticator
    {
        private readonly string accessToken;
        private readonly Func<string> accessTokenEvaluator;

        /// <summary>
        /// Creates a new instance of the BearerAuthentication class.
        /// </summary>
        /// <param name="accessToken">The access token to use for Bearer authentication in the RestRequest / RestClient.</param>
        public BearerAuthenticator(string accessToken)
        {
            this.accessToken = accessToken;
        }

        /// <summary>
        /// Creates a new instance of the BearerAuthentication class (this consructor useful in certain DI scenarios).
        /// </summary>
        /// <param name="">A function to get the access token when it's is only known after the the class has been instaniated.</param>
        public BearerAuthenticator(Func<string> accessTokenEvaluator)
        {
            this.accessTokenEvaluator = accessTokenEvaluator;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            var realAccessToken = accessToken ?? accessTokenEvaluator.Invoke();

            if (realAccessToken == null)
                throw new ArgumentNullException(nameof(realAccessToken));

            request.AddOrUpdateParameter("Authorization", "Bearer " + realAccessToken, ParameterType.HttpHeader);
        }
    }
}
