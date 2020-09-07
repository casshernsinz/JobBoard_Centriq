using System;
using System.Collections.Generic;
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
                                             || a.UserDetail.LastName.ToUpper().Contains(searchUpCase))
                                             .OrderBy(a => a.UserDetail.FirstName)
                                             .ThenBy(a => a.UserDetail.LastName)
                                             .ToList();

                //Method syntax example above Or Query syntax example below
                //List<Application> searchResult2 = (from a in db.Authors
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

            #region Search With Paging
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
                         orderby j.Title
                         select j).ToList();
            }

            //Set up a ViewBag variable for passing currentFilter based on whatever searchString is now
            ViewBag.CurrentFilter = searchString;

            return View(jobs.ToPagedList(page, pageSize));
        }

        //public ActionResult LabMagazinesMVCPaging(string searchString, string currentFilter, int page = 1)
        //{
        //    int pageSize = 5;
        //    var magazines = db.Magazines.OrderBy(c => c.Category).ToList();

        //    if (searchString != null)
        //    {
        //        page = 1;
        //    }
        //    else
        //    {
        //        searchString = currentFilter;
        //    }

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        magazines = (from c in magazines
        //                     where c.Category.ToLower().Contains(searchString.ToLower())
        //                     orderby c.Category
        //                     select c).ToList();
        //    }

        //    ViewBag.CurrentFilter = searchString;

        //    return View(magazines.ToPagedList(page, pageSize));
        //}
    }
}
