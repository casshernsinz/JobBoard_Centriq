using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobBoard.DATA.MVC;
using PagedList;//Added after NuGet PagedList
using PagedList.Mvc;//Added after NuGet PagedList.MVC

namespace JobBoard.UI.MVC.Controllers
{
    public class FiltersController : Controller
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
        public PartialViewResult PositionDetails(int id)
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

        #region AJAX Create - Positions
        //Add Publisher to database via AJAX and return results
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult PositionCreate(Position position)
        {
            db.Positions.Add(position);
            db.SaveChanges();
            return Json(position);
        }

        #endregion

        #region AJAX Edit - GET (Show the form) and POST (process the form)
        public PartialViewResult PositionEdit(int id)
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


        // GET: Filters
        public ActionResult Index()
        {

            return View();
        }

        //Servor Side Filter Action
        public ActionResult ApplicationsQS (string searchFilter)
        {
            if (String.IsNullOrEmpty(searchFilter))
            {
                //If optional search isn't used, return all records

                return View(db.Applications.ToList());
            }
            else
            {
                //If optional search is used, compare it to the first and last name. Use Linq
                //This is a Method example, below this is a Keyword Syntax example
                string searchUpCase = searchFilter.ToUpper();
                List<Application> searchResults = db.Applications
                                             .Where(a => a.UserDetail.FirstName.ToUpper().Contains(searchUpCase)
                                             || a.UserDetail.LastName.ToUpper().Contains(searchUpCase) 
                                             || a.OpenPosition.Position.Category.ToLower().Contains(searchUpCase))
                                             .OrderBy(a => a.UserDetail.FirstName)
                                             .ThenBy(a => a.UserDetail.LastName)
                                             .ThenBy(a => a.OpenPosition.Position.Category)
                                             .ToList();

                //Method syntax example above Or Query syntax example below
                //List<Application> searchResult2 = 
                //                              (from a in db.Authors
                //                              where a.FirstName.ToUpper().Contains(searchUpCase) ||
                //                              a.LastName.ToUpper().Contains(searchUpCase)
                //                              orderby a.FirstName, a.LastName
                //                              select a).ToList();
                return View(searchResults);
            }
        }

        //public ActionResult OpenPositionsQS (string searchFilter)
        //{
        //    if (String.IsNullOrEmpty(searchFilter))
        //    {
        //        return View(db.OpenPositions.ToList());
        //    }
        //    else
        //    {
        //        string searchUpCase = searchFilter.ToUpper();
        //        List<OpenPosition> searchResults = db.OpenPositions
        //                                     .Where(m => m.Location)
        //                                     .OrderBy(m => m.Location)
        //                                     .ThenBy(m => m.IsOpen)
        //                                     .ToList();

        //        return View(searchResults);
        //    }
        //}
        //}

        public ActionResult PositionsQS (string searchString, string currentFilter, int page = 1)
        {
            int pageSize = 5;
            var jobs = db.Positions.OrderBy(b => b.Title).ToList();

            #region Search With Paging Notes
            //We are tracking it's a new search(Go To Page 1 with results)
            //or if it's a previous search(track with current filter and use paging based on the last request)
            /*
             * In the Action-
             * SearchString only gets assigned new searches
             * If searchString has a value, then it is a search - update the page to 1(first page of results)
             * Else if searchString is null, assign searchString to use the currentFilter value ( either null/empty OR previously tracked old search)
             * 
             */

            #endregion

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            //Check if the searchString is not null or empty.
            //If it is NOT null use the filter to grab the new data set

            if (!String.IsNullOrEmpty(searchString))
            {
                jobs = (from j in jobs
                        where j.Title.ToLower().Contains(searchString.ToLower()) 
                        || j.Category.ToLower().Contains(searchString.ToLower())
                         orderby j.Title,
                         j.Category
                         select j).ToList();
            }

            //Set up a ViewBag variable for passing currentFilter based on whatever searchString is now
            ViewBag.CurrentFilter = searchString;

            return View(jobs.ToPagedList(page, pageSize));
        }

    }
}
