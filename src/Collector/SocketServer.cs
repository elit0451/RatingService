using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Collector
{
    public class SocketServer
    {
        public static void Run()
        {
            new SocketServer().Start();
        }

        public void Start()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 12345);
            listener.Start();

            Socket client = null;

            while (true)
            {
                Console.WriteLine("Server waiting");
                client = listener.AcceptSocket();
                ThreadPool.QueueUserWorkItem(ThreadProc, client);
            }
        }

        private static void ThreadProc(object obj)
        {
            Socket client = (Socket)obj;

            Console.WriteLine("A client just connected.");

            while (client.Connected == true)
            {
                NetworkStream stream = new NetworkStream(client);
                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream);

                writer.AutoFlush = true;

                string clientMessage = reader.ReadLine();
                if (clientMessage != "")
                {
                    Console.WriteLine(client.RemoteEndPoint + " asked for \"" + clientMessage + "\"");
                    string[] commands = clientMessage.Split(' ');

                    switch (commands[0])
                    {
                        case "average":
                            try
                            {
                                switch (commands[1])
                                {
                                    case "grade":
                                        writer.WriteLine(CalculateAvgGrade());
                                        break;
                                    case "gender":
                                        writer.WriteLine(CalculateAvgGenderPercentage());
                                        break;
                                    case "age":
                                        writer.WriteLine(CalculateAvgAgePercentage());
                                        break;
                                }
                            }
                            catch(Exception e)
                            {
                                writer.WriteLine("No available results!");
                            }
                            break;
                        default:
                            writer.WriteLine("Unknown command");
                            break;
                    }
                }
            }
        }

        private static string CalculateAvgGrade()
        {
            List<Questionnaire> answers = AnswersRepository.Instance.GetQuestionnaires();
            int totalGrade = 0;

            foreach (Questionnaire answer in answers)
                totalGrade += answer.Grade;

            return (totalGrade / answers.Count).ToString();
        }

        private static string CalculateAvgGenderPercentage()
        {
            List<Questionnaire> answers = AnswersRepository.Instance.GetQuestionnaires();
            int males = 0;
            int females = 0;
            int other = 0;
            int totalCount = answers.Count;
            float malePercentage = 0;
            float femalePercentage = 0;
            float otherPercentage = 0;

            foreach (Questionnaire answer in answers)
            {
                if (answer.Gender == Gender.Male)
                    males++;
                else if (answer.Gender == Gender.Female)
                    females++;
                else
                    other++;
            }

            malePercentage = males * 100 / totalCount;
            femalePercentage = females * 100 / totalCount;
            otherPercentage = other * 100 / totalCount;

            return $"Males: {malePercentage}%, Females: {femalePercentage}%, Other: {otherPercentage}%";
        }

        private static string CalculateAvgAgePercentage()
        {
            List<Questionnaire> answers = AnswersRepository.Instance.GetQuestionnaires();
            int youths = 0;
            int adults = 0;
            int seniors = 0;
            int other = 0;
            int totalCount = answers.Count;
            float youthPercentage = 0;
            float adulthoodPercentage = 0;
            float seniorityPercentage = 0;
            float otherPercentage = 0;

            foreach (Questionnaire answer in answers)
            {
                if (answer.AgeGr == AgeGroup.Youth)
                    youths++;
                else if (answer.AgeGr == AgeGroup.Adulthood)
                    adults++;
                else if (answer.AgeGr == AgeGroup.Seniority)
                    seniors++;
                else
                    other++;
            }

            youthPercentage = youths * 100 / totalCount;
            adulthoodPercentage = adults * 100 / totalCount;
            seniorityPercentage = seniors * 100 / totalCount;
            otherPercentage = other * 100 / totalCount;

            return $"Youth: {youthPercentage}%, Adulthood: {adulthoodPercentage}%, Seniority: {seniorityPercentage}%, Other: {otherPercentage}%";
        }
    }
}