using System.Text.Json.Serialization;

public abstract class User
{
    [JsonPropertyName("ID")]
    public int ID { get; set; }
    [JsonPropertyName("Name")]
    public string Name { get; set; }

    [JsonPropertyName("Email")]
    public string Email { get; set; }
    [JsonPropertyName("Password")]
    public string Password { get; set; }
    public string UserType { get; set; }
    [JsonPropertyName("Address")]
    public string Address { get; set; }
    [JsonPropertyName("Phone")]
    public string Phone { get; set; }
    [JsonPropertyName("RegisteredWith")]
    public int [] RegisteredWith { get; set; }




    public User() {}
    public abstract void MainMenu();

    public void Logout()
    {
        Console.WriteLine("Logging out....");
        //LoginPage.u1 = null;
        Console.Clear();
        Program.l1 = null;
        
        LoginPage l1 = new LoginPage();
    }

    protected void Exit()
    {
        Environment.Exit(0);
    }

    public override string ToString()
    {
        //return $"{ID,-10},{Name},{Email},{Password},{Address},{Phone},{UserType}";

        return $"{ID,-10} | {Name,-20} | {Email,-25} | {Phone,-20} | {Address,-60} ";
    }

    public static void DisplayUserInTable(User user)
    {
        //creates table for displaying doctors
        Console.WriteLine($"{"ID",-10} | {"Name",-20} | {"Email",-25} | {"Phone",-20} | {"Address",-60}");
        for (int i = 0; i < 149; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine("");
        //-----------------------------------------------------------------------------------------------------
        Console.WriteLine(user.ToString());
        for (int i = 0; i < 149; i++)
        {
            Console.Write("-");
        }
        //-----------------------------------------------------------------------------------------------------
        Console.WriteLine("\n Press any key to continue...");
    }

    public static void myDetails()
    {
        Console.Clear();
        Header h1 = new Header("My Details");
        Console.WriteLine("");
        DisplayUserInTable(DataManager.curentUser);

    }
}