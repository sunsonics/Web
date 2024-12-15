using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Data;
using Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Pages
{
    public class ModeratorPageModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ModeratorPageModel(ApplicationDbContext context)
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

        
        public async Task<IActionResult> OnPostEditUserAsync(string login, string password, int role, int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.Login = login;
                user.Password = password;
                user.role = role;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        
        public async Task<IActionResult> OnPostEditOrderAsync(int count, int id)
        {
            var order = await _context.orders.FindAsync(id);
            if (order != null)
            {
                order.Count = count;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

         
        public async Task<IActionResult> OnPostEditGoodsAsync(string name, string description, bool inStock, int id)
        {
            var goods = await _context.Goods.FindAsync(id);
            if (goods != null)
            {
                goods.Name = name;
                goods.Description = description;
                goods.In_stock = inStock;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        
        public async Task<IActionResult> OnPostDeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        
        public async Task<IActionResult> OnPostDeleteOrderAsync(int id)
        {
            var order = await _context.orders.FindAsync(id);
            if (order != null)
            {
                _context.orders.Remove(order);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

         
        public async Task<IActionResult> OnPostDeleteGoodsAsync(int id)
        {
            var goods = await _context.Goods.FindAsync(id);
            if (goods != null)
            {
                _context.Goods.Remove(goods);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}

