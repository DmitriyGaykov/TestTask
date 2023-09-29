using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;

    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<User> GetUser()
    {
        return this._dbContext.Users
            .OrderByDescending(user => user.Orders.Count())
            .FirstOrDefaultAsync();
    }

    public Task<List<User>> GetUsers()
    {
        return this._dbContext.Users
            .Where(user => user.Status.Equals(UserStatus.Inactive))
            .ToListAsync();
    }
}