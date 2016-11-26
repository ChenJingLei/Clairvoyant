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
    public class ChildrensController : ApiController
    {
        private ChildrenDBContext db = new ChildrenDBContext();

        // GET: api/Childrens
        public IQueryable<Children> GetChildrens()
        {
            return db.Childrens;
        }

        // GET: api/Childrens/5
        [ResponseType(typeof(Children))]
        public IHttpActionResult GetChildren(string id)
        {
            Children children = db.Childrens.Find(id);
            if (children == null)
            {
                return NotFound();
            }

            return Ok(children);
        }

        // PUT: api/Childrens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChildren(string id, Children children)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != children.ID)
            {
                return BadRequest();
            }

            db.Entry(children).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChildrenExists(id))
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

        // POST: api/Childrens
        [ResponseType(typeof(Children))]
        public IHttpActionResult PostChildren(Children children)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Childrens.Add(children);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ChildrenExists(children.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = children.ID }, children);
        }

        // DELETE: api/Childrens/5
        [ResponseType(typeof(Children))]
        public IHttpActionResult DeleteChildren(string id)
        {
            Children children = db.Childrens.Find(id);
            if (children == null)
            {
                return NotFound();
            }

            db.Childrens.Remove(children);
            db.SaveChanges();

            return Ok(children);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChildrenExists(string id)
        {
            return db.Childrens.Count(e => e.ID == id) > 0;
        }
    }
}