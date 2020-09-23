using Store.Data.Models;
using StoreWS.UnitOfWork;
using System;
using System.Collections.Generic;

namespace StoreWS.Service
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }        

        public List<Client> Get()
        {
            var clients = new List<Client>
            {
                new Client
                {
                    ClientId = new Guid("0C5F4E9F-68E0-DF11-9D9F-0014D1184EFC"),
                    Cpf = "04569852378",
                    Email = "jonilson@gmail.com",
                    FirstName = "Jonilson",
                    LastName = "Alves",
                    Password = "*******",
                    CreatedOn = DateTime.Now,
                    Status = true
                },
                new Client
                {
                    ClientId = new Guid("FB326931-6577-E411-80CF-00155DC0AB72"),
                    Cpf = "98765555378",
                    Email = "jael@gmail.com",
                    FirstName = "Jael",
                    LastName = "Macedo",
                    Password = "*******",
                    CreatedOn = DateTime.Now,
                    Status = true
                },
                new Client
                {
                    ClientId = new Guid("834550E8-BDD3-4C91-A6FF-00B418FF551A"),
                    Cpf = "35415486988",
                    Email = "mariana@gmail.com",
                    FirstName = "Mariana",
                    LastName = "Gomes Mendes",
                    Password = "*******",
                    CreatedOn = DateTime.Now,
                    Status = true
                },
                new Client
                {
                    ClientId = new Guid("9102CDA2-4239-4B59-BDF5-03FF8EAB50A5"),
                    Cpf = "38546564511",
                    Email = "francisco@gmail.com",
                    FirstName = "Francisco",
                    LastName = "Silveira",
                    Password = "*******",
                    CreatedOn = DateTime.Now,
                    Status = true
                }
            };

            return clients;
        }
    }
}