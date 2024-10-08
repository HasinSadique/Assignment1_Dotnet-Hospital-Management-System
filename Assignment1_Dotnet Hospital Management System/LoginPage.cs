﻿//using Assignment1_Dotnet_Hospital_Management_System;
using System;
using System.CodeDom.Compiler;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;

public class LoginPage
{
    public int uid;
    public static User u1 = null;
    public string pass = "";
    public string Current_UserType = "";
    
    public string AdminDataJSON_location = "C:\\Users\\25536727\\source\\repos\\Assigment 1\\Assignment1_Dotnet Hospital Management System\\Assignment1_Dotnet Hospital Management System\\AdminData.Json";
    public string DoctorDataJSON_location = "C:\\Users\\25536727\\source\\repos\\Assigment 1\\Assignment1_Dotnet Hospital Management System\\Assignment1_Dotnet Hospital Management System\\DoctorData.JSON";
    public string PatientDataJSON_location = "C:\\Users\\25536727\\source\\repos\\Assigment 1\\Assignment1_Dotnet Hospital Management System\\Assignment1_Dotnet Hospital Management System\\PatientData.JSON";
    
    
    
    //RECORD THE KEYSTROKES
    ConsoleKey key;
    public LoginPage()
    {
        Header h1 = new Header("Login Page");
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Login as Admin\n2. Login as Doctor\n3. Login as Patient\n4. Login as Receptionist\n\nEnter login option:");
        try
        {
            string option = Console.ReadLine();

            //Clears/refreshes the screen.
            Console.Clear();

            //checks for login option.
            if (option == "1")
            {
                createLoginPage("Admin");
            }
            else if (option == "2")
            {
                 createLoginPage("Doctor");
            }
            else if (option == "3")
            {
                 createLoginPage("Patient");
            }
            else if (option == "4")
            {
               createLoginPage("Receptionist");
            }
            else
            {
                Console.WriteLine("Invalid entry.\n\n");
            }
        }
        catch (Exception e)
        {
            //throw new Exception();
            //Console.Clear();
            Console.WriteLine("Invalid input. press any key to try again!!\n");
            Console.ReadKey();
            Console.Clear();

        }
    }
    public void createLoginPage(String userType)
    {
        do
        {
            LoginForm();

            if (userType == "Admin")
            {
                u1 = DataManager.ValidateUser("Admin", uid, pass);
                Current_UserType = u1?.UserType;
                if (Current_UserType == null)
                {
                    Console.Clear();
                    //Header h1 = new Header("Login Page");


                }

                //Admin A1 = new Admin(u1.ID,u1.Name,u1.Email,u1.UserType,u1.Password);
            }
            else if (userType == "Doctor")
            {
                u1 = DataManager.ValidateUser("Doctor", uid, pass);
                Current_UserType = u1?.UserType;
                if (Current_UserType == null)
                {
                    Console.Clear();
                    //Header h1 = new Header("Login Page");


                }
            }
            else if (userType == "Patient")
            {
                u1 = DataManager.ValidateUser("Patient", uid, pass);
                Current_UserType = u1?.UserType;
                if (Current_UserType == null)
                {
                    Console.Clear();
                    //Header h1 = new Header("Login Page");
                }
            }
            else
            {
                Console.WriteLine("Invalid entry. press any key to try again!!");
                Console.ReadKey();
            }
        } while (u1==null);
        Console.WriteLine("<<< User >>>> : " + u1);
        u1?.MainMenu();
        //else if (userType == "Doctor") {
        //    //Load Doctor Data
        //    Console.WriteLine("Doctor selected");
        //} else if ( userType=="Patient") 
        //{
        //    Console.WriteLine("Patient selected");
        //}
        //else {
        //    Console.WriteLine("Receptionist selected");
        //}

        //bool ish=checkLoginInfo(AdminDataJson, email, pass);

    }


    public void LoginForm()
    {

        Header h1 = new Header("Login Page");
        Console.WriteLine("Enter your ID");
        uid = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Password");
        getPassword();

        //CheckUserDetails
    }
    public void getPassword() 
    {
        pass = "";
        do
        {
            var keyInfo = Console.ReadKey(intercept: true); // the pressed key is intercepted and stored in the keyInfo and not displayed in the console
            key = keyInfo.Key;

            //checked if the pressed key is not a control key
            if (!char.IsControl(keyInfo.KeyChar))
            {
                Console.Write("*");
                pass += keyInfo.KeyChar;
            }
            //Also check if backspace key is pressed. Delete/ommit last data from array
            else if (key == ConsoleKey.Backspace && pass.Length > 0)
            {
                //DELETE THE ASTERISK FROM CONSOLE AND PASSWORD ARRAY
                Console.Write("\b \b");
                //COPIES THE WHOLE ARRAY FROM 0 TO END OF LENGTH - 2
                pass = pass[0..^1];
            }
        } while (key != ConsoleKey.Enter);
    }


}