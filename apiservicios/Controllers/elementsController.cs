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
    public class elementsController : ApiController
    {
        private Datamodel db = new Datamodel();

        // GET: api/elements
        public IQueryable<element> Getelement()
        {
            return db.element;
        }

        // GET: api/elements/5
        [ResponseType(typeof(element))]
        public async Task<IHttpActionResult> Getelement(int id)
        {
            element element = await db.element.FindAsync(id);
            if (element == null)
            {
                return NotFound();
            }

            return Ok(element);
        }

        // PUT: api/elements/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putelement(int id, element element)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != element.id)
            {
                return BadRequest();
            }

            db.Entry(element).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!elementExists(id))
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

        // POST: api/elements
        [ResponseType(typeof(element))]
        public async Task<IHttpActionResult> Postelement(element element)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.element.Add(element);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = element.id }, element);
        }

        // DELETE: api/elements/5
        [ResponseType(typeof(element))]
        public async Task<IHttpActionResult> Deleteelement(int id)
        {
            element element = await db.element.FindAsync(id);
            if (element == null)
            {
                return NotFound();
            }

            db.element.Remove(element);
            await db.SaveChangesAsync();

            return Ok(element);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool elementExists(int id)
        {
            return db.element.Count(e => e.id == id) > 0;
        }
    }
}