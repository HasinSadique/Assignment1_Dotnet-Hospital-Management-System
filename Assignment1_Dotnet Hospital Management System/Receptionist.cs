using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Dotnet_Hospital_Management_System
{
    public class Receptionist : User
    {
        public Receptionist()
        {
            UserType = "Receptionist";
        }

        public override void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Header h1 = new Header("Receptionist Home");
                Console.WriteLine("Welcome to DOTNET Hospital Management System\n");
                Console.WriteLine("Patient Menu");
                Console.WriteLine(" 1. List All Appointments");
                Console.WriteLine(" 2. Logout");
                Console.WriteLine(" 3. Exit System");
                Console.Write("\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ShowAllAppointments();
                        break;
                    case "2":
                        Logout();
                        break;
                    case "3":

                        Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;

                }
                Console.ReadKey();
            }
        }

        public void ShowAllAppointments()
        {
            List<Appointment> appointments = DataManager.GetFullAppointmentList();
            Console.Clear();
            Header h1 = new Header("Receptionist Home");
            Console.WriteLine($"\n{"Appointment ID",-15} | {"Patient ID",-10} | {"Doctor ID",-10} | {"Patient Name",-20} | {"Doctor Name",-15} | {"Description",-60} ");
            for (int i = 0; i < 150; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("");
            //-----------------------------------------------------------------------------------------------------
            //******************Print Appointment Data in Table*******************************
            foreach (Appointment appointment in appointments) 
            {
                Console.WriteLine(appointment.ToString());
            }
            //*************************************************
            for (int i = 0; i < 150; i++)
            {
                Console.Write("-");
            }
            //-----------------------------------------------------------------------------------------------------
            Console.WriteLine("\nPress any key to continue...");

        }
    }
}