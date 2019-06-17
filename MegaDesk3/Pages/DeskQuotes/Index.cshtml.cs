using System;
using MegaDesk3.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDesk3.Pages.DeskQuotes
{
	public class IndexModel : PageModel
	{
		private readonly MegaDesk3.Data.MegaDeskContext _context;

		public IndexModel( MegaDesk3.Data.MegaDeskContext context )
		{
			_context = context;
		}

		public IList<DeskQuote> DeskQuote { get; set; }

		public async Task OnGetAsync( bool sortByDate, bool sortByName, string customerName )
		{
			DeskQuote = await _context.DeskQuotes.Include( q => q.Desk )
				.Include( q => q.Desk.SurfaceMaterial ).ToListAsync();

			if ( string.IsNullOrWhiteSpace( customerName ) )
			{
				DeskQuote = await _context.DeskQuotes.Include( q => q.Desk )
					.Include( q => q.Desk.SurfaceMaterial ).ToListAsync();
			}
			else
			{
				DeskQuote = await _context.DeskQuotes.Include( q => q.Desk )
					.Include( q => q.Desk.SurfaceMaterial )
					.Where( dq => dq.CustomerName.Contains( customerName, StringComparison.InvariantCultureIgnoreCase ) ).ToListAsync();
			}

			if ( sortByDate )
			{
				DeskQuote = DeskQuote.OrderBy( dq => dq.Date ).ToList();
				return;
			}

			if ( sortByName )
			{
				DeskQuote = DeskQuote.OrderBy( dq => dq.CustomerName ).ToList();
			}
		}
	}
}
