using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WebApplication2.Models
{
    public class User : IComparable<User>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }



        public User(int id, string email, string password)
            {
                this.Id = id;
                this.Email = email;
                this.Password = password;
            }
     

        public int CompareTo(User other)
        {
            if (this.Id == other.Id && this.Email == other.Email && this.Password == other.Password)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
