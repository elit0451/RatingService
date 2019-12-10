using System;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;

namespace Client
{
    public static class MessageGateway
    {
        private static ConnectionFactory factory;
        private static IConnection connection;
        private static IModel channel;
        static MessageGateway()
        {
            factory = new ConnectionFactory() { HostName = "167.172.98.57" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
        }
        public static void SendAnswers(int grade, string description, string country, string gender, int age)
        {   
            JObject answers = new JObject();

            answers.Add("Grade", grade);
            answers.Add("Description", description);
            answers.Add("Country", country);
            answers.Add("Gender", gender);
            answers.Add("Age", age);

            channel.QueueDeclare(queue: "answers",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
            
            var body = Encoding.UTF8.GetBytes(answers.ToString());

            channel.BasicPublish(exchange: "",
                                 routingKey: "answers",
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine("Sent notification");
        }
    }
}