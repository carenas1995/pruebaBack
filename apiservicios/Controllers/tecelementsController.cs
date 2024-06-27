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
    public class tecelementsController : ApiController
    {
        private Datamodel db = new Datamodel();

        // GET: api/tecelements
        public IQueryable<tecelement> Gettecelement()
        {
            return db.tecelement;
        }

        // GET: api/tecelements/5
        [ResponseType(typeof(tecelement))]
        public async Task<IHttpActionResult> Gettecelement(int id)
        {
            tecelement tecelement = await db.tecelement.FindAsync(id);
            if (tecelement == null)
            {
                return NotFound();
            }

            return Ok(tecelement);
        }

        // PUT: api/tecelements/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttecelement(int id, tecelement tecelement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tecelement.id)
            {
                return BadRequest();
            }

            db.Entry(tecelement).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tecelementExists(id))
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

        // POST: api/tecelements
        [ResponseType(typeof(tecelement))]
        public async Task<IHttpActionResult> Posttecelement(tecelement tecelement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tecelement.Add(tecelement);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tecelement.id }, tecelement);
        }

        // DELETE: api/tecelements/5
        [ResponseType(typeof(tecelement))]
        public async Task<IHttpActionResult> Deletetecelement(int id)
        {
            tecelement tecelement = await db.tecelement.FindAsync(id);
            if (tecelement == null)
            {
                return NotFound();
            }

            db.tecelement.Remove(tecelement);
            await db.SaveChangesAsync();

            return Ok(tecelement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tecelementExists(int id)
        {
            return db.tecelement.Count(e => e.id == id) > 0;
        }
    }
}