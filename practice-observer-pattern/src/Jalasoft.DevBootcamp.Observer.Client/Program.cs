namespace Jalasoft.DevBootcamp.Observer.Client
{
    using System;
    using Jalasoft.DevBootcamp.Observer.Pattern;
    using Jalasoft.DevBootcamp.Observer.Viewers;

    public class Program
    {
        public static void Main(string[] args)
        {
            int option;
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
                        Console.Write("Introduce the tablet's name: ");
                        var tabletName = Console.ReadLine();
                        new Tablet(account, tabletName);
                        break;
                    case 3:
                        Console.Write("Introduce the deposit amount: ");
                        account.Deposit(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 4:
                        Console.Write("Name of the device: ");
                        var deviceToUnregister = Console.ReadLine();
                        var deviceFound = account.GetDevice(deviceToUnregister);
                        account.UnregsiterDevice(deviceFound);
                        break;
                    case 5:
                        account.ListDevices();
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
            Console.WriteLine("1. Register mobile");
            Console.WriteLine("2. Register tablet");
            Console.WriteLine("3. Deposit money");
            Console.WriteLine("4. Unregister device");
            Console.WriteLine("5. List registered devices");
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
