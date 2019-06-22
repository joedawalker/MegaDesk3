using System;
using MegaDesk3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;

namespace MegaDesk3.Pages.DeskQuotes
{
	public class CreateModel : PageModel
	{
		private readonly MegaDesk3.Data.MegaDeskContext _context;

		public CreateModel( MegaDesk3.Data.MegaDeskContext context )
		{
			_context = context;
		}

		public SelectList SurfaceMaterials { get; set; }

		public async Task<IActionResult> OnGet()
		{
			SurfaceMaterials = new SelectList( await _context.SurfaceMaterials.Select( s => s.Name ).ToListAsync() );

			return Page();
		}

		[BindProperty]
		public DeskQuote DeskQuote { get; set; }

		[BindProperty]
		public string SelectedMaterial { get; set; }

		public async Task<IActionResult> OnPostAsync()
		{
			if ( !ModelState.IsValid )
			{
				return Page();
			}

			List<SurfaceMaterial> rawSurfaceMaterials = await _context.SurfaceMaterials.ToListAsync();
			DeskQuote.Desk.SurfaceMaterial = rawSurfaceMaterials.FirstOr(m => m.Name == SelectedMaterial, rawSurfaceMaterials[0] );
			DeskQuote.QuotePrice = DeskQuote.GetQuote( await _context.RushOrderTypes.ToListAsync() );
			DeskQuote.Date = DateTime.Now;
			_context.Desks.Add( DeskQuote.Desk );
			_context.DeskQuotes.Add( DeskQuote );
			await _context.SaveChangesAsync();

			return RedirectToPage( "./Index" );
		}
	}
}