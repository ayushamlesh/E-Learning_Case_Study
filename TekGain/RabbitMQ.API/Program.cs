using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQ.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // Establish RabbitMQ connection and channel
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var connection = services.GetRequiredService<IConnection>();
                var channel = connection.CreateModel();

                // Declare a queue to ensure it exists
                channel.QueueDeclare(queue: "my_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

                // Set up a consumer to receive messages
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (sender, eventArgs) =>
                {
                    var body = eventArgs.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    Console.WriteLine("Received message: " + message);
                };
                channel.BasicConsume(queue: "my_queue", autoAck: true, consumer: consumer);
            }

            // Run the host
            host.Run();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}