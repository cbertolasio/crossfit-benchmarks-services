using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.IdentityModel.Claims;
using Microsoft.IdentityModel.Web;
using WindowsAzure.Acs.Oauth2.Protocol.Swt;

namespace WindowsAzure.Acs.Oauth2.ResourceServer
{
    public class MyOAuth2MessageHandler : DelegatingHandler
    {
        private readonly string _realm;
        private string _issuer;
        private string _serviceNamespace;
        private string _tokenSigningKey;
        private List<IAuthenticationStep> authenticationPipeline = new List<IAuthenticationStep>();

        public void AddAuthenticationStep(IAuthenticationStep step)
        {
            authenticationPipeline.Add(step);
        }

        public void SetAuthenticationPipeline(IEnumerable<IAuthenticationStep> pipeline)
        {
            authenticationPipeline = pipeline.ToList();
        }


        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpContextBase httpContext;

            if (!request.TryGetHttpContext(out httpContext))
            {
                throw new InvalidOperationException("HttpContext must not be null.");
            }


            string accessToken;
            // checks if it is an OAuth Request and gets the access token
            if (TryReadAccessToken(request, out accessToken))
            {
                // Parses the token and validates it.
                ResourceAccessErrorResponse error;
                if (!ReadAndValidateToken(accessToken, out error))
                {
                    throw new HttpResponseException(
                            new HttpResponseMessage(HttpStatusCode.BadRequest) {
                                Content = new ObjectContent(typeof(ResourceAccessErrorResponse), error, new JsonMediaTypeFormatter())
                            });
                }
            }

            return base.SendAsync(request, cancellationToken);
        }

        /// <summary>
        /// This method looks for the access token in the incoming request.
        /// </summary>
        /// <param name="request">The incoming request message.</param>
        /// <param name="accessToken">This out parameter contains the access token if found.</param>
        /// <returns>True if access token is found , otherwise false.</returns>
        protected bool TryReadAccessToken(HttpRequestMessage request, out string accessToken)
        {
            accessToken = null;

            // search for tokens in the Authorization header            
            accessToken = GetTokenFromAuthorizationHeader(request);
            if (!string.IsNullOrEmpty(accessToken))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the access token from the Authorization header of the incoming request.
        /// </summary>
        /// <param name="request">The Http request message.</param>
        /// <returns>The access token.</returns>
        public string GetTokenFromAuthorizationHeader(HttpRequestMessage request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (!request.Headers.Contains("Authorization"))
            {
                return null;
            }


            string authHeader = request.Headers.GetValues("Authorization").FirstOrDefault();
            // check that it starts with 'OAuth2'
            if (!authHeader.StartsWith("OAuth2 ")) {
                return null;
            }

            string[] nameValuePair = authHeader.Substring("OAuth2 ".Length).Split(new char[] { '=' }, 2);

            if (nameValuePair.Length != 2 ||
                nameValuePair[0] != "access_token" ||
                !nameValuePair[1].StartsWith("\"") ||
                !nameValuePair[1].EndsWith("\"")) {
                return null;
            }

            // trim off the leading and trailing double-quotes
            string token = nameValuePair[1].Substring(1, nameValuePair[1].Length - 2);

            return token;
        }

        /// <summary>
        /// This method parses the incoming token and validates it.
        /// </summary>
        /// <param name="accessToken">The incoming access token.</param>
        /// <param name="error">This out paramter is set if any error occurs.</param>
        /// <returns>True on success, False on error.</returns>
        protected bool ReadAndValidateToken(string accessToken, out ResourceAccessErrorResponse error)
        {
            error = null;
            bool tokenValid = false;
            // create a token validator
            TokenValidator validator = new TokenValidator("accesscontrol.windows.net", _serviceNamespace,
                this._realm,
                this._tokenSigningKey);

            // validate the token
            try
            {
                if (validator.Validate(accessToken))
                {
                    var handler = new SimpleWebTokenHandler(_issuer, _tokenSigningKey);

                    // read the token
                    SecurityToken token = null;
                    token = handler.ReadToken(accessToken);

                    // validate the token
                    ClaimsIdentityCollection claimsIdentityCollection = null;
                    claimsIdentityCollection = handler.ValidateToken(token, _realm);
                    // create a claims Principal from the token
                    var claimsPrincipal = ClaimsPrincipal.CreateFromIdentities(claimsIdentityCollection);
                    if (claimsPrincipal != null) {
                        tokenValid = true;

                        // push it through the pipeline
                        foreach (var step in authenticationPipeline) {
                            claimsPrincipal = step.Authenticate(token, claimsPrincipal);
                        }

                        // assign to threads
                        if (HttpContext.Current != null) {
                            HttpContext.Current.User = claimsPrincipal;
                        }
                        Thread.CurrentPrincipal = claimsPrincipal;
                    }

                    return true;
                }
            }
            catch (InvalidTokenReceivedException ex) {
                error = new ResourceAccessErrorResponse(_realm, ex.ErrorCode, ex.ErrorDescription);
            }
            catch (ExpiredTokenReceivedException ex) {
                error = new ResourceAccessErrorResponse(_realm, ex.ErrorCode, ex.ErrorDescription);
            }
            catch (Exception) {
                error = new ResourceAccessErrorResponse(_realm, "SWT401", "Token validation failed");
            }

            return tokenValid;
        }

        public  MyOAuth2MessageHandler() : this(ConfigurationManager.AppSettings["WindowsAzure.OAuth.RelyingPartyRealm"],
                    string.Format("https://{0}.accesscontrol.windows.net/", ConfigurationManager.AppSettings["WindowsAzure.OAuth.ServiceNamespace"]),
                    ConfigurationManager.AppSettings["WindowsAzure.OAuth.SwtSigningKey"], ConfigurationManager.AppSettings["WindowsAzure.OAuth.ServiceNamespace"])
        {
        }

        public MyOAuth2MessageHandler(string realm, string issuer, string tokenSigningKey, string serviceNamespace)
        {
            if (realm == null) throw new ArgumentNullException("realm");
            if (issuer == null) throw new ArgumentNullException("issuer");
            if (tokenSigningKey == null) throw new ArgumentNullException("tokenSigningKey");

            _realm = realm;
            _issuer = issuer;
            _tokenSigningKey = tokenSigningKey;
            _serviceNamespace = serviceNamespace;
        }
    }
}

