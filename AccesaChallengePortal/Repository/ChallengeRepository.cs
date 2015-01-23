using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AccesaChallengePortal.Interfaces;
using AccesaChallengePortal.DatabaseLink;

namespace AccesaChallengePortal.Repository
{
    public class ChallengeRepository : IRepository<Challenge>
    {
        private readonly ACPDatabaseEntities _context;

        public ChallengeRepository()
        {
            _context = new ACPDatabaseEntities();
        }

        public List<Challenge> GetAll()
        {
            return _context.Challenges.ToList();
        }

        public void Add(Challenge entity)
        {
            _context.Challenges.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Challenge entity)
        {
            _context.Challenges.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Challenge entity)
        {
            _context.Entry(entity).State = System.Data.EntityState.Modified;
            _context.SaveChanges();
        }

        public Challenge FindById(int id)
        {
            var result = (from r in _context.Challenges where r.Id == id select r).FirstOrDefault();
            return result;
        }

    }
}