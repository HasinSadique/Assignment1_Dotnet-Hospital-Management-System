using Assignment1_Dotnet_Hospital_Management_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

//public class Admin : User
//{
//    public int AID { get; set; }
//    public string email { get; set; }
//    public string UserType { get; set; }
//    public string Password { get; set; }
//}
//sdv

public class Admin : User
{

    //public int ID { get; set; }
    //public string Name { get; set; }
    //public string Email { get; set; }
    //public string UserType { get; set; }
    //private string Password { get; set; }


    //public Admin(int ID, String Name, String Email, String UserType, String Password) {
    //    this.ID = ID;
    //    this.Name = Name;  
    //    this.Email = Email;
    //    this.UserType = UserType;
    //    this.Password = Password;

    //    Header h1 = new Header("Admin Home");
    //    MainMenu();

    //}
    public override void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Header h1 = new Header("Admin Home");
            Console.WriteLine("Administrator Menu");
            Console.WriteLine(" 1. List All Doctors");
            Console.WriteLine(" 2. Check Doctor Details");
            Console.WriteLine(" 3. List All Patients");
            Console.WriteLine(" 4. Check Patient Details");
            Console.WriteLine(" 5. Add Doctor");
            Console.WriteLine(" 6. Add Patient");
            Console.WriteLine(" 7. Logout");
            Console.Write("\nSelect an option: ");

