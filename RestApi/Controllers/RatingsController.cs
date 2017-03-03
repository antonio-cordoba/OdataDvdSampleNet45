using EFSDAL;

namespace RestApi.Odata
{
    public class RatingsController : OdataMaster<rating>
    {
        public RatingsController()
        {
            this.table = db.ratings;
        }
    }
}
