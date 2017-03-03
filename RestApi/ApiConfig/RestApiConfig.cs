using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using RestApi.ApiConfig;
using log4net;
using Newtonsoft.Json;

namespace RestApi
{
    public static class RestApiConfig
    {
        
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            //// Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            //// Web API routes
            //config.MapHttpAttributeRoutes();

            ODataModelConfig.setModels(config);

        }
    }
}
