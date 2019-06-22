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
				if ( context.SurfaceMaterials == null || !context.SurfaceMaterials.Any() )
				{
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

                if ( context.RushOrderTypes == null || !context.RushOrderTypes.Any() )
                {

                    context.RushOrderTypes.AddRange(
                               new RushOrder
                               {
                                   RushOrderName = "7-day",
                                   TierOnePrice = 60.00M,
                                   TierTwoPrice = 40.00M,
                                   TierThreePrice = 30.00M
                               },
                               new RushOrder
                               {
                                   RushOrderName = "5-day",
                                   TierOnePrice = 70.00M,
                                   TierTwoPrice = 50.00M,
                                   TierThreePrice = 35.00M
                               },
                               new RushOrder
                               {
                                   RushOrderName = "3-day",
                                   TierOnePrice = 80.00M,
                                   TierTwoPrice = 60.00M,
                                   TierThreePrice = 40.00M
                               }
                               );
                    context.SaveChanges();
                }
			}
		}
	}
}