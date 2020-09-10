using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using JobBoard.DATA.MVC;

namespace JobBoard.UI.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PositionsController : Controller
    {
        private Job_Board_Entities db = new Job_Board_Entities();

        #region AJAX Delete
        //Delete Publisher record, return only json data on id and confirmation
        [HttpPost]
        public JsonResult PositionDelete(int id)
        {
            //Retrieve that publisher from db
            Position pos = db.Positions.Find(id);

            //Remove the publisher
            db.Positions.Remove(pos);

            //Save Changes to the DB
            db.SaveChanges();

            //Create a message to send back to the UI as a JSON result
            var message = $"Deleted Publisher {pos.PositionId} from the database!";
            return Json(
                new
                {
                    id = id,
                    message = message
                });
        }

        #endregion

        #region AJAX Details
        [HttpGet]
        public PartialViewResult PositionDetails (int id)
        {
            //Retrieve the publisher by its id
            Position pub = db.Positions.Find(id);

            //Return a partial view to the browser with the publisher object
            return PartialView(pub);

            //Right click and add a partial view
            //scaffold to details
            //select partial view
        }

        #endregion

        #region AJAX Create
        //Add Publisher to database via AJAX and return results
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult PositionCreate (Position position)
        {
            db.Positions.Add(position);
            db.SaveChanges();
            return Json(position);
        }

        #endregion

        #region AJAX Edit - GET (Show the form) and POST (process the form)
        public PartialViewResult PositionEdit (int id)
        {
            Position pos = db.Positions.Find(id);
            return PartialView(pos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AjaxEdit(Position position)
        {
            db.Entry(position).State = EntityState.Modified;
            db.SaveChanges();
            return Json(position);
        }

        #endregion

        // GET: Positions
        public ActionResult Index()
        {
            return View(db.Positions.ToList());
        }

        // GET: Positions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // GET: Positions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Positions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PositionId,Title,JobDescription,Category")] Position position)
        {
            if (ModelState.IsValid)
            {
                db.Positions.Add(position);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(position);
        }

        // GET: Positions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: Positions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PositionId,Title,JobDescription,Category")] Position position)
        {
            if (ModelState.IsValid)
            {
                db.Entry(position).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(position);
        }

        // GET: Positions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Position position = db.Positions.Find(id);
            db.Positions.Remove(position);
            db.SaveChanges();
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
