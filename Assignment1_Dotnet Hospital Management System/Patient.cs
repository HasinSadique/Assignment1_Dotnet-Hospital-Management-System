using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment1_Dotnet_Hospital_Management_System
{
    public class Patient : User
    {
        public int WardNumber { get; set; }
        public Patient()
        {
            UserType = "Patient";
        }
        public override void MainMenu()
        {
            while (true)
            {

                Console.Clear();
                Header h1 = new Header("Patient Home");
                Console.WriteLine("Welcome to DOTNET Hospital Management System\n");
                Console.WriteLine("Patient Menu");
                Console.WriteLine(" 1. List Patient Details");
                Console.WriteLine(" 2. List my doctor detail");
                Console.WriteLine(" 3. List all appointments");
                Console.WriteLine(" 4. Book appointment");
                Console.WriteLine(" 5. Logout");
                Console.WriteLine(" 6. Exit System");
                Console.Write("\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        myDetails();
                        break;
                    case "2":
                        ListMyDoctors();
                        break;
                    case "3":
                        ListAllMyAppointments();
                        break;
                    case "4":
                        //Book Appointment
                        BookMyAppointment();
                        break;
                    case "5":
                        Logout();
                        break;
                    case "6":
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                Console.ReadKey();
            }
        }
        //List patients registered doctors
        private void ListMyDoctors()
        {
            DataManager.reloadData();
            int [] MyDoctorList = DataManager.curentUser.RegisteredWith;

//if there are doctors registered
            if (MyDoctorList.Length > 0)
            {
                Console.Clear();
                Header h1 = new Header("Patient Home");
                Console.WriteLine($"\n{"Doctor ID",-10} | {"Doctor Name",-20} | {"Email",-25} | {"Phone",-20} | {"Address",-45} ");
                for (int i = 0; i < 134; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine("");
                //---------------------Data Below--------------------------------------------------------------------------------

                for (int i = 0; i < MyDoctorList.Length; i++)
                {
                    Doctor d = DataManager.getDoctorInfo(MyDoctorList[i]);
                    Console.WriteLine(d.ToString());
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
            else {
                Console.Clear();
                Header h1 = new Header("Patient Home");
 //ShowAllDoctors
                Console.WriteLine("\nNo doctors registered. Press any key to see and select a doctor to register.");
                Console.ReadKey();
                ShowDocTable(DataManager.Doctors);

                Console.WriteLine("\nPlease type one of the doctor ID you want to register with and press any key to register.\n\nOr to go back to main menue press 0.");
//Type doc id to get registered with
                try
                {
                    int myDocID = int.Parse(Console.ReadLine());
                    if (myDocID == 0)
                    {
                        Console.WriteLine("Press any key.");
                    }
                    else if (!DataManager.curentUser.RegisteredWith.Contains(myDocID))
                    {
//checked if typed ID for registration is correct or not
                        if (DataManager.CheckID("Doctor", myDocID))
                        {
                            DataManager.RegisterMeWith(myDocID);
                            Console.WriteLine($"\nYou have been registered with a doctor.\n\nPress any key to go back to main menu...");
                        }
                        else
                        {
                            Console.WriteLine($"\nIncorrect ID.\n\nPress any key to try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Already registered with this doctor!!");

                    }
                }
                catch (Exception e) {
                    Console.WriteLine("Invalid entry. Taking back to main menu.");
                }
            }
        }

        private void ListAllMyAppointments()
        {
            
            List<Appointment> myAppointments = DataManager.GetFullAppointmentList();

            Console.WriteLine($"{"Appointment ID",-15} | {"Patient Name",-20} | {"Doctor Name",-20} | {"Description",-60} |");
            for (int i = 0; i < 125; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("");
            //------------------------------data below-----------------------------------------------------------------------

                foreach (Appointment a in myAppointments) {
                    if (a.P_ID==DataManager.curentUser.ID) {
                        Console.WriteLine(a.ToString());
                    }
                }
            //------------------------------data below-----------------------------------------------------------------------
            for (int i = 0; i < 125; i++)
            {
                Console.Write("-");
            }
            //-----------------------------------------------------------------------------------------------------

            Console.WriteLine("\n Press any key to continue...");
        }

        private void ShowDocTable(List<Doctor> DocList) {

            Console.WriteLine($"\n{"Doctor ID",-10} | {"Doctor Name",-20} | {"Email",-25} | {"Phone",-20} | {"Address",-45} |");
            for (int i = 0; i < 133; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("");
            //-----------------------------Data below------------------------------------------------------------------------
            foreach (Doctor d in DocList)
            {
                Console.WriteLine(d.ToString());
            }
            //-----------------------------Data above------------------------------------------------------------------------
            for (int i = 0; i < 133; i++)
            {
                Console.Write("-");
            }
            //-----------------------------------------------------------------------------------------------------
    

        }
        //private void ShowDocTable(List<int> myDocList)
        //{
        //    Console.WriteLine($"{"Doctor ID",-10} | {"Doctor Name",-20} | {"Email",-25} | {"Phone",-20} | {"Address",-45} ");
        //    for (int i = 0; i < 89; i++)
        //    {
        //        Console.Write("-");
        //    }
        //    Console.WriteLine("");
        //    //-----------------------------------------------------------------------------------------------------


        //    foreach (int id in myDocList) {
        //        Console.Write("mydoclist: >>>  " + myDocList[id]);
        //        Doctor d = DataManager.getDoctorInfo(id);
        //        d.ToString();
        //    }





        //    for (int i = 0; i < 134; i++)
        //    {
        //        Console.Write("-");
        //    }
        //    //-----------------------------------------------------------------------------------------------------
        //    Console.WriteLine("\n Press any key to continue...");
        //}

        private void BookMyAppointment()
        {
            int [] MyDoctors=DataManager.curentUser.RegisteredWith;
            //if no doctor registered
            if (MyDoctors.Length == 0)
            {
                Console.Clear();
                Header h1 = new Header("Patient Home");

                Console.WriteLine("\nYou are not registered with any doctor. Select a doctor from the list below:\n");
                //shows all doctors in hospital.
                ShowDocTable(DataManager.Doctors);
                Console.WriteLine("\n\nType the doctor id to register with and book an appointment.\nDoctor ID: ");
                int selectedDocId = int.Parse(Console.ReadLine());

                if(DataManager.CheckID("Doctor", selectedDocId))
                {
                    DataManager.RegisterMeWith(selectedDocId);
                    CreateAppointment(selectedDocId,DataManager.curentUser.ID);
                }
                else{
                    Console.WriteLine("\nInvalid id entered. Going back to main menu.");
                }
            }
            else {
                List<Doctor> DoctorList = new List<Doctor>();
                for (int i = 0; i < MyDoctors.Length; i++)
                {
                    DoctorList.Add(DataManager.getDoctorInfo(MyDoctors[i]));
                }
                ShowDocTable(DoctorList);
                Console.WriteLine("\nType the doctor id to book an appointment.");
                int selectedDocId = int.Parse(Console.ReadLine());
                CreateAppointment(selectedDocId, DataManager.curentUser.ID);
            }
        }

        private void CreateAppointment(int selectedDocId, int id)
        {
            Console.Write("\nPlease mention your purpose for the appointment: ");
            string description = Console.ReadLine();
            Console.WriteLine("\n");

            List<Appointment> appointments= DataManager.GetFullAppointmentList();

            //CreateAppointment appointment
            Appointment a1 = new Appointment
            {
                A_ID = appointments.Count + 1, //just using number of appointments + 1 as A_id. basically generating an ID
                P_ID = id,
                D_ID = selectedDocId,
                Patient_Name = DataManager.curentUser.Name,
                Doctor_Name = DataManager.getDoctorInfo(selectedDocId).Name,
                Description = description
            };
            appointments.Add(a1);
            //Save appointment in file
            DataManager.SaveAppointment(appointments);

        }

        public override string ToString()
        {
            return $"{ID,-10} | {Name,-20} | {Email,-25} | {Phone,-20} | {Address,-45} |";
        }
    }
}
