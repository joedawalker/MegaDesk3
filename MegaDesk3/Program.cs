using MegaDesk3.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RazorPagesMovie.Models;
using System;

namespace MegaDesk3
{
	public class Program
	{
		public static void Main( string[] args )
		{
			var host = CreateWebHostBuilder( args ).Build();

			using ( var scope = host.Services.CreateScope() )
			{
				var services = scope.ServiceProvider;

				try
				{
					var context = services.
						GetRequiredService<MegaDeskContext>();
					context.Database.Migrate();
					SeedData.Initialize( services );
				}
				catch ( Exception ex )
				{
					ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError( ex, "An error occurred while seeding the DB." );
				}
			}

			host.Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder( string[] args ) =>
			WebHost.CreateDefaultBuilder( args )
				.UseStartup<Startup>();
	}
}