            switch (Console.ReadLine())
        {
            case "1":
                ListAllDoctors();
                break;
            case "2":
                CheckDoctorDetails();
                break;
            case "3":
                ListAllPatients();
                break;
            case "4":
                CheckPatientDetails();
                break;
            case "5":
                AddDoctor();
                break;
            case "6":
                AddPatient();
                break;
            case "7":
                    
                Logout();
                break;// Logout
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
        Console.ReadKey();
        }
    }
    private void ListAllDoctors()
    {
        List<User> doctors =  DataManager.LoadData("Doctor");
        DisplayUsersInTable(doctors);
    }
    static void DisplayUsersInTable(List<User> users)
    {
        //creates table for displaying doctors
        Console.WriteLine($"{"ID",-10} | {"Name",-20} | {"Email",-25} | {"Phone", -20} | {"Address",-45} |");
        for (int i = 0; i < 134; i++) {
            Console.Write("-");
        }
        Console.WriteLine("");
        //-----------------------------------------------------------------------------------------------------

        foreach (var user in users)
        {
            Console.WriteLine(user.ToString());
        }

        for (int i = 0; i < 134; i++)
        {
            Console.Write("-");
        }
        //-----------------------------------------------------------------------------------------------------
        Console.WriteLine("\n Press any key to continue...");
        
    }
    static void DisplayUserInTable(User user)
    {
        //creates table for displaying doctors
        Console.WriteLine($"{"ID",-10} | {"Name",-20} | {"Email",-25} | {"Phone",-20} | {"Address",-45} |");
        for (int i = 0; i < 134; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine("");
        //-----------------------------------------------------------------------------------------------------
        Console.WriteLine(user.ToString());
        for (int i = 0; i < 134; i++)
        {
            Console.Write("-");
        }
        //-----------------------------------------------------------------------------------------------------
        Console.WriteLine("\n Press any key to continue...");
    }

    public override string ToString()
    {
        return $"{ID,-5} | {Name,-15} | {Email,-25} | {UserType,-20}";
    }

    private void CheckDoctorDetails()
    {
        List<User> doctors = DataManager.LoadData("Doctor");
        Console.WriteLine("");
        Console.WriteLine("Please enter the ID of the doctor you want to check: ");

        int id = Convert.ToInt32(Console.ReadLine());
        //while ("Dtatype" + id.GetType().ToString() != "DtatypeSystem.Int32") {
        //    CheckDoctorDetails();
        
        //}
        //while ();
        bool found = false;
        foreach (Doctor doc in doctors)
        {
            if (doc.ID == id)
            {
                found = true;
                Console.WriteLine("\n");
                DisplayUserInTable(doc);
               
                break;
            }
            else {
                found = false;
            }
        }

        if (found == false) {
            Console.WriteLine("No doctor found with this ID.\n Press any key to go to main menu.");
        }
    }

    private void ListAllPatients()
    {
        List<User> patients = DataManager.LoadData("Patient");
        DisplayUsersInTable(patients);
    }

    private void CheckPatientDetails()
    {
        List<User> patients = DataManager.LoadData("Patient");
        Console.WriteLine("");
        Console.WriteLine("Please enter the Patient ID you want to check: ");
        int id = Convert.ToInt32(Console.ReadLine());
        bool found = false;
        foreach (Patient patient in patients)
        {
            if (patient.ID == id)
            {
                found = true;
                Console.WriteLine("\n");
                DisplayUserInTable(patient);

                break;
            }
            else
            {
                found = false;
            }
        }

        if (found == false)
        {
            Console.WriteLine("No doctor found with this ID.\n Press any key to go to main menu.");
        }
    }
    private void AddDoctor()
    {
        Console.Clear();
        Header h1 = new Header("Admin Home");
        Console.WriteLine("Registering new Doctor.\nSubmit the doctor details to complete registration.\n");
        Console.Write("First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        string lastName =Console.ReadLine();
        Console.Write("E-mail: ");
        string Email = Console.ReadLine();
        Console.Write("Phone: ");
        string phone = Console.ReadLine();
        Console.Write("Street number and name: ");
        string street = Console.ReadLine();
        Console.Write("City: ");
        string city = Console.ReadLine();
        Console.Write("State and Postcode: ");
        string state = Console.ReadLine();
        Console.Write("Country: ");
        string country = Console.ReadLine();
        Console.Write("set Password for this Doctor: ");
        string password = Console.ReadLine();


        int id = getGeneratedID();
        if (id > 0)
        {
            Console.WriteLine(firstName + " " + lastName + " registered as Doctor with \nID: " + id + " and pasword: " + password);
            List<User> ListAllDoctors = DataManager.LoadData("Doctor");
            Doctor d1 = new Doctor
            {
                ID = id,
                Name = firstName + " " + lastName,
                Email = Email,
                Address=street+" "+ city + " " + state + " " + country,
                Phone =phone,
                Password=password


                //id, firstName + " " + lastName, Email, phone, street + " " + city + " " + state + " " + country, password 
            };

        //    string jsonString = @"
        //[
        //    { ""ID"": 101, ""Name"": ""Alice"", ""Email"": ""admin@example.com"", ""Password"": ""admin"", ""UserType"": ""Admin"" },
        //    { ""ID"": 1000004, ""Name"": ""Eve"", ""Email"": ""eve_admin@example.com"", ""Password"": ""evepass123"", ""UserType"": ""Admin"" },
        //    { ""ID"": 1000005, ""Name"": ""Frank"", ""Email"": ""frank_admin@example.com"", ""Password"": ""frankpass123"", ""UserType"": ""Admin"" },
        //    { ""ID"": 1000006, ""Name"": ""Grace"", ""Email"": ""grace_admin@example.com"", ""Password"": ""gracepass123"", ""UserType"": ""Admin"" },
        //    { ""ID"": 1000007, ""Name"": ""Hank"", ""Email"": ""hank_admin@example.com"", ""Password"": ""hankpass123"", ""UserType"": ""Admin"" },
        //    { ""ID"": 1000008, ""Name"": ""Ivy"", ""Email"": ""ivy_admin@example.com"", ""Password"": ""ivypass123"", ""UserType"": ""Admin"" }
        //]";

            ListAllDoctors.Add(d1);
            Console.WriteLine("total doctors: " + ListAllDoctors.Count);
            DataManager.SaveData("Doctor", ListAllDoctors);

        
            //string jsonString = JsonSerializer.Serialize<List<Doctor>>(ListAllDoctors);

            //foreach (Doctor doc in ListAllDoctors) 
            //{
                Console.WriteLine("Check >>>>>>> " + ListAllDoctors[0].ID);
            //}
        }
        else 
        {
            Console.WriteLine();
        }
       
        




    }

    private int getGeneratedID()
    {
        try
        {
            string filePath = "C:\\Users\\25536727\\source\\repos\\Assigment 1\\Assignment1_Dotnet Hospital Management System\\Assignment1_Dotnet Hospital Management System\\TotalUsers.txt";
            string fileContent = File.ReadAllText(filePath);

            int last_UID = int.Parse(fileContent.Trim());
            last_UID++;

            File.WriteAllText(filePath, last_UID.ToString());
            return last_UID;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The specified file was not found.");
        }
        catch (FormatException)
        {
            Console.WriteLine("The content of the file is not a valid integer.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return -1;
    }

    private void AddPatient()
    {
        
    }
}