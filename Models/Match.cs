using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatchOdds.Models
{
    public enum SportType
    {
        Football = 1,
        Basketball = 2
    }

    public class Match
    {
        public int ID { get; set; }

        [NotMapped]
        public string Description { get { return TeamA + "-" + TeamB; } }
        public DateTime MatchDate { get; set; }

        [NotMapped]
        public string MatchTime { get { return MatchDate.ToString("HH:mm:ss"); } }

        public string TeamA { get; set; }

        public string TeamB { get; set; }

        public SportType Sport { get; set; }

        public List<MatchOdd> MatchOdds { get; set; }

    }
}