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
using Planter.Models;

namespace Planter.Controllers
{
    public class PlantsController : ApiController
    {
        private PlanterContext db = new PlanterContext();

        // GET: api/Plants
        public IQueryable<Plant> GetPlants()
        {
            return db.Plants;
        }

        // GET: api/Plants/5
        [ResponseType(typeof(Plant))]
        public async Task<IHttpActionResult> GetPlant(int id)
        {
            Plant plant = await db.Plants.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }

            return Ok(plant);
        }

        // PUT: api/Plants/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPlant(int id, Plant plant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plant.Id)
            {
                return BadRequest();
            }

            db.Entry(plant).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantExists(id))
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

        // POST: api/Plants
        [ResponseType(typeof(Plant))]
        public async Task<IHttpActionResult> PostPlant(Plant plant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Plants.Add(plant);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = plant.Id }, plant);
        }

        // DELETE: api/Plants/5
        [ResponseType(typeof(Plant))]
        public async Task<IHttpActionResult> DeletePlant(int id)
        {
            Plant plant = await db.Plants.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }

            db.Plants.Remove(plant);
            await db.SaveChangesAsync();

            return Ok(plant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlantExists(int id)
        {
            return db.Plants.Count(e => e.Id == id) > 0;
        }
    }
}