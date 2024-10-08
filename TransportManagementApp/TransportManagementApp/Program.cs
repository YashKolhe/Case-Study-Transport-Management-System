using TransportManagementApp.MainModule;
using TransportManagementApp.Repository;

internal class Program
{
    public static void Main(string[] args)
    {

        TransportApp TMApp = new TransportApp();
        TransportManagementServiceImpl TMSimpl = new TransportManagementServiceImpl();

        Console.WriteLine("Are you a USER or the ADMIN?");
        string input = Console.ReadLine();
        string input1 = input.ToUpper();

        if(input1 == "USER")
        {
            Console.WriteLine("-------- SIGNIN --------");

            Console.WriteLine("Enter your Email : ");
            string eMail = Console.ReadLine();
            Console.WriteLine("User Signed In Successfully.");
               TMApp.UserRun();
            //if (TMSimpl.SignIn(eMail))
            //{
            //    Console.WriteLine("User Signed In Successfully.");
            //    TMApp.userRun();
            //}
            //else
            //{
            //    Console.WriteLine("Incorrect SignIN Details");
            //}
        }
        else if(input1 == "ADMIN")
        {

            Console.WriteLine("Enter your Email : ");
            string eMail = Console.ReadLine();
            if (eMail == "yash123@example.com")
            {
                Console.WriteLine("Admin SignIN Successful");
                TMApp.AdminRun();
            }
            else
            {
                Console.WriteLine("Incorrect Credentials");
            }
        }
        else
        {
            Console.WriteLine("Incorrect Input");
        }
    }
}