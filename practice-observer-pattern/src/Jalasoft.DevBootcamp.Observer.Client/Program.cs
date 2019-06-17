namespace Jalasoft.DevBootcamp.Observer.Client
{
    using System;
    using Jalasoft.DevBootcamp.Observer.Pattern;
    using Jalasoft.DevBootcamp.Observer.Viewers;

    public class Program
    {
        public static void Main(string[] args)
        {
            int option = 0;
            var account = new Account();
            do
            {
                option = DisplayMenu();

                switch (option)
                {
                    // 1. Deposit money
                    case 1:
                        Console.Write("Introduce the mobile's name: ");
                        var mobileName = Console.ReadLine();
                        new Mobile(account, mobileName);
                        break;
                    case 2:
                        Console.Write("Introduce the amount: ");
                        account.Deposit(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 3:
                        Console.Write("Name of the mobile: ");
                        var mobileToUnregister = Console.ReadLine();
                        var deviceFound = account.GetMobile(mobileToUnregister); 
                        account.UnregsiterMobile(deviceFound);
                        break;

                    default:
                        break;
                }
            }
            while (option != 0);

            Console.Write("\r\nBye!\n");
            Console.Read();
        }

        private static int DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=======================");
            Console.WriteLine("Menu");
            Console.WriteLine("1. Register device");
            Console.WriteLine("2. Deposit money");
            Console.WriteLine("3. Unregister device");
            Console.WriteLine("0. Exit");
            Console.WriteLine("=======================");

            Console.Write("Introduce the option: ");
            var result = Console.ReadLine();
            Console.WriteLine();

            int.TryParse(result, out int option);

            return option;
        }
    }
}
