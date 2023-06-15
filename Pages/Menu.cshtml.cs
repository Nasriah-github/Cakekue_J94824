using Cakekue_J94824.Data;
using Cakekue_J94824.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cakekue_J94824.Pages
{
    public class MenuModel : PageModel
    {

        private readonly Cakekue_J94824.Data.Cakekue_J94824Context _context;

        public MenuModel(Cakekue_J94824.Data.Cakekue_J94824Context context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Product != null)
            {
                Product = await _context.Product.ToListAsync();
            }
        }
    }
}
