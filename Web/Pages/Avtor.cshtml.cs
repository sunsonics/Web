using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Pochta;
using Web.Data;

namespace Web.Pages
{
    public class AvtorModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AvtorModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Login { get; set; }  

        [BindProperty]
        public string Code { get; set; } 

        public int Step { get; set; } = 1;  

        public IActionResult OnPostSendCode()
        {
           
            var user = _context.Users.FirstOrDefault(u => u.Login == Login);

            if (user == null)
            {
                ViewData["ErrorMessage"] = "������������ � ����� email �� ������.";
                return Page();
            }

             
            string confirmationCode = Poschtik.YandexMailSender.SendMailYandex(Login);
            if (confirmationCode == null)
            {
                ViewData["ErrorMessage"] = "�� ������� ��������� ��� �������������. ���������� �����.";
                return Page();
            }

             
            TempData["ConfirmationCode"] = confirmationCode;
            TempData["Login"] = Login;

            
            Step = 2;
            ViewData["Step"] = Step;

            return Page();
        }

        public IActionResult OnPostConfirmCode()
        {
          
            string storedCode = TempData["ConfirmationCode"] as string;
            string storedLogin = TempData["Login"] as string;

            if (storedCode == null || storedLogin == null || Login != storedLogin || Code != storedCode)
            {
                ViewData["ErrorMessage"] = "�������� ��� �������������.";
                return Page();
            }

            
            ViewData["SuccessMessage"] = "��� ������������� ������� ������. �� ������ ������� ������.";
            return Page();
        }
    }
}


