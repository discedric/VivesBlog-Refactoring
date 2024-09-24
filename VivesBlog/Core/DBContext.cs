using System.Linq;
using Microsoft.EntityFrameworkCore;
using VivesBlog.Model;

namespace VivesBlog.Core
{
    public class DBContext
    {
        private readonly DB _database;

        public DBContext()
        {
            var builder = new DbContextOptionsBuilder<DB>();
            builder.UseInMemoryDatabase("VivesBlog");
            _database = new DB(builder.Options);
            if (!_database.Articles.Any())
            {
                _database.Seed();
            }
        }

        public DB GetDatabase => _database;
    }
}
