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
    public class sucursalesController : ApiController
    {
        private Datamodel db = new Datamodel();

        // GET: api/sucursales
        public IQueryable<sucursales> Getsucursales()
        {
            return db.sucursales;
        }

        // GET: api/sucursales/5
        [ResponseType(typeof(sucursales))]
        public async Task<IHttpActionResult> Getsucursales(int id)
        {
            sucursales sucursales = await db.sucursales.FindAsync(id);
            if (sucursales == null)
            {
                return NotFound();
            }

            return Ok(sucursales);
        }

        // PUT: api/sucursales/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putsucursales(int id, sucursales sucursales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sucursales.id)
            {
                return BadRequest();
            }

            db.Entry(sucursales).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sucursalesExists(id))
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

        // POST: api/sucursales
        [ResponseType(typeof(sucursales))]
        public async Task<IHttpActionResult> Postsucursales(sucursales sucursales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sucursales.Add(sucursales);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sucursales.id }, sucursales);
        }

        // DELETE: api/sucursales/5
        [ResponseType(typeof(sucursales))]
        public async Task<IHttpActionResult> Deletesucursales(int id)
        {
            sucursales sucursales = await db.sucursales.FindAsync(id);
            if (sucursales == null)
            {
                return NotFound();
            }

            db.sucursales.Remove(sucursales);
            await db.SaveChangesAsync();

            return Ok(sucursales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool sucursalesExists(int id)
        {
            return db.sucursales.Count(e => e.id == id) > 0;
        }
    }
}