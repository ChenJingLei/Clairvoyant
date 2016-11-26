using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ClairvoyantAPI.Models;

namespace ClairvoyantAPI.Controllers
{
    public class SuspectsController : ApiController
    {
        private SuspectDBContext db = new SuspectDBContext();

        // GET: api/Suspects
        public IQueryable<Suspect> GetSuspects()
        {
            return db.Suspects;
        }

        // GET: api/Suspects/5
        [ResponseType(typeof(Suspect))]
        public IHttpActionResult GetSuspect(string id)
        {
            Suspect suspect = db.Suspects.Find(id);
            if (suspect == null)
            {
                return NotFound();
            }

            return Ok(suspect);
        }

        // PUT: api/Suspects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuspect(string id, Suspect suspect)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != suspect.ID)
            {
                return BadRequest();
            }

            db.Entry(suspect).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuspectExists(id))
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

        // POST: api/Suspects
        [ResponseType(typeof(Suspect))]
        public IHttpActionResult PostSuspect(Suspect suspect)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Suspects.Add(suspect);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SuspectExists(suspect.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = suspect.ID }, suspect);
        }

        // DELETE: api/Suspects/5
        [ResponseType(typeof(Suspect))]
        public IHttpActionResult DeleteSuspect(string id)
        {
            Suspect suspect = db.Suspects.Find(id);
            if (suspect == null)
            {
                return NotFound();
            }

            db.Suspects.Remove(suspect);
            db.SaveChanges();

            return Ok(suspect);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuspectExists(string id)
        {
            return db.Suspects.Count(e => e.ID == id) > 0;
        }
    }
}