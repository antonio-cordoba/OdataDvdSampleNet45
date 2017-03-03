using EFSDAL;

namespace RestApi.Odata
{
    public class StudiosController : OdataMaster<studio>
    {
        public StudiosController() 
        {
            this.table = db.studios;
        }
    }
}
