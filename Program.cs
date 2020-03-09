using System;
using System.Collections.Generic;
using System.IO;

namespace PruebaSabadell
{
    public class Program
    {
        public static string FilePath = Path.GetFullPath (@"D:\Proyectos Programación\PruebaSabadell\Cuentas.txt"); //Ruta del archivo a leer
        static void Main(string[] args)
        {
            //1.Mostrar Datos de cuenta
            InfoTxt();
            
        }

        public static void InfoTxt()
        {
            List<DatosFichero> cuentas = new List<DatosFichero>();

            try
            {
                //Chequea si existe
                var fileInfo = new FileInfo(FilePath);

                if(fileInfo.Exists)
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

                    cuentas.Add(new DatosFichero()
                    {
                        Name = Console.ReadLine(),
                        Balance = decimal.Parse(Console.ReadLine()),
                        Pass = int.Parse(Console.ReadLine()),
                        NoAccount = cuentas.Count
                    }); ;
                }

                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    foreach (var account in cuentas)
                    {
                        var line = $"{account.Name}\t{account.Balance}\t{account.Pass}\t{account.NoAccount}";

                        writer.WriteLine(line);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        /*public static void Lectura_fichero()
        {
            try
            {
                //Abre el archivo de texto
                using (StreamReader sr = new StreamReader("Cuentas.txt"))
                {
                    string line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }*/
    }
}
