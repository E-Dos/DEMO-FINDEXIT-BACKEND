using TEMPLATE_ELDOS_BACKEND.Domain.Interfaces;
using TEMPLATE_ELDOS_BACKEND.Infrastructure.Data;

namespace TEMPLATE_ELDOS_BACKEND.Infrastructure.Services
{
    public class EMailService : IEMailService
    {
        private readonly ILogger<EMailService> logger;
        public EMailService(ILogger<EMailService> appLogger, AppDbContext appDb)
        {
            logger = appLogger;
        }

        public Task SendMailKit(int fileCount)
        {
            throw new NotImplementedException();
        }

        //public async Task SendMailKit(int fileCount)
        //{
        //    var email = new MimeMessage();
        //    email.From.Add(MailboxAddress.Parse("infobars23@mail.ru"));
        //    email.To.Add(MailboxAddress.Parse("mukhaniyarov@gmail.com"));
        //    email.To.Add(MailboxAddress.Parse("eldos.taspikh@gmail.com"));
        //    email.Subject = $"Импорт данных в СКПБ БАРС";
        //    var builder = new BodyBuilder();

        //    builder.HtmlBody = $"Данные загружены на сервер. Количество загруженных данных {fileCount}";
        //    email.Body = builder.ToMessageBody();
        //    using var smtp = new SmtpClient();
        //    smtp.Connect("smtp.mail.ru", 465, SecureSocketOptions.Auto);
        //    smtp.Authenticate("infobars23@mail.ru", "BgsbqGtapPuCcuqCxi64");
        //    await smtp.SendAsync(email);
        //    smtp.Disconnect(true);
        //}
    }
}
