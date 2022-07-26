using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Settings
{
    public class AgentDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public int? SaleId { get; set; }
    }
}
