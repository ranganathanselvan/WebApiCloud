using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCloud.Models
{
    /// <summary>
    /// WorkInfo
    /// </summary>
    public class WorkInfo
    {
        /// <summary>
        /// CompanyName
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Role
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// StartDate
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// EndDate
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// isCurrentCompany
        /// </summary>
        public bool isCurrentCompany { get; set; }
        /// <summary>
        /// Experience In Year Month
        /// </summary>
        public string ExperienceInYearMonth { get; set; }

    }
}