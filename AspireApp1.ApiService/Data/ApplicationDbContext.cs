using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AspireApp1.ApiService.Data;

public partial class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
  {
  }
  public virtual DbSet<Catalog> Catalogs { get; set; } = null!;
}
