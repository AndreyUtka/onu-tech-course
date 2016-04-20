using System;
using System.Collections.Generic;


namespace CourseApp
{
    class Program
    {
        private const string ConnectionString = "Server=localhost;Port=5432;Database=casino;User Id=postgres;Password=AdajPif921;";

        static void Main()
        {
            // initialize repositories
            ClientRepository clientRepo = new ClientRepository(ConnectionString);
            ServiceRepository serviceRepository = new ServiceRepository(ConnectionString);

            // initialize services
            ClientManager clientManager = new ClientManager(clientRepo, serviceRepository);

            List<Client> clients = clientManager.GetClientsFinancialOperations();

            Console.WriteLine("=== === === === === === === === ===");
            Console.WriteLine("All Client Data: ");
            foreach (var client in clients)
            {
                //Print client data
                Console.WriteLine(
                    "id_cl: {0}{6}SecondName: {1}{6}FirstName: {2}{6}Patronymic: {3}{6}Birthday: {4}{6}GNum: {5}{6}",
                    client.Id, client.SecondName, 
                    client.FirstName, 
                    client.Patronymic, 
                    client.Birthday, 
                    client.GNum,
                    Environment.NewLine);

                //Print client's services data
                Console.WriteLine();
                Console.WriteLine("Client operations: ");
                foreach (var service in client.Services)
                {
                    Console.WriteLine(
                       "id_cl: {0}{3}Rate: {1}{3}Result: {2}{3}",
                       service.Id, 
                       service.Rate, 
                       service.Result, 
                       Environment.NewLine);
                }

                Console.WriteLine();
            }


            /*ClientRepository clientRepo = new ClientRepository(ConnectionString);
            Client concreteClient = clientRepo.GetById(1);
                                 
            Console.WriteLine(
                "id_cl: {0}\n" +
                "SecondName: {1}\n" +
                "FirstName: {2}\n" +
                "Patronymic: {3}\n" +
                "Birthday: {4}\n" +
                "GNum: {5}\n",
                concreteClient.id_cl, concreteClient.SecondName, concreteClient.FirstName, concreteClient.Patronymic, concreteClient.Birthday, concreteClient.GNum);

            List<Client> clients = clientRepo.GetAll();
            foreach (var client in clients)
            {
                Console.WriteLine(
                "id_cl: {0}\n" +
                "SecondName: {1}\n" +
                "FirstName: {2}\n" +
                "Patronymic: {3}\n" +
                "Birthday: {4}\n" +
                "GNum: {5}\n",
                client.id_cl, client.SecondName, client.FirstName, client.Patronymic, client.Birthday, client.GNum);
            }*/

            ServiceRepository serviceRepo = new ServiceRepository(ConnectionString);
            Service concreteService = serviceRepo.GetByClientId(2); 
            
            Console.WriteLine(
                "id_cl: {0}\n" +
                "Rate: {1}\n" +
                "Result: {2}\n",
                concreteService.Id, concreteService.Rate, concreteService.Result);






        

                
        }

    }
}
