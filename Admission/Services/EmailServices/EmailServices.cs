//using Admission.Manage.manageEmail;
//using MimeKit.Text;
//using MimeKit;
//using MailKit.Net.Smtp;


//namespace Admission.Services.EmailServices
//{
//    public class EmailServices : IEmailServices
//    {
//        private readonly IConfiguration _configuration;
//        public EmailServices(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        public void SendEmail(EmailDTO request)
//        {
//            var email = new MimeMessage();
//            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUserName").Value));
//            email.To.Add(MailboxAddress.Parse(request.to));
//            email.Subject = request.subject;
//            email.Body = new TextPart(TextFormat.Html)
//            {
//                Text =request.body,
//            };
//            using var smtp = new SmtpClient();
//            smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
//            smtp.Authenticate(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassword").Value);
//            smtp.Send(email);
//            smtp.Disconnect(true);

//        }
//    }
//}
