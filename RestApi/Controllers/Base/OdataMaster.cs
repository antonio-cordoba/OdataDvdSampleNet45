﻿using EFSDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace RestApi.Odata
{
    public class OdataMaster<t> : ODataController where t : class
    {
        protected SGreenBox db;

        protected DbSet<t> table { get; set; }
        public OdataMaster(SGreenBox dbc) { db = dbc; }

        public OdataMaster()
        {
            if (db == null)
                db = new SGreenBox();
        }

        [EnableQuery]
        public IQueryable<t> Get()
        {
            return table;
        }

        [EnableQuery]
        public SingleResult<t> Get([FromODataUri] int key)
        {
            List<t> results = new List<t>();
            results.Add(table.Find(key));
            return SingleResult.Create(results.AsQueryable());
        }

        public async Task<IHttpActionResult> Post(t entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            table.Add(entry);
            await db.SaveChangesAsync();

            return Created(entry);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
