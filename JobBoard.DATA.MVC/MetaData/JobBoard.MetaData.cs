using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.DATA.MVC//.MetaData
{
    #region Application MetaData
    [MetadataType(typeof(ApplicationMetadata))]
    public partial class Application { }
    public class ApplicationMetadata
    {
        public int ApplicationId { get; set; }
        public string UserId { get; set; }
        public int OpenPositionId { get; set; }

        [Required(ErrorMessage = "Please Fill Out Today's Date")]
        [Display(Name = "Today's Date")]
        public DateTime ApplicationDate { get; set; }


        public string ManagerNotes { get; set; }


        public int ApplicationStatusId { get; set; }

        [Required(ErrorMessage ="Please Upload your Resume")]
        [Display(Name = "Upload Resume")]
        public string ResumeFileName { get; set; }
    }
    #endregion

    #region Applcation Status MetaData
    public class ApplicationStatusMetadata
    {
        
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
        
    }
    #endregion

    #region Location MetaData
    [MetadataType(typeof(LocationMetadata))]
    public partial class Location { }
    public class LocationMetadata
    {
        
        public int LocationId { get; set; }
        public string StoreNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ManagerId { get; set; }
        
    }
    #endregion

    #region OpenPosition MetaData
    [MetadataType(typeof(OpenPositionMetadata))]
    public partial class OpenPosition { }
    public class OpenPositionMetadata
    {
        
        public int OpenPositionId { get; set; }
        public int LocationId { get; set; }
        public int PositionId { get; set; }

        [Display(Name = "Is there an Open Spot?")]
        [Required]
        public bool? IsOpen { get; set; }

        
    }
    #endregion
    
    #region Position MetaData
    [MetadataType(typeof(PositionMetadata))]
    public partial class Position { }
    public class PositionMetadata
    {
                
        public int PositionId { get; set; }

        [Display(Name = "Position Title")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Position Duties")]

        public string JobDescription { get; set; }

        [Display(Name = "What kind of Position is this?")]
        [Required]
        public string Category { get; set; }
        
    }
    #endregion

    #region UserDetails MetaData
    [MetadataType(typeof(UserDetailsMetadata))]
    public partial class UserDetail { }
    public class UserDetailsMetadata
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ResumeFileName { get; set; }
        
    }
    #endregion

    #region AspNetUserMetaData
    [MetadataType(typeof(AspNetUserMetadata))]
    public partial class AspNetUser { }
    public class AspNetUserMetadata
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
    }
    #endregion
}
