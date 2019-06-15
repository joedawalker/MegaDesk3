using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDesk3.Data;
using MegaDesk3.Models;

namespace MegaDesk3.Pages.DeskQuotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDesk3.Data.MegaDeskContext _context;

        public IndexModel(MegaDesk3.Data.MegaDeskContext context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuote { get;set; }

        public async Task OnGetAsync()
        {
            DeskQuote = await _context.DeskQuotes.ToListAsync();
        }
    }
}
