using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Models;
using Web.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Pages
{
    public class AdminPageModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AdminPageModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Login { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; private set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Login and password are required.";
                return Page();
            }

            
            if (_context.Users.Any(u => u.Login == Login))
            {
                ErrorMessage = "User with this login already exists.";
                return Page();
            }

            
            var user = new Users { Login = Login, Password = Password, role = 1 };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            
            return RedirectToPage("Index");
        }
    }
}
