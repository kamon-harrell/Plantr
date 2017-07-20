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
using Plantr.Models;

namespace Plantr.Controllers
{
    public class PlantInfoController : ApiController
    {
        private PlantrContext db = new PlantrContext();

        // GET: api/PlantInfo
        public IQueryable<PlantDTO> GetPlantInfoes()
        {
            var plants = from p in db.Plants
                         select new PlantDTO()
                         {
                             Id = p.Id,
                             Name = p.Name,
                             PlantName = p.Name
                         };
        }

        // GET: api/PlantInfo/5
        [ResponseType(typeof(PlantInfoDTO))]
        public async Task<IHttpActionResult> GetPlant(int id)
        {
            var plant = await db.Plants.Include(p => p.Plant).Select(p =>
                new PlantInfoDTO()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                }).SingleOrDefaultAsync(p => p.Id == id);
            if (plant == null)
            {
                return NotFound()
            } 
            return Ok(Plant)
        }

        // PUT: api/PlantInfo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPlantInfo(int id, PlantInfo plantInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plantInfo.Id)
            {
                return BadRequest();
            }

            db.Entry(plantInfo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantInfoExists(id))
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

        // POST: api/PlantInfo
        [ResponseType(typeof(PlantInfo))]
        public async Task<IHttpActionResult> PostPlantInfo(PlantInfoDTO plantInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlantInfoes.Add(plantInfo);
            await db.SaveChangesAsync();

            db.Entry(plantInfo).Reference(x => x.PlantName).Load();

            var dto = new PlantDTO()
            {
                Id = plantInfo.Id,
                Name = plantInfo.Name,
                PlantName = plantInfo.PlantName
            };

            return CreatedAtRoute("DefaultApi", new { id = plantInfo.Id }, plantInfo);
        }

        // DELETE: api/PlantInfo/5
        [ResponseType(typeof(PlantInfo))]
        public async Task<IHttpActionResult> DeletePlantInfo(int id)
        {
            PlantInfo plantInfo = await db.PlantInfoes.FindAsync(id);
            if (plantInfo == null)
            {
                return NotFound();
            }

            db.PlantInfoes.Remove(plantInfo);
            await db.SaveChangesAsync();

            return Ok(plantInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlantInfoExists(int id)
        {
            return db.PlantInfoes.Count(e => e.Id == id) > 0;
        }
    }
}