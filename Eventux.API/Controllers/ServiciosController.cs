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
using Eventux.Common.Models;
using Eventux.Domain.Models;

namespace Eventux.API.Controllers
{
    public class ServiciosController : ApiController
    {
        private Datacontext db = new Datacontext();

        // GET: api/Servicios
        public IQueryable<Servicios> GetServicios()
        {
            return db.Servicios;
        }

        // GET: api/Servicios/5
        [ResponseType(typeof(Servicios))]
        public async Task<IHttpActionResult> GetServicios(int id)
        {
            Servicios servicios = await db.Servicios.FindAsync(id);
            if (servicios == null)
            {
                return NotFound();
            }

            return Ok(servicios);
        }

        // PUT: api/Servicios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutServicios(int id, Servicios servicios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != servicios.ServiceId)
            {
                return BadRequest();
            }

            db.Entry(servicios).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciosExists(id))
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

        // POST: api/Servicios
        [ResponseType(typeof(Servicios))]
        public async Task<IHttpActionResult> PostServicios(Servicios servicios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Servicios.Add(servicios);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = servicios.ServiceId }, servicios);
        }

        // DELETE: api/Servicios/5
        [ResponseType(typeof(Servicios))]
        public async Task<IHttpActionResult> DeleteServicios(int id)
        {
            Servicios servicios = await db.Servicios.FindAsync(id);
            if (servicios == null)
            {
                return NotFound();
            }

            db.Servicios.Remove(servicios);
            await db.SaveChangesAsync();

            return Ok(servicios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiciosExists(int id)
        {
            return db.Servicios.Count(e => e.ServiceId == id) > 0;
        }
    }
}