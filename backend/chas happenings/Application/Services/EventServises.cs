using Application.Interfaces.Irepositories;
using Application.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    internal class EventServises : IEventServices
    {
        private readonly IEventRepositories _repo;
        public EventServises(IEventRepositories repo)
        {
            _repo = repo;
        }
    }
}
