using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment1_Dotnet_Hospital_Management_System
{
    public class Patient : User
    {
        public string WardNumber { get; set; }
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
            else {
                Console.Clear();
                Header h1 = new Header("Patient Home");

                //ShowAllDoctors
                Console.WriteLine("\nNo doctors registered. Press any key to see and select a doctor to register.");
                Console.ReadKey();
                ShowDocTable(DataManager.Doctors);

                Console.WriteLine("\nPlease type one of the doctor ID you want to register with and press any key to register.\n\nOr to go back to main menue press 0.");
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
            
            List<Appointment> myAppointments = DataManager.AppointmentList;
        }

        private void BookMyAppointment()
        {

            DataManager.LoadData();
            List<int> myList=checkForDoctorRegistration();
            //ShowDocTable(myList);
            if (myList != null)
            {
                //Choose Doctor for appointment
            }
            else {
                //choose doctor to register and then book appointment
            }
            
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

        private List<int> checkForDoctorRegistration()
        {
            
            List<Registration> registrations = DataManager.RegistartionList;
            List<int> myList=new List<int>();
            foreach (Registration registration in registrations) {
                    if (registration.P_ID==DataManager.curentUser.ID) {
                        if(myList.Contains(registration.D_ID))
                            continue;
                        myList.Add(registration.D_ID);
                    }
            }
            return myList;
        }

        public override string ToString()
        {
            return $"{ID,-10} | {Name,-20} | {Email,-25} | {Phone,-20} | {Address,-45} |";
        }
    }
}
