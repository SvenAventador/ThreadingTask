using System;

namespace ThreadingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shall we begin? Let's get started!");

            DummyRequestHandler dRH = new DummyRequestHandler();
            string[] arguments;
            List<string> argumentsList = new List<string>();
            string arg = "";

            Console.WriteLine("Enter the text of the request to send! If you want to exit, write /exit");

            var command = Console.ReadLine();

            while (command != "/exit")
            {
                while(arg != "/end")
                {
                    Console.WriteLine("Enter arguments! If you want to exit, write /end");
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                    arg = Console.ReadLine();
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                    argumentsList.Add(arg);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                }
                argumentsList.Remove("/end");
                arguments = argumentsList.ToArray();

                ThreadPool.QueueUserWorkItem(callBack =>
                {

                    try
                    {
                        Console.WriteLine($"Message '{command}' recieve a response: " + dRH.HandleRequest(command!, arguments));
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                });

                Console.WriteLine($"The following message was sent: '{command}'");
                Console.WriteLine("Enter arguments! If you want to exit, write /end");
                arg = "";
                argumentsList.Clear();
                command = Console.ReadLine();

            }

        }
    }
}