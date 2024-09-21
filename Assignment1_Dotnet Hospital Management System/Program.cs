internal class Program
{
    public static LoginPage l1;
    public static User currentUser;
    private static void Main(string[] args)
    {


        bool running = true;
        //while (running) {
        //    ApplicationSession session = new ApplicationSession();
        //    running = session.Run();
        //}
        do {
            DataManager.LoadData();
            //Header h1 = new Header("Login Page");
            l1 = new LoginPage();
            //h1.setHeaderTitle(l1.Current_UserType+" Home");
        } while (running);
        

    }
}