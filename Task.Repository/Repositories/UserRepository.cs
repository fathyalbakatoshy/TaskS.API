using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 
using Task.Core.Entities;
using Task.Core.Interfaces;
using Task.Repository.Data;

namespace Task.Repository.Repositories
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Set<ApplicationUser>().FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
