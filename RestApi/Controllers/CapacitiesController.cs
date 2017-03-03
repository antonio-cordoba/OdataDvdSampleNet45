using EFSDAL;

namespace RestApi.Odata
{
    public class CapacitiesController : OdataMaster<capacity>
    {
        public CapacitiesController()
        {
            this.table = db.capacities;
        }
    }
}
