using System.Collections.Generic;
using System.Linq;

namespace CourseApp
{
    public class ClientManager
    {
        public ClientRepository ClientRepository { get; private set; }
        public ServiceRepository ServiceRepository { get; private set; }

        public ClientManager(ClientRepository clientRepository, ServiceRepository serviceRepository)
        {
            ClientRepository = clientRepository;
            ServiceRepository = serviceRepository;
        }

        //TODO: change name if needed
        public List<Client> GetClientsFinancialOperations()
        {
            List<Client> clients = ClientRepository.GetAll();
            List<Service> services = ServiceRepository.GetAll();

            //TODO: understand this tricky moment
            foreach (var client in clients)
            {
                // we assign to the client all services that have clientId same as client Id
                client.Services = services.Where(s => s.ClientId == client.Id).ToList();
            }

            return clients;
        }
    }
}
