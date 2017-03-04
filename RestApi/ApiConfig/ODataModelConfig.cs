using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using EFSDAL;
using RestApi.Extensions;

namespace RestApi.ApiConfig
{
    public static class ODataModelConfig
    {
        internal static void setModels(HttpConfiguration webApiConfig)
        {

            ODataModelBuilder odataMetadataBuilder = new ODataConventionModelBuilder();

            odataMetadataBuilder.Register<dvd>(name: "Dvds", key: a => a.id);
            odataMetadataBuilder.Register<dvd_partaker>(name: "Dvd_partakers", key: a => a.id);
            odataMetadataBuilder.Register<aspect>(name: "Aspects", key: a => a.code);
            odataMetadataBuilder.Register<capacity>(name: "Capacities", key: a => a.code);
            odataMetadataBuilder.Register<studio>(name: "Studios", key: a => a.id);
            odataMetadataBuilder.Register<partaker>(name: "Partakers", key: a => a.id);
            odataMetadataBuilder.Register<genre>(name: "Genres", key: a => a.code);
            odataMetadataBuilder.Register<rating>(name: "Ratings", key: a => a.code);
            odataMetadataBuilder.Register<status>(name: "Statuses", key: a => a.code);

            webApiConfig.MapODataServiceRoute(
                routeName: "odata",
                routePrefix: "odata",
                model: odataMetadataBuilder.GetEdmModel());

        }
    }
}
