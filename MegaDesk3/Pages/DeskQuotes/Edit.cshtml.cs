using System;
using System.Collections.Generic;
using MegaDesk3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;

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
        public SelectList SurfaceMaterials { get; set; }

        [BindProperty]
        public string SelectedMaterial { get; set; }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<IActionResult> OnGetAsync( int? id )
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            if ( id == null )
            {
                return NotFound();
            }

            Task<DeskQuote> getQuoteAsync = _context.DeskQuotes.Include( dq => dq.Desk )
                .Include( dq => dq.Desk.SurfaceMaterial ).FirstOrDefaultAsync( m => m.DeskQuoteId == id );

            Task<List<string>> getSurfaceMaterialsAsync = _context.SurfaceMaterials.Select( s => s.Name ).ToListAsync();

            Task.WaitAll( getQuoteAsync, getSurfaceMaterialsAsync );

            DeskQuote = getQuoteAsync.Result;
            SurfaceMaterials = new SelectList( getSurfaceMaterialsAsync.Result );
            SelectedMaterial =
                getSurfaceMaterialsAsync.Result.FirstOrDefault( m => m == DeskQuote.Desk.SurfaceMaterial.Name );

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

            List<SurfaceMaterial> rawSurfaceMaterials = await _context.SurfaceMaterials.ToListAsync();
            DeskQuote.Desk.SurfaceMaterial = rawSurfaceMaterials.FirstOr( m => m.Name == SelectedMaterial, rawSurfaceMaterials[0] );
            DeskQuote.QuotePrice = DeskQuote.GetQuote( await _context.RushOrderTypes.ToListAsync() );
            DeskQuote.Date = DateTime.Now;

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
