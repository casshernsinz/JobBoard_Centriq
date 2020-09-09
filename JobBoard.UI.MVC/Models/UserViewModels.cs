using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.ComponentModel.DataAnnotations;
using JobBoard.DATA.MVC;

namespace JobBoard.UI.MVC.Models
{
    public class UserViewModels : AspNetUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ResumeFileName { get; set; }
    }
}