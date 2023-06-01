using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cakekue_J94824.Data;
using Cakekue_J94824.Models;

namespace Cakekue_J94824.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly Cakekue_J94824.Data.Cakekue_J94824Context _context;

        public IndexModel(Cakekue_J94824.Data.Cakekue_J94824Context context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Product != null)
            {
                Product = await _context.Product.ToListAsync();
            }
        }
    }
}
