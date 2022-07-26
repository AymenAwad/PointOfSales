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
    public class Branch_GallaryRepository : BaseServiceRepository<BranchGallary> , IBranch_Gallary
    {
        private readonly ApplicationDbContext _context;

        public Branch_GallaryRepository(ApplicationDbContext context) :base(context)
        {
            _context = context;
        }
    }
}
