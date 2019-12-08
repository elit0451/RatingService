using System;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Collector
{
    public static class MessageGateway
    {
        private static ConnectionFactory factory;
        private static IConnection connection;
        private static IModel channel;
        static MessageGateway()
        {
            factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
        }
        public static void ReceiveAnswers()
        {
            channel.QueueDeclare(queue: "answers",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);

                int grade = 0;
                string description = "";
                string country = "";
                string gender = "";
                int age = 0;

                JObject receivedObj = JsonConvert.DeserializeObject<JObject>(message);
                grade = receivedObj["Grade"].Value<int>();
                description = receivedObj["Description"].Value<string>();
                country = receivedObj["Country"].Value<string>();
                gender = receivedObj["Gender"].Value<string>();
                age = receivedObj["Age"].Value<int>();

                Questionnaire questionnaire = DataNormalizer.Normalize(grade, description, country, gender, age);
                Console.WriteLine("Collected some data");
                AnswersRepository.Instance.AddQuestionnaire(questionnaire);
            };
            channel.BasicConsume(queue: "answers",
                                 autoAck: true,
                                 consumer: consumer);
        }
    }
}