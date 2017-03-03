using EFSDAL;

namespace RestApi.Odata
{
    public class GenresController : OdataMaster<genre>
    {
        public GenresController()
        {
            this.table = db.genres;
        }
    }
}
