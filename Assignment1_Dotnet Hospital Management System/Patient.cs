using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Dotnet_Hospital_Management_System
{
    public class Patient : User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public string Phone { get; set; }
        private string Password { get; set; }

        public override void MainMenu()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"{ID,-10} | {Name,-20} | {Email,-25} | {Phone,-20} | {Address,-45} |";
        }
    }
}
