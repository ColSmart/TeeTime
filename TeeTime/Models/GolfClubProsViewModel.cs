using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeeTime.Models
{
    public class GolfClubProsViewModel
    {
        public List<ClubPro> ClubPros { get; set; }

        public GolfClub Club { get; set; }

        public ClubPro ClubPro { get; set; }

        public GolfClubProsViewModel()
        {
            ClubPro = new ClubPro();
        }
    }
}