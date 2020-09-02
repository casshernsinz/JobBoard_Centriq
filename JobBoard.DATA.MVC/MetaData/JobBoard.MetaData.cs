using System;
using System.Collections.Generic;
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
        public int PositionId { get; set; }
        #endregion
    }

    public class PositionMetaData
    {
        #region Position MetaData
        public string Title { get; set; }
        public string JobDescription { get; set; }
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
