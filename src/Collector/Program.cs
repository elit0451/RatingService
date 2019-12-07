using System;

namespace Collector
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }

        private void Run()
        {
            MessageGateway.ReceiveAnswers();
            while(true){
            }
        }
    }
}
