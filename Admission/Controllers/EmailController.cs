using Admission.Model.DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Admission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly ISendGridClient _sendGridClient;
        private readonly IConfiguration _configuration;
        public EmailController(ISendGridClient sendGridClient,
            IConfiguration configuration)
        {
            _sendGridClient = sendGridClient;
            _configuration=configuration;
        }

        [HttpGet,Route("SendPlainTextEmail")]
        public async Task<IActionResult> SendPlainTextEmail(string toEmail)
        {
            string fromEmail = _configuration.GetSection("SendGridEmailSettings")
                .GetValue<string>("FromEmail");

            string fromName = _configuration.GetSection("SendGridEmailSettings")
                .GetValue<string>("FromName");

            var msg = new SendGridMessage()
            {
                From=new EmailAddress(fromEmail, fromName),
                Subject="plain Text Email",
                PlainTextContent=" Done Sending Email With Sendgrid"
            };
            msg .AddTo(toEmail);
            var response = await _sendGridClient.SendEmailAsync(msg);
            string message = response.IsSuccessStatusCode ? "Email Sent" : "Email Sending Failed";
            return Ok(message);

        }

        private string EmailHTML(SendGridEmail sendGridEmail)
        {
            return @"<html>
    <head>
        <style>           
            .container{
                border: 2px solid rgb(37, 37, 148);
                border-radius: 5px;
                box-shadow:7px 7px rgb(137, 150, 150);
                display: block;
                width: max-content;
                height:max-content;
                border-color: black;
                flex-wrap: wrap;
                float:inline-start;
                padding: 5px;
                margin: 5px;
                justify-content: center;
                
                background: rgb(14, 12, 63);
                background: linear-gradient(150deg, rgb(23, 17, 129) 0%, rgb(37, 37, 148) 10%, rgba(0,212,255,1) 100%);            
           
            }
            .box{
                display: inline;
                background-image: url('');
            background-repeat: no-repeat;
            background-position: center;
            background-size: 60%;
            /* backface-visibility:visible; */
        }
        p,ul {
           /*border: 2px hidden rebeccapurple;*/
            padding: .5em;
            text-align: center;
            }
    p,.Welcome{
                 text-align: center;
                text-decoration: wavy;
            }

            .block,
            li
{
    box-shadow: 5px;
padding: .5em;
    text-align: center;
}

ul
{
display: flex;
    list-style: none;
    justify-content: center;
}

            .block
{
display: block;
}
        </style>
    </head>
    <body>
        <div class='container'>
            <div class='box'>
                <p class=''Welcome'>Welcome {{name}}</p>
                <p><span class='block'>Hello{{name}}</span></p>
                <p>Now you are waiting for interview, Please always check your email for new updates</p>
            </div>
        </div>
    </body>
</html>".Replace("{{name}}",sendGridEmail.Name);
       
        }

        [HttpPost, Route("SendHTMLEmail")]
        public async Task<IActionResult> SendHTMLEmail(SendGridEmail sendGridEmail)
        {
            string fromEmail = _configuration.GetSection("SendGridEmailSettings")
                .GetValue<string>("FromEmail");

            string fromName = _configuration.GetSection("SendGridEmailSettings")
                .GetValue<string>("FromName");

            var msg = new SendGridMessage()
            {
                From=new EmailAddress(fromEmail, fromName),
                Subject="HTML Email",
                HtmlContent=EmailHTML(sendGridEmail)
            };
            msg.AddTo(sendGridEmail.ToEmail);
            var response = await _sendGridClient.SendEmailAsync(msg);
            string message = response.IsSuccessStatusCode ? "Email Sent" : "Email Sending Failed";
            return Ok(message);

        }

        [HttpPost, Route("SendAttechmentsEmail")]
        public async Task<IActionResult> SendAttechmentsEmail([FromForm]EmailAttachments attachementEmail)
        {
            string fromEmail = _configuration.GetSection("SendGridEmailSettings")
                .GetValue<string>("FromEmail");

            string fromName = _configuration.GetSection("SendGridEmailSettings")
                .GetValue<string>("FromName");

            var msg = new SendGridMessage()
            {
                From=new EmailAddress(fromEmail, fromName),
                Subject="FIle Attachment Email",
                PlainTextContent= "Check Attached File",
                HtmlContent=EmailHTML(attachementEmail.Name)
                //Attachments=
            };

            // if we use multiple files use AddAttachment
            await msg.AddAttachmentAsync(
                attachementEmail.ImageFile.FileName,
                attachementEmail.ImageFile.OpenReadStream(),
                attachementEmail.ImageFile.ContentType,
                "attachment"
                );
            msg.AddTo(attachementEmail.ToEmail);
           
            var response = await _sendGridClient.SendEmailAsync(msg);
            string message = response.IsSuccessStatusCode ? "Email Sent" : "Email Sending Failed";
            return Ok(message);

        }

    }
}
