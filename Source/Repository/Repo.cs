using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace Repository
{
    public class Repo
    {
        private readonly BSDbContext _context;
        DbSet<AppUser> users;

        public Repo(BSDbContext context)
        {
            _context = context;
            users = _context.Users;
        }

        //users controller
        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            return await users.ToListAsync();
        }

        public async Task<AppUser> GetUserById(int id)
        {
            return await users.FirstOrDefaultAsync(users => users.Id == id);
        }
        // do we use this?
        public AppUser GetUserByIdNonAsync(int id)
        {
            return users.FirstOrDefault(users => users.Id == id);
        }

        // account controller
        public async Task<AppUser> RegisterUser(AppUser newUser)
        {
            users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<AppUser> LoginUser(string username)
        {
            return await users.SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<bool> UserExists(string username)
        {
            return await users.AnyAsync(user => user.UserName == username.ToLower());
        }


    }
}
