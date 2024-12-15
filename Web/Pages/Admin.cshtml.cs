using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

namespace Web.Pages
{
    public class AdminModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AdminModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Users> Users { get; set; }
        public IList<orders> Orders { get; set; }
        public IList<goods> Goods { get; set; }

        public async Task OnGetAsync()
        {
            
            Users = await _context.Users.ToListAsync();
 
            Orders = await _context.orders
                .Include(o => o.Users)  
                .Include(o => o.goods)  
                .ToListAsync();
             
            Goods = await _context.Goods.ToListAsync();
        }
    }
}