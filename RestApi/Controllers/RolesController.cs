using MySql.EF.DataAccess;
using System.Security.Principal;
using Microsoft.AspNet.Identity;
using RestApi.Services;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using RestApi.Models;
using System.Net.Http;
using Microsoft.AspNet.Identity.Owin;

namespace RestApi.Controllers
{
    [Authorize]
    public class RolesController : ODataController
    {
        private IdentityEntities db = new IdentityEntities();

        private ApplicationRoleManager _roleManager;

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? Request.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        public RolesController() { }
        private bool RoleExists(string key)
        {
            return db.Roles.Any(p => p.Id == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        [EnableQuery]
        public IQueryable<Role> Get()
        {
            return db.Roles;
        }
        [EnableQuery]
        public SingleResult<Role> Get([FromODataUri] string key)
        {
            IQueryable<Role> result = db.Roles.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        [EnableQuery]
        public IHttpActionResult Post([FromBody] Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var loggedUser = db.UserFromIdentity(User);

            if (!loggedUser.HasFunction(AuthFunctions.ADMIN_TAB))
            {
                throw AuthMessages.PERMISSION_EXCEPTION();
            }

            Role dbRole = null;
                
            if (! string.IsNullOrEmpty(role.Id))
                dbRole= db.Roles.Where(r => (r.Id == role.Id)).FirstOrDefault();

            if (dbRole == null)
            {
                ApplicationRole ar = new ApplicationRole { Name = role.Name };

                if (!RoleManager.RoleExists(ar.Name))
                    RoleManager.Create(ar);

                dbRole = db.Roles.Where(r => (r.Id == ar.Id)).FirstOrDefault();
            }

            if (dbRole != null)
            {
                dbRole.Name = role.Name;
                dbRole.Active = role.Active;

                dbRole.LastModified = new LastModified() {
                    LastModifiedUser = loggedUser.UserInfos.First().Id,
                    LastModifiedDate = System.DateTime.Now };

                var desiredFunctionIds = role.Functions.Select(f => f.Id).ToList();
                dbRole.Functions.Merge(db.Functions.Where(p => desiredFunctionIds.Contains(p.Id)));

                db.SaveChanges();
                return Created(dbRole);
            }

            throw AuthMessages.OUT_OF_REACH_EXCEPTION();
        }
    }
}
