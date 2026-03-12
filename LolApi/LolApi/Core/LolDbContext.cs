using Microsoft.EntityFrameworkCore;

namespace LolApi.Core;

public class LolDbContext(DbContextOptions<LolDbContext> options ): DbContext(options)
{
    public DbSet<Champion> Champions { get; set; }
}
