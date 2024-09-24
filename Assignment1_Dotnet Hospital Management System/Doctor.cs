using System;
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
                        ListMyPatients();
                        break;
                    case "3":
                        ListAllMyAppointments();
                        break;
                    case "4":
                        CheckPatientDetailsWithID();
                        break;
                    case "5":
                        AppointmentsWithPatient();
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

        private void AppointmentsWithPatient()
        {
            Console.Clear();
            Header h1 = new Header("Patient Home");
            Console.WriteLine("Enter the patient ID to check appointment details: ");
            int pid = int.Parse(Console.ReadLine());
            if (DataManager.CheckID("Patient", pid))
            {
                List<Appointment> appointmentShortList = DataManager.GetAppointmentInfo(pid);
                ShowinTable(appointmentShortList);
            }
            else {
                Console.Write("\nNo appointment found with this id. Please press any key to go abck to main menu.");
            }
            
            

        }

        private void ListAllMyAppointments()
        {
            List<Appointment> myAppointments = DataManager.GetFullAppointmentList();
            ShowinTable(myAppointments);
        }

        private void CheckPatientDetailsWithID()
        {
            Console.Write("\nEnter Patient ID: ");
            int PID = int.Parse(Console.ReadLine());
            bool PatientFound = false;
            Patient p = DataManager.getPatientInfo(PID);

            if (p != null)
            {
                //Show in table
                Console.WriteLine($"\n{"Patient ID",-10} | {"Patient Name",-20}  | {"Email",-25} | {"Phone",-20} | {"Address",-45} |");
                for (int i = 0; i < 137; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine("");
                //---------------------Data Below--------------------------------------------------------------------------------

                Console.WriteLine(DataManager.getPatientInfo(PID).ToString());
                //---------------------Data above--------------------------------------------------------------------------------

                for (int i = 0; i < 137; i++)
                {
                    Console.Write("-");
                }
                //-----------------------------------------------------------------------------------------------------
                Console.WriteLine("\n Press any key to continue...");
            }
            else {
                Console.WriteLine("No patient found with this ID! \nPress any key to go back to min menu.");
            }

        }

        private void ListMyPatients()
        {
            DataManager.reloadData();
            int[] MyPatientList = DataManager.curentUser.RegisteredWith;

            //if there are Patients registered
            if (MyPatientList.Length > 0)
            {
                Console.Clear();
                Header h1 = new Header("Doctor Home");
                Console.WriteLine("\nMy registered patients.\n");
                Console.WriteLine($"\n{"Patient ID",-10} | {"Patient Name",-20} | {"Email",-25} | {"Phone",-20} | {"Address",-45} ");
                for (int i = 0; i < 134; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine("");
                //---------------------Data Below--------------------------------------------------------------------------------

                for (int i = 0; i < MyPatientList.Length; i++)
                {
                    Patient p = DataManager.getPatientInfo(MyPatientList[i]);
                    Console.WriteLine(p.ToString());
                }
                //---------------------Data above--------------------------------------------------------------------------------

                for (int i = 0; i < 134; i++)
                {
                    Console.Write("-");
                }
                //-----------------------------------------------------------------------------------------------------
                Console.WriteLine("\n Press any key to continue...");
            }
            //If no doctor registered
            else
            {
                Console.Clear();
                Header h1 = new Header("Patient Home");
                Console.WriteLine("You don't have any registered patients. Press any key to go back to main menu.");
            }
        }
        
        //Show data in table.
        public void ShowinTable(List<Appointment> myAppointments) {
            Console.WriteLine($"\n{"Appointment ID",-15} | {"Patient Name",-20} | {"Doctor Name",-20} | {"Description",-60} |");
            for (int i = 0; i < 125; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("");
            //Print result
            //------------------------------data below-----------------------------------------------------------------------

            foreach (Appointment a in myAppointments)
            {
                if (a.D_ID == DataManager.curentUser.ID)
                {
                    Console.WriteLine(a.ToString());
                }
            }
            //------------------------------data below-----------------------------------------------------------------------
            for (int i = 0; i < 125; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("");
            //-----------------------------------------------------------------------------------------------------

            Console.WriteLine("\n Press any key to continue...");
        }
        public override string ToString()
        {
            return $"{ID,-10} | {Name,-20} | {Email,-25} | {Phone,-20} | {Address,-45} |";
        }
    }

}
