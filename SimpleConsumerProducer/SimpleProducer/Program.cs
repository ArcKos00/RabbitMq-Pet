using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory { HostName = "localhost", Port = 5672};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
channel.QueueDeclare("BasicTest", false, false, false, null);

const string message = "Getting started with .NET Core RabbitMQ";
var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish("", "BasicTest", null, body);
Console.WriteLine("Sent message {0}...", message);

Console.WriteLine("Press [enter] to exit the Sender App");
Console.ReadLine();