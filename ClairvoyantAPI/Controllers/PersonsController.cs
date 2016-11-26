using ClairvoyantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ClairvoyantAPI.Controllers
{
    public class PersonsController : ApiController
    {
        // POST: api/Suspects
        [ResponseType(typeof(Person))]
        public IHttpActionResult PostSuspect(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
               
            }
            catch (Exception)
            {

            }

            //return CreatedAtRoute("DefaultApi", new { id = suspect.ID }, suspect);
            return null;
        }
    }
}
