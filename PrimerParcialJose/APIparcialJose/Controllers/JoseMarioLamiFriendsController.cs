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
using APIparcialJose.Models;

namespace APIparcialJose.Controllers
{
    public class JoseMarioLamiFriendsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/JoseMarioLamiFriends
        public IQueryable<JoseMarioLamiFriend> GetJoseMarioLamiFriends()
        {
            return db.JoseMarioLamiFriends;
        }

        // GET: api/JoseMarioLamiFriends/5
        [ResponseType(typeof(JoseMarioLamiFriend))]
        public IHttpActionResult GetJoseMarioLamiFriend(int id)
        {
            JoseMarioLamiFriend joseMarioLamiFriend = db.JoseMarioLamiFriends.Find(id);
            if (joseMarioLamiFriend == null)
            {
                return NotFound();
            }

            return Ok(joseMarioLamiFriend);
        }

        // PUT: api/JoseMarioLamiFriends/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJoseMarioLamiFriend(int id, JoseMarioLamiFriend joseMarioLamiFriend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != joseMarioLamiFriend.FriendId)
            {
                return BadRequest();
            }

            db.Entry(joseMarioLamiFriend).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JoseMarioLamiFriendExists(id))
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

        // POST: api/JoseMarioLamiFriends
        [ResponseType(typeof(JoseMarioLamiFriend))]
        public IHttpActionResult PostJoseMarioLamiFriend(JoseMarioLamiFriend joseMarioLamiFriend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JoseMarioLamiFriends.Add(joseMarioLamiFriend);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = joseMarioLamiFriend.FriendId }, joseMarioLamiFriend);
        }

        // DELETE: api/JoseMarioLamiFriends/5
        [ResponseType(typeof(JoseMarioLamiFriend))]
        public IHttpActionResult DeleteJoseMarioLamiFriend(int id)
        {
            JoseMarioLamiFriend joseMarioLamiFriend = db.JoseMarioLamiFriends.Find(id);
            if (joseMarioLamiFriend == null)
            {
                return NotFound();
            }

            db.JoseMarioLamiFriends.Remove(joseMarioLamiFriend);
            db.SaveChanges();

            return Ok(joseMarioLamiFriend);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JoseMarioLamiFriendExists(int id)
        {
            return db.JoseMarioLamiFriends.Count(e => e.FriendId == id) > 0;
        }
    }
}