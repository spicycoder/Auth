using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SimpleAuth;

public class AppDBContext(DbContextOptions<AppDBContext> options) : IdentityDbContext<IdentityUser>(options)
{
}
