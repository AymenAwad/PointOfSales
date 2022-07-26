using Application.Repository.BaseService;
using Core.Entities;
using Core.Interfaces.Settings;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Settings
{
   public class StoreReturnedRepository : BaseServiceRepository<StoreReturned> , IStoreReturned
    {
        private readonly ApplicationDbContext _context;

        public StoreReturnedRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
