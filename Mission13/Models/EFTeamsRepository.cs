using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class EFTeamsRepository : ITeamsRepository
    {
        private BowlingDbContext _context { get; set; }

        public EFTeamsRepository(BowlingDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Team> Teams => _context.Teams;


        public void AddTeam(Team t)
        {
            _context.Add(t);
            _context.SaveChanges();
        }

        public void UpdateTeam(Team t)
        {
            _context.Update(t);
            _context.SaveChanges();
        }

        public void RemoveTeam(Team t)
        {
            _context.Remove(t);
            _context.SaveChanges();
        }

    }
}


