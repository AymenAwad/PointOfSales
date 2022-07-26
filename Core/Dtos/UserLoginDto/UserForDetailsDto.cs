using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.UserLoginDto
{
    public class UserForDetailsDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime Creationdate { get; set; }
        public decimal Enteredbyid { get; set; }
        public decimal Lastupdatedbyid { get; set; }
        public string EnteredbyNameen { get; set; }
        public string EnteredbyName { get; set; }
        public string LastupdatedbyName { get; set; }
        public string LastupdatedbyNameen { get; set; }
        public string Status { get; set; }




    }
}
