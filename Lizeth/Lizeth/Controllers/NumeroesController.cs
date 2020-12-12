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
using Lizeth.Models;

namespace Lizeth.Controllers
{
    [RoutePrefix("{api}")]
    public class NumeroesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Numeroes
        public IQueryable<Numero> GetNumeroes()
        {
            return db.Numeroes;
        }

        // GET: api/Numeroes/5
        [ResponseType(typeof(Numero))]
        public IHttpActionResult GetNumero(int id)
        {
            Numero numero = db.Numeroes.Find(id);
            if (numero == null)
            {
                return NotFound();
            }

            return Ok(numero);
        }

        // PUT: api/Numeroes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNumero(int id, Numero numero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != numero.Numero1)
            {
                return BadRequest();
            }

            db.Entry(numero).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NumeroExists(id))
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

        // POST: api/Numeroes
        [ResponseType(typeof(Numero))]
        public IHttpActionResult PostNumero(Numero numero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Numeroes.Add(numero);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = numero.Numero1 }, numero);
        }

        [HttpGet]
        [Route("{a:int}")]

        public string Numero1(int a)
        {
            string t = "";
            if (a<0)
            {
                t = "ERROR";
            }

            if (a == 0)
            {
                t = "REALIZADO POR LIZETH JIMENEZ";
            }

            if (a>0)
            {
                t = "https://image.freepik.com/vector-gratis/numeros-cartel-imagen_1639-6453.jpg";
            }

            return t;
        }


        // DELETE: api/Numeroes/5
        [ResponseType(typeof(Numero))]
        public IHttpActionResult DeleteNumero(int id)
        {
            Numero numero = db.Numeroes.Find(id);
            if (numero == null)
            {
                return NotFound();
            }

            db.Numeroes.Remove(numero);
            db.SaveChanges();

            return Ok(numero);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NumeroExists(int id)
        {
            return db.Numeroes.Count(e => e.Numero1 == id) > 0;
        }
    }
}