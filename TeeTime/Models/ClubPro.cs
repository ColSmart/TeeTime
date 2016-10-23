using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeeTime.Models
{
    public class ClubPro
    {
        public int ClubProId { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }

        public int GolfClubId { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}