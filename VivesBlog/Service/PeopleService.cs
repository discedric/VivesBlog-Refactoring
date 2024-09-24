using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VivesBlog.Core;
using VivesBlog.Model;

namespace VivesBlog.Service
{
    public class PeopleService
    {
        private readonly DB _context;
        private DbSet<Person> _people;
        public PeopleService()
        {
            var DBcontext = new DBContext();
            _context = DBcontext.GetDatabase;
            _people = _context.People;
        }

        public List<Person> getPersons()
        {
            return _people.ToList();
        }

        public List<Person> GetOrderedPeople()
        {
            return _people
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .ToList();
        }

        public Person GetPerson(int id)
        {
            return _people.Find(id);
        }

        public void AddPerson(Person person)
        {
            _people.Add(person);
            _context.SaveChanges();
        }

        public void DeletePerson(int id) {
            var person = _people.Find(id);
            _people.Remove(person);
            _context.SaveChanges();
        }

        public void UpdatePerson(Person person) {
            _people.Update(person);
            _context.SaveChanges();
        }
    }
}
