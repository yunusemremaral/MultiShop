using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MultiShop.RabbitMQMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateMessage()
        {
            var connectionfactory = new ConnectionFactory()
            {
                HostName = "localhost",
            };

            using var connection = connectionfactory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "Kuyruk1",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var messagecontent = "Merhaba RabbitMQ";
            var bytemessagecontent = Encoding.UTF8.GetBytes(messagecontent);

            channel.BasicPublish(
                exchange: "",
                routingKey: "Kuyruk1",
                mandatory: false,
                basicProperties: null,
                body: bytemessagecontent
            );

            return Ok("Mesaj Kuyruğa Alınmıştır.");
        }

        private static string? message;


        [HttpGet]
        public IActionResult ReadMessage()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "Kuyruk1",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            var tcs = new TaskCompletionSource<string>();

            consumer.Received += (model, eventArgs) =>
            {
                var bytemessage = eventArgs.Body.ToArray();
                var receivedMessage = Encoding.UTF8.GetString(bytemessage);
                tcs.SetResult(receivedMessage); // Mesaj alındığında tamamlanır
            };

            channel.BasicConsume(queue: "Kuyruk1",
                                 autoAck: true,
                                 consumer: consumer);

            // Mesajı bekle
            if (tcs.Task.Wait(TimeSpan.FromSeconds(5))) // Maksimum 5 saniye bekle
            {
                return Ok(tcs.Task.Result);
            }
            else
            {
                return Ok("Mesaj Bulunamadı veya zaman aşımına uğradı.");
            }
        }

    }
}
