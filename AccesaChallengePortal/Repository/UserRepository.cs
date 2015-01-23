using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AccesaChallengePortal.Interfaces;
using AccesaChallengePortal.DatabaseLink;

namespace AccesaChallengePortal.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly ACPDatabaseEntities _context;

        public UserRepository()
        {
            _context = new ACPDatabaseEntities();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            _context.Entry(entity).State = System.Data.EntityState.Modified;
            _context.SaveChanges();
        }

        public User FindById(int id)
        {
            var result = (from r in _context.Users where r.Id == id select r).FirstOrDefault();
            return result;
        }

        internal User GetByUsername(string username)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username.Equals(username));
            return user;
        }
    }
}