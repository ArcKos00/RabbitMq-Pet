using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory { HostName = "localhost", Port = 5672 };

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare("BasicTest", false,false, false, null);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body;
    var message = Encoding.UTF8.GetString(body.ToArray());
    Console.WriteLine("Received message {0}...", message);
};

channel.BasicConsume("BasicTest", true, consumer);

Console.WriteLine("Press [enter to exit consumer]");
Console.ReadLine();