using MegaDesk3.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

		public async Task OnGetAsync()
		{
			DeskQuote = await _context.DeskQuotes.Include( q => q.Desk )
				.Include( q => q.Desk.SurfaceMaterial ).ToListAsync();
		}
	}
}
