﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment1_Dotnet_Hospital_Management_System
{
    public class Doctor : User
    {


        public Doctor()
        {
            UserType = "Doctor";
        }
            public Doctor(int id, string fullName, string email, string phone, string address, string password)
        {
            this.ID = id;
            this.Name = fullName;
            this.Email = email;
            this.Phone = phone;
            UserType = "Doctor";
            this.Address = address;
            this.Password = password;

        }

        public override void MainMenu()
        {
            while (true) {
                Console.Clear();
                Header h1 = new Header("Doctor Home");
                Console.WriteLine("Doctor Menu");
                Console.WriteLine(" 1. List Doctor Details");
                Console.WriteLine(" 2. List patients");
                Console.WriteLine(" 3. List appointments");
                Console.WriteLine(" 4. Check particular patient");
                Console.WriteLine(" 5. List appointments with patient");
                Console.WriteLine(" 6. Logout");
                Console.WriteLine(" 7. Exit System");
                Console.Write("\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        myDetails();
                        break;
                    case "2":
                        //ListAllPatients();
                        break;
                    case "3":
                        //ListAllMyAppointments();
                        break;
                    case "4":
                        //CheckPatientDetailsWithID();
                        break;
                    case "5":
                        //AppointmentWithPatient();
                        break;
                    case "6":
                        Logout();
                        break;
                    case "7":
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                Console.ReadKey();
            }
        }

        //private void myDetails()
        //{
        //    Console.Clear();
        //    Header h1 = new Header("My Details");
        //    Console.WriteLine("");
        //    DisplayUserInTable(DataManager.curentUser);

        //}

        public override string ToString()
        {
            return $"{ID,-10} | {Name,-20} | {Email,-25} | {Phone,-20} | {Address,-45} |";
        }
    }

}
