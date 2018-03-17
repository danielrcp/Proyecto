using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;

namespace proyecto.Controllers
{
    public class ExperienciasController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: Experiencias
        public async Task<ActionResult> Index()
        {
            var experiencia = db.Experiencia.Include(e => e.Usuario);
            return View(await experiencia.ToListAsync());
        }

        // GET: Experiencias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiencia experiencia = await db.Experiencia.FindAsync(id);
            if (experiencia == null)
            {
                return HttpNotFound();
            }
            return View(experiencia);
        }

        // GET: Experiencias/Create
        public ActionResult Create()
        {
            ViewBag.Usuario_id = new SelectList(db.Usuario, "id", "Nombre");
            return View();
        }

        // POST: Experiencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Usuario_id,Tipo,Nombre,Titulo,Desde,Hasta,Descripcion")] Experiencia experiencia)
        {
            if (ModelState.IsValid)
            {
                db.Experiencia.Add(experiencia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Usuario_id = new SelectList(db.Usuario, "id", "Nombre", experiencia.Usuario_id);
            return View(experiencia);
        }

        // GET: Experiencias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiencia experiencia = await db.Experiencia.FindAsync(id);
            if (experiencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.Usuario_id = new SelectList(db.Usuario, "id", "Nombre", experiencia.Usuario_id);
            return View(experiencia);
        }

        // POST: Experiencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Usuario_id,Tipo,Nombre,Titulo,Desde,Hasta,Descripcion")] Experiencia experiencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(experiencia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Usuario_id = new SelectList(db.Usuario, "id", "Nombre", experiencia.Usuario_id);
            return View(experiencia);
        }

        // GET: Experiencias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiencia experiencia = await db.Experiencia.FindAsync(id);
            if (experiencia == null)
            {
                return HttpNotFound();
            }
            return View(experiencia);
        }

        // POST: Experiencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Experiencia experiencia = await db.Experiencia.FindAsync(id);
            db.Experiencia.Remove(experiencia);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
