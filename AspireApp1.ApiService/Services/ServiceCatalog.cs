using AspireApp1.ApiService.Data;

namespace AspireApp1.ApiService.Services
{
  public class ServiceCatalog
  {
    private ApplicationDbContext _context;
    public ServiceCatalog(ApplicationDbContext dbContext)
    {
      _context = dbContext;
    }

    public List<Catalog> GetCatalogs()
    
    {
      return _context.Catalogs.ToList();
    }

  }
}
