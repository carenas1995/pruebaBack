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
    public class tecsucusController : ApiController
    {
        private Datamodel db = new Datamodel();

        // GET: api/tecsucus
        public IQueryable<tecsucu> Gettecsucu()
        {
            return db.tecsucu;
        }

        // GET: api/tecsucus/5
        [ResponseType(typeof(tecsucu))]
        public async Task<IHttpActionResult> Gettecsucu(int id)
        {
            tecsucu tecsucu = await db.tecsucu.FindAsync(id);
            if (tecsucu == null)
            {
                return NotFound();
            }

            return Ok(tecsucu);
        }

        // PUT: api/tecsucus/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttecsucu(int id, tecsucu tecsucu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tecsucu.id)
            {
                return BadRequest();
            }

            db.Entry(tecsucu).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tecsucuExists(id))
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

        // POST: api/tecsucus
        [ResponseType(typeof(tecsucu))]
        public async Task<IHttpActionResult> Posttecsucu(tecsucu tecsucu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tecsucu.Add(tecsucu);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tecsucu.id }, tecsucu);
        }

        // DELETE: api/tecsucus/5
        [ResponseType(typeof(tecsucu))]
        public async Task<IHttpActionResult> Deletetecsucu(int id)
        {
            tecsucu tecsucu = await db.tecsucu.FindAsync(id);
            if (tecsucu == null)
            {
                return NotFound();
            }

            db.tecsucu.Remove(tecsucu);
            await db.SaveChangesAsync();

            return Ok(tecsucu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tecsucuExists(int id)
        {
            return db.tecsucu.Count(e => e.id == id) > 0;
        }
    }
}