using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MatchOdds.Models;

namespace MatchOdds.Data
{
    public class MatchOddsContext:DbContext
    {
        public MatchOddsContext(DbContextOptions<MatchOddsContext> options):base (options)
        {
        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchOdd> MatchOdds { get; set; }
    }
}