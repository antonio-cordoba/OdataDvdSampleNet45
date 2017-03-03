using EFSDAL;

namespace RestApi.Odata
{
    public class StatusesController : OdataMaster<status>
    {
        public StatusesController() // (PGreenBox dbc) : base(dbc)
        {
            this.table = db.status;
        }
    }
}