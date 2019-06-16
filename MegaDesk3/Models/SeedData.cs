using MegaDesk3.Data;
using MegaDesk3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace RazorPagesMovie.Models
{
	public static class SeedData
	{
		public static void Initialize( IServiceProvider serviceProvider )
		{
			using ( var context = new MegaDeskContext(
				serviceProvider.GetRequiredService<
					DbContextOptions<MegaDeskContext>>() ) )
			{
				// Look if Surface Materials exist yet.
				if ( context.SurfaceMaterials.Any() )
				{
					return;   // DB has been seeded
				}

				context.SurfaceMaterials.AddRange(
					new SurfaceMaterial
					{
						Name = "Pine",
						Price = 50.00M
					},
					new SurfaceMaterial
					{
						Name = "Laminate",
						Price = 100.00M
					},
					new SurfaceMaterial
					{
						Name = "Veneer",
						Price = 125.00M
					},
					new SurfaceMaterial
					{
						Name = "Oak",
						Price = 200.00M
					},
					new SurfaceMaterial
					{
						Name = "Rosewood",
						Price = 300.00M
					}
				);
				context.SaveChanges();
			}
		}
	}
}