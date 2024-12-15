using System.Net.Mail;
using System.Net;
 

namespace Web.Pochta
{
    public class Poschtik
    {
        internal class YandexMailSender
        {
            public static string SendMailYandex(string userEmail)
            {
                string yandexAppPassword = "onkwkpinovwxzyse";
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("sonic33saharova@yandex.ru");
                mail.To.Add(userEmail);
                mail.Subject = "Код подтверждения";
                string confirmationCode = GenerateFourDigitCode();
                mail.Body = $"Ваш код подтверждения: {confirmationCode}";
                SmtpClient smtpClient = new SmtpClient("smtp.yandex.ru");
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("sonic33saharova@yandex.ru", yandexAppPassword);
                try
                {
                    smtpClient.Send(mail);
                    Console.WriteLine("Письмо успешно отправлено");
                    return confirmationCode;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при отправке письма: " + ex.Message);
                    return null;
                }
            }

            private static string GenerateFourDigitCode()
            {
                Random random = new Random();
                int code = random.Next(1000, 10000);
                return code.ToString("D4");
            }
        }

        internal class MailRuMailSender
        {

            public static string SendMailRu(string userEmail)
            {
                string mailRuAppPassword = "xnRfzxxPibnZ0SJ13spg";
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("sunsonicc@mail.ru");
                mail.To.Add(userEmail);
                mail.Subject = "Код подтверждения";
                string confirmationCode = GenerateFourDigitCode();
                mail.Body = $"Ваш код подтверждения: {confirmationCode}";
                SmtpClient smtpClient = new SmtpClient("smtp.mail.ru");
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("sunsonicc@mail.ru", mailRuAppPassword);
                try
                {
                    smtpClient.Send(mail);
                    Console.WriteLine("Письмо успешно отправлено");
                    return confirmationCode;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при отправке письма: " + ex.Message);
                    return null;
                }
            }
            private static string GenerateFourDigitCode()
            {
                Random random = new Random();
                int code = random.Next(1000, 10000);
                return code.ToString("D4");
            }
        }


        internal class GmailSender
        {
            public static string SendGMail(string userEmail)
            {
                string gmailAppPassword = "craf ljnh iwkg iheo";
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("yliua.com22@gmail.com");
                mail.To.Add(userEmail);
                mail.Subject = "Код подтверждения";
                string confirmationCode = GenerateFourDigitCode();
                mail.Body = $"Ваш код подтверждения: {confirmationCode}";
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("yliua.com22@gmail.com", gmailAppPassword);
                try
                {
                    smtpClient.Send(mail);
                    Console.WriteLine("Письмо успешно отправлено");
                    return confirmationCode;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при отправке письма: " + ex.Message);
                    return null;
                }
            }
            private static string GenerateFourDigitCode()
            {
                Random random = new Random();
                int code = random.Next(1000, 10000);
                return code.ToString("D4");
            }
        }
    }
}

