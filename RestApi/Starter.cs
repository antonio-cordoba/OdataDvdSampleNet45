using System.Web.Http;
using Owin;
using Microsoft.Owin.Security.OAuth;

namespace RestApi
{
    public class Starter
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Configuration(IAppBuilder owinApp)
        {
            HttpConfiguration webApiConfig = new HttpConfiguration();

            RestApiConfig.Register(webApiConfig);
         
            owinApp.UseWebApi(webApiConfig);
        }
    }
}
