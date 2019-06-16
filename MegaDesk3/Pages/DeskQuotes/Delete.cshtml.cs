using System.Linq;
using MegaDesk3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MegaDesk3.Pages.DeskQuotes
{
	public class DeleteModel : PageModel
	{
		private readonly MegaDesk3.Data.MegaDeskContext _context;

		public DeleteModel( MegaDesk3.Data.MegaDeskContext context )
		{
			_context = context;
		}

		[BindProperty]
		public DeskQuote DeskQuote { get; set; }

		public async Task<IActionResult> OnGetAsync( int? id )
		{
			if ( id == null )
			{
				return NotFound();
			}

			DeskQuote = await _context.DeskQuotes.Include( dq => dq.Desk )
				.Include( dq => dq.Desk.SurfaceMaterial ).FirstOrDefaultAsync( m => m.DeskQuoteId == id );

			if ( DeskQuote == null )
			{
				return NotFound();
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync( int? id )
		{
			if ( id == null )
			{
				return NotFound();
			}

			DeskQuote = await _context.DeskQuotes.Include( dq => dq.Desk )
				.Include( dq => dq.Desk.SurfaceMaterial ).FirstOrDefaultAsync( m => m.DeskQuoteId == id );

			if ( DeskQuote != null )
			{
				_context.DeskQuotes.Remove( DeskQuote );
				_context.Desks.Remove( DeskQuote.Desk );
				await _context.SaveChangesAsync();
			}

			return RedirectToPage( "./Index" );
		}
	}
}
