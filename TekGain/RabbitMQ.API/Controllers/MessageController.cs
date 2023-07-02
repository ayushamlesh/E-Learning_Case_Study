using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQ.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        // Implement the service here
        private readonly string _rabbitMQHost = "localhost";


        [HttpGet("Publish")]
        public IActionResult Publish(string email)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = _rabbitMQHost };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "Admission",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var message = Encoding.UTF8.GetBytes(email);
                    channel.BasicPublish(exchange: "",
                                         routingKey: "Admission",
                                         basicProperties: null,
                                         body: message);
                }

                return Ok(email);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while publishing the email: {ex.Message}");
            }
        }

        [HttpGet("Consume")]
        public IActionResult Consume()
        {
            List<string> emailAddresses;
            try
            {
                emailAddresses = new List<string>();
                var factory = new ConnectionFactory() { HostName = _rabbitMQHost };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "Admission",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var email = Encoding.UTF8.GetString(body);
                        emailAddresses.Add(email);

                        // Send the email
                        SendEmail(email);
                    };

                    channel.BasicConsume(queue: "Admission",
                                         autoAck: true,
                                         consumer: consumer);
                }

                return Ok(emailAddresses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while consuming emails: {ex.Message}");
            }
        }

        private void SendEmail(string recipientEmail)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Phoebe Fay", "phoebe.fay18@ethereal.email")); // Replace with your name and email
            message.To.Add(new MailboxAddress("", recipientEmail));

            message.Subject = "Admission Confirmation";
            message.Body = new TextPart(TextFormat.Plain)
            {
                Text = "Congratulations! You have been admitted to our program."
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
                client.Authenticate("phoebe.fay18@ethereal.email", "YH7s5w8Efbh3Ped3Fk"); // Replace with your email and password
                client.Send(message);
                client.Disconnect(true);
            }
        }


    }

}