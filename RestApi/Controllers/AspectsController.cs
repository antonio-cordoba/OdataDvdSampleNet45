using EFSDAL;

namespace RestApi.Odata
{
    public class AspectsController : OdataMaster<aspect>
    {
        public AspectsController()
        {
            this.table = db.aspects;
        }
    }
}
