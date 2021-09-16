using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchOdds.Models
{
    public class MatchOdd
    {
        public int ID { get; set; }
        public int MatchId { get; set; }
        public Match Match { get; set; }
        public string Specifier { get; set; }
        public decimal Odd { get; set; }
    }
}