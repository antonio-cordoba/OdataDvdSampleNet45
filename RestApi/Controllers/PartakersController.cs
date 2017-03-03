using EFSDAL;

namespace RestApi.Odata
{
    public class PartakersController : OdataMaster<partaker>
    {
        public PartakersController()
        {
            this.table = db.partakers;
        }
    }
}
