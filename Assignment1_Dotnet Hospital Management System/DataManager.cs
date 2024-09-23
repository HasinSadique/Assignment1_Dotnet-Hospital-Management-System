using Assignment1_Dotnet_Hospital_Management_System;
using System.ComponentModel.Design.Serialization;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class DataManager
{
    static string filePathToCurrentUser = projectRoot + "\\currentUser.txt";

    public static string projectRoot = Directory.GetCurrentDirectory();
    static string AdminJsonData = File.ReadAllText(projectRoot + "\\AdminData.Json");
    static string DoctorJsonData = File.ReadAllText(projectRoot + "\\DoctorData.JSON");
    static string PatientJsonData = File.ReadAllText(projectRoot + "\\PatientData.Json");
    static string ReceptionistJsonData = File.ReadAllText(projectRoot + "\\ReceptionistData.Json");

    static string AppointmentData = File.ReadAllText(projectRoot + "\\AppointmentData.JSON");
    static string RegistrationData = File.ReadAllText(projectRoot + "\\Registrations.JSON");

    public static User curentUser;


    public static List<Admin> Admins { get; set; } = new List<Admin>();
    public static List<Doctor> Doctors { get; set; } = new List<Doctor>();
    public static List<Patient> Patients { get; set; } = new List<Patient>();
    public static List<Receptionist> ReceptionistList { get; set; }=new List<Receptionist>();

    public static List<Registration> RegistartionList { get; set; } = new List<Registration>();
    public static List<Appointment> AppointmentList { get; set; }=new List<Appointment>();


    //public static string fileContent;

    //public static Doctor testDoc { get; set; } = new Doctor();

    public static List<Appointment> GetFullAppointmentList() {

        
        return JsonSerializer.Deserialize<List<Appointment>>(AppointmentData);
        //return AppointmentList;
    }

    public static Doctor getDoctorInfo(int DocID) {

        foreach (Doctor d in Doctors) {
            
                if (DocID == d.ID) {
                    return d;
                }
        }
        return null;
    }
    public static void reloadData()
    {
        projectRoot = Directory.GetCurrentDirectory();
        AdminJsonData = File.ReadAllText(projectRoot + "\\AdminData.Json");
        DoctorJsonData = File.ReadAllText(projectRoot + "\\DoctorData.JSON");
        PatientJsonData = File.ReadAllText(projectRoot + "\\PatientData.Json");
        ReceptionistJsonData = File.ReadAllText(projectRoot + "\\ReceptionistData.Json");

        RegistrationData = File.ReadAllText(projectRoot + "\\Registrations.JSON");
        //AppointmentData = File.ReadAllText(projectRoot + "\\AppointmentData.JSON");
    }

    //loads all data
    public static void LoadData(){

        reloadData();
        Admins = JsonSerializer.Deserialize<List<Admin>>(AdminJsonData);
        Doctors = JsonSerializer.Deserialize<List<Doctor>>(DoctorJsonData);
        Patients = JsonSerializer.Deserialize<List<Patient>>(PatientJsonData);
        ReceptionistList = JsonSerializer.Deserialize<List<Receptionist>>(ReceptionistJsonData);
        //fileContent = File.ReadAllText(filePathToCurrentUser);
        RegistartionList = JsonSerializer.Deserialize<List<Registration>>(RegistrationData);
        //AppointmentList = JsonSerializer.Deserialize<List<Appointment>>(AppointmentData);

    }

    //loads specific user data
    public static List<User> LoadData(string userType)
    {
        LoadData();
        if (userType == "Admin")
        {
            return new List<User>(Admins);
        }
        else if (userType == "Doctor")
        {
            return new List<User>(Doctors); ;
        }
        else if (userType == "Patient")
        {
            return new List<User>(Patients); ;
        }
        else
        {
            return null;
        }

    }

    //Write data into file
    public static void SaveData(string userType, List<User> userList)
    {
        if (userType == "Admin") { }
        else if (userType == "Doctor")
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(userList,options);
            File.WriteAllText(projectRoot + "\\DoctorData.JSON", jsonString);
            
            Console.WriteLine("Doctor Registered successfully. Press any key to go back to main menu.");
        }
        else if (userType == "Patient") {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(userList, options);
            File.WriteAllText(projectRoot + "\\PatientData.JSON", jsonString);

            Console.WriteLine("Patient Registered successfully. Press any key to go back to main menu.");
        }

    }
    public static User ValidateUser(string userType, int uid, string password)
    {
        Console.WriteLine($"UID: {uid}, \npass: {password}");
        if (userType == "Admin")
        {
            foreach (var admin in Admins)
            {
                if (admin.ID == uid && admin.Password == password)
                {
                    curentUser = admin;
                    return admin;
                }

            }
            Console.WriteLine("\nInvalid Email or Password. \nPress any key to try again.");
            Console.ReadKey();
            return null;
        }
        else if (userType == "Doctor")
        {
            foreach (var doctor in Doctors)
            {
                if (doctor.ID == uid && doctor.Password == password)
                {
                    curentUser = doctor;
                    return doctor;
                }
            }
            Console.WriteLine("\nInvalid Email or Password. \nPress any key to try again.");
            Console.ReadKey();
            return null;
        }
        else if (userType == "Patient")
        {
            foreach (var patient in Patients)
            {
                if (patient.ID == uid && patient.Password == password)
                {
                    curentUser = patient;
                    return patient;
                }
            }
            Console.WriteLine("\nInvalid Email or Password. \nPress any key to try again.");
            Console.ReadKey();
            return null;
        }
        else if(userType== "Receptionist")
        {
            foreach (var receptionist in ReceptionistList)
            {
                if (receptionist.ID == uid && receptionist.Password == password)
                {
                    curentUser = receptionist;
                    return receptionist;
                }
            }
            Console.WriteLine("\nInvalid Email or Password. \nPress any key to try again.");
            Console.ReadKey();
            return null;
        }
        return null; // Invalid credentials
    }
    //LoaderOptimization all appointments
    public static Appointment loadAppointments() {
        return null;
    }

    public static List<Doctor> getDoctorList(int iD)
    {
        LoadData();

        //foreach (Patient p in Patients) {
        //    if (p.ID == curentUser.ID) { 
            
        //    }
        //}

        return JsonSerializer.Deserialize<List<Doctor>>(DoctorJsonData); ;
    }
    //Funtion to register with a doctor
    public static void RegisterMeWith(int id)
    {
        LoadData();
        if (curentUser.UserType == "Patient" && !curentUser.RegisteredWith.Contains(id))
        {
            foreach (Patient p in Patients)
            {
                if (p.ID == curentUser.ID)
                {
                    List<int> registeredWith = new List<int>(p.RegisteredWith);
                    if (registeredWith.Contains(id))
                    {
                        break;
                    }
                    registeredWith.Add(id);
                    p.RegisteredWith = registeredWith.ToArray();
                    break;
                }
            }
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(Patients, options);
            File.WriteAllText(projectRoot + "\\PatientData.JSON", jsonString);


        }
        else { 
        
        }
        //else if (curentUser.UserType=="Doctor") {
        //    foreach (Doctor d in Doctors)
        //    {
        //        if (d.ID == curentUser.ID)
        //        {
        //            List<int> registeredWith = new List<int>(d.RegisteredWith);
        //            registeredWith.Add(id);
        //            d.RegisteredWith = registeredWith.ToArray();
        //            break;
        //        }
        //    }
        //    var options = new JsonSerializerOptions
        //    {
        //        WriteIndented = true
        //    };
        //    string jsonString = JsonSerializer.Serialize(Doctors, options);
        //    File.WriteAllText(projectRoot + "\\DoctorData.JSON", jsonString);

        //    Console.WriteLine($"\nYou have been registered with a Patient.");
        //}

    }
    //Checks for correct ID and 
    public static bool CheckID(string userType, int myDocID)
    {
        reloadData();

        if (userType == "Doctor") { 
            foreach (Doctor d in Doctors) {
            if (d.ID == myDocID)
                return true;
            }
        }
        return false;
    }
}
