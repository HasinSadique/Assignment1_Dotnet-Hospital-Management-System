public abstract class User
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserType { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }

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


    public override string ToString()
    {
        //return $"{ID,-10},{Name},{Email},{Password},{Address},{Phone},{UserType}";

        return $"{ID,-5} | {Name,-15} | {Email,-25} | {Phone,-20} | {Address,-20} | {Password, -25}";
    }
}