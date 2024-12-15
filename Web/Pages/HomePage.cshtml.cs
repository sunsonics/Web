using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Data;
using Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
 
 

namespace Web.Pages
{
    public class HomePageModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public HomePageModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<goods> Goods { get; set; }
        public IList<orders> Orders { get; set; }

       
        public async Task OnGetAsync()
        {
            Goods = await _context.Goods.ToListAsync();

             
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId.HasValue)
            {
                 
                Orders = await _context.orders
                    .Where(o => o.User_id == userId.Value)
                    .Include(o => o.Goods_id)  
                    .ToListAsync();
            }
        }

        
        public async Task<IActionResult> OnPostCreateOrderAsync(int goodsId, int quantity)
        {
            
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId.HasValue)
            {
                 
                var goods = await _context.Goods.FindAsync(goodsId);
                if (goods != null && goods.In_stock && quantity > 0)
                {
                    
                    var order = new orders
                    {
                        User_id = userId.Value,  
                        Goods_id = goods.ID,
                        Count = quantity
                    };

                    _context.orders.Add(order);
                    await _context.SaveChangesAsync();

                    TempData["Message"] = "Заказ успешно добавлен!";
                    return RedirectToPage();
                }

                 
                TempData["Error"] = "Ошибка при создании заказа.";
                return RedirectToPage();
            }

             
            TempData["Error"] = "Пользователь не найден.";
            return RedirectToPage();
        }
    }
}

