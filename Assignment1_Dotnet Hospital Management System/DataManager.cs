using Assignment1_Dotnet_Hospital_Management_System;
using System.ComponentModel.Design.Serialization;
using System.Numerics;
using System.Text.Json;

public class DataManager 
{
    static string AdminJsonData = File.ReadAllText("C:\\Users\\25536727\\source\\repos\\Assigment 1\\Assignment1_Dotnet Hospital Management System\\Assignment1_Dotnet Hospital Management System\\AdminData.Json");
    static string DoctorJsonData = File.ReadAllText("C:\\Users\\25536727\\source\\repos\\Assigment 1\\Assignment1_Dotnet Hospital Management System\\Assignment1_Dotnet Hospital Management System\\DoctorData.Json");
    static string PatientJsonData = File.ReadAllText("C:\\Users\\25536727\\source\\repos\\Assigment 1\\Assignment1_Dotnet Hospital Management System\\Assignment1_Dotnet Hospital Management System\\PatientData.Json");
    static string currentUserDataFilepath = File.ReadAllText("currentUser.txt");

    public static List<Admin> Admins { get; set; } = new List<Admin>();
    public static List<Doctor> Doctors { get; set; } = new List<Doctor>();
    public static List<Patient> Patients { get; set; } = new List<Patient>();
    //Program.currentUser= 


    //loads all data
    public static void LoadData()
    {
        //Console.WriteLine(">>>>>>>>>>>> " + AdminJsonData);

        Admins = JsonSerializer.Deserialize<List<Admin>>(AdminJsonData);
        Doctors = JsonSerializer.Deserialize<List<Doctor>>(DoctorJsonData);
        Patients = JsonSerializer.Deserialize<List<Patient>>(PatientJsonData);
        
         


    }

    //loads specific user data
    public static List<User> LoadData(String userType)
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
        else {
            return null;
        }



    }

    //Write data into file
    public static void SaveData(String userType, List<User> userList)
    {
        if (userType == "Admin") { }
        else if (userType == "Doctor")
        {
            Console.WriteLine("Checkinging ?????????");
            foreach (var doc in userList) { 
                Console.WriteLine(doc.ID);
            }
            Console.WriteLine("Checkinging ?????????");
            Console.WriteLine("\n\n\n\n\ndoctor list before conversion >>>\n\n" + userList[0].ID + "\n\n\n\n\n\n\n\n");
            string jsonString = JsonSerializer.Serialize(userList, new JsonSerializerOptions { WriteIndented = true });
            //string jsonString = JsonSerializer.Serialize(userList[1]);
            //File.WriteAllText(DoctorJsonData, jsonString);
            Console.WriteLine("\n\n\ndoctor list >>>\n\n" + jsonString + "\n\n\n\n\n\n\n\n");



        }
        else if (userType == "Patient") { }

    }
    public static User ValidateUser(String userType, int uid, string password)
    {
        if (userType == "Admin")
        {
            foreach (var admin in Admins)
            {
                //Console.WriteLine("current checking >>> "+admin.Email +" "+ admin.Password);
                if (admin.ID == uid && admin.Password == password)
                {
                    return admin;
                }
                else
                {
                    Console.WriteLine("\nInvalid Email or Password. Please try again.");
                    Console.ReadKey();
                    return null;
                }

            }
        }
        else if (userType == "Doctor")
        {
            foreach (var doctor in Doctors)
            {
                if (doctor.ID == uid && doctor.Password == password)
                {
                    return doctor;
                }
                else
                {
                    Console.WriteLine("\nInvalid Email or Password.");
                    Console.ReadKey();
                    return null;
                }

            }
        }
        else if (userType == "Patient")
        {
            foreach (var patient in Patients)
            {
                if (patient.ID == uid && patient.Password == password)
                {
                    return patient;
                }
                else
                {
                    Console.WriteLine("\nInvalid Email or Password.");
                    Console.ReadKey();
                    return null;
                }

            }
        }
        else {
            Console.WriteLine("Please wait for further update.");
        }
        

        //foreach (var doctor in Doctors)
        //{
        //    if (doctor.Email == email && doctor.Password == password)
        //        return doctor;
        //}

        //foreach (var patient in Patients)
        //{
        //    if (patient.Email == email && patient.Password == password)
        //        return patient;
        //}

        return null; // Invalid credentials
    }

}
