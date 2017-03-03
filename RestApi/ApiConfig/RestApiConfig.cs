using System.Web.Http;
using RestApi.ApiConfig;
using Newtonsoft.Json;

namespace RestApi
{
    public static class RestApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Switch default serializer to JSON
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            ODataModelConfig.setModels(config);
        }
    }
}
