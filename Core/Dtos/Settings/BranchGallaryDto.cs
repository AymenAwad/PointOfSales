using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Settings
{
    public class BranchGallaryDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int StoreId { get; set; }
        public int? SaleId { get; set; }
        public int? SupplimentId { get; set; }
    }
}
