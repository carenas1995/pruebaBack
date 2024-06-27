using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using apiservicios.Models;

namespace apiservicios.Controllers
{
    public class tecnicosController : ApiController
    {
        private Datamodel db = new Datamodel();

        // GET: api/tecnicos
        public IQueryable<tecnicos> Gettecnicos()
        {
            return db.tecnicos;
        }

        // GET: api/tecnicos/5
        [ResponseType(typeof(tecnicos))]
        public async Task<IHttpActionResult> Gettecnicos(int id)
        {
            tecnicos tecnicos = await db.tecnicos.FindAsync(id);
            if (tecnicos == null)
            {
                return NotFound();
            }

            return Ok(tecnicos);
        }

        // PUT: api/tecnicos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttecnicos(int id, tecnicos tecnicos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tecnicos.id)
            {
                return BadRequest();
            }

            db.Entry(tecnicos).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tecnicosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/tecnicos
        [ResponseType(typeof(tecnicos))]
        public async Task<IHttpActionResult> Posttecnicos(tecnicos tecnicos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tecnicos.Add(tecnicos);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tecnicos.id }, tecnicos);
        }

        // DELETE: api/tecnicos/5
        [ResponseType(typeof(tecnicos))]
        public async Task<IHttpActionResult> Deletetecnicos(int id)
        {
            tecnicos tecnicos = await db.tecnicos.FindAsync(id);
            if (tecnicos == null)
            {
                return NotFound();
            }

            db.tecnicos.Remove(tecnicos);
            await db.SaveChangesAsync();

            return Ok(tecnicos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tecnicosExists(int id)
        {
            return db.tecnicos.Count(e => e.id == id) > 0;
        }
    }
}