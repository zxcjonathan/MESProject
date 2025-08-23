using Microsoft.EntityFrameworkCore;
using MESProject.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<WorkOrder> WorkOrders { get; set; }
}