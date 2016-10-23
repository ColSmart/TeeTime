using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeeTime.Models
{
    public class GolfClub
    {
        public int GolfClubId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Area { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string WebSite { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string ContactNo { get; set; }
    }
}