using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.ComponentModel.DataAnnotations;


namespace JobBoard.UI.MVC.Models
{
    public class UsersViewModels
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}