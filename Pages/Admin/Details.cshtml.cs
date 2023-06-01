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
    public class DetailsModel : PageModel
    {
        private readonly Cakekue_J94824.Data.Cakekue_J94824Context _context;

        public DetailsModel(Cakekue_J94824.Data.Cakekue_J94824Context context)
        {
            _context = context;
        }

      public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                Product = product;
            }
            return Page();
        }
    }
}
