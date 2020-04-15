using System;
using System.Collections.Generic;
using System.IO;

namespace PruebaSabadell
{
    public class Program
    {
        public static string FilePath = Path.GetFullPath(@"D:\Proyectos Programación\PruebaSabadell\Cuentas.txt"); //Ruta del archivo a leer
        public static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            int num = 0;
            while (num != 7)
            {
                Console.WriteLine("Welcome to new app of Sabadell Bank");
                Console.WriteLine();
                Console.WriteLine("¿Which of the following options do you want to do?");
                Console.WriteLine("1)Insert new account");
                Console.WriteLine("2)Check your balance");
                Console.WriteLine("3)Extract money");
                Console.WriteLine("4)Insert money");
                Console.WriteLine("5)Move balance another account");
                Console.WriteLine("6)Exit");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        {
                            InfoTxt();
                        }
                        break;

                    case 2:
                        {
                            Balance();
                        }
                        break;

                    case 3:
                        {
                            ExtractMoney();
                        }
                        break;

                    case 4:
                        {
                            InsertMoney();
                        }
                        break;

                    case 5:
                        {
                            TransferMoney();
                        }
                        break;

                    case 6:
                        {
                            num = 7;
                        }
                        break;
                }
            }
        }
        public static void InfoTxt()
        {
            List<DatosFichero> cuentas = new List<DatosFichero>();

            try
            {
                //Chequea si existe
                var fileInfo = new FileInfo(FilePath);

                if (fileInfo.Exists)
                {
                    //Leemos los datos que contiene
                    using (StreamReader reader = new StreamReader(FilePath))
                    {
                        cuentas = new List<DatosFichero>();
                        string s = "";

                        while ((s = reader.ReadLine()) != null)
                        {
                            var line = s.Split("\t", StringSplitOptions.RemoveEmptyEntries);

                            var account = new DatosFichero()
                            {
                                Name = line[0],
                                Balance = decimal.Parse(line[1]),
                                Pass = int.Parse(line[2]),
                                NoAccount = int.Parse(line[3])
                            };

                            cuentas.Add(account);
                        }
                    }

                    Console.WriteLine("¿Do you want insert a new account? y/n");
                    string request = Console.ReadLine().ToLower();

                    if (request == "y")
                    {
                        Console.WriteLine("Insert your Name, Balance and Pass");
                        cuentas.Add(new DatosFichero()
                        {
                            Name = Console.ReadLine(),
                            Balance = decimal.Parse(Console.ReadLine()),
                            Pass = int.Parse(Console.ReadLine()),
                            NoAccount = cuentas.Count
                        }); ;; ;
                        Console.WriteLine();
                    }
                }

                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    foreach (var account in cuentas)
                    {
                        var line = $"{account.Name}\t{account.Balance}\t{account.Pass}\t{account.NoAccount}";

                        writer.WriteLine(line);

                        Console.WriteLine("ID:{0} Name:{1} Balance:{2}", account.NoAccount, account.Name, account.Balance);
                        Console.WriteLine();
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        public static void Balance()
        {
            List<DatosFichero> cuentas = new List<DatosFichero>();

            try
            {
                //Chequea si existe
                var fileInfo = new FileInfo(FilePath);

                if (fileInfo.Exists)
                {
                    //Leemos los datos que contiene
                    using (StreamReader reader = new StreamReader(FilePath))
                    {
                        cuentas = new List<DatosFichero>();
                        string s = "";

                        while ((s = reader.ReadLine()) != null)
                        {
                            var line = s.Split("\t", StringSplitOptions.RemoveEmptyEntries);

                            var account = new DatosFichero()
                            {
                                Name = line[0],
                                Balance = decimal.Parse(line[1]),
                                Pass = int.Parse(line[2]),
                                NoAccount = int.Parse(line[3])
                            };

                            cuentas.Add(account);
                        }
                    }

                    Console.WriteLine("List of your accounts:");

                    foreach (var account in cuentas)
                    {
                        var accounts = $"{account.NoAccount}\t{account.Name}";

                        Console.WriteLine(accounts);
                    }

                    Console.WriteLine("Insert your Password to access the account:");

                    string pass = Console.ReadLine();

                    bool foundaccount = false;

                    foreach (var account in cuentas)
                    {

                        var access = $"{account.Pass}";

                        if (pass == access)
                        {
                            foundaccount = true;

                            var line = $"{account.Balance}";

                            Console.WriteLine();
                            Console.WriteLine("Your actual Balance is {0}$", line);
                            Console.WriteLine();
                        }                      
                    }

                    if (foundaccount == false)
                    {
                        
                       Console.WriteLine("Wrong Password");
                        
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        public static void ExtractMoney()
        {
            List<DatosFichero> cuentas = new List<DatosFichero>();

            try
            {
                //Chequea si existe
                var fileInfo = new FileInfo(FilePath);

                if (fileInfo.Exists)
                {
                    //Leemos los datos que contiene
                    using (StreamReader reader = new StreamReader(FilePath))
                    {
                        cuentas = new List<DatosFichero>();
                        string s = "";

                        while ((s = reader.ReadLine()) != null)
                        {
                            var line = s.Split("\t", StringSplitOptions.RemoveEmptyEntries);

                            var account = new DatosFichero()
                            {
                                Name = line[0],
                                Balance = decimal.Parse(line[1]),
                                Pass = int.Parse(line[2]),
                                NoAccount = int.Parse(line[3])
                            };

                            cuentas.Add(account);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(FilePath))
                    {

                        Console.WriteLine("List of your accounts:");

                        foreach (var account in cuentas)
                        {
                            var accounts = $"{account.NoAccount}\t{account.Name}";

                            Console.WriteLine(accounts);
                        }

                        Console.WriteLine("Insert your Password to access the account:");

                        string pass = Console.ReadLine();

                        bool foundaccount = false;

                        foreach (var account in cuentas)
                        {
                            var access = $"{account.Pass}";

                            if (pass == access)
                            {
                                foundaccount = true;

                                Console.WriteLine("¿How much money do you want to extract?");
                                int money = int.Parse(Console.ReadLine());

                                account.Balance = account.Balance - money;

                                Console.WriteLine("Your actual Balance is {0}$, you extract {1}$", account.Balance, money);
                                Console.WriteLine();

                                //var line = $"{account.Name}\t{account.Balance}\t{account.Pass}\t{account.NoAccount}";

                                //writer.WriteLine(line);
                            }
                        }
                        if (foundaccount == false)
                        {
                            Console.WriteLine("Wrong Password");
                        }
                        else
                        {
                            foreach (var account in cuentas)
                            {
                                var line = $"{account.Name}\t{account.Balance}\t{account.Pass}\t{account.NoAccount}";

                                writer.WriteLine(line);
                            }
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        public static void InsertMoney()
        {
            List<DatosFichero> cuentas = new List<DatosFichero>();

            try
            {
                //Chequea si existe
                var fileInfo = new FileInfo(FilePath);

                if (fileInfo.Exists)
                {
                    //Leemos los datos que contiene
                    using (StreamReader reader = new StreamReader(FilePath))
                    {
                        cuentas = new List<DatosFichero>();
                        string s = "";

                        while ((s = reader.ReadLine()) != null)
                        {
                            var line = s.Split("\t", StringSplitOptions.RemoveEmptyEntries);

                            var account = new DatosFichero()
                            {
                                Name = line[0],
                                Balance = decimal.Parse(line[1]),
                                Pass = int.Parse(line[2]),
                                NoAccount = int.Parse(line[3])
                            };

                            cuentas.Add(account);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(FilePath))
                    {
                        foreach (var account in cuentas)
                        {
                            var accounts = $"{account.NoAccount}\t{account.Name}";

                            Console.WriteLine(accounts);
                        }

                        Console.WriteLine("Insert your Password to access the account:");

                        string pass = Console.ReadLine();

                        bool foundaccount = false;

                        foreach (var account in cuentas)
                        {
                            var access = $"{account.Pass}";

                            if (pass == access)
                            {
                                foundaccount = true;

                                Console.WriteLine("¿How much money do you want to insert?");
                                int money = int.Parse(Console.ReadLine());

                                account.Balance += money;

                                Console.WriteLine("Your actual Balance is {0}$, you insert {1}$", account.Balance, money);
                                Console.WriteLine();

                            }
                        }
                        if (foundaccount == false)
                        {
                            Console.WriteLine("Wrong Password");
                        }
                        else
                        {
                            foreach (var account in cuentas)
                            {
                                var line = $"{account.Name}\t{account.Balance}\t{account.Pass}\t{account.NoAccount}";

                                writer.WriteLine(line);
                            }
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        public static void TransferMoney()
        {
            List<DatosFichero> cuentas = new List<DatosFichero>();

            try
            {
                //Chequea si existe
                var fileInfo = new FileInfo(FilePath);

                if (fileInfo.Exists)
                {
                    //Leemos los datos que contiene
                    using (StreamReader reader = new StreamReader(FilePath))
                    {
                        cuentas = new List<DatosFichero>();
                        string s = "";

                        while ((s = reader.ReadLine()) != null)
                        {
                            var line = s.Split("\t", StringSplitOptions.RemoveEmptyEntries);

                            var account = new DatosFichero()
                            {
                                Name = line[0],
                                Balance = decimal.Parse(line[1]),
                                Pass = int.Parse(line[2]),
                                NoAccount = int.Parse(line[3])
                            };

                            cuentas.Add(account);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(FilePath))
                    {
                        foreach (var account in cuentas)
                        {
                            var accounts = $"{account.NoAccount}\t{account.Name}\t{account.Balance}";

                            Console.WriteLine(accounts);
                        }

                        Console.WriteLine("Insert your Password to access the account:");
                        string pass = Console.ReadLine();

                        Console.WriteLine("¿How much money do you want to transfer?");
                        int money = int.Parse(Console.ReadLine());

                        bool foundaccount = false;
                        
                        foreach (var account in cuentas)
                        {
                            var access = $"{account.Pass}";


                            if (pass == access)
                            {
                                foundaccount = true;

                                account.Balance -= money;

                                Console.WriteLine("Your actual Balance is {0}$, you extract {1}$", account.Balance, money);
                                Console.WriteLine();

                                break;
                            }                          
                            else
                            {
                                Console.WriteLine("Account Not Found");
                            }
                        }
                        if (foundaccount == false)
                        {
                            Console.WriteLine("Wrong Password");
                        }
                        else
                        {
                            bool foundsecondaccount = false;

                            Console.WriteLine("Insert the Password to destination account");
                            string secondpass = Console.ReadLine();

                            foreach (var account in cuentas)
                            {
                                var access = $"{account.Pass}";

                                if (secondpass == access)
                                {
                                    foundsecondaccount = true;

                                    account.Balance += money;

                                    Console.WriteLine("Your actual Balance is {0}$, you insert {1}$", account.Balance, money);
                                    Console.WriteLine();
                                }
                            }
                            if (foundaccount == true && foundsecondaccount == true)
                            {
                                foreach (var account in cuentas)
                                {
                                    var line = $"{account.Name}\t{account.Balance}\t{account.Pass}\t{account.NoAccount}";

                                    writer.WriteLine(line);
                                }
                            }
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }    
}
