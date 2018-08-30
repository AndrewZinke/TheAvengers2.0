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
using WebAPIStuff.Models;
using WebAPIStuff.Repositories;

namespace WebAPIStuff.Controllers
{
    public class SharesController : ApiController
    {
        private ShareRepo db = new ShareRepo();

        // GET: api/Shares
        public IQueryable<Share> GetShares()
        {
            return db.Shares;
        }

        // GET: api/Shares/5
        [ResponseType(typeof(Share))]
        public IHttpActionResult GetShare(int id)
        {
            Share share = db.Shares.Find(id);
            if (share == null)
            {
                return NotFound();
            }

            return Ok(share);
        }

        // PUT: api/Shares/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShare(int id, Share share)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != share.ID)
            {
                return BadRequest();
            }

            db.Entry(share).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShareExists(id))
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

        // POST: api/Shares
        [ResponseType(typeof(Share))]
        public IHttpActionResult PostShare(Share share)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Shares.Add(share);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = share.ID }, share);
        }

        // DELETE: api/Shares/5
        [ResponseType(typeof(Share))]
        public IHttpActionResult DeleteShare(int id)
        {
            Share share = db.Shares.Find(id);
            if (share == null)
            {
                return NotFound();
            }

            db.Shares.Remove(share);
            db.SaveChanges();

            return Ok(share);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShareExists(int id)
        {
            return db.Shares.Count(e => e.ID == id) > 0;
        }
    }
}