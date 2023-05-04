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
using TVapimvcuygulama.Models;

namespace TVapimvcuygulama.Controllers
{
    public class GörevlersController : ApiController
    {
        private apimvcuygulamaEntities3 db = new apimvcuygulamaEntities3();

        // GET: api/Görevlers
        public IQueryable<Görevler> GetGörevler()
        {
            return db.Görevler;
        }

        // GET: api/Görevlers/5
        [ResponseType(typeof(Görevler))]
        public async Task<IHttpActionResult> GetGörevler(int id)
        {
            Görevler görevler = await db.Görevler.FindAsync(id);
            if (görevler == null)
            {
                return NotFound();
            }

            return Ok(görevler);
        }

        // PUT: api/Görevlers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGörevler(int id, Görevler görevler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != görevler.GörevNo)
            {
                return BadRequest();
            }

            db.Entry(görevler).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GörevlerExists(id))
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

        // POST: api/Görevlers
        [ResponseType(typeof(Görevler))]
        public async Task<IHttpActionResult> PostGörevler(Görevler görevler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Görevler.Add(görevler);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = görevler.GörevNo }, görevler);
        }

        // DELETE: api/Görevlers/5
        [ResponseType(typeof(Görevler))]
        public async Task<IHttpActionResult> DeleteGörevler(int id)
        {
            Görevler görevler = await db.Görevler.FindAsync(id);
            if (görevler == null)
            {
                return NotFound();
            }

            db.Görevler.Remove(görevler);
            await db.SaveChangesAsync();

            return Ok(görevler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GörevlerExists(int id)
        {
            return db.Görevler.Count(e => e.GörevNo == id) > 0;
        }
    }
}