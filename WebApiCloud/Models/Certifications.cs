using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCloud.Models
{
    /// <summary>
    /// Certifications
    /// </summary>
    public class Certifications
    {
        /// <summary>
        /// CertificationName
        /// </summary>
        public string CertificationName { get; set; }
        /// <summary>
        /// CertificationId
        /// </summary>
        public string CertificationId { get; set; }
        /// <summary>
        /// IssuedBy
        /// </summary>
        public string IssuedBy { get; set; }
        /// <summary>
        /// ValidFrom
        /// </summary>
        public string ValidFrom { get; set; }
        /// <summary>
        /// ValidTill
        /// </summary>
        public string ValidTill { get; set; }
        /// <summary>
        /// AdditionalNotes
        /// </summary>
        public string AdditionalNotes { get; set; }
    }
}