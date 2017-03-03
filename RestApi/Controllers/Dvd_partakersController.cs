using EFSDAL;

namespace RestApi.Odata
{
    public class Dvd_partakersController : OdataMaster<dvd_partaker>
    {
        public Dvd_partakersController()
        {
            this.table = db.dvd_partakers;
        }
    }
}
