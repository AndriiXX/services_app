using Microsoft.EntityFrameworkCore;
using services_app.Models;

namespace services_app.Services
{
    public interface IServiceUsers
    {
        public UserContext? db { get; set; }
        public IEnumerable<User>? Read();
        User? Create(User? user);
        public User? Update(User? user);
        public void Delete(int id);
        public User? GetUserById(int id);

    }
    public class ServiceUsers : IServiceUsers
    {
        public UserContext? db { get; set; }

        private readonly UserContext _db;

        public ServiceUsers(UserContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db), "UserContext не може бути null");
        }

        public User? Create(User? user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "Користувач не може бути null");
            }

            _db.Users.Add(user);
            _db.SaveChanges(); // Збереження змін
            return user;
        }
        public void Delete(int id)
        {
            _ = (db?.Users.Remove(GetUserById(id)));
        }

        public User? GetUserById(int id)
        {
            return db?.Users.Find(id);
        }

        public IEnumerable<User>? Read()
        {
            return db?.Users.ToList();
        }

        public User? Update(User? user)
        {
            db.Entry(user).State = EntityState.Modified;
            return user;
        }
    }
}
