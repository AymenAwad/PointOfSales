using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.UserLoginDto
{
    public class UserForListDto
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Nameen { get; set; }

        public string UserName { get; set; }
        public decimal? Unitid { get; set; }
        public decimal? Depatmentid { get; set; }
        public decimal? Sectionid { get; set; }
        public decimal? Classficationid { get; set; }
        public DateTime Creationdate { get; set; }
        public decimal Enteredbyid { get; set; }
        public decimal Lastupdatedbyid { get; set; }
        public string Status { get; set; }
       
    }
}
