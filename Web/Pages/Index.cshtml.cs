using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Linq;
using Web.Models;
using Web.Data;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public string Login { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Login == Login && u.Password == Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Неверный логин или пароль.");
                return Page();  
            }

            switch (user.role)  
            {
                case 1:  
                    Console.WriteLine($"UserId из TempData: {TempData["UserId"]}");
                    return RedirectToPage("/HomePage");  

                case 2:  
                    Console.WriteLine($"ModeratorId из TempData: {TempData["UserId"]}");
                    return RedirectToPage("/ModeratorPage");  

                case 3:  
                    Console.WriteLine($"AdminId из TempData: {TempData["UserId"]}");
                    return RedirectToPage("/Admin");  

                default:
                    ModelState.AddModelError("", "Неизвестная роль пользователя.");
                    return Page();  
            }
        }

    }
    }
    


