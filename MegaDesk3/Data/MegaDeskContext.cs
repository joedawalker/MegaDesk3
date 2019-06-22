using MegaDesk3.Models;
using Microsoft.EntityFrameworkCore;
namespace MegaDesk3.Data
{
	public class MegaDeskContext : DbContext
	{
		public MegaDeskContext( DbContextOptions<MegaDeskContext> options ) : base( options )
		{
		}

		public DbSet<DeskQuote> DeskQuotes { get; set; }
		public DbSet<Desk> Desks { get; set; }
		public DbSet<SurfaceMaterial> SurfaceMaterials { get; set; }
        public DbSet<RushOrder> RushOrderTypes { get; set; }
	}
}
