using System;
using System.Linq.Expressions;
using System.Web.OData.Builder;
using System.Web.OData.Query;

namespace RestApi.Extensions
{
    public static class OdataCustom
    {
        public static void Register<t>(this ODataModelBuilder om, string name, Expression<Func<t, int>> key) where t : class
        {
            om.EntitySet<t>(name)
                .EntityType.HasKey(key)
                .Filter(QueryOptionSetting.Allowed)
                .Select(SelectExpandType.Allowed)
                .Expand(SelectExpandType.Allowed, 3)
                .OrderBy(QueryOptionSetting.Allowed)
                .Page(50, 200)
                .Count(QueryOptionSetting.Allowed);
        }
    }
}
