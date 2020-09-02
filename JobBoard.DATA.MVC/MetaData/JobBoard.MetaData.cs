using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.DATA.MVC//.MetaData
{
    public class ApplicationMetadata
    {
        #region Application MetaData
        public int ApplicationId { get; set; }
        public string UserId { get; set; }
        public int OpenPositionId { get; set; }
        public System.DateTime ApplicationDate { get; set; }
        public string ManagerNotes { get; set; }
        public int ApplicationStatusId { get; set; }
        public string ResumeFileName { get; set; }
        #endregion
    }

    public class ApplicationStatusMetadata
    {
        #region Applcation Status MetaData
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
        #endregion
    }

    public class LocationMetadata
    {
        #region Location MetaData
        public int LocationId { get; set; }
        public string StoreNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ManagerId { get; set; }
        #endregion
    }

    public class OpenPositionMetadata
    {
        #region OpenPosition MetaData
        public int OpenPositionId { get; set; }
        public int LocationId { get; set; }
        public int PositionId { get; set; }
        #endregion
    }

    public class PositionMetadata
    {
        #region Position MetaData
        [Display(Name = "Position Title")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Position Duties")]
        [Required]
        public string JobDescription { get; set; }
        [Display(Name ="Is there an Open Spot?")]
        public bool? IsOpen { get; set; }
        [Display(Name = "What kind of Position is this?")]
        public string Category { get; set; }
        #endregion
    }

    public class UserDetailsMetadata
    {
        #region UserDetails MetaData
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        #endregion
    }
    
}
