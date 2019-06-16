﻿using MegaDesk3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDesk3.Pages.DeskQuotes
{
	public class EditModel : PageModel
	{
		private readonly MegaDesk3.Data.MegaDeskContext _context;

		public EditModel( MegaDesk3.Data.MegaDeskContext context )
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

		public async Task<IActionResult> OnPostAsync()
		{
			if ( !ModelState.IsValid )
			{
				return Page();
			}

			_context.Attach( DeskQuote ).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch ( DbUpdateConcurrencyException )
			{
				if ( !DeskQuoteExists( DeskQuote.DeskQuoteId ) )
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return RedirectToPage( "./Index" );
		}

		private bool DeskQuoteExists( int id )
		{
			return _context.DeskQuotes.Any( e => e.DeskQuoteId == id );
		}
	}
}
