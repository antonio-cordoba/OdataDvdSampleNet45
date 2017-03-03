using EFSDAL;

namespace RestApi.Odata
{
    public class DvdsController : OdataMaster<dvd>
    {
        public DvdsController()
        {
            this.table = db.dvds;
        }
    }
}
